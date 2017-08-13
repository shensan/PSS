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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CustomerManagerService”。
    public class CustomerManagerService : ICustomerManagerService
    {

        AbstractFactory.DalFactory dataFactory = null;
        public CustomerManagerService()
        {
            dataFactory = DefaultProviderDal.DefaultDataProviderFactory;
        }

        public CustomerModel[] GetCustomers(string name, string tel, string address, string remark)
        {
            string sqlWhere = "";
            if (!string.IsNullOrWhiteSpace(name))
            {
                sqlWhere += string.Format(" and name like '%{0}%'",name);
            }
            if (!string.IsNullOrWhiteSpace(tel))
            {
                sqlWhere += string.Format(" and telphone like '%{0}%'", tel);
            }
            if (!string.IsNullOrWhiteSpace(address))
            {
                sqlWhere += string.Format(" and address like '%{0}%'", address);
            }
            if (!string.IsNullOrWhiteSpace(remark))
            {
                sqlWhere += string.Format(" and remark like '%{0}%'", remark);
            }
            //ICustomerService CustomerService = new OracleDAL.CustomerService();
            //return CustomerService.GetEntities(sqlWhere).ToArray();
            return dataFactory.CustomerDal.GetEntities(sqlWhere).ToArray();
        }


        public CustomerModel[] GetCustomersByCondition(string condition)
        {
            string sqlWhere = "";
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sqlWhere += string.Format("and (name Like '%{0}%' or telphone Like '%{0}%' or address Like '%{0}%' or remark Like '%{0}%' )", condition);
            }
            //return new OracleDAL.CustomerService().GetEntities(sqlWhere).ToArray();
            return dataFactory.CustomerDal.GetEntities(sqlWhere).ToArray();
        }

        /// <summary>
        /// 获取一个顾客信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerModel GetOneCustomer(int id)
        {
            //return new OracleDAL.CustomerService().GetOneEntityByID(id);
            return dataFactory.CustomerDal.GetOneEntityByID(id);
        }


        public CustomerModel AddCustomer(CustomerModel oneCustomer)
        {
            if (string.IsNullOrWhiteSpace(oneCustomer.Name))
            {
                Exception oe = new Exception();
                throw new FaultException<Exception>(oe,"顾客名称不能为空");
            }
            //return new OracleDAL.CustomerService().AddEntity(oneCustomer);
            return dataFactory.CustomerDal.AddEntity(oneCustomer);
        }


        public bool UpdateCustomer(CustomerModel Customer)
        {
            if (string.IsNullOrWhiteSpace(Customer.Name))
            {
                Exception oe = new Exception();
                throw new FaultException<Exception>(oe, "顾客名称不能为空");
            }
            //return new OracleDAL.CustomerService().UpdateEntity(Customer) ;
            return dataFactory.CustomerDal.UpdateEntity(Customer);
        }

    }
}
