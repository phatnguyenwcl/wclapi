using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WCLWebAPI.Server.Enums;
using WCLWebAPI.Server.Interfaces;

namespace WCLWebAPI.Server.Entities
{
    [Table("Employees")]
    public class Employee : IDateTracking
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public string Imgage { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public Marital Marital { get; set; }

        public DateTime DOB { get; set; }

        [StringLength(15)]
        public string CCCD { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        public decimal Salary { get; set; }

        public Guid UserId { get; set; }

        public bool IsManager { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
