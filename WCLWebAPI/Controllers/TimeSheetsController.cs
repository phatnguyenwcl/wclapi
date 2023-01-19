using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : ControllerBase
    {
        private readonly ITimeSheetService _timeSheetService;

        public TimeSheetsController(ITimeSheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTimeSheets()
        {
            var result = await _timeSheetService.GetTimeSheetsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeSheets([FromBody] TimeSheetVM timeSheetVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _timeSheetService.AddTimeSheetAsync(timeSheetVM);

            return Ok(res);
        }

        [HttpPut("{id}/updateTimeSheets")]
        public async Task<IActionResult> UpdateTimeSheets(int id, [FromBody] TimeSheetVM timeSheetVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _timeSheetService.UpdateTimeSheetAsync(id, timeSheetVM);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSheets(int id)
        {
            var result = await _timeSheetService.DeleteTimeSheetAsync(id);

            if (!result.IsSuccessed) return BadRequest();

            return Ok(result);
        }

    }
}
