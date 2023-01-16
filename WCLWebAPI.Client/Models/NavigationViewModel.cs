using Microsoft.AspNetCore.Mvc.Rendering;

namespace WCLWebAPI.Client.Models
{
    public class NavigationViewModel
    {
        public List<SelectListItem> Languages { get; set; }

        public string CurrentLanguageId { get; set; }

        public string ReturnUrl { set; get; }
    }
}
