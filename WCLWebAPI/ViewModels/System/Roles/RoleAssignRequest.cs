using WCLWebAPI.Server.Common;

namespace WCLWebAPI.Server.ViewModels.System.Roles
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
