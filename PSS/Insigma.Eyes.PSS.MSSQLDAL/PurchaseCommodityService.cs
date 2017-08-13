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
     public class PurchaseCommodityService:IPurchaseCommodityService
    {
        public List<Model.PurchaseCommodityModel> GetEntities(string sqlWhere)
        {
            string sql = string.Format("select * from View_Purchase where 1=1 {0}", sqlWhere);
            List<Model.PurchaseCommodityModel> listPurchaseCommodities = new List<Model.PurchaseCommodityModel>();
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    Model.PurchaseCommodityModel purchaseCommodityModel = new Model.PurchaseCommodityModel();
                    purchaseCommodityModel.ID = odr.GetInt32(8);
                    //由于数据库在该字段设置了值太大，所以溢出
                    purchaseCommodityModel.PurchaseOrderID = odr.GetInt32(0);
                    purchaseCommodityModel.CommodityID = odr.GetInt32(12);
                    purchaseCommodityModel.CommodityName = odr.IsDBNull(13) ? "" : odr.GetString(13);
                    purchaseCommodityModel.CommodityType = odr.IsDBNull(14) ? "" : odr.GetString(14);
                    purchaseCommodityModel.CommodityManufacturer = odr.IsDBNull(15) ? "" : odr.GetString(15);
                    //purchaseCommodityModel.CommodityInventory = odr.IsDBNull(6) ? 0 : odr.GetInt32(6);
                    purchaseCommodityModel.CommodityUnitPrice = odr.IsDBNull(18) ? 0 : odr.GetDecimal(18);
                    purchaseCommodityModel.CommodityUnit = odr.IsDBNull(19) ? "" : odr.GetString(19);
                    purchaseCommodityModel.Count = odr.IsDBNull(9) ? 0 : odr.GetInt32(9);
                    purchaseCommodityModel.PurchasePrice = odr.IsDBNull(10) ? 0 : odr.GetDecimal(10);
                    purchaseCommodityModel.TotalPrice = odr.IsDBNull(11) ? 0 : odr.GetDecimal(11);
                    listPurchaseCommodities.Add(purchaseCommodityModel);
                }
            }
            return listPurchaseCommodities;
        }

        public Model.PurchaseCommodityModel GetOneEntityByID(int id)
        {
            string sqlWhere = string.Format(" and ItemId={0}", id);
            List<Model.PurchaseCommodityModel> list = GetEntities(sqlWhere);
            return list.SingleOrDefault(p => p.ID == id);
        }

        public Model.PurchaseCommodityModel AddEntity(Model.PurchaseCommodityModel entity)
        {
            string sql = string.Format("insert into purchaseCommodity(orderId,commodityId,count,purchasePrice,totalPrice) values({0},{1},{2},{3},{4})",
                entity.PurchaseOrderID, entity.CommodityID, entity.Count, entity.PurchasePrice, entity.TotalPrice);
            if (MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null) > 0)
            {
                //int curID = Convert.ToInt32(MSSqlHelper.ExecuteScalar(MSSqlHelper.ConStr, CommandType.Text, "select ident_current('purchasecommodity')", null).ToString());
                //entity.ID = curID;
                return entity;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEntity(Model.PurchaseCommodityModel entity)
        {
            string sql = string.Format("update purchaseCommodity set orderId={0},commodityId={1},count={2},purchasePrice={3},totalPrice={4} where id={5}",
                entity.PurchaseOrderID, entity.CommodityID, entity.Count, entity.PurchasePrice, entity.TotalPrice, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null) > 0;
        }

        public bool DeleteEntity(string sqlWhere)
        {
            string sql = string.Format("delete from purchaseCommodity where 1=1 {0}", sqlWhere);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null) > 0;
        }
    }
}
