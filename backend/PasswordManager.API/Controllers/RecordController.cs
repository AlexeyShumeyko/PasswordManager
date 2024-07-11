using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Exceptions;
using PasswordManager.Application.Interfaces;
using PasswordManager.Core.Request;

namespace PasswordManager.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordSrvice _recordSrvice;

        public RecordController(IRecordSrvice recordSrvice)
        {
            _recordSrvice = recordSrvice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecords()
        {
            try
            {
                var records = await _recordSrvice.GetAllRecordsAsync();

                return Ok(records);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord([FromBody] CreateRecordRequest request)
        {
            try
            {
                var addedRecord = await _recordSrvice.AddRecordAsync(request);

                return Ok(addedRecord);
            }
            catch (EmailFormatException ex)
            {
                return StatusCode(502, ex.Message);
            }
            catch (RecordExistsException ex)
            {
                return StatusCode(501, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchRecord(string searchQuery)
        {
            try
            {
                var records = await _recordSrvice.SearchRecordsAsync(searchQuery);
                return Ok(records);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
