using WCLWebAPI.Server.Entities;

namespace WCLWebAPI.Server.ViewModels
{
    public class TimeSheetVM
    {
        
        public TimeSpan LunchTime
        {
            get
            {
                return BreakEnd.Subtract(BreakStart);
            }
        }

        public TimeSpan ShiftEndTime
        {
            get
            {
                return EndWorking.Subtract(StartWorking);
            }
        }

        public int EmployeeID { get; set; }

        public DateTime StartWorking { get; set; }

        public DateTime EndWorking { get; set; }

        public DateTime BreakStart { get; set; }

        public DateTime BreakEnd { get; set; }

    }
}
