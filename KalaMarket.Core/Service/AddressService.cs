using KalaMarket.Core.Service.IService;
using KalaMarket.Core.ViewModel;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class AddressService : IAddressService
    {
        KalaMarketContext _context;
        public AddressService(KalaMarketContext context)
        {
            _context = context;
        }
       
        public int AddUserAddress(UserAddress userAddress)
        {
            try
            {
                _context.Add(userAddress);
                _context.SaveChanges();
                return userAddress.AddressId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteAddress(UserAddress userAddress)
        {
            try
            {
                userAddress.IsDelete = true;
                _context.Update(userAddress);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ShowAddressForUserVM FindAddressForUser(int userId)
        {
            var useraddress = (from ua in _context.userAddresses
                              where (!ua.IsDelete && ua.UserId == userId)
                               select new ShowAddressForUserVM
                               {
                                    UserId = ua.UserId,
                                    AddressId = ua.AddressId,
                                    CityName = ua.City,
                                    FullAddress = ua.FullAddress,
                                    PhoneNumber = ua.PhoneNumber,
                                    PostalCode = ua.PostalCode,
                                    ProvinceName = ua.Province,
                                   
                               }).FirstOrDefault();
            return useraddress;
        }

        public bool UpdateAddress(UserAddress userAddress)
        {
            try
            {
                _context.Update(userAddress);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region AddressForOrder

        public List<UserAddress> GetUserAddress(int userId)
        {
            return _context.userAddresses.Where(c => c.UserId == userId)
                .OrderByDescending(c => c.AddressId).ToList();
        }

        #endregion

    }
}
