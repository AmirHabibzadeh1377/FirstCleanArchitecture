using AutoMapper;
using CleanArchitecture.MVC3.Contract;
using CleanArchitecture.MVC3.Model;
using CleanArchitecture.MVC3.Model.ViewModels.Weblog;
using CleanArchitecture.MVC3.Services.Base;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Exeptions;

namespace CleanArchitecture.MVC3.Services.Weblog
{
    public class WeblogServiceRespository : BaseHttpResponse, IWeblogServiceContract
    {
        #region Fields 

        private readonly IClient _client;
        private readonly ILocalStorageServiceContract _localStorageServiceContract;
        private readonly IMapper _mapper;
    
        #endregion

        #region Ctor

        public WeblogServiceRespository(IMapper mapper, IClient client, ILocalStorageServiceContract localStorageServiceContract) : base(localStorageServiceContract, client)
        {
            _client = client;
            _localStorageServiceContract = localStorageServiceContract;
            _mapper = mapper;
        }

        #endregion
      
        public async Task<GenericResponseApi<int>> CreateWeblog(CreateWeblogVM model)
        {
            try
            {
                var response = new GenericResponseApi<int>();
                var createWeblogDTo = _mapper.Map<CreateWeblogDTOs>(model);
                var apiResponse = await _client.CreateWeblogDTO(createWeblogDTo);
                if (!apiResponse.Success)
                {
                    response.Success = false;
                    foreach (var err in apiResponse.Errors)
                    {
                        response.ValidationError = err + Environment.NewLine;
                    }
                }
                else
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvretApiExceptions<int>(ex);
            }
        }

        public async Task<GenericResponseApi<int>> DeleteWeblog(int weblogId)
        {
            var response = new GenericResponseApi<int>();
            try
            {
                var apiResponse = await _client.DeleteWeblog(weblogId);
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Message = "deleted success full";
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.Success = false;
                    foreach (var err in apiResponse.Errors)
                    {
                        response.ValidationError = err + Environment.NewLine;
                    }
                }
            }
            catch (ApiException ex)
            {
                return ConvretApiExceptions<int>(ex);
            }

            return response;
        }

        public async Task<List<WeblogListVM>> GetAllWeblogList()
        {
            var weblogListDtos = await _client.GetWeblogDTO();
            return _mapper.Map<List<WeblogListVM>>(weblogListDtos);
        }

        public async Task<WeblogListVM> GetWeblogById(int weblogId)
        {
            var weblogDTo = await _client.GetWeblogById(weblogId);
            return _mapper.Map<WeblogListVM>(weblogDTo);
        }

        public async Task<GenericResponseApi<int>> UpdateWeblog(UpdateWeblogVM model)
        {
            var response = new GenericResponseApi<int>();
            try
            {
                var updateWeblogDto = _mapper.Map<UpdateWeblogDTOs>(model);
                var apiResponse = await _client.UpdateWeblog(updateWeblogDto);
                if (apiResponse.Success)
                {
                    response.Success = true;
                    response.Data = apiResponse.Id;
                    response.Message = "update success full";
                }
                else
                {
                    response.Success = false;
                    foreach(var err in apiResponse.Errors)
                    {
                        response.ValidationError += err + Environment.NewLine;
                    }
                }
            }
            catch (ApiException ex)
            {
                return ConvretApiExceptions<int>(ex);
            }

            return response;
        }
    }
}