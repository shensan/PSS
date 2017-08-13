using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insigma.Eyes.PSS.MSSQLDAL
{
    public class DalMSSqlFactory : Insigma.Eyes.PSS.AbstractFactory.DalFactory
    {
        public override IDAL.ICommodityService CommdityDal
        {
            //缓存里拿
            get
            {

                MSSQLDAL.CommodityService instance = System.Web.HttpRuntime.Cache["CommodityDal"] as MSSQLDAL.CommodityService;
                if (instance == null)
                {
                    instance = new MSSQLDAL.CommodityService();
                    System.Web.HttpRuntime.Cache.Add("CommodityDal", instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                return instance;

            }

        }

        public override IDAL.IPurchaseCommodityService PurchaseCommdityDal
        {
            get
            {

                MSSQLDAL.PurchaseCommodityService instance = System.Web.HttpRuntime.Cache["PurchaseCommdityDal"] as MSSQLDAL.PurchaseCommodityService;
                if (instance == null)
                {
                    instance = new MSSQLDAL.PurchaseCommodityService();
                    System.Web.HttpRuntime.Cache.Add("PurchaseCommdityDal", instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                return instance;

            }
        }

        public override IDAL.IPurchaseOrdersService PurchaseOrderDal
        {
            get
            {

                MSSQLDAL.PurchaseOrderService instance = System.Web.HttpRuntime.Cache["PurchaseOrderDal"] as MSSQLDAL.PurchaseOrderService;
                if (instance == null)
                {
                    instance = new MSSQLDAL.PurchaseOrderService();
                    System.Web.HttpRuntime.Cache.Add("PurchaseOrderDal", instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                return instance;

            }
        }

        public override IDAL.ISalesCommodityService SalesCommodityDal
        {
            get
            {

                MSSQLDAL.SalesCommodityService instance = System.Web.HttpRuntime.Cache["SalesCommodityDal"] as MSSQLDAL.SalesCommodityService;
                if (instance == null)
                {
                    instance = new MSSQLDAL.SalesCommodityService();
                    System.Web.HttpRuntime.Cache.Add("SalesCommodityDal", instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                return instance;

            }
        }

        public override IDAL.ISalesOrdersService SalesOrderDal
        {
            get
            {

                MSSQLDAL.SalesOrderService instance = System.Web.HttpRuntime.Cache["SalesOrdersDal"] as MSSQLDAL.SalesOrderService;
                if (instance == null)
                {
                    instance = new MSSQLDAL.SalesOrderService();
                    System.Web.HttpRuntime.Cache.Add("SalesOrdersDal", instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                return instance;

            }
        }

        public override IDAL.IUserService UserDal
        {
            //缓存里拿
            get
            {

                MSSQLDAL.UserService instance = System.Web.HttpRuntime.Cache["UserDal"] as MSSQLDAL.UserService;
                if (instance == null)
                {
                    instance = new MSSQLDAL.UserService();
                    System.Web.HttpRuntime.Cache.Add("UserDal", instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                return instance;

            }
        }
        public override IDAL.IManufacturerService ManufacturerDal
        {
            get
            {
                MSSQLDAL.ManufacturerService instance = System.Web.HttpRuntime.Cache["ManufacturerDal"] as MSSQLDAL.ManufacturerService;
                if (instance == null)
                {
                    instance = new MSSQLDAL.ManufacturerService();
                    System.Web.HttpRuntime.Cache.Add("ManufacturerDal", instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                return instance;
            }
        }
        public override IDAL.ICustomerService CustomerDal
        {
            get
            {
                MSSQLDAL.CustomerService instance = System.Web.HttpRuntime.Cache["CustomerDal"] as MSSQLDAL.CustomerService;
                if (instance == null)
                {
                    instance = new MSSQLDAL.CustomerService();
                    System.Web.HttpRuntime.Cache.Add("CustomerDal", instance, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                return instance;
            }
        }
    }
}
