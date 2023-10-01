using _Project.Scripts.Application.Core.Singeltons;
using MechaNest._Project.Scripts.Application.Core.Managers;
using UnityEngine.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Application.Core.Managers
{
    
    [System.Serializable] public class EventMenuState : UnityEvent<MenuManager.MenuState, MenuManager.MenuState> {}
    public class MenuManager : Singelton<MenuManager>
    {
        [Header("MENU STATE")]
        [SerializeField] private string currentMenuName;

        [Header("Ui Panels")] 
        [SerializeField] private GameObject playerGameUi;
        [SerializeField] private GameObject titlePanel;
        [SerializeField] private GameObject loginPanel;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject gameMenuPanel;
        [SerializeField] private GameObject controlsPanel;
        [SerializeField] private GameObject gameplayPanel;
        [SerializeField] private GameObject interfacePanel;
        [SerializeField] private GameObject displayPanel;
        [SerializeField] private GameObject audioPanel;
        [SerializeField] private GameObject developerPanel;
        [SerializeField] private GameObject deadPanel;

        [Header("BUTTONS")]
        [SerializeField] private Button restartButton;

        [Header("TEXT")] [SerializeField] private TMP_Text deadTMPText;
        private void OnEnable()
        {
            playerGameUi.SetActive(false);
            titlePanel.SetActive(false);
            loginPanel.SetActive(false);
            pausePanel.SetActive(false);
            gameMenuPanel.SetActive(false); // panel at start of the game.
            controlsPanel.SetActive(false);
            gameplayPanel.SetActive(false); // panel in the settings menu.
            interfacePanel.SetActive(false);
            displayPanel.SetActive(false);
            audioPanel.SetActive(false);
            developerPanel.SetActive(false);
            deadPanel.SetActive(false);
        }
         #region MENU STATES
            public enum MenuState
                    {
                        LOGINMENU,
                        TITLESCREEN,
                        PAUSEMENU,
                        GAMEMENU,
                        GAMESETTINGMENU,
                        DISPLAYMENU,
                        GRAPHICSMENU,
                        AUDIOMENU,
                        CONTROLSMENU,
                        INTERFACE,
                        DEADMENU,
                        DEVELOPERMENU,
                        ALLCLOSED,
                    }
                public EventMenuState onMenuStateChanged;
                private MenuState _currentMenuState;

                public MenuState CurrentMenuState
                {
                    get { return _currentMenuState; }
                    private set { _currentMenuState = value;  }
                }
                public void UpdateMenuState(MenuState state) // Control the State of the menu.
                {
                    MenuState previousGameState = _currentMenuState;
                    _currentMenuState = state;

                    switch (_currentMenuState)
                    {
                        case MenuState.TITLESCREEN:
                            GameManager.Instance.UpdateGameState(GameManager.GameState.TITLE);
                            //Panels
                            playerGameUi.SetActive(false);
                            titlePanel.SetActive(true);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(false);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Login Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.LOGINMENU:
                            GameManager.Instance.UpdateGameState(GameManager.GameState.LOGIN);
                            //Panels
                            playerGameUi.SetActive(false);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(true);
                            pausePanel.SetActive(false);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Login Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.GAMEMENU:
                            GameManager.Instance.UpdateGameState(GameManager.GameState.PREGAME);
                            //Panels
                            playerGameUi.SetActive(false);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(false);
                            gameMenuPanel.SetActive(true); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(true);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Paused Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.PAUSEMENU:
                            GameManager.Instance.UpdateGameState(GameManager.GameState.PAUSED);
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(true);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(true); // first panel on the pause panel.
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Paused Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.GAMESETTINGMENU:
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(true);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(true);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Paused Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.DISPLAYMENU:
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(true);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(true);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Paused Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.GRAPHICSMENU:
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(true);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Paused Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.AUDIOMENU:
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(true);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(true);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Paused Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.CONTROLSMENU:
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(true);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(true); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Paused Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.INTERFACE:
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(true);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(true);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Paused Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.DEADMENU:
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(true);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(true);
                            //Editor menu name.
                            currentMenuName = "Dead menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            
                            restartButton.enabled = true;
                            restartButton.gameObject.SetActive(true);
                            deadTMPText.text = "You Died!";
                            break;
                        case MenuState.DEVELOPERMENU:
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(false);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(true);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "Developer Menu";
                            //Cursor
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            //Time
                            Time.timeScale = 1;
                            break;
                        case MenuState.ALLCLOSED:
                            GameManager.Instance.UpdateGameState(GameManager.GameState.RUNNING);
                            //Panels
                            playerGameUi.SetActive(true);
                            titlePanel.SetActive(false);
                            loginPanel.SetActive(false);
                            pausePanel.SetActive(false);
                            gameMenuPanel.SetActive(false); // panel at start of the game.
                            controlsPanel.SetActive(false); 
                            gameplayPanel.SetActive(false);
                            interfacePanel.SetActive(false);
                            displayPanel.SetActive(false);
                            audioPanel.SetActive(false);
                            developerPanel.SetActive(false);
                            deadPanel.SetActive(false);
                            //Editor menu name.
                            currentMenuName = "ALL menus closed";
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                            Time.timeScale = 1;
                            break;
                            
                    }

                }
        

        #endregion
        
        public void OnClickBack()
        {
            UpdateMenuState(MenuState.ALLCLOSED);
        }

        public void OnClickQuit()
        {
            UnityEngine.Application.Quit();
        }

        public void OnClickRestart()
        {
            restartButton.enabled = false;
            restartButton.gameObject.SetActive(false);
            deadTMPText.text = "Getting you back in Game...";
        }

        public void OnClickLogin()
        {
            UpdateMenuState(MenuState.LOGINMENU);
        }

        public void OnClickMainGame()
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.PREGAME);
            UpdateMenuState(MenuState.GAMEMENU);
        }

        public void OnClickControlsMenu()
        {
            UpdateMenuState(MenuState.CONTROLSMENU);
        }

        public void OnClickGamePlayMenu()
        {
            UpdateMenuState(MenuState.GAMESETTINGMENU);
        }

        public void OnClickInterfaceMenu()
        {
            UpdateMenuState(MenuState.INTERFACE);
        }

        public void OnClickDisplayMenu()
        {
            UpdateMenuState(MenuState.DISPLAYMENU);
        }

        public void OnClickAudioMenu()
        {
            UpdateMenuState(MenuState.AUDIOMENU);
        }
        
    }
}