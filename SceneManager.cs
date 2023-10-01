using UnityEngine;


{
    public class SceneManager : Singelton<SceneManager>
    {
        public void LoadTitleScene()
        {
            GameManager.Instance.LoadScene("TitleScene"); // Start with title screen.
            GameManager.Instance.UpdateGameState(GameManager.GameState.TITLE);
        }
        public void LoadLoginScene()
        {
            try
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.PREGAME);
                GameManager.Instance.LoadScene("LoginScene");
                Debug.LogWarning("Loading the LOGIN SCENE");
            }
            catch
            {
                Debug.LogError("Can't load LOGIN Scene");
            }
            finally
            {
                if (GameManager.Instance.CurrentGameState == GameManager.GameState.PREGAME)
                {
                    GameManager.Instance.UnloadScene("TitleScene");
                    Debug.LogWarning("UNLOADING TITLE SCENE");
                    GameManager.Instance.UpdateGameState(GameManager.GameState.LOGIN);
                }
            } 
        }
        public void LoadOxygenDistrict()
        {
            GameManager.Instance.LoadScene("OxygenDistrict");
            GameManager.Instance.UpdateGameState(GameManager.GameState.RUNNING);
        }

        public void LoadGearsDistrict()
        {
            GameManager.Instance.LoadScene("GearsDistrict");
            GameManager.Instance.UpdateGameState(GameManager.GameState.RUNNING);
        }
        public void QuitGame()
        {
            UnityEngine.Application.Quit();
        }
    }
}