using UnityEngine;

namespace KuroKitten.UniKuroKit.Core
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static bool IsInitialize => !_disposed;

        private static T _instance = null;

        private static bool _disposed = false;

        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = FindFirstObjectByType<T>();
                if (_instance != null)
                {
                    _disposed = false;
                    return _instance;
                }

                var go = new GameObject($"[{typeof(T).Name} Instance]");
                _instance = go.AddComponent<T>();
                _disposed = false;
                return _instance;
            }
        }

        [Header("Singleton")]
        [SerializeField] protected bool IsPersistent = true;

        protected virtual void Awake()
        {
            if (IsInitialize && _instance != this)
            {
                Destroy(this);
                return;
            }

            _instance = this as T;

            if (IsPersistent)
                DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            if (_disposed) return;

            _disposed = true;
            _instance = null;
        }
    }
}
