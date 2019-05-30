using System;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Model;

namespace accesscontrol.Service
{
    public interface IAuthService
    {
        SecurityModel GenerateToken(UserGroup entity, DateTime expirate);

        string GetEmail();

        int GetUserId();
    }
}