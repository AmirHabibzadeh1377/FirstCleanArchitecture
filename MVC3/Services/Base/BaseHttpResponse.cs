﻿using CleanArchitecture.MVC3.Contract;
using CleanArchitecture.MVC3.Model;

using CleanArichitecture.Application.Exeptions;

namespace CleanArchitecture.MVC3.Services.Base
{
    public class BaseHttpResponse
    {
        #region Fields

        public ILocalStorageServiceContract _localStorageService;
        public IClient _client;

        #endregion

        #region Ctor

        public BaseHttpResponse(ILocalStorageServiceContract localStorageService, IClient client)
        {
            _localStorageService = localStorageService;
            _client = client;
        }

        #endregion

        protected GenericResponseApi<Guid> ConvretApiExceptions<Guid>(ApiException exception)
        {
            if (exception.StatusCode == 400)
            {
                return new GenericResponseApi<Guid> { Message = exception.Message, ValidationError = exception.Response, Success = false };
            }
            if (exception.StatusCode == 404)
            {
                return new GenericResponseApi<Guid> { Message = "Not Found", Success = false };
            }
            else
            {
                return new GenericResponseApi<Guid> { Message = "Somethings Went Wrong", Success = false };
            }
        }

        protected void AddBearerToken()
        {
            if (_localStorageService.ExistsLocalStorage("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _localStorageService.GetLocalStorage<string>("token"));
            }
        }
    }
}
