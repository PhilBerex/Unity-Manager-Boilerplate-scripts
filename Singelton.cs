using UnityEngine;


{
    public class Singelton<T> : MonoBehaviour where T : Singelton<T>
    {
        public static T Instance { get; private set; }

        public static bool IsInitialized => Instance != null;

        protected virtual void Awake()
        {
            if (Instance != null)
                Debug.LogError("[Singleton] Trying to instantiate a second instance of a singleton class.");
            else
                Instance = (T)this;
        }

        protected virtual void OnDestroy()
        {
            if (Instance == this) Instance = null;
        }
    }
}