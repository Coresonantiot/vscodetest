using System.Threading.Tasks;

namespace HexTest.Application.Interfaces;

public interface IEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string body);
}
