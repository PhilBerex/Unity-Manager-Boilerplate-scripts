using System;
using System.Collections.Generic;
using _Project.Scripts.Application.Core.Singeltons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MechaNest._Project.Scripts.Application.Core.Managers
{
    
    [Serializable]
    public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState>
    {
    }
    public class GameManager: Singelton<GameManager>
    {
        //**NOTES**
        // keep track of the game states
        // generate other persistent system
        public enum GameState
        {
            TITLE,
            PREGAME,
            RUNNING,
            DEAD,
            PAUSED,
            RESTART,
            LOGIN,
            LOADING,
        }
        public EventGameState OnGameStateChanged;


        public GameObject[] SystemPrefabs;
        public List<GameObject> _instancedSystemPrefabs;
        
        [SerializeField] private string currentSceneName = string.Empty; // Name of the Scene that we want to load.
        [SerializeField] private string currentGameState = string.Empty; // Name of the Game state that the game is in.
        
        private List<AsyncOperation> loadOperation; // List with the loaded Scenes.
        
        public GameState CurrentGameState { get; private set; } = GameState.PREGAME;
        private void Start()
        {
            //DontDestroyOnLoad(gameObject);

            loadOperation = new List<AsyncOperation>(); // Create a new list for adding the loaded scenes in it.
            InstantiateSystemPrefabs(); // Create all the managers in the array "SystemPrefabs"
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();

            for (var i = 0; i < _instancedSystemPrefabs.Count; ++i)
            {
                Destroy(_instancedSystemPrefabs[i]);
                _instancedSystemPrefabs.Clear();
            }
        }
        public void UpdateGameState(GameState state) // Control the State of the game.
        {
            var previousGameState = CurrentGameState;
            CurrentGameState = state;

            switch (CurrentGameState)
            {
                case GameState.TITLE:
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    currentGameState = "Title State";
                    break;
                case GameState.LOGIN:
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    currentGameState = "Login State";
                    break;
                case GameState.PREGAME:
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    currentGameState = "Pregame State";
                    break;
                case GameState.LOADING:
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    currentGameState = "Loading State";
                    break;
                case GameState.RUNNING:
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    currentGameState = "Running State";
                    break;
                case GameState.DEAD:
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    currentGameState = "Offline Running State";
                    break;
                case GameState.PAUSED:
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    currentGameState = "Paused State";
                    break;
                case GameState.RESTART:
                    currentGameState = "Restart State";
                    break;
                // dispatch messages
                // transition between scenes
                // put here code what you want to do at the end of a scene load
            }

            OnGameStateChanged.Invoke(CurrentGameState, previousGameState);
        }
        public void OnLoadOperationComplete(AsyncOperation ao) //Adds the loaded scenes to the "loadOperation" List.
        {
            if (loadOperation.Contains(ao)) loadOperation.Remove(ao);
            Debug.Log("Load Scene Complete" + currentSceneName);
        }
        public void UnLoadOperationComplete(AsyncOperation ao)
        {
            Debug.Log("Unload Scene Complete");
        }
        private void InstantiateSystemPrefabs()
        {
            GameObject prefabInstance;
            for (var i = 0; i < SystemPrefabs.Length; ++i)
            {
                prefabInstance = Instantiate(SystemPrefabs[i]); //Create a GameObject of the objects in the array
                _instancedSystemPrefabs.Add(prefabInstance); // Adds the GameObject to the "instancedSystemPrefabs List"
            }
        }
        public void LoadScene(string sceneName)
        {
            var ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            if (ao == null)
            {
                Debug.LogError("[GameManager] Unable to load Scene " + sceneName);
                return;
            }

            ao.completed += OnLoadOperationComplete;
            loadOperation.Add(ao);

            currentSceneName = sceneName;
        }
        public void UnloadScene(string sceneName)
        {
            var ao = SceneManager.UnloadSceneAsync(sceneName);

            if (ao == null)
            {
                Debug.LogError("[GameManager] Unable to unload Scene " + currentSceneName);
                return;
            }

            ao.completed += UnLoadOperationComplete;
        }
    }
}