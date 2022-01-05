using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface IAddressService
    {
        ShowAddressForUserVM FindAddressForUser(int userId);
        int AddUserAddress(UserAddress userAddress);
        bool UpdateAddress(UserAddress userAddress);
        bool DeleteAddress(UserAddress userAddress);
        
        #region AddressForOrder


        List<UserAddress> GetUserAddress(int userId);

        #endregion
    }
}
