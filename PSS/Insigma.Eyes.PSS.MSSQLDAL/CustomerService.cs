using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insigma.Eyes.PSS.IDAL;
using Insigma.Eyes.PSS.Model;
using System.Data;
using System.Data.SqlClient;

namespace Insigma.Eyes.PSS.MSSQLDAL
{
    public class CustomerService : ICustomerService
    {
        public List<Model.CustomerModel> GetEntities(string sqlWhere)
        {
            string sql = string.Format("select * from customer where 1=1 {0}", sqlWhere);
            List<CustomerModel> listCustomers = new List<CustomerModel>();
            //Using 限定对象使用的范围在花括号里面，出了花括号后释放资源
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    CustomerModel Customer = new CustomerModel();
                    Customer.ID = odr.GetInt32(0);
                    Customer.Name = odr.IsDBNull(1) ? "" : odr.GetString(1);
                    Customer.Birthday = odr.IsDBNull(2) ? "" : odr.GetString(2);
                    Customer.Address = odr.IsDBNull(3) ? "" : odr.GetString(3);
                    Customer.Telphone = odr.IsDBNull(4) ? "" : odr.GetString(4);
                    Customer.TotalMoney = odr.IsDBNull(5) ? 0M : odr.GetDecimal(5);
                    Customer.Mark = odr.IsDBNull(6) ? "" : odr.GetString(6);
                    listCustomers.Add(Customer);
                }
            }
            return listCustomers;

        }

        public Model.CustomerModel GetOneEntityByID(int id)
        {
            string sqlWhere = string.Format(" and id={0}", id);
            List<Model.CustomerModel> list = GetEntities(sqlWhere);
            return list.SingleOrDefault(c => c.ID == id);//1.从List取一条数据 ，取到数据返回这条数据，取不到返回NULL 2.C是Customer类型参数（List是什么类型，C就是什么类型） (c=>c.ID==id)看作是个方法，参数c 方法里执行判断
        }
        //private int GetNewID()
        //{
        //    string sql = "select s_Customer.nextval from dual";
        //    return int.Parse(MSSqlHelper.ExecuteScalar(MSSqlHelper.ConStr, CommandType.Text, sql, null).ToString());
        //}

        public Model.CustomerModel AddEntity(Model.CustomerModel entity)
        {

            string sql = string.Format(@"insert into customer(name,birthday,address,telphone,totalMoney,remark) 
                                                    values({0},'{1}','{2}','{3}',{4},{5})", entity.Name, entity.Birthday, entity.Address, entity.Telphone, entity.TotalMoney, entity.Mark);
            if (MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEntity(Model.CustomerModel entity)
        {
            string sql = string.Format("update customer set name='{0}',birthday='{1}',address='{2}',telphone='{3}',totalMoney='{4}',remark='{5}' where id={6}",
                                                  entity.Name, entity.Birthday, entity.Address, entity.Telphone, entity.TotalMoney, entity.Mark, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        public bool DeleteEntity(string sqlWhere)
        {
            string sql = string.Format("delete form customer where 1=1 {0}", sqlWhere);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

    }
}
