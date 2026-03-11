using System;

namespace KuroKitten.UniKuroKit.Core
{
    public abstract class LegacySingleton<T> : IDisposable where T : LegacySingleton<T>, new()
    {
        protected LegacySingleton() { }

        private static readonly object _lock = new();

        public static bool IsInitialize => !_disposed;

        private static T _instance = null;
        private static bool _disposed = false;

        public static T Instance
        {
            get
            {
                if (IsInitialize) return _instance;

                lock (_lock)
                {
                    _instance = new();
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

            lock (_lock)
            {
                if (disposing)
                {
                    // Dispose managed resources here if needed
                }

                // Dispose unmanaged resources here if needed

                _disposed = true;
                _instance = null;
            }
        }

        ~LegacySingleton()
        {
            Dispose(false);
        }
    }
}
