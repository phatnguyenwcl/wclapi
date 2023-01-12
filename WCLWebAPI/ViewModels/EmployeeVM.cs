using WCLWebAPI.Enums;

namespace WCLWebAPI.ViewModels
{
    public class EmployeeVM
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Imgage { get; set; }

        public string Password { get; set; }

        public string EEO { get; set; }

        public string Address { get; set; }

        public Marital Marital { get; set; }

        public string Location { get; set; }

        public string Position { get; set; }


        public string Contract { get; set; }

        public DateTime DOB { get; set; }

        public string CCCD { get; set; }

        public Gender Gender { get; set; }
    }
}
