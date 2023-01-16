using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface ILanguageApiClientService
    {
        Task<ApiResult<List<LanguageVM>>> GetAll();
    }
}
