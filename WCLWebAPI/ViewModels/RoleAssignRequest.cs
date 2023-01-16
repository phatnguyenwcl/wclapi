using WCLWebAPI.Server.Common;

namespace WCLWebAPI.Server.ViewModels
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
