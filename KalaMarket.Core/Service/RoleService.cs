using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.Role;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class RoleService : IRoleService
    {
        private KalaMarketContext _context;
        public RoleService(KalaMarketContext context)
        {
            _context = context;
        }

        
        public List<Role> GetAllRoles()
        {
            return _context.roles.Where(c => !c.IsDelete).OrderByDescending(c => c.RoleId).ToList();
        }

        public bool AddUserToRole(int userId, List<int> roleIds)
        {
            foreach (var item in roleIds)
            {
                UserRole UR = new UserRole();
                UR.RoleId = item;
                UR.UserId = userId;
                _context.userRoles.Add(UR);
            }
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public List<string> GetUserRoles(string email)
        {
            int userId = _context.users.Where(c => c.Email == email).FirstOrDefault().UserId;
            return _context.userRoles.Include(c => c.role).Where(c => c.UserId == userId)
                .Select(c => c.role.RoleTitle).ToList();
        }

        public void RemoveUserFromAllRoles(int userId)
        {
            List<UserRole> userroles = _context.userRoles.Where(c => c.UserId == userId).ToList();
            _context.userRoles.RemoveRange(userroles);
            _context.SaveChanges();
        }
        public int GetCountOfUsersInRole(int roleId)
        {
            return _context.roles.Count(c => c.RoleId == roleId);
        }
        public bool IsRoleExists(string roleTitle)
        {
            return _context.roles.Any(c => c.RoleTitle == roleTitle && !c.IsDelete);
        }
        public bool AddRole(Role role)
        {
            role.IsDelete = false;
            _context.roles.Add(role);
            return Convert.ToBoolean(_context.SaveChanges());
        }
        public Role GetRoleById(int roleId)
        {
            return _context.roles.Where(c => c.RoleId == roleId && !c.IsDelete).FirstOrDefault();
        }
        public string EditRole(Role role)
        {
            Role rl = _context.roles.Find(role.RoleId);
            rl.RoleTitle = role.RoleTitle;
            _context.Entry(rl).State = EntityState.Modified;
            if (Convert.ToBoolean(_context.SaveChanges()) == true)
                return "ثبت با موفقیت انجام شد";
            else
                return "خطایی رخ داد لطفا مجدد تلاش کنید";
        }
        public bool DeleteRole(int roleId)
        {
            Role role = _context.roles.Find(roleId);
            if (role.IsDelete == true)
                return false;

            role.IsDelete = true;
            _context.Entry(role).State = EntityState.Modified;
            return Convert.ToBoolean(_context.SaveChanges());
        }
        public bool Authorize(string roleTitle, string email)
        {
            int roleId = _context.roles.Where(c => c.RoleTitle == roleTitle).Select(c => c.RoleId).FirstOrDefault();
            int userId = _context.users.Where(c => c.Email == email).Select(c => c.UserId).FirstOrDefault();
            return _context.userRoles.Any(c => c.RoleId == roleId && c.UserId == userId);
        }

        public bool GetAdminRoleForWeb(string email)
        {
            int roleId = _context.roles.Where(c => c.RoleTitle == "Admin").Select(c => c.RoleId).FirstOrDefault();
            int userId = _context.users.Where(c => c.Email == email).Select(c => c.UserId).FirstOrDefault();
            return _context.userRoles.Any(c => c.RoleId == roleId && c.UserId == userId);
        }
        public bool GetDefaultRoleForWeb(string email)
        {
            int roleId = _context.roles.Where(c => c.RoleTitle == "Default").Select(c => c.RoleId).FirstOrDefault();
            int userId = _context.users.Where(c => c.Email == email).Select(c => c.UserId).FirstOrDefault();
            return _context.userRoles.Any(c => c.RoleId == roleId && c.UserId == userId);
        }
    }
}
   
