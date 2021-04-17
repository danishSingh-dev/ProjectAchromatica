#ifndef TERRAFORMER_SNOW_CGINC_INCLUDED
#define TERRAFORMER_SNOW_CGINC_INCLUDED

UNITY_DECLARE_TEX2D(_SnowDiffuse);

float _SnowState;
fixed4 _SnowColor;
float _SnowSmoothness;
float _SnowTile;
float _SnowAmount, _SnowAngle, _NormalInfluence;
float _SnowStartHeight;
float _HeightFalloff;
float _SnowThickness;
float _SnowDamping;
float _SnowPower;

//sampler2D _SnowNormalmap, _SnowMaskmap; // Use UNITY_DECLARE_TEX2D like "_SnowDiffuse" if needed
//float _SnowNormalPower;
//float _SnowMetallic;
//float _DisplacementSnow;

void Snow (inout fixed3 albedo, inout float smoothness, inout fixed3 surfaceNormal, float3 worldNormal, float2 uv_Control, float normalY, float worldPosY, fixed3 finalCol, float _Smoothness, float waterMask)
{
	if (_SnowState == 1)
	{
		half4 snow = UNITY_SAMPLE_TEX2D(_SnowDiffuse, float2(uv_Control * _SnowTile));
		//fixed3 snowNormalmap = UnpackNormalWithScale(tex2D(_SnowNormalmap, uv_Snow), _SnowNormalPower);
		//half4 snowMaskmap = tex2D(_SnowMaskmap, uv_Snow);

		//snowAmount = (_SnowAmount * normalY * (clamp(worldNormal.y + _SnowAngle, 0, 1)) + clamp(o.Normal.y + _NormalInfluence, 0, 1) * _SnowAmount * .25) * _SnowPower;
		float snowAmount = (_SnowAmount * (clamp(worldNormal.y + _SnowAngle, 0, 1)) + clamp(normalY + _NormalInfluence, 0, 1) * _SnowAmount * .25) * _SnowPower;
		snowAmount *= clamp((worldPosY - _SnowStartHeight) * .0125, 0, 1);
		snowAmount = clamp(pow(snowAmount , 6) * 256, 0, 1);

		//half noise = tex2D(_Noise, uv_Control * _NoiseTiling).r * _NoiseIntensity;
		//snowAmount = clamp(snowAmount * noise, 0, 1);

		snowAmount *= waterMask;

		float snowSmoothness = snow.a * _SnowSmoothness * snowAmount * 2.5;

		//surfaceNormal = lerp(surfaceNormal, float3(0, 0, 1), snowAmount);
		albedo = finalCol * (1 - snowAmount) + snow.rgb * snowAmount * _SnowColor * 2;
		smoothness = _Smoothness + snowSmoothness;
	}
	else
	{
		albedo = finalCol;
		smoothness = _Smoothness * 4;
	}
}

#endif // TERRAFORMER_SNOW_CGINC_INCLUDED

