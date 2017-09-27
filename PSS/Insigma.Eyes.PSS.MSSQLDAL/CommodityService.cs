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
    public class CommodityService:ICommodityService
    {
        #region 处理商品数据
        public List<Model.CommodityModel> GetEntities(string sqlWhere)
        {
            string sql = string.Format("select * from View_Commodity where 1=1 {0}", sqlWhere);
            List<Model.CommodityModel> listCommodities = new List<Model.CommodityModel>();
            //Using 限定对象使用的范围在花括号里面，出了花括号后释放资源
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    Model.CommodityModel commodity = new Model.CommodityModel();
                    commodity.ID = odr.GetInt32(0);
                    commodity.Name = odr.IsDBNull(1) ? "" : odr.GetString(1);
                    commodity.Type = odr.IsDBNull(3) ? "" : odr.GetString(3);
                    commodity.Manufacturer = odr.IsDBNull(5) ? "" : odr.GetString(5);
                    commodity.Person = odr.IsDBNull(6) ? "" : odr.GetString(6);
                    commodity.Telphone = odr.IsDBNull(7) ? "" : odr.GetString(7);
                    commodity.Address = odr.IsDBNull(8) ? "" : odr.GetString(8);
                    commodity.UnitPrice = odr.IsDBNull(10) ? 0 : odr.GetDecimal(10);
                    commodity.Unit = odr.IsDBNull(12) ? "" : odr.GetString(12);
                    listCommodities.Add(commodity);
                }
            }
            return listCommodities;

        }

        public Model.CommodityModel GetOneEntityByID(int id)
        {
            string sqlWhere = string.Format(" and id={0}", id);
            List<Model.CommodityModel> list = GetEntities(sqlWhere);
            return list.SingleOrDefault(c => c.ID == id);//1.从List取一条数据 ，取到数据返回这条数据，取不到返回NULL 2.C是Commodity类型参数（List是什么类型，C就是什么类型） (c=>c.ID==id)看作是个方法，参数c 方法里执行判断
        }
        private int GetNewID()
        {
            string sql = "select s_commodity.nextval from dual";
            return int.Parse(MSSqlHelper.ExecuteScalar(MSSqlHelper.ConStr, CommandType.Text, sql, null).ToString());
        }

        public Model.CommodityModel AddEntity(Model.CommodityModel entity)
        {
            entity.ID = GetNewID();
            string sql = string.Format(@"insert into Commodity(ID,Name,Type,Manufacturer,Inventory,UnitPrice,Unit) 
                                                    values({0},'{1}','{2}','{3}',{4},{5},'{6}')", entity.ID, entity.Name, entity.Type, entity.Manufacturer, entity.Inventory, entity.UnitPrice, entity.UnitPrice);
            if (MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEntity(Model.CommodityModel entity)
        {
            string sql = string.Format("update Commodity set Name='{0}',Type='{1}',Manufacturer='{2}',Inventory={3},UnitPrice={4},Unit='{5}' where ID={6}",
                                                  entity.Name, entity.Type, entity.Manufacturer, entity.Inventory, entity.UnitPrice, entity.Unit, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        public bool DeleteEntity(string sqlWhere)
        {
            string sql = string.Format("delete form Commodity where 1=1 {0}", sqlWhere);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }
        #endregion 处理商品数据

        #region 处理单位数据
        public List<UnitModel> GetUnitEntities(string sqlWhere)
        {
            string sql = string.Format("select id,name,status,mark,line from unit where 1=1 {0}", sqlWhere);
            sql = sql + " order by line";
            List<UnitModel> listUnits = new List<UnitModel>();
            //Using 限定对象使用的范围在花括号里面，出了花括号后释放资源
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    UnitModel unit = new UnitModel();
                    unit.ID = odr.GetInt32(0);
                    unit.Name = odr.GetString(1);
                    unit.Status = odr.GetString(2) == "1" ? "激活" : "未激活";
                    unit.Mark = odr.IsDBNull(3) ? "" : odr.GetString(3);
                    unit.Line = odr.GetInt32(4);
                    listUnits.Add(unit);
                }
            }
            return listUnits;
        }

        public bool AddUnitEntity(UnitModel entity)
        {
            string sql = string.Format(@"insert into unit(name,line) values() values('{0}',{1})", entity.Name, entity.Line);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        public bool UpdateUnitEntity(UnitModel entity)
        {
            string sql = string.Format(@"update unit set name='{0}',line={1} where ID={2}", entity.Name, entity.Line, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        #endregion 处理单位数据

        #region 处理商品类型数据
        public List<TypeModel> GetTypeEntities(string sqlWhere)
        {
            string sql = string.Format("select id,name,status,mark,line from commodityType where 1=1 {0}", sqlWhere);
            sql = sql + " order by line";
            List<TypeModel> listTypes = new List<TypeModel>();
            //Using 限定对象使用的范围在花括号里面，出了花括号后释放资源
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    TypeModel type = new TypeModel();
                    type.ID = odr.GetInt32(0);
                    type.Name = odr.GetString(1);
                    type.Status = odr.GetString(2) == "1" ? "激活" : "未激活";
                    type.Mark = odr.IsDBNull(3) ? "" : odr.GetString(3);
                    type.Line = odr.GetInt32(4);
                    listTypes.Add(type);
                }
            }
            return listTypes;
        }

        public bool AddTypeEntity(TypeModel entity)
        {
            string sql = string.Format(@"insert into commodityType(name,line) values() values('{0}',{1})", entity.Name, entity.Line);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        public bool UpdateTypeEntity(TypeModel entity)
        {
            string sql = string.Format(@"update commodityType set name='{0}',line={1} where ID={2}", entity.Name, entity.Line, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        #endregion 处理商品类型数据
    }
}
