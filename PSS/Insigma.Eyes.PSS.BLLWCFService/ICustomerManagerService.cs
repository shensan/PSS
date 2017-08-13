using System;
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
    public interface ICustomerManagerService
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        CustomerModel[] GetCustomers(string name, string tel, string address, string remark);

        [OperationContract]
        CustomerModel[] GetCustomersByCondition(string condition);

        [OperationContract]
        CustomerModel GetOneCustomer(int id);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        CustomerModel AddCustomer(CustomerModel oneCommodity);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool UpdateCustomer(CustomerModel commodity);

    }
}
