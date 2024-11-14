//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input/CharacterControls.inputactions
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

public partial class @CharacterControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterControls"",
    ""maps"": [
        {
            ""name"": ""BaseCombat"",
            ""id"": ""a66bf337-adb6-4335-9f25-240ace1489b3"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7ef5e95f-0484-4e37-9981-b5680a6d16b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""381b7182-5aa7-4073-a322-f8962d71cdee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AttackNeutral"",
                    ""type"": ""Button"",
                    ""id"": ""7c974ed5-bc66-4759-bfbe-a3dbcfe61c57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackFavor"",
                    ""type"": ""Button"",
                    ""id"": ""e5e124b8-4330-421b-8563-6a8a7fb391d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""cce3adc6-d172-4aac-b0d8-e9e96767ddb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""299fc845-e3fb-4477-819c-0722a34d2fc2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0373576-2a5b-46cf-8100-c5ac2233416e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""577e309f-d14e-4f4b-a720-45be38898b69"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""ba9b1aba-8f11-4b69-a4b9-01c46b7474b0"",
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
                    ""id"": ""7fefb5d3-73e0-4998-8389-634c4338adc5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""62144b70-bae6-4a48-9ded-614d5dab8c3c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2f062d80-0787-4b80-93e2-a2d85f4b1773"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""76850954-a481-44eb-9b69-b802b59f53ca"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c9fc6b8c-f91e-4c84-a28b-0786daf42946"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackNeutral"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11118c6e-acb5-4fe1-a725-58ce452fe069"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackNeutral"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03040a76-377f-4d6f-9100-efbb0fa83175"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackFavor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4640be03-b2aa-4f86-a28e-222c4365e30f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackFavor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d12ae93d-5b3a-49a5-976c-ef15321a2c93"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32f74806-4a52-4e76-a506-41867061d614"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ui"",
            ""id"": ""368ed9bc-e3c2-4d34-a826-ca9c681875b6"",
            ""actions"": [
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Value"",
                    ""id"": ""e8024e3a-12bb-4ab7-82e3-3d2031f306f0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""768877f8-0707-45b5-9163-03a0624cd7a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c06ec0d-5c33-49db-8a22-653bbd672bcb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b7525f2-7559-4a2b-a996-a6d620206cc2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player1"",
            ""bindingGroup"": ""Player1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // BaseCombat
        m_BaseCombat = asset.FindActionMap("BaseCombat", throwIfNotFound: true);
        m_BaseCombat_Jump = m_BaseCombat.FindAction("Jump", throwIfNotFound: true);
        m_BaseCombat_Movement = m_BaseCombat.FindAction("Movement", throwIfNotFound: true);
        m_BaseCombat_AttackNeutral = m_BaseCombat.FindAction("AttackNeutral", throwIfNotFound: true);
        m_BaseCombat_AttackFavor = m_BaseCombat.FindAction("AttackFavor", throwIfNotFound: true);
        m_BaseCombat_Dash = m_BaseCombat.FindAction("Dash", throwIfNotFound: true);
        // Ui
        m_Ui = asset.FindActionMap("Ui", throwIfNotFound: true);
        m_Ui_Cursor = m_Ui.FindAction("Cursor", throwIfNotFound: true);
        m_Ui_Select = m_Ui.FindAction("Select", throwIfNotFound: true);
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

    // BaseCombat
    private readonly InputActionMap m_BaseCombat;
    private List<IBaseCombatActions> m_BaseCombatActionsCallbackInterfaces = new List<IBaseCombatActions>();
    private readonly InputAction m_BaseCombat_Jump;
    private readonly InputAction m_BaseCombat_Movement;
    private readonly InputAction m_BaseCombat_AttackNeutral;
    private readonly InputAction m_BaseCombat_AttackFavor;
    private readonly InputAction m_BaseCombat_Dash;
    public struct BaseCombatActions
    {
        private @CharacterControls m_Wrapper;
        public BaseCombatActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_BaseCombat_Jump;
        public InputAction @Movement => m_Wrapper.m_BaseCombat_Movement;
        public InputAction @AttackNeutral => m_Wrapper.m_BaseCombat_AttackNeutral;
        public InputAction @AttackFavor => m_Wrapper.m_BaseCombat_AttackFavor;
        public InputAction @Dash => m_Wrapper.m_BaseCombat_Dash;
        public InputActionMap Get() { return m_Wrapper.m_BaseCombat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseCombatActions set) { return set.Get(); }
        public void AddCallbacks(IBaseCombatActions instance)
        {
            if (instance == null || m_Wrapper.m_BaseCombatActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BaseCombatActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @AttackNeutral.started += instance.OnAttackNeutral;
            @AttackNeutral.performed += instance.OnAttackNeutral;
            @AttackNeutral.canceled += instance.OnAttackNeutral;
            @AttackFavor.started += instance.OnAttackFavor;
            @AttackFavor.performed += instance.OnAttackFavor;
            @AttackFavor.canceled += instance.OnAttackFavor;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
        }

        private void UnregisterCallbacks(IBaseCombatActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @AttackNeutral.started -= instance.OnAttackNeutral;
            @AttackNeutral.performed -= instance.OnAttackNeutral;
            @AttackNeutral.canceled -= instance.OnAttackNeutral;
            @AttackFavor.started -= instance.OnAttackFavor;
            @AttackFavor.performed -= instance.OnAttackFavor;
            @AttackFavor.canceled -= instance.OnAttackFavor;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
        }

        public void RemoveCallbacks(IBaseCombatActions instance)
        {
            if (m_Wrapper.m_BaseCombatActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBaseCombatActions instance)
        {
            foreach (var item in m_Wrapper.m_BaseCombatActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BaseCombatActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BaseCombatActions @BaseCombat => new BaseCombatActions(this);

    // Ui
    private readonly InputActionMap m_Ui;
    private List<IUiActions> m_UiActionsCallbackInterfaces = new List<IUiActions>();
    private readonly InputAction m_Ui_Cursor;
    private readonly InputAction m_Ui_Select;
    public struct UiActions
    {
        private @CharacterControls m_Wrapper;
        public UiActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cursor => m_Wrapper.m_Ui_Cursor;
        public InputAction @Select => m_Wrapper.m_Ui_Select;
        public InputActionMap Get() { return m_Wrapper.m_Ui; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
        public void AddCallbacks(IUiActions instance)
        {
            if (instance == null || m_Wrapper.m_UiActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UiActionsCallbackInterfaces.Add(instance);
            @Cursor.started += instance.OnCursor;
            @Cursor.performed += instance.OnCursor;
            @Cursor.canceled += instance.OnCursor;
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
        }

        private void UnregisterCallbacks(IUiActions instance)
        {
            @Cursor.started -= instance.OnCursor;
            @Cursor.performed -= instance.OnCursor;
            @Cursor.canceled -= instance.OnCursor;
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
        }

        public void RemoveCallbacks(IUiActions instance)
        {
            if (m_Wrapper.m_UiActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUiActions instance)
        {
            foreach (var item in m_Wrapper.m_UiActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UiActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UiActions @Ui => new UiActions(this);
    private int m_Player1SchemeIndex = -1;
    public InputControlScheme Player1Scheme
    {
        get
        {
            if (m_Player1SchemeIndex == -1) m_Player1SchemeIndex = asset.FindControlSchemeIndex("Player1");
            return asset.controlSchemes[m_Player1SchemeIndex];
        }
    }
    public interface IBaseCombatActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnAttackNeutral(InputAction.CallbackContext context);
        void OnAttackFavor(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IUiActions
    {
        void OnCursor(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
