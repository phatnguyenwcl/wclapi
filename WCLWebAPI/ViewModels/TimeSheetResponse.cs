namespace WCLWebAPI.Server.ViewModels
{
    public class TimeSheetResponse
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

        public TimeSpan Total
        {
            get
            {
                return ShiftEndTime.Subtract(LunchTime);
            }
        }

        public int EmployeeID { get; set; }

        public DateTime StartWorking { get; set; }

        public DateTime EndWorking { get; set; }

        public DateTime BreakStart { get; set; }

        public DateTime BreakEnd { get; set; }
    }
}
