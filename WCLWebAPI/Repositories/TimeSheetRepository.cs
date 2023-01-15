using AutoMapper;
using WCLWebAPI.Server.EF;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Repositories
{
    public class TimeSheetRepository : ITimeSheet
    {
        private WCLManagementDbContext _context;
        private readonly IMapper _mapper;
        public TimeSheetRepository(WCLManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TimeSheetVM> GetTimeSheets()
        {
            var result = _context.TimeSheets.ToList();

            if (!result.Any())
            {
                return new List<TimeSheetVM>();
            }

            var mapRes = _mapper.Map<List<TimeSheet>, List<TimeSheetVM>>(result);

            return mapRes;
        }

        public TimeSheetVM GetTimeSheetDetails(int id)
        {
            if (id == null) return new TimeSheetVM();

            var query = _context.TimeSheets.FirstOrDefault(x => x.ID == id);

            var mapRes = _mapper.Map<TimeSheet, TimeSheetVM>(query);

            return mapRes;
        }

        public TimeSheetVM AddTimeSheet(TimeSheetVM timeSheet)
        {
            var mapRes = _mapper.Map<TimeSheetVM, TimeSheet>(timeSheet);

            _context.TimeSheets.Add(mapRes);

            return timeSheet;
        }

        public TimeSheetVM UpdateTimeSheet(TimeSheetVM timeSheet)
        {
            var mapRes = _mapper.Map<TimeSheetVM, TimeSheet>(timeSheet);

            _context.TimeSheets.Update(mapRes);

            return timeSheet;
        }

        public bool DeleteTimeSheet(int id)
        {
            var query = _context.TimeSheets.FirstOrDefault(x => x.ID == id);

            if (query is null) return false;

            _context.TimeSheets.Remove(query);

            return true;
        }

        public bool CheckTimeSheet(int id)
        {
            return _context.TimeSheets.Any(x => x.ID == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
