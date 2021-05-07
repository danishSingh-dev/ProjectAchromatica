// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/ControllerInput/BaseControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BaseControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BaseControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BaseControls"",
    ""maps"": [
        {
            ""name"": ""FreeRoam"",
            ""id"": ""3b6dde1d-113f-439e-a9d0-70786beb90b5"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""764a148a-bd1b-410e-9d27-f4f8813b145c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera Control"",
                    ""type"": ""Value"",
                    ""id"": ""900e3729-8b08-4b06-a60e-25a38c9db111"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""70f77b25-8487-431c-8f7a-b910cffac330"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Light Attack"",
                    ""type"": ""Button"",
                    ""id"": ""f32ef602-c054-4ba4-a331-5f523c71ca99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""Heavy Attack"",
                    ""type"": ""Button"",
                    ""id"": ""1a5d7f2d-8af1-43f3-b933-2bfe5b8123fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""Ranged Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2b29833b-c858-4613-bb8b-ee83acc80f12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""926ae59b-5658-4569-9134-235eb955f866"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""Speed Powers"",
                    ""type"": ""Button"",
                    ""id"": ""1b76a81c-d423-45bb-8b84-cbc8c3baf223"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""Strength Powers"",
                    ""type"": ""Button"",
                    ""id"": ""eabe659f-e492-4e53-9416-015821b13099"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""803f3fb6-bc4c-4d6a-8825-cb217ccc79e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,MultiTap""
                },
                {
                    ""name"": ""Camera Reset"",
                    ""type"": ""Button"",
                    ""id"": ""e348cabc-08b3-4fb0-9a75-933222c398fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Options"",
                    ""type"": ""Button"",
                    ""id"": ""26ee3a02-b16d-4564-a9cf-f9fe1fdd86d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""DirUp"",
                    ""type"": ""Button"",
                    ""id"": ""055d8547-6203-4c2f-a46e-8728b665faf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""DirLeft"",
                    ""type"": ""Button"",
                    ""id"": ""cd4acb82-65e9-4571-aa95-f9683bcc7047"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""DirRight"",
                    ""type"": ""Button"",
                    ""id"": ""d299d802-2e88-4ca3-980e-146710fa1b7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                },
                {
                    ""name"": ""DirDown"",
                    ""type"": ""Button"",
                    ""id"": ""0f8477f2-b92c-4b22-9362-df5554b522ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""44841115-cac8-4e74-8312-10e9fa492ff8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""29dbb40d-f2b3-4ba9-8626-38df80b7d3f6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3239f77f-a467-44cb-a9e8-d81cc4757827"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a523b854-f541-4239-94d3-61475a61d582"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""aefc43e1-c3db-44bf-aa8b-fb4cd37698f2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0ee9ac7c-e95e-4a45-8ce8-25285e0fc65a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7d4309df-644b-40f7-8c19-66cce552a608"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Camera Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1258fd0c-1eb3-46dc-b20b-f3395e64d6d7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Controls"",
                    ""action"": ""Camera Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a662d2ee-893b-4a92-8d80-1dd8b425dce9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press,Hold"",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Light Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8dadaa1-b11d-498a-8538-4774fda871ac"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Controls"",
                    ""action"": ""Light Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21c46e5a-7528-4e9a-80e5-393e5acf2a58"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press,Hold"",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Heavy Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11b256e6-fbb7-4d8d-8802-c97be1fb6240"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Controls"",
                    ""action"": ""Heavy Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da05a697-9e4d-496e-b5c4-29f0cc9c4083"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56bec6f7-472e-4817-be51-1635857d2ece"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Controls"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa48240a-df6b-4341-a0b5-72499269e923"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Ranged Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7833b3a-ccd3-4439-b0e2-2258d529bafa"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19f101fe-c43e-4101-8773-11fd511233d5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Speed Powers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d29509c-5414-4f9b-a5da-86c452329a18"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Strength Powers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cacfd5aa-2073-4116-a101-3ede6718d258"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bd374de-348b-49f7-8eaf-627702ea6bda"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Camera Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9d5190f-f1f6-40f9-a225-d805eef0434c"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Options"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d654a72-ad09-4487-9a65-57e5e09310aa"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""DirUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b48ca04-517c-449e-9d8f-305d95a5594c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""DirLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a22fc3b-8398-48a9-9a34-834c811ff829"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""DirRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8203b50c-56a2-4abd-a0bf-75162eee1c32"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""DirDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard Controls"",
            ""bindingGroup"": ""Keyboard Controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller Controls"",
            ""bindingGroup"": ""Controller Controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // FreeRoam
        m_FreeRoam = asset.FindActionMap("FreeRoam", throwIfNotFound: true);
        m_FreeRoam_Movement = m_FreeRoam.FindAction("Movement", throwIfNotFound: true);
        m_FreeRoam_CameraControl = m_FreeRoam.FindAction("Camera Control", throwIfNotFound: true);
        m_FreeRoam_Guard = m_FreeRoam.FindAction("Guard", throwIfNotFound: true);
        m_FreeRoam_LightAttack = m_FreeRoam.FindAction("Light Attack", throwIfNotFound: true);
        m_FreeRoam_HeavyAttack = m_FreeRoam.FindAction("Heavy Attack", throwIfNotFound: true);
        m_FreeRoam_RangedAttack = m_FreeRoam.FindAction("Ranged Attack", throwIfNotFound: true);
        m_FreeRoam_Dodge = m_FreeRoam.FindAction("Dodge", throwIfNotFound: true);
        m_FreeRoam_SpeedPowers = m_FreeRoam.FindAction("Speed Powers", throwIfNotFound: true);
        m_FreeRoam_StrengthPowers = m_FreeRoam.FindAction("Strength Powers", throwIfNotFound: true);
        m_FreeRoam_Sprint = m_FreeRoam.FindAction("Sprint", throwIfNotFound: true);
        m_FreeRoam_CameraReset = m_FreeRoam.FindAction("Camera Reset", throwIfNotFound: true);
        m_FreeRoam_Options = m_FreeRoam.FindAction("Options", throwIfNotFound: true);
        m_FreeRoam_DirUp = m_FreeRoam.FindAction("DirUp", throwIfNotFound: true);
        m_FreeRoam_DirLeft = m_FreeRoam.FindAction("DirLeft", throwIfNotFound: true);
        m_FreeRoam_DirRight = m_FreeRoam.FindAction("DirRight", throwIfNotFound: true);
        m_FreeRoam_DirDown = m_FreeRoam.FindAction("DirDown", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // FreeRoam
    private readonly InputActionMap m_FreeRoam;
    private IFreeRoamActions m_FreeRoamActionsCallbackInterface;
    private readonly InputAction m_FreeRoam_Movement;
    private readonly InputAction m_FreeRoam_CameraControl;
    private readonly InputAction m_FreeRoam_Guard;
    private readonly InputAction m_FreeRoam_LightAttack;
    private readonly InputAction m_FreeRoam_HeavyAttack;
    private readonly InputAction m_FreeRoam_RangedAttack;
    private readonly InputAction m_FreeRoam_Dodge;
    private readonly InputAction m_FreeRoam_SpeedPowers;
    private readonly InputAction m_FreeRoam_StrengthPowers;
    private readonly InputAction m_FreeRoam_Sprint;
    private readonly InputAction m_FreeRoam_CameraReset;
    private readonly InputAction m_FreeRoam_Options;
    private readonly InputAction m_FreeRoam_DirUp;
    private readonly InputAction m_FreeRoam_DirLeft;
    private readonly InputAction m_FreeRoam_DirRight;
    private readonly InputAction m_FreeRoam_DirDown;
    public struct FreeRoamActions
    {
        private @BaseControls m_Wrapper;
        public FreeRoamActions(@BaseControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_FreeRoam_Movement;
        public InputAction @CameraControl => m_Wrapper.m_FreeRoam_CameraControl;
        public InputAction @Guard => m_Wrapper.m_FreeRoam_Guard;
        public InputAction @LightAttack => m_Wrapper.m_FreeRoam_LightAttack;
        public InputAction @HeavyAttack => m_Wrapper.m_FreeRoam_HeavyAttack;
        public InputAction @RangedAttack => m_Wrapper.m_FreeRoam_RangedAttack;
        public InputAction @Dodge => m_Wrapper.m_FreeRoam_Dodge;
        public InputAction @SpeedPowers => m_Wrapper.m_FreeRoam_SpeedPowers;
        public InputAction @StrengthPowers => m_Wrapper.m_FreeRoam_StrengthPowers;
        public InputAction @Sprint => m_Wrapper.m_FreeRoam_Sprint;
        public InputAction @CameraReset => m_Wrapper.m_FreeRoam_CameraReset;
        public InputAction @Options => m_Wrapper.m_FreeRoam_Options;
        public InputAction @DirUp => m_Wrapper.m_FreeRoam_DirUp;
        public InputAction @DirLeft => m_Wrapper.m_FreeRoam_DirLeft;
        public InputAction @DirRight => m_Wrapper.m_FreeRoam_DirRight;
        public InputAction @DirDown => m_Wrapper.m_FreeRoam_DirDown;
        public InputActionMap Get() { return m_Wrapper.m_FreeRoam; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FreeRoamActions set) { return set.Get(); }
        public void SetCallbacks(IFreeRoamActions instance)
        {
            if (m_Wrapper.m_FreeRoamActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnMovement;
                @CameraControl.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraControl;
                @CameraControl.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraControl;
                @CameraControl.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraControl;
                @Guard.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnGuard;
                @LightAttack.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnLightAttack;
                @LightAttack.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnLightAttack;
                @LightAttack.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnLightAttack;
                @HeavyAttack.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnHeavyAttack;
                @RangedAttack.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnRangedAttack;
                @RangedAttack.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnRangedAttack;
                @RangedAttack.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnRangedAttack;
                @Dodge.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDodge;
                @SpeedPowers.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnSpeedPowers;
                @SpeedPowers.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnSpeedPowers;
                @SpeedPowers.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnSpeedPowers;
                @StrengthPowers.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnStrengthPowers;
                @StrengthPowers.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnStrengthPowers;
                @StrengthPowers.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnStrengthPowers;
                @Sprint.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnSprint;
                @CameraReset.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraReset;
                @CameraReset.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraReset;
                @CameraReset.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraReset;
                @Options.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnOptions;
                @Options.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnOptions;
                @Options.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnOptions;
                @DirUp.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirUp;
                @DirUp.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirUp;
                @DirUp.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirUp;
                @DirLeft.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirLeft;
                @DirLeft.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirLeft;
                @DirLeft.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirLeft;
                @DirRight.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirRight;
                @DirRight.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirRight;
                @DirRight.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirRight;
                @DirDown.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirDown;
                @DirDown.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirDown;
                @DirDown.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnDirDown;
            }
            m_Wrapper.m_FreeRoamActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CameraControl.started += instance.OnCameraControl;
                @CameraControl.performed += instance.OnCameraControl;
                @CameraControl.canceled += instance.OnCameraControl;
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
                @RangedAttack.started += instance.OnRangedAttack;
                @RangedAttack.performed += instance.OnRangedAttack;
                @RangedAttack.canceled += instance.OnRangedAttack;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @SpeedPowers.started += instance.OnSpeedPowers;
                @SpeedPowers.performed += instance.OnSpeedPowers;
                @SpeedPowers.canceled += instance.OnSpeedPowers;
                @StrengthPowers.started += instance.OnStrengthPowers;
                @StrengthPowers.performed += instance.OnStrengthPowers;
                @StrengthPowers.canceled += instance.OnStrengthPowers;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @CameraReset.started += instance.OnCameraReset;
                @CameraReset.performed += instance.OnCameraReset;
                @CameraReset.canceled += instance.OnCameraReset;
                @Options.started += instance.OnOptions;
                @Options.performed += instance.OnOptions;
                @Options.canceled += instance.OnOptions;
                @DirUp.started += instance.OnDirUp;
                @DirUp.performed += instance.OnDirUp;
                @DirUp.canceled += instance.OnDirUp;
                @DirLeft.started += instance.OnDirLeft;
                @DirLeft.performed += instance.OnDirLeft;
                @DirLeft.canceled += instance.OnDirLeft;
                @DirRight.started += instance.OnDirRight;
                @DirRight.performed += instance.OnDirRight;
                @DirRight.canceled += instance.OnDirRight;
                @DirDown.started += instance.OnDirDown;
                @DirDown.performed += instance.OnDirDown;
                @DirDown.canceled += instance.OnDirDown;
            }
        }
    }
    public FreeRoamActions @FreeRoam => new FreeRoamActions(this);
    private int m_KeyboardControlsSchemeIndex = -1;
    public InputControlScheme KeyboardControlsScheme
    {
        get
        {
            if (m_KeyboardControlsSchemeIndex == -1) m_KeyboardControlsSchemeIndex = asset.FindControlSchemeIndex("Keyboard Controls");
            return asset.controlSchemes[m_KeyboardControlsSchemeIndex];
        }
    }
    private int m_ControllerControlsSchemeIndex = -1;
    public InputControlScheme ControllerControlsScheme
    {
        get
        {
            if (m_ControllerControlsSchemeIndex == -1) m_ControllerControlsSchemeIndex = asset.FindControlSchemeIndex("Controller Controls");
            return asset.controlSchemes[m_ControllerControlsSchemeIndex];
        }
    }
    public interface IFreeRoamActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCameraControl(InputAction.CallbackContext context);
        void OnGuard(InputAction.CallbackContext context);
        void OnLightAttack(InputAction.CallbackContext context);
        void OnHeavyAttack(InputAction.CallbackContext context);
        void OnRangedAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnSpeedPowers(InputAction.CallbackContext context);
        void OnStrengthPowers(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCameraReset(InputAction.CallbackContext context);
        void OnOptions(InputAction.CallbackContext context);
        void OnDirUp(InputAction.CallbackContext context);
        void OnDirLeft(InputAction.CallbackContext context);
        void OnDirRight(InputAction.CallbackContext context);
        void OnDirDown(InputAction.CallbackContext context);
    }
}
