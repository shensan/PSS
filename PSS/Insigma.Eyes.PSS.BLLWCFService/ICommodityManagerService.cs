﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Insigma.Eyes.PSS.Model;

namespace Insigma.Eyes.PSS.BLLWCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICommodityManagerService”。
    [ServiceContract]
    public interface ICommodityManagerService
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        CommodityModel[] GetCommodities(string name,string type,string manufacturer,string priceLow,string priceHigh);

        [OperationContract]
        CommodityModel[] GetCommoditiesByCondition(string condition);

        [OperationContract]
        CommodityModel GetOneCommodity(int id);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        CommodityModel AddCommodity(CommodityModel oneCommodity);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool UpdateCommodity(Model.CommodityModel commodity);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        ManufacturerModel[] GetManufacturers(string name, string person, string tel, string addr, string status);

        //[OperationContract]
        //[FaultContract(typeof(Exception))]
        //ManufacturerModel AddManufacturer(ManufacturerModel oneManufacturer);

        //[OperationContract]
        //[FaultContract(typeof(Exception))]
        //bool UpdateManufacturer(Model.ManufacturerModel manufacturer);
    }
}
