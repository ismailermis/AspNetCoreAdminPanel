using Models.DTOs.Email;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
