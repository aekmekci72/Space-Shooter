using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _isQuitting = false;

    public static T Instance
    {
        get
        {
            if (_isQuitting)
                return null;

            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();

                    if (Application.isPlaying) 
                    {
                        DontDestroyOnLoad(singletonObject);
                    }
                }
            }
            return _instance;
        }
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }
}
