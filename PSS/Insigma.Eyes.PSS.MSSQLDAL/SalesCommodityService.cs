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
    public class SalesCommodityService:ISalesCommodityService
    {

        public List<Model.SalesCommodityModel> GetEntities(string sqlWhere)
        {
            string sql = string.Format("select * from View_Sales where 1=1 {0}", sqlWhere);
            List<Model.SalesCommodityModel> listSalesCommodity = new List<Model.SalesCommodityModel>();
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    Model.SalesCommodityModel salesCommodityModel = new Model.SalesCommodityModel();
                    salesCommodityModel.ID = odr.GetInt32(10);
                    salesCommodityModel.SalesOrderID = odr.GetInt32(0);
                    salesCommodityModel.CommodityID = odr.GetInt32(14);
                    salesCommodityModel.CommodityName = odr.IsDBNull(15) ? "" : odr.GetString(15);
                    salesCommodityModel.CommodityType = odr.IsDBNull(18) ? "" : odr.GetString(18);
                    salesCommodityModel.CommodityManufacturer = odr.IsDBNull(19) ? "" : odr.GetString(19);
                    //salesCommodityModel.CommodityInventory = odr.IsDBNull(6) ? 0 : odr.GetInt32(6);
                    salesCommodityModel.CommodityUnitPrice = odr.IsDBNull(16) ? 0M : odr.GetDecimal(16);
                    salesCommodityModel.CommodityUnit = odr.IsDBNull(17) ? "" : odr.GetString(17);
                    salesCommodityModel.Count = odr.IsDBNull(11) ? 0 : odr.GetInt32(11);
                    salesCommodityModel.SalesPrice = odr.IsDBNull(12) ? 0M : odr.GetDecimal(12);
                    salesCommodityModel.TotalPrice = odr.IsDBNull(13) ? 0M : odr.GetDecimal(13);
                    listSalesCommodity.Add(salesCommodityModel);
                }
            }
            return listSalesCommodity;
        }

        public Model.SalesCommodityModel GetOneEntityByID(int id)
        {
            string sqlWhere = string.Format(" and ItemId={0}", id);
            List<Model.SalesCommodityModel> listSalesCommodity = GetEntities(sqlWhere);
            return listSalesCommodity.SingleOrDefault(u => u.ID == id);
        }

        private int GetNewID()
        {
            string sql = "select s_salescommodity.nextval from dual";
            return int.Parse(MSSqlHelper.ExecuteScalar(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null).ToString());
        }

        public Model.SalesCommodityModel AddEntity(Model.SalesCommodityModel entity)
        {
            string sql = string.Format("insert into salesCommodity(orderId,commodityId,count,salesPrice,totalPrice) values({0},{1},{2},{3},{4})",
                entity.SalesOrderID, entity.CommodityID, entity.Count, entity.SalesPrice, entity.TotalPrice);
            if (MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null) > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEntity(Model.SalesCommodityModel entity)
        {
            string sql = string.Format("update  salesCommodity set orderId={0},commodityId={1},count={2},salesPrice={3},totalPrice={4} where id={5}",
               entity.SalesOrderID, entity.CommodityID, entity.Count, entity.SalesPrice, entity.TotalPrice, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null) > 0;
        }

        public bool DeleteEntity(string sqlWhere)
        {
            string sql = string.Format("delete from salesCommodity where 1=1 {0}", sqlWhere);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null) > 0;
        }

    }
}
