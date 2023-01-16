using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface ITimeSheetService
    {
        IEnumerable<TimeSheetVM> GetTimeSheets();
        TimeSheetVM GetTimeSheetDetails(int id);
        TimeSheetVM AddTimeSheet(TimeSheetVM employee);
        TimeSheetVM UpdateTimeSheet(TimeSheetVM employee);
        bool DeleteTimeSheet(int id);
        bool CheckTimeSheet(int id);
        void Save();
    }
}
