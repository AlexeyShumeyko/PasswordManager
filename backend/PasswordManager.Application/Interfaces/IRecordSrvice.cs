using PasswordManager.Core.Models;
using PasswordManager.Core.Request;

namespace PasswordManager.Application.Interfaces
{
    public interface IRecordSrvice
    {
        Task<List<Record>> GetAllRecordsAsync();
        Task<Record> AddRecordAsync(CreateRecordRequest request);
        Task<IEnumerable<Record>> SearchRecordsAsync(string searchQuery);
    }
}
