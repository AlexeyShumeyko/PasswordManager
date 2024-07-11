using Microsoft.EntityFrameworkCore;
using PasswordManager.Application.Exceptions;
using PasswordManager.Application.Interfaces;
using PasswordManager.Core.Models;
using PasswordManager.Core.Request;
using PasswordManager.DAL;

namespace PasswordManager.Application.Services
{
    public class RecordSrvice : IRecordSrvice
    {
        private readonly PasswordManagerDbContext _context;

        public RecordSrvice(PasswordManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Record>> GetAllRecordsAsync()
        {
            return await _context.Records.OrderByDescending(p => p.DateCreated).ToListAsync();
        }

        public async Task<Record> AddRecordAsync(CreateRecordRequest request)
        {
            if (request.RecordType == Core.Enum.RecordType.Email 
                && !IsValidEmail(request.Name))
            {
                throw new EmailFormatException("Неверный формат электронной почты.");
            }

            var existingRecords = await _context.Records
                .FirstOrDefaultAsync(r => r.Name == request.Name);

            if (existingRecords != null) 
            {
                throw new RecordExistsException("Запись с таким названием уже существует.");
            }

            var record = new Record()
            {
                Name = request.Name,
                Password = request.Password,
                DateCreated = DateTime.UtcNow,
                RecordType = request.RecordType
            };

            _context.Records.Add(record);
            await _context.SaveChangesAsync();

            return record;
        }

        public async Task<IEnumerable<Record>> SearchRecordsAsync(string searchQuery)
        {
            var searchingResult = await _context.Records
                .Where(r => r.Name.Contains(searchQuery))
                .OrderByDescending(r => r.DateCreated)
                .ToListAsync();

            return searchingResult;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
