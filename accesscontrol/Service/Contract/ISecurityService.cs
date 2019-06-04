using System.Threading.Tasks;
using accesscontrol.Model;

namespace accesscontrol.Service
{
    public interface ISecurityService
    {
        Task<SecurityModel> LoginAsync(LoginModel model);
        Task ResetPasswordAsync(ResetPasswordModel model);
        Task ChangePasswordAsync(ChangePasswordModel model);
    }
}