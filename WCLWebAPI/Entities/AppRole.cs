using Microsoft.AspNetCore.Identity;

namespace WCLWebAPI.Server.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
