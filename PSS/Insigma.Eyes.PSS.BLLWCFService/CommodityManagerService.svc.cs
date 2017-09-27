using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Insigma.Eyes.PSS.IDAL;
using Insigma.Eyes.PSS.Model;
namespace Insigma.Eyes.PSS.BLLWCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CommodityManagerService”。
    public class CommodityManagerService : ICommodityManagerService
    {

        AbstractFactory.DalFactory dataFactory = null;
        public CommodityManagerService()
        {
            dataFactory = DefaultProviderDal.DefaultDataProviderFactory;
        }


        #region 处理商品

        public Model.CommodityModel[] GetCommodities(string name, string type, string manufacturer, string priceLow, string priceHigh)
        {
            string sqlWhere = "";
            if (!string.IsNullOrWhiteSpace(name))
            {
                sqlWhere += string.Format(" and Name like '%{0}%'",name);
            }
            if (!string.IsNullOrWhiteSpace(type))
            {
                sqlWhere += string.Format(" and Type like '%{0}%'", type);
            }
            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                sqlWhere += string.Format(" and Manufacturer like '%{0}%'", manufacturer);
            }
            if (!string.IsNullOrWhiteSpace(priceLow))
            {
                try
                {
                    decimal dPriceLow=decimal.Parse(priceLow);//调试一下，是否需要赋值
                    sqlWhere += string.Format(" and UnitPrice>={0}", dPriceLow);
                }
                catch
                {
                    Exception e = new Exception();
                    throw new FaultException<Exception>(e,"单价下限有误！");
                }
            }
            if (!string.IsNullOrWhiteSpace(priceHigh))
            {
                try
                {
                    decimal dPriceHigh = decimal.Parse(priceHigh);
                    sqlWhere += string.Format(" and UnitPrice<={0}",dPriceHigh);
                }
                catch 
                {
                    Exception e = new Exception();
                    throw new FaultException<Exception>(e, "单价上限有误会!");
                }
            }
            //ICommodityService commodityService = new OracleDAL.CommodityService();
            //return commodityService.GetEntities(sqlWhere).ToArray();
            return dataFactory.CommdityDal.GetEntities(sqlWhere).ToArray();
        }


        public Model.CommodityModel[] GetCommoditiesByCondition(string condition)
        {
            string sqlWhere = "";
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sqlWhere+=string.Format("and (Name Like '%{0}%' or Type Like '%{0}%' or Manufacturer Like '%{0}%' )",condition);
            }
            sqlWhere += " and status='1'";
            //return new OracleDAL.CommodityService().GetEntities(sqlWhere).ToArray();
            return dataFactory.CommdityDal.GetEntities(sqlWhere).ToArray();
        }

        /// <summary>
        /// 获取一个产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.CommodityModel GetOneCommodity(int id)
        {
            //return new OracleDAL.CommodityService().GetOneEntityByID(id);
            return dataFactory.CommdityDal.GetOneEntityByID(id);
        }


        public Model.CommodityModel AddCommodity(Model.CommodityModel oneCommodity)
        {
            if (string.IsNullOrWhiteSpace(oneCommodity.Name))
            {
                Exception oe = new Exception();
                throw new FaultException<Exception>(oe,"商品名称不能为空");
            }
            //return new OracleDAL.CommodityService().AddEntity(oneCommodity);
            return dataFactory.CommdityDal.AddEntity(oneCommodity);
        }


        public bool UpdateCommodity(Model.CommodityModel commodity)
        {
            if (string.IsNullOrWhiteSpace(commodity.Name))
            {
                Exception oe = new Exception();
                throw new FaultException<Exception>(oe,"商品名称不能为空");
            }
            //return new OracleDAL.CommodityService().UpdateEntity(commodity) ;
            return dataFactory.CommdityDal.UpdateEntity(commodity);
        }

        #endregion 处理商品


        #region 处理基本数据中单位数据

        public UnitModel[] GetCommdityUnits()
        {
            string sqlWhere = "";
            
            //ICommodityService commodityService = new OracleDAL.CommodityService();
            //return commodityService.GetEntities(sqlWhere).ToArray();
            return dataFactory.CommdityDal.GetUnitEntities(sqlWhere).ToArray();
        }

        public bool AddCommdityUnit(UnitModel oneUnit)
        {
            if (string.IsNullOrWhiteSpace(oneUnit.Name))
            {
                Exception oe = new Exception();
                throw new FaultException<Exception>(oe, "商品名称不能为空");
            }
            return dataFactory.CommdityDal.AddUnitEntity(oneUnit);
        }


        public bool UpdateCommdityUnit(UnitModel oneUnit)
        {
            if (string.IsNullOrWhiteSpace(oneUnit.Name))
            {
                Exception oe = new Exception();
                throw new FaultException<Exception>(oe, "商品名称不能为空");
            }
            //return new OracleDAL.CommodityService().UpdateEntity(commodity) ;
            return dataFactory.CommdityDal.UpdateUnitEntity(oneUnit);
        }

        #endregion 处理基本数据中单位数据

        #region 处理基本数据中商品类型数据
        public TypeModel[] GetCommdityTypes()
        {
            string sqlWhere = "";

            //ICommodityService commodityService = new OracleDAL.CommodityService();
            //return commodityService.GetEntities(sqlWhere).ToArray();
            return dataFactory.CommdityDal.GetTypeEntities(sqlWhere).ToArray();
        }

        public bool AddCommdityType(TypeModel oneType)
        {
            if (string.IsNullOrWhiteSpace(oneType.Name))
            {
                Exception oe = new Exception();
                throw new FaultException<Exception>(oe, "商品名称不能为空");
            }
            return dataFactory.CommdityDal.AddTypeEntity(oneType);
        }


        public bool UpdateCommdityType(TypeModel oneType)
        {
            if (string.IsNullOrWhiteSpace(oneType.Name))
            {
                Exception oe = new Exception();
                throw new FaultException<Exception>(oe, "商品名称不能为空");
            }
            //return new OracleDAL.CommodityService().UpdateEntity(commodity) ;
            return dataFactory.CommdityDal.UpdateTypeEntity(oneType);
        }
        #endregion 处理基本数据中商品类型数据

        #region 处理基本数据中供应商与厂商数据
        /// <summary>
        /// 供应商与厂商
        /// </summary>
        /// <param name="name"></param>
        /// <param name="person"></param>
        /// <param name="tel"></param>
        /// <param name="addr"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        public ManufacturerModel[] GetManufacturers(string name, string person, string tel, string addr, string status)
        {
            string sqlWhere = "";
            if (!string.IsNullOrWhiteSpace(name))
            {
                sqlWhere += string.Format(" and name like '%{0}%'", name);
            }
            if (!string.IsNullOrWhiteSpace(person))
            {
                sqlWhere += string.Format(" and person like '%{0}%'", person);
            }
            if (!string.IsNullOrWhiteSpace(tel))
            {
                sqlWhere += string.Format(" and telephone like '%{0}%'", tel);
            }
            if (!string.IsNullOrWhiteSpace(addr))
            {
                sqlWhere += string.Format(" and address like '%{0}%'", addr);
            }
            if (!string.IsNullOrWhiteSpace(status))
            {
                sqlWhere += string.Format(" and status = '{0}'", status);
            }

            return dataFactory.ManufacturerDal.GetEntities(sqlWhere).ToArray();
        }


        //public ManufacturerModel AddManufacturer(ManufacturerModel oneManufacturer)
        //{ }


        //public bool UpdateManufacturer(Model.ManufacturerModel manufacturer)
        //{ }
        #endregion 处理基本数据中供应商与厂商数据
    }
}
