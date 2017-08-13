using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Insigma.Eyes.PSS.MSSQLDAL
{
    public class UserService : IDAL.IUserService
    {
        public Model.UserModel GetOneUser(string sqlWhere)
        {
            string sql = string.Format("select * from users where 1=1 {0}", sqlWhere);
            using (SqlDataReader sdr = MSSqlHelper.ExecuteReader(MSSqlHelper.ConStr, System.Data.CommandType.Text, sql, null))
            {
                if (sdr.Read())
                {
                    Model.UserModel user = new Model.UserModel();
                    user.ID = sdr.GetInt32(0);
                    user.UserName = sdr.GetString(1);
                    user.Password = sdr.GetString(2);
                    user.Role = sdr.GetInt32(3);
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
