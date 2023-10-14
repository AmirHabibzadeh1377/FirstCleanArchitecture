using CleanArichitecture.Application.DTOs.Weblog;
using Newtonsoft.Json;
using System.Text;

namespace CleanArchitecture.MVC.Services.Base
{
    public partial class Client : IClient
    {
        #region Fields

        private string _baseUrl = "";
        private readonly HttpClient _httpClient;
        private readonly Lazy<Newtonsoft.Json.JsonSerializerSettings> _jsonSetting;

        #endregion

        #region Properties

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }
        
        protected JsonSerializerSettings JsonSerializerSetting { get { return _jsonSetting.Value; } }

        #endregion

        #region Ctor

        public Client(string baseUrl, HttpClient httpClient)
        {
            _baseUrl = baseUrl;
            _httpClient = httpClient;
            _jsonSetting =new  Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateJsonSerializerSetting);
        }

        #endregion

        #region Utility

        private JsonSerializerSettings CreateJsonSerializerSetting()
        {
            var setting = new JsonSerializerSettings();
            UpdateJsonSerialazerSetting(setting);
            return setting;
        }

        partial void UpdateJsonSerialazerSetting(JsonSerializerSettings settings);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        #endregion

        public Task CreateWeblogDTO()
        {
            throw new NotImplementedException();
        }

        public Task DeleteWeblog(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WeblogListDTOs> GetWeblogById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<WeblogListDTOs>> GetWeblogDTOd()
        {
            var urlBilder = new StringBuilder();
            urlBilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : string.Empty);
            var client = _httpClient;
        }

        public Task UpdateWeblog(UpdateWeblogDTOs model)
        {
            throw new NotImplementedException();
        }
    }
}
