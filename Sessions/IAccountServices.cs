using radiobutton.Models;
using System.Security.Principal;
namespace radiobutton.Sessions
{
    public interface IAccountServices
    {
        public Account Login(string username, string password);
    }
}
