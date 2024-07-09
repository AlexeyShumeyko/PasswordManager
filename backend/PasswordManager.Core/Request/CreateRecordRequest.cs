using PasswordManager.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Core.Request
{
    public record CreateRecordRequest(

        [Required]
        [StringLength(100, MinimumLength = 1)]
        string Name,

        [Required]
        [MinLength(8)]
        string Password,

        [Required] 
        RecordType RecordType);
}
