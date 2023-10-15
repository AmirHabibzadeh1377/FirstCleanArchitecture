using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Exeptions;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
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
            _jsonSetting = new Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateJsonSerializerSetting);
        }

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

        public async Task<ICollection<WeblogListDTOs>> GetWeblogDTO()
        {
            var urlBilder = new StringBuilder();
            urlBilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : string.Empty);
            var client = _httpClient;
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));
            PrepareRequest(client, request, urlBilder);
            var url = urlBilder.ToString();
            request.RequestUri = new Uri(url);
            PrepareRequest(client, request, url);
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);
            var disposeResponse = true;
            try
            {
                var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                if (response.Content != null && response.Headers != null)
                {
                    foreach (var header in response.Content.Headers)
                    {
                        headers[header.Key] = header.Value;
                    }
                }

                ProcessResponse(client, response);
                var statusCode = (int)response.StatusCode;
                if (statusCode == 200)
                {
                    var objectResponse = await ReadObjectReponseAsync<ICollection<WeblogListDTOs>>(response, headers, CancellationToken.None).ConfigureAwait(false);
                    if(objectResponse.Object == null)
                    {
                        throw new ApiException("Response was null which was not expected.", statusCode, objectResponse.Text, headers, null);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    throw new ApiException("The HTTP status code of the response was not expected (" + statusCode + ").", statusCode, responseData, headers, null);
                }

            }

            finally
            {
                if (disposeResponse)
                {
                    client.Dispose();
                }
            }
        }

        public async Task UpdateWeblog(UpdateWeblogDTOs model)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.Trim('/') : "").Append("this place for api adderess in api layer");
            var client = _httpClient;
            var disposeClient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var json = JsonConvert.SerializeObject(model, _jsonSetting.Value);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    request.Content = content;
                    request.Method = HttpMethod.Post;
                    PrepareRequest(client, request, urlBuilder);
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url);
                    PrepareRequest(client, request, url);
                    var response = await client.SendAsync(request,HttpCompletionOption.ResponseContentRead,CancellationToken.None).ConfigureAwait(false);
                    disposeClient = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Headers != null)
                        {
                            foreach (var header in response.Headers)
                                headers[header.Key] = header.Value;
                        }

                        ProcessResponse(client, response);

                        var statusCode = (int)response.StatusCode;
                        if (statusCode == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + statusCode + ").", statusCode, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeClient)
                        {
                            client.Dispose();
                        }
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        #region Utility

        private JsonSerializerSettings CreateJsonSerializerSetting()
        {
            var setting = new JsonSerializerSettings();
            UpdateJsonSerialazerSetting(setting);
            return setting;
        }

        partial void UpdateJsonSerialazerSetting(JsonSerializerSettings settings);
        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url);
        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder);
        partial void ProcessResponse(HttpClient client, HttpResponseMessage response);

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        protected bool ReadResponseAsString { get; set; }
        protected virtual async Task<ObjectResponseResult<T>> ReadObjectReponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
        {
            if (response.Headers == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }
            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typeBody = JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSetting);
                    return new ObjectResponseResult<T>(typeBody, responseText);
                }
                catch (JsonException ex)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, ex);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var streamReader = new StreamReader(responseStream))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var serializer = JsonSerializer.Create(JsonSerializerSetting);
                        var typeBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typeBody, string.Empty);
                    }

                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }
        private string ConvertToString(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool)
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }

        #endregion
    }
}
