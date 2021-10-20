// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""8441717c-b793-4efd-83ce-79df9cbda060"",
            ""actions"": [
                {
                    ""name"": ""switchAngleHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""cd3af535-dfe6-4f4b-895e-946417316b13"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""switchAngleVertical"",
                    ""type"": ""Value"",
                    ""id"": ""6c0a1516-4f7b-43fa-8b1d-71b93473a2df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""shoot"",
                    ""type"": ""Value"",
                    ""id"": ""c443d1ef-02f4-4925-abb3-8810ec1248e5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveRight"",
                    ""type"": ""Button"",
                    ""id"": ""f5ec64de-9737-4305-bbff-9b8786d75450"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""5fed3987-4e54-408a-ba4d-e58cf3fc227c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveUp"",
                    ""type"": ""Button"",
                    ""id"": ""f7a424f4-ff17-4282-b548-99a10cb7e5a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveDown"",
                    ""type"": ""Button"",
                    ""id"": ""ba4487b7-5b37-4689-b48f-bfce51b5605e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bdffa689-67e3-4faf-bbd8-752dc50dd2aa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5d2058c3-a8f4-403c-9690-f4d182f8cb49"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""switchAngleHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""18633592-135b-4eca-af40-7ebdebc995af"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""switchAngleHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""68a8f0c1-df32-4ed7-a2c1-942c3fa97745"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""switchAngleHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1860f689-9a69-444d-93b0-7201db386d92"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ad95736-283e-43ad-be42-303853cfaffe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9151b15-ffa2-4a95-a309-09e149abe1c2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2469fd8-5786-48bf-8523-4fdcb4ee2532"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""85f2c187-2f5b-4f4a-96e3-7a7d2af3e416"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""switchAngleVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f42df66d-5bff-4130-aa20-f6c2103fd801"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""switchAngleVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""70e1d140-e6c0-478f-ab6f-245f556c125d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""switchAngleVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_switchAngleHorizontal = m_Gameplay.FindAction("switchAngleHorizontal", throwIfNotFound: true);
        m_Gameplay_switchAngleVertical = m_Gameplay.FindAction("switchAngleVertical", throwIfNotFound: true);
        m_Gameplay_shoot = m_Gameplay.FindAction("shoot", throwIfNotFound: true);
        m_Gameplay_moveRight = m_Gameplay.FindAction("moveRight", throwIfNotFound: true);
        m_Gameplay_moveLeft = m_Gameplay.FindAction("moveLeft", throwIfNotFound: true);
        m_Gameplay_moveUp = m_Gameplay.FindAction("moveUp", throwIfNotFound: true);
        m_Gameplay_moveDown = m_Gameplay.FindAction("moveDown", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_switchAngleHorizontal;
    private readonly InputAction m_Gameplay_switchAngleVertical;
    private readonly InputAction m_Gameplay_shoot;
    private readonly InputAction m_Gameplay_moveRight;
    private readonly InputAction m_Gameplay_moveLeft;
    private readonly InputAction m_Gameplay_moveUp;
    private readonly InputAction m_Gameplay_moveDown;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @switchAngleHorizontal => m_Wrapper.m_Gameplay_switchAngleHorizontal;
        public InputAction @switchAngleVertical => m_Wrapper.m_Gameplay_switchAngleVertical;
        public InputAction @shoot => m_Wrapper.m_Gameplay_shoot;
        public InputAction @moveRight => m_Wrapper.m_Gameplay_moveRight;
        public InputAction @moveLeft => m_Wrapper.m_Gameplay_moveLeft;
        public InputAction @moveUp => m_Wrapper.m_Gameplay_moveUp;
        public InputAction @moveDown => m_Wrapper.m_Gameplay_moveDown;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @switchAngleHorizontal.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchAngleHorizontal;
                @switchAngleHorizontal.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchAngleHorizontal;
                @switchAngleHorizontal.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchAngleHorizontal;
                @switchAngleVertical.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchAngleVertical;
                @switchAngleVertical.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchAngleVertical;
                @switchAngleVertical.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchAngleVertical;
                @shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @moveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @moveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @moveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @moveLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @moveLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @moveLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @moveUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                @moveUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                @moveUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveUp;
                @moveDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveDown;
                @moveDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveDown;
                @moveDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveDown;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @switchAngleHorizontal.started += instance.OnSwitchAngleHorizontal;
                @switchAngleHorizontal.performed += instance.OnSwitchAngleHorizontal;
                @switchAngleHorizontal.canceled += instance.OnSwitchAngleHorizontal;
                @switchAngleVertical.started += instance.OnSwitchAngleVertical;
                @switchAngleVertical.performed += instance.OnSwitchAngleVertical;
                @switchAngleVertical.canceled += instance.OnSwitchAngleVertical;
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
                @moveRight.started += instance.OnMoveRight;
                @moveRight.performed += instance.OnMoveRight;
                @moveRight.canceled += instance.OnMoveRight;
                @moveLeft.started += instance.OnMoveLeft;
                @moveLeft.performed += instance.OnMoveLeft;
                @moveLeft.canceled += instance.OnMoveLeft;
                @moveUp.started += instance.OnMoveUp;
                @moveUp.performed += instance.OnMoveUp;
                @moveUp.canceled += instance.OnMoveUp;
                @moveDown.started += instance.OnMoveDown;
                @moveDown.performed += instance.OnMoveDown;
                @moveDown.canceled += instance.OnMoveDown;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnSwitchAngleHorizontal(InputAction.CallbackContext context);
        void OnSwitchAngleVertical(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
    }
}
