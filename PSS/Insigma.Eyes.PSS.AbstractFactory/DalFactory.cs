using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insigma.Eyes.PSS.AbstractFactory
{
    public abstract class DalFactory
    {
        public abstract IDAL.ICommodityService CommdityDal
        {
            get;
        }
        public abstract IDAL.IPurchaseCommodityService PurchaseCommdityDal
        {
            get;
        }
        public abstract IDAL.IPurchaseOrdersService PurchaseOrderDal
        {
            get;
        }
        public abstract IDAL.ISalesCommodityService SalesCommodityDal
        {
            get;
        }
        public abstract IDAL.ISalesOrdersService SalesOrderDal
        {
            get;
        }
        public abstract IDAL.IUserService UserDal
        {
            get;
        }
        public abstract IDAL.IManufacturerService ManufacturerDal
        {
            get;
        }
        public abstract IDAL.ICustomerService CustomerDal
        {
            get;
        }
    }
}
