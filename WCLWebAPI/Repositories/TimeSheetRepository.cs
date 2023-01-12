using AutoMapper;
using WCLWebAPI.EF;
using WCLWebAPI.Entities;
using WCLWebAPI.Interfaces;
using WCLWebAPI.ViewModels;

namespace WCLWebAPI.Repositories
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

        public void AddTimeSheet(TimeSheetVM timeSheet)
        {
            var mapRes = _mapper.Map<TimeSheetVM, TimeSheet>(timeSheet);

            _context.TimeSheets.Add(mapRes);

            _context.SaveChanges();
        }

        public void UpdateTimeSheet(TimeSheetVM timeSheet)
        {
            var mapRes = _mapper.Map<TimeSheetVM, TimeSheet>(timeSheet);

            _context.SaveChanges();
        }

        public TimeSheetVM DeleteTimeSheet(int id)
        {
            if (id == 0) return new TimeSheetVM();

            var query = _context.TimeSheets.FirstOrDefault(x => x.ID == id);

            if (query == null) return new TimeSheetVM();

            _context.TimeSheets.Remove(query);

            _context.SaveChanges();

            var mapRes = _mapper.Map<TimeSheet, TimeSheetVM>(query);

            return mapRes;
        }

        public bool CheckTimeSheet(int id)
        {
            return _context.TimeSheets.Any(x => x.ID == id);
        }
    }
}
