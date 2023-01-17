using WCLWebAPI.Server.Common;

namespace WCLWebAPI.Server.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
