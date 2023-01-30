using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Enums;

namespace WCLWebAPI.Server.ViewModels
{
    public class EmployeeVM
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Imgage { get; set; }

        public string Address { get; set; }

        public Marital Marital { get; set; }

        public DateTime DOB { get; set; }

        public string CCCD { get; set; }

        public Gender Gender { get; set; }

        public int DepartmentID { get; set; }

        public decimal Salary { get; set; }
    }
}
