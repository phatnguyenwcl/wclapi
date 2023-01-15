using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WCLWebAPI.Server.Interfaces;

namespace WCLWebAPI.Server.Entities
{
    [Table("Departments")]
    public class Department : IDateTracking
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { set; get; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
