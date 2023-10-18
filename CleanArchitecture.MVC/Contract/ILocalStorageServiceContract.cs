namespace CleanArchitecture.MVC.Contract
{
    public interface ILocalStorageServiceContract
    {
        void SetLocalStorage<T>(string key, T value);
        T GetLocalStorage<T>(string key);
       bool ExistsLocalStorage(string key);
        void ClearLocalStorage(List<string> keys);
    }
}