using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WCLWebAPI.Enums;
using WCLWebAPI.Interfaces;

namespace WCLWebAPI.Entities
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

        public string Imgage { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public string EEO { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public Marital Marital { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [StringLength(50)]
        public string Contract { get; set; }

        public DateTime DOB { get; set; }

        [StringLength(15)]
        public string CCCD { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
