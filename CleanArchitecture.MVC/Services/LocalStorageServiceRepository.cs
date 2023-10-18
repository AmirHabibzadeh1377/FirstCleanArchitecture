using CleanArchitecture.MVC.Contract;
using Hanssens.Net;
namespace CleanArchitecture.MVC.Services
{
    public class LocalStorageServiceRepository : ILocalStorageServiceContract
    {
        #region Fields

        private readonly LocalStorage _storage;

        #endregion

        #region Ctor

        public LocalStorageServiceRepository()
        {
            var localStorageConfig = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "CleanArchitecture_LocalStorage"
            };

            _storage = new LocalStorage(localStorageConfig);
        }

        #endregion

        public void ClearLocalStorage(List<string> keys)
        {
            foreach(var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool ExistsLocalStorage(string key)
        {
           return _storage.Exists(key);
        }

        public T GetLocalStorage<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetLocalStorage<T>(string key, T value)
        {
            _storage.Store(key, value);
            _storage.Persist();
        }
    }
}