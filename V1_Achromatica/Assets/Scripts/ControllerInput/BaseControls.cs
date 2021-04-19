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
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""70f77b25-8487-431c-8f7a-b910cffac330"",
                    ""expectedControlType"": ""Button"",
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
                    ""id"": ""7d4309df-644b-40f7-8c19-66cce552a608"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller Controls"",
                    ""action"": ""Camera Control"",
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
        m_FreeRoam_Guard = m_FreeRoam.FindAction("Guard", throwIfNotFound: true);
        m_FreeRoam_CameraControl = m_FreeRoam.FindAction("Camera Control", throwIfNotFound: true);
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
    private readonly InputAction m_FreeRoam_Guard;
    private readonly InputAction m_FreeRoam_CameraControl;
    public struct FreeRoamActions
    {
        private @BaseControls m_Wrapper;
        public FreeRoamActions(@BaseControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_FreeRoam_Movement;
        public InputAction @Guard => m_Wrapper.m_FreeRoam_Guard;
        public InputAction @CameraControl => m_Wrapper.m_FreeRoam_CameraControl;
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
                @Guard.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnGuard;
                @CameraControl.started -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraControl;
                @CameraControl.performed -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraControl;
                @CameraControl.canceled -= m_Wrapper.m_FreeRoamActionsCallbackInterface.OnCameraControl;
            }
            m_Wrapper.m_FreeRoamActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @CameraControl.started += instance.OnCameraControl;
                @CameraControl.performed += instance.OnCameraControl;
                @CameraControl.canceled += instance.OnCameraControl;
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
        void OnGuard(InputAction.CallbackContext context);
        void OnCameraControl(InputAction.CallbackContext context);
    }
}
