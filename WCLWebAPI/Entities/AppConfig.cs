using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCLWebAPI.Server.Entities
{
    [Table("AppConfigs")]
    public class AppConfig
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
