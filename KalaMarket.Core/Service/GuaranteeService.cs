using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service
{
    public class GuaranteeService : IGuaranteeService
    {
        private KalaMarketContext _context;
        public GuaranteeService(KalaMarketContext Context)
        {
            _context = Context;
        }

        public int AddGuarantee(ProductGuarantee productGuarantee)
        {
            try
            {
                _context.productGuarantees.Add(productGuarantee);
                _context.SaveChanges();
                return productGuarantee.GuaranteeId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteGuarantee(ProductGuarantee productGuarantee)
        {
            try
            {
                productGuarantee.IsDelete = true;
                _context.productGuarantees.Update(productGuarantee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductGuarantee FindGuaranteeById(int id)
        {
            return _context.productGuarantees.Find(id);
        }

        public bool IsGuaranteeExists(string guaranteeName, int guaranteeId)
        {
            return _context.productGuarantees.Any(g => g.GuaranteeName == guaranteeName && g.GuaranteeId != guaranteeId && !g.IsDelete);
        }

        public List<ProductGuarantee> ShowAllGuarantee()
        {
            return _context.productGuarantees.Where(g => !g.IsDelete).ToList();
        }

        public bool UpdateGuarantee(ProductGuarantee productGuarantee)
        {
            try
            {
                _context.productGuarantees.Update(productGuarantee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
