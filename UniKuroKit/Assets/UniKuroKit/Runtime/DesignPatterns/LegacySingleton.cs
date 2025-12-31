using System;

namespace Kuro.UniKit.DesignPatterns
{
    public abstract class LegacySingleton<T> : IDisposable where T : LegacySingleton<T>, new()
    {
        protected LegacySingleton() { }

        private static readonly object _lock = new();

        public static bool IsInitialize => _instance != null;

        private static T _instance = default;
        private bool _disposed = false;

        public static T Instance
        {
            get
            {
                if (IsInitialize) return _instance;

                lock (_lock)
                {
                    _instance = Activator.CreateInstance<T>();
                    return _instance;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // Dispose managed resources here if needed
            }

            // Dispose unmanaged resources here if needed

            _disposed = true;

            lock (_lock)
            {
                _instance = null;
            }
        }

        ~LegacySingleton()
        {
            Dispose(false);
        }
    }
}
