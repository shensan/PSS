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
    public class PurchaseOrderService:IPurchaseOrdersService
    {
        public List<Model.PurchaseOrdersModel> GetEntities(string sqlWhere)
        {
            string sql = string.Format("select * from purchaseOrders where 1=1 {0}", sqlWhere);
            List<Model.PurchaseOrdersModel> listPurchaseOrders = new List<Model.PurchaseOrdersModel>();
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    Model.PurchaseOrdersModel purchaseOrderModel = new Model.PurchaseOrdersModel();
                    purchaseOrderModel.ID = odr.GetInt32(0);
                    purchaseOrderModel.OrderNumber = odr.IsDBNull(1) ? "" : odr.GetString(1);
                    purchaseOrderModel.SupplierName = odr.IsDBNull(2) ? "" : odr.GetString(2);
                    purchaseOrderModel.Person = odr.IsDBNull(3) ? "" : odr.GetString(3);
                    purchaseOrderModel.Tel = odr.IsDBNull(4) ? "" : odr.GetString(4);
                    purchaseOrderModel.Address = odr.IsDBNull(5) ? "" : odr.GetString(5);
                    purchaseOrderModel.Contract = odr.IsDBNull(6) ? "" : odr.GetString(6);
                    //purchaseOrderModel.Status = odr.IsDBNull(7) ? "" : odr.GetString(7);
                    purchaseOrderModel.OrderDate = odr.IsDBNull(8) ? DateTime.Now : odr.GetDateTime(8);
                    listPurchaseOrders.Add(purchaseOrderModel);
                }
            }
            return listPurchaseOrders;
        }

        public Model.PurchaseOrdersModel GetOneEntityByID(int id)
        {
            string sqlWhere = string.Format(" and id={0}", id);
            List<Model.PurchaseOrdersModel> listPurchaseOrders = GetEntities(sqlWhere);
            return listPurchaseOrders.SingleOrDefault(u => u.ID == id);
        }

        public Model.PurchaseOrdersModel AddEntity(Model.PurchaseOrdersModel entity)
        {
            string sql = string.Format("insert into purchaseOrders(orderNumber,supplier,person,telphone,address,contract,OrderDate) values({0},'{1}','{2}','{3}','{4}','{5}','{6}')",
             entity.OrderNumber, entity.SupplierName, entity.Person, entity.Tel, entity.Address, entity.Contract, entity.OrderDate);
            int resRows=MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) ;
            if (resRows > 0)
            {
                int curID = Convert.ToInt32(MSSqlHelper.ExecuteScalar(MSSqlHelper.ConStr, CommandType.Text, "select ident_current('purchaseOrders')", null).ToString());
                entity.ID = curID;
                return entity;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEntity(Model.PurchaseOrdersModel entity)
        {
            string sql = string.Format("Update purchaseOrders Set orderNumber='{0}',supplier='{1}',person='{2}',telphone='{3}',address='{4}',contract='{5}',orderDate='{6}' Where id={7}",
               entity.OrderNumber, entity.SupplierName, entity.Person, entity.Tel, entity.Address, entity.Contract, entity.OrderDate, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        public bool DeleteEntity(string sqlWhere)
        {
            string sql = string.Format("delete from purchaseOrders where 1=1  {0}", sqlWhere);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }
    }
}
