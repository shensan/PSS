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
    public class SalesOrderService:ISalesOrdersService
    {
        public List<SalesOrdersModel> GetEntities(string sqlWhere)
        {
            string sql = string.Format("select * from salesOrders where 1=1 {0}", sqlWhere);
            List<Model.SalesOrdersModel> listSalesOrders = new List<SalesOrdersModel>();
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    Model.SalesOrdersModel salesOrdersModel = new SalesOrdersModel();
                    salesOrdersModel.ID = odr.GetInt32(0);
                    salesOrdersModel.OrderNumber = odr.IsDBNull(1) ? "" : odr.GetString(1);
                    salesOrdersModel.CustomerId = odr.IsDBNull(2) ? 0 : odr.GetInt32(2);
                    salesOrdersModel.CustomerName = odr.IsDBNull(3) ? "" : odr.GetString(3);
                    salesOrdersModel.Tel = odr.IsDBNull(4) ? "" : odr.GetString(4);
                    salesOrdersModel.Address = odr.IsDBNull(5) ? "" : odr.GetString(5);
                    salesOrdersModel.Contract = odr.IsDBNull(6) ? "" : odr.GetString(6);
                    salesOrdersModel.Status = odr.IsDBNull(7) ? "" : odr.GetString(7);
                    salesOrdersModel.OrderDate = odr.IsDBNull(8) ? DateTime.Now : odr.GetDateTime(8);
                    listSalesOrders.Add(salesOrdersModel);
                }
            }
            return listSalesOrders;
        }

        public SalesOrdersModel GetOneEntityByID(int id)
        {
            string sqlWhere = string.Format(" and id={0}", id);
            List<Model.SalesOrdersModel> listSalesOrders = GetEntities(sqlWhere);
            return listSalesOrders.SingleOrDefault(u => u.ID == id);
        }

        public SalesOrdersModel AddEntity(SalesOrdersModel entity)
        {
            string sql = string.Format("insert into salesOrders(orderNumber,customerId,customerName,telphone,address,contract,orderDate) values('{0}',{1},'{2}','{3}','{4}','{5}','{6}')",
             entity.OrderNumber, entity.CustomerId, entity.CustomerName, entity.Tel, entity.Address, entity.Contract, entity.OrderDate);
            if (MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0)
            {
                int curID = Convert.ToInt32(MSSqlHelper.ExecuteScalar(MSSqlHelper.ConStr, CommandType.Text, "select ident_current('salesOrders')", null).ToString());
                entity.ID = curID;
                return entity;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEntity(SalesOrdersModel entity)
        {
            //OrderNumber 这儿写上吧，实际业务里不能被修改
            string sql = string.Format("Update salesOrders Set orderNumber='{0}',customerId={1},customerName='{2}',telphone='{3}',address='{4}',contract='{5}',orderDate='{6}' Where id={7}",
                entity.OrderNumber, entity.CustomerId, entity.CustomerName, entity.Tel, entity.Address, entity.Contract, entity.OrderDate, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        /// <summary>
        /// 删除订单信息之前必须要先删除订单对应的商品信息，不然有垃圾数据
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>

        public bool DeleteEntity(string sqlWhere)
        {
            string sql = string.Format("delete from salesOrders where 1=1  {0}", sqlWhere);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

    }
}
