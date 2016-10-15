using System.Threading.Tasks;

namespace RandalApps.IdentityServer.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
