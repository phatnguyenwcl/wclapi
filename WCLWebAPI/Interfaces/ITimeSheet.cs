using WCLWebAPI.Entities;
using WCLWebAPI.ViewModels;

namespace WCLWebAPI.Interfaces
{
    public interface ITimeSheet
    {
        IEnumerable<TimeSheetVM> GetTimeSheets();
        TimeSheetVM GetTimeSheetDetails(int id);
        void AddTimeSheet(TimeSheetVM employee);
        void UpdateTimeSheet(TimeSheetVM employee);
        TimeSheetVM DeleteTimeSheet(int id);
        bool CheckTimeSheet(int id);
    }
}
