using WCLWebAPI.Server.Enums;

namespace WCLWebAPI.Server.ViewModels
{
    public class EmployeeWorkingResponse
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string CCCD { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public bool IsManager { get; set; }

        public int DepartmentID { get; set; }

        public DateTime StartWorking { get; set; }

        public DateTime EndWorking { get; set; }

        public DateTime BreakStart { get; set; }

        public DateTime BreakEnd { get; set; }
        
        public TimeSpan TotalTime { get; set; }

        public double TotalWorkingHour { get; set; }
        public string TotalWorkingHours { get; set; }
    }
}
