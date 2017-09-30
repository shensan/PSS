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
    public class ManufacturerService : IManufacturerService
    {
        public List<Model.ManufacturerModel> GetEntities(string sqlWhere)
        {
            string sql = string.Format("select * from manufacturer where 1=1 {0}", sqlWhere);
            sql = sql + " order by line";
            List<Model.ManufacturerModel> listManufacturer = new List<Model.ManufacturerModel>();
            //Using 限定对象使用的范围在花括号里面，出了花括号后释放资源
            using (SqlDataReader odr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, CommandType.Text, sql, null))
            {
                while (odr.Read())
                {
                    Model.ManufacturerModel manufacturer = new Model.ManufacturerModel();
                    manufacturer.ID = odr.GetInt32(0);
                    manufacturer.Name = odr.IsDBNull(1) ? "" : odr.GetString(1);
                    manufacturer.Person = odr.IsDBNull(2) ? "" : odr.GetString(2);
                    manufacturer.Telephone = odr.IsDBNull(3) ? "" : odr.GetString(3);
                    manufacturer.Address = odr.IsDBNull(4) ? "" : odr.GetString(4);
                    manufacturer.Status = (odr.IsDBNull(5) ? "" : odr.GetString(5))=="1"?"激活":"未激活";
                    manufacturer.Line =  Convert.ToInt32(odr.GetValue(6));
                    listManufacturer.Add(manufacturer);
                }
            }
            return listManufacturer;

        }

        public Model.ManufacturerModel GetOneEntityByID(int id)
        {
            string sqlWhere = string.Format(" and id={0}", id);
            List<Model.ManufacturerModel> list = GetEntities(sqlWhere);
            return list.SingleOrDefault(c => c.ID == id);//1.从List取一条数据 ，取到数据返回这条数据，取不到返回NULL 2.C是Commodity类型参数（List是什么类型，C就是什么类型） (c=>c.ID==id)看作是个方法，参数c 方法里执行判断
        }


        public Model.ManufacturerModel AddEntity(Model.ManufacturerModel entity)
        {
            string sql = string.Format(@"insert into manufacturer(name,person,telephone,address) 
                                                    values({0},'{1}','{2}','{3}')", entity.Name, entity.Person, entity.Telephone, entity.Address);
            if (MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateEntity(Model.ManufacturerModel entity)
        {
            string sql = string.Format("update manufacturer set name='{0}',person='{1}',telephone='{2}',address='{3}',status='{4}',line={5} where ID={6}",
                                                  entity.Name, entity.Person, entity.Telephone, entity.Address, entity.Status, entity.Line, entity.ID);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

        public bool DeleteEntity(string sqlWhere)
        {
            string sql = string.Format("delete form manufacturer where 1=1 {0}", sqlWhere);
            return MSSqlHelper.ExecuteNonQuery(MSSqlHelper.ConStr, CommandType.Text, sql, null) > 0;
        }

    }
}
