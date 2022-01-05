using KalaMarket.DataLayer.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Service.IService
{
    public interface IGuaranteeService
    {
        List<ProductGuarantee> ShowAllGuarantee();
        ProductGuarantee FindGuaranteeById(int id);
        bool UpdateGuarantee(ProductGuarantee productGuarantee);
        bool DeleteGuarantee(ProductGuarantee productGuarantee);
        bool IsGuaranteeExists(string guaranteeName, int guaranteeId);
        int AddGuarantee(ProductGuarantee productGuarantee);
    }
}
