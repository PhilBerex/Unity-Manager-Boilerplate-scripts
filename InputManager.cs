using System;
using UnityEngine;


{
    public class InputManager : Singelton<InputManager>
    {
        private static MainAssets _mainAssets;
        
        protected override void Awake()
        {
            _mainAssets = new MainAssets();
            base.Awake();
        }
        private void OnEnable()
        {
            _mainAssets.Player.Enable();
        }
        public static MainAssets MainAssets => _mainAssets;

        [Header("Character Input Values")] 
        [SerializeField] private Vector2 inspectorMoveValue;
        [SerializeField] private Vector2 inspectorLookValue;
        [SerializeField] private bool inspectorJumpBool;
        [SerializeField] private bool inspectorSprintBool;
        [SerializeField] private bool inspectorEscapeBool;

        
        private void Update()
        {
            PlayerInputControls();
            
            if (UnityEngine.Application.isEditor)
            {
                inspectorMoveValue = _mainAssets.Player.Move.ReadValue<Vector2>();
                inspectorLookValue = _mainAssets.Player.Look.ReadValue<Vector2>();
            
                inspectorJumpBool = _mainAssets.Player.Jump.WasPressedThisFrame();
                inspectorSprintBool = _mainAssets.Player.Sprint.WasPressedThisFrame(); 
            }
        }
        void PlayerInputControls()
        {
            
            _mainAssets.Player.Enable();
            _mainAssets.UI.Disable();
            /*
             * if (MenuManager.Instance.CurrentMenuState == MenuManager.MenuState.TITLESCREEN)
            {
                _mainAssets.Player.Disable();
                _mainAssets.UI.Enable();
            }

            if (MenuManager.Instance.CurrentMenuState == MenuManager.MenuState.LOGINMENU)
            {
                _mainAssets.Player.Disable();
                _mainAssets.UI.Enable();
            }
            
            if (MenuManager.Instance.CurrentMenuState == MenuManager.MenuState.GAMEMENU)
            {
                _mainAssets.Player.Disable();
                _mainAssets.UI.Enable();
            }

            if (MenuManager.Instance.CurrentMenuState == MenuManager.MenuState.ALLCLOSED)
            {
                _mainAssets.Player.Enable();
                _mainAssets.UI.Disable();
            }

            if (MenuManager.Instance.CurrentMenuState == MenuManager.MenuState.PAUSEMENU)
            {
                _mainAssets.Player.Disable();
                _mainAssets.UI.Enable();
            }

            if (MenuManager.Instance.CurrentMenuState == MenuManager.MenuState.DEADMENU)
            {
                _mainAssets.Player.Disable();
                _mainAssets.UI.Enable();
            }
             */
            
            
            
        }
    }
}