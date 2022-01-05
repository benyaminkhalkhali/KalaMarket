using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface IUserService
    {
        int AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool IsEmailExists(string email);
        public bool IsMobileExists(string mobile);
        User FindUser(int userId, string code);
        User FindUserByEmail(string email);
        User LoginUser(string email, string password);
        InformationAccountVM InformationAccount(int userId);
        User FindEditUserBuId(int userId);
        EditUserVM FindUserById(int userId);
        List<ShowFavouriteVM> ShowFavouriteUser(int userId);
        List<ShowOrderForUserVM> ShowOrderForUsers(int userId);
        List<ShowDetailOrderForUserVM> showDetailOrderForUsers(int userId, int cartId);

        #region AdminPanel

        EditUserVM GetUserDataForEdit(string email);
        bool SaveUserEdit(string email, EditUserVM model);
        ShowUsersInAdminVM ShowUserInAdmin(int pageId = 1, int take = 10, 
            string filterByName = "", string filterByMobile = "", string filterByEmail = "");

        int AddUserByAdmin(AddUserByAdminVM model);
        EditUserByAdminVM GetUserDataForEditInAdminPanel(int userId);
        bool EditUserByAdmin(EditUserByAdminVM model);
        User GetUserById(int id);
        bool DeleteUser(int userId);
        int CountofDeletedUsers();
        int CountofDeactiveUsers();
        ShowUsersInAdminVM DeletedUsers(int pageId = 1, int take = 10,
            string filterByName = "", string filterByMobile = "", string filterByEmail = "");
        ShowUsersInAdminVM DeactiveUsers(int pageId = 1, int take = 10,
            string filterByName = "", string filterByMobile = "", string filterByEmail = "");
        #endregion

        #region Order

        int GetUserIdByEmail(string email);
        bool IsExistPostalCodeForUser(int userId, int postalCode);
        bool AddNewAddressForUser(UserAddress address);
        #endregion
    }
}
