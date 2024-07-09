using PasswordManager.Core.Enum;

namespace PasswordManager.Core.Models
{
    public class Record
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required DateTime DateCreated { get; set; }
        public required RecordType RecordType { get; set; }
    }
}
