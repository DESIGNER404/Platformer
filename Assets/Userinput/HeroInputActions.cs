// GENERATED AUTOMATICALLY FROM 'Assets/HeroInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @HeroInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @HeroInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""HeroInputActions"",
    ""maps"": [
        {
            ""name"": ""Hero"",
            ""id"": ""5c36f88d-b976-463b-9bee-9df0a080c30d"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovment"",
                    ""type"": ""Button"",
                    ""id"": ""d7cddc19-9222-4192-9f63-fc9ec1297a65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Kayboard"",
                    ""id"": ""cba9b36b-037b-4dfa-aa3f-cbb282c0a332"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""436f56a8-a667-43af-9b3f-9ba4e9f066ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f14f750f-f965-4bb9-994e-09963cc69150"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hero
        m_Hero = asset.FindActionMap("Hero", throwIfNotFound: true);
        m_Hero_HorizontalMovment = m_Hero.FindAction("HorizontalMovment", throwIfNotFound: true);
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

    // Hero
    private readonly InputActionMap m_Hero;
    private IHeroActions m_HeroActionsCallbackInterface;
    private readonly InputAction m_Hero_HorizontalMovment;
    public struct HeroActions
    {
        private @HeroInputActions m_Wrapper;
        public HeroActions(@HeroInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovment => m_Wrapper.m_Hero_HorizontalMovment;
        public InputActionMap Get() { return m_Wrapper.m_Hero; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HeroActions set) { return set.Get(); }
        public void SetCallbacks(IHeroActions instance)
        {
            if (m_Wrapper.m_HeroActionsCallbackInterface != null)
            {
                @HorizontalMovment.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnHorizontalMovment;
                @HorizontalMovment.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnHorizontalMovment;
                @HorizontalMovment.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnHorizontalMovment;
            }
            m_Wrapper.m_HeroActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMovment.started += instance.OnHorizontalMovment;
                @HorizontalMovment.performed += instance.OnHorizontalMovment;
                @HorizontalMovment.canceled += instance.OnHorizontalMovment;
            }
        }
    }
    public HeroActions @Hero => new HeroActions(this);
    public interface IHeroActions
    {
        void OnHorizontalMovment(InputAction.CallbackContext context);
    }
}
