//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Inputs/Inputs.inputactions
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

public partial class @Inputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""0078373d-4192-4612-92fc-71314e08b147"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""e2a09319-88c1-4570-b577-c9ccce7ff1e0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChooseWeapon1"",
                    ""type"": ""Button"",
                    ""id"": ""ce608a54-3a38-4e8c-af92-8128e75fd9d9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChooseWeapon2"",
                    ""type"": ""Button"",
                    ""id"": ""96a6620e-64f8-48c2-a520-73ff69ae606e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChooseWeapon3"",
                    ""type"": ""Button"",
                    ""id"": ""2db99cd0-d7ed-4589-b0ec-a553a0864d4f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""568dd4c5-396b-4302-8650-704e86ec71b0"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f463d83-b42e-4807-9e7d-dc87eb5bbe35"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseWeapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b90eb96f-4bc2-46dd-9eb6-fea92ba6e92a"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseWeapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0a0902d-1fad-4a83-997f-f5031fe3c4c7"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseWeapon3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_ChooseWeapon1 = m_Gameplay.FindAction("ChooseWeapon1", throwIfNotFound: true);
        m_Gameplay_ChooseWeapon2 = m_Gameplay.FindAction("ChooseWeapon2", throwIfNotFound: true);
        m_Gameplay_ChooseWeapon3 = m_Gameplay.FindAction("ChooseWeapon3", throwIfNotFound: true);
    }

    ~@Inputs()
    {
        UnityEngine.Debug.Assert(!m_Gameplay.enabled, "This will cause a leak and performance issues, Inputs.Gameplay.Disable() has not been called.");
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_ChooseWeapon1;
    private readonly InputAction m_Gameplay_ChooseWeapon2;
    private readonly InputAction m_Gameplay_ChooseWeapon3;
    public struct GameplayActions
    {
        private @Inputs m_Wrapper;
        public GameplayActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @ChooseWeapon1 => m_Wrapper.m_Gameplay_ChooseWeapon1;
        public InputAction @ChooseWeapon2 => m_Wrapper.m_Gameplay_ChooseWeapon2;
        public InputAction @ChooseWeapon3 => m_Wrapper.m_Gameplay_ChooseWeapon3;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @ChooseWeapon1.started += instance.OnChooseWeapon1;
            @ChooseWeapon1.performed += instance.OnChooseWeapon1;
            @ChooseWeapon1.canceled += instance.OnChooseWeapon1;
            @ChooseWeapon2.started += instance.OnChooseWeapon2;
            @ChooseWeapon2.performed += instance.OnChooseWeapon2;
            @ChooseWeapon2.canceled += instance.OnChooseWeapon2;
            @ChooseWeapon3.started += instance.OnChooseWeapon3;
            @ChooseWeapon3.performed += instance.OnChooseWeapon3;
            @ChooseWeapon3.canceled += instance.OnChooseWeapon3;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @ChooseWeapon1.started -= instance.OnChooseWeapon1;
            @ChooseWeapon1.performed -= instance.OnChooseWeapon1;
            @ChooseWeapon1.canceled -= instance.OnChooseWeapon1;
            @ChooseWeapon2.started -= instance.OnChooseWeapon2;
            @ChooseWeapon2.performed -= instance.OnChooseWeapon2;
            @ChooseWeapon2.canceled -= instance.OnChooseWeapon2;
            @ChooseWeapon3.started -= instance.OnChooseWeapon3;
            @ChooseWeapon3.performed -= instance.OnChooseWeapon3;
            @ChooseWeapon3.canceled -= instance.OnChooseWeapon3;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnChooseWeapon1(InputAction.CallbackContext context);
        void OnChooseWeapon2(InputAction.CallbackContext context);
        void OnChooseWeapon3(InputAction.CallbackContext context);
    }
}
