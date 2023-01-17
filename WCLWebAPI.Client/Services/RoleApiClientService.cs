using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using WCLWebAPI.Client.IServicesInterface;
using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.ViewModels.System.Roles;

namespace WCLWebAPI.Client.Services
{
    public class RoleApiClientService : IRoleApiClientServiceInterface
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleApiClientService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<List<RoleVM>>> GetAllAsync()
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/roles");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                List<RoleVM> myDeserializedObjList = (List<RoleVM>)JsonConvert.DeserializeObject(body, typeof(List<RoleVM>));
                return new ApiSuccessResult<List<RoleVM>>(myDeserializedObjList);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<List<RoleVM>>>(body);
        }
    }
}
