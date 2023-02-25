//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Core/InputSystem/GameplayActionMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameplayActionMap : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayActionMap"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""51809d25-a1b7-48b5-9cb2-31ebd67de749"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""3409d4a4-29e6-4e6e-b2fa-429821e5aa84"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""57d777f9-16e7-4293-b64f-83c8d7e259a6"",
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
                    ""id"": ""992ae2df-249a-4106-a7f1-d03acca92048"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4989d4d3-42a4-461f-a08d-92ae367f5ea0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6808872e-6d19-4bbe-80f2-349d978dbbab"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""774dcd76-5e25-47d7-8fde-2cf264ef7b5c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerAttack"",
            ""id"": ""f3a12932-58ef-459a-9281-94b9eb83c546"",
            ""actions"": [
                {
                    ""name"": ""ActivateSkill"",
                    ""type"": ""Button"",
                    ""id"": ""90c74130-88f9-4c4e-9f3e-87a285562b12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""55e4470f-f0bb-4dc7-81ca-86073ee0f222"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DeviceHandler"",
            ""id"": ""71968d3e-bd99-4fa9-bdda-045978489d94"",
            ""actions"": [
                {
                    ""name"": ""JoinGame"",
                    ""type"": ""Button"",
                    ""id"": ""7b4102cc-7b4b-46ae-9c45-8a6c3221f8f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3ac92ef-b9a8-4ee6-b01d-35f98851fef2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoinGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8308fdd2-a5b3-41c0-85f2-80e27f09561f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoinGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        // PlayerAttack
        m_PlayerAttack = asset.FindActionMap("PlayerAttack", throwIfNotFound: true);
        m_PlayerAttack_ActivateSkill = m_PlayerAttack.FindAction("ActivateSkill", throwIfNotFound: true);
        // DeviceHandler
        m_DeviceHandler = asset.FindActionMap("DeviceHandler", throwIfNotFound: true);
        m_DeviceHandler_JoinGame = m_DeviceHandler.FindAction("JoinGame", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    public struct PlayerMovementActions
    {
        private @GameplayActionMap m_Wrapper;
        public PlayerMovementActions(@GameplayActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerAttack
    private readonly InputActionMap m_PlayerAttack;
    private IPlayerAttackActions m_PlayerAttackActionsCallbackInterface;
    private readonly InputAction m_PlayerAttack_ActivateSkill;
    public struct PlayerAttackActions
    {
        private @GameplayActionMap m_Wrapper;
        public PlayerAttackActions(@GameplayActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @ActivateSkill => m_Wrapper.m_PlayerAttack_ActivateSkill;
        public InputActionMap Get() { return m_Wrapper.m_PlayerAttack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerAttackActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerAttackActions instance)
        {
            if (m_Wrapper.m_PlayerAttackActionsCallbackInterface != null)
            {
                @ActivateSkill.started -= m_Wrapper.m_PlayerAttackActionsCallbackInterface.OnActivateSkill;
                @ActivateSkill.performed -= m_Wrapper.m_PlayerAttackActionsCallbackInterface.OnActivateSkill;
                @ActivateSkill.canceled -= m_Wrapper.m_PlayerAttackActionsCallbackInterface.OnActivateSkill;
            }
            m_Wrapper.m_PlayerAttackActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ActivateSkill.started += instance.OnActivateSkill;
                @ActivateSkill.performed += instance.OnActivateSkill;
                @ActivateSkill.canceled += instance.OnActivateSkill;
            }
        }
    }
    public PlayerAttackActions @PlayerAttack => new PlayerAttackActions(this);

    // DeviceHandler
    private readonly InputActionMap m_DeviceHandler;
    private IDeviceHandlerActions m_DeviceHandlerActionsCallbackInterface;
    private readonly InputAction m_DeviceHandler_JoinGame;
    public struct DeviceHandlerActions
    {
        private @GameplayActionMap m_Wrapper;
        public DeviceHandlerActions(@GameplayActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @JoinGame => m_Wrapper.m_DeviceHandler_JoinGame;
        public InputActionMap Get() { return m_Wrapper.m_DeviceHandler; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeviceHandlerActions set) { return set.Get(); }
        public void SetCallbacks(IDeviceHandlerActions instance)
        {
            if (m_Wrapper.m_DeviceHandlerActionsCallbackInterface != null)
            {
                @JoinGame.started -= m_Wrapper.m_DeviceHandlerActionsCallbackInterface.OnJoinGame;
                @JoinGame.performed -= m_Wrapper.m_DeviceHandlerActionsCallbackInterface.OnJoinGame;
                @JoinGame.canceled -= m_Wrapper.m_DeviceHandlerActionsCallbackInterface.OnJoinGame;
            }
            m_Wrapper.m_DeviceHandlerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JoinGame.started += instance.OnJoinGame;
                @JoinGame.performed += instance.OnJoinGame;
                @JoinGame.canceled += instance.OnJoinGame;
            }
        }
    }
    public DeviceHandlerActions @DeviceHandler => new DeviceHandlerActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IPlayerAttackActions
    {
        void OnActivateSkill(InputAction.CallbackContext context);
    }
    public interface IDeviceHandlerActions
    {
        void OnJoinGame(InputAction.CallbackContext context);
    }
}
