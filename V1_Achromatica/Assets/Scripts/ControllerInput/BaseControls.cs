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
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light Attack"",
                    ""type"": ""Button"",
                    ""id"": ""f32ef602-c054-4ba4-a331-5f523c71ca99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy Attack"",
                    ""type"": ""Button"",
                    ""id"": ""1a5d7f2d-8af1-43f3-b933-2bfe5b8123fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
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
                    ""processors"": """",
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
                    ""interactions"": ""Press(behavior=2)"",
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
    public struct FreeRoamActions
    {
        private @BaseControls m_Wrapper;
        public FreeRoamActions(@BaseControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_FreeRoam_Movement;
        public InputAction @CameraControl => m_Wrapper.m_FreeRoam_CameraControl;
        public InputAction @Guard => m_Wrapper.m_FreeRoam_Guard;
        public InputAction @LightAttack => m_Wrapper.m_FreeRoam_LightAttack;
        public InputAction @HeavyAttack => m_Wrapper.m_FreeRoam_HeavyAttack;
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
    }
}
