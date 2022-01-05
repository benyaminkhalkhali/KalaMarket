using KalaMarket.DataLayer.Entities.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface IRoleService
    {
        
        List<Role> GetAllRoles();
        bool AddUserToRole(int userId, List<int> roleIds);
        List<string> GetUserRoles(string email);
        void RemoveUserFromAllRoles(int userId);
        int GetCountOfUsersInRole(int roleId);
        bool IsRoleExists(string roleTitle);
        bool AddRole(Role role);
        Role GetRoleById(int roleId);
        string EditRole(Role role);
        bool DeleteRole(int roleId);
        bool Authorize(string roleTitle, string email);
        bool GetAdminRoleForWeb(string email);
        bool GetDefaultRoleForWeb(string email);
    }
}
