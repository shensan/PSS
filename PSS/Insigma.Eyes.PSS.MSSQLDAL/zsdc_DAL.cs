using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ntgl.Model;

namespace ntgl.SQLDAL
{
   /// <summary>
   /// 棉花长势调查的操作
   /// </summary>
    public  class zsdc_DAL
    {
        //private const string SELECT_ZS = "select * from mhzsdc mh where mh.ntID = 1 and YEAR(mh.dcdate) = 2013";
        //private const string INSERT_SF = "insert into ShifeiJuece values(@ntID,@jcnd,@zwmc,@mbdc,@tjsdzl,@bqjfl,@dgzfl,@tjsll,@tjsjl,@tjyjz)";
        //private const string DELETE_SF = "delete from ShifeiJuece where sfjcid=@sfjcid";
        //private const string UPDATE_SF = "update ShifeiJuece set mbdc=@mbdc,tjsdzl=@tjsdzl,bqjfl=@bqjfl,dgzfl=@dgzfl,tjsll=@tjsll where sfjcid=@sfjcid";
        private const string QUERY_ZS = "select * from mhzsdc mh where mh.ntmc = @ntmc and YEAR(mh.dcdate) = @dcyear order by mh.dcdate desc";
        private const string QUERY_ZS_NTID = "select mh.*,SysUser.truename from mhzsdc mh left outer join SysUser on mh.userid=SysUser.userid where mh.ntID = @ntID and YEAR(mh.dcdate) = @dcyear order by mh.dcdate desc";
        private const string QUERY_ZS_MHID = "select * from mhzsdc mh where mh.mhzhdcid=@mhzhdcid";
        private const string QUERY_MZZS = "select mz.weizhi weizhi, mz.zhugao zhugao, mz.yeling yeling, mz.guozhishu guozhishu, mz.lingshu lingshu, mz.guojieshu guojieshu, mz.dsyk dsyk, mz.zjrzzl zjrzzl from mzdc mz where weizhi='边行' and mz.mhzhdcid=@m1 union all select '边行平均' weizhi, AVG(mz.zhugao) zhugao, AVG(mz.yeling) yeling, AVG(mz.guozhishu) guozhishu, AVG(mz.lingshu) lingshu, AVG(mz.guojieshu) guojieshu, AVG(mz.dsyk) dsyk, AVG(mz.zjrzzl) zjrzzl from mzdc mz where weizhi='边行' and mz.mhzhdcid=@m2 union all select mz.weizhi weizhi, mz.zhugao zhugao, mz.yeling yeling, mz.guozhishu guozhishu, mz.lingshu lingshu, mz.guojieshu guojieshu, mz.dsyk dsyk, mz.zjrzzl zjrzzl from mzdc mz where weizhi='中间行' and mz.mhzhdcid=@m3 union all select '中间行平均' weizhi, AVG(mz.zhugao) zhugao, AVG(mz.yeling) yeling, AVG(mz.guozhishu) guozhishu, AVG(mz.lingshu) lingshu, AVG(mz.guojieshu) guojieshu, AVG(mz.dsyk) dsyk, AVG(mz.zjrzzl) zjrzzl from mzdc mz where weizhi='中间行' and mz.mhzhdcid=@m4 union all select '总体平均' weizhi, AVG(mz.zhugao) zhugao, AVG(mz.yeling) yeling, AVG(mz.guozhishu) guozhishu, AVG(mz.lingshu) lingshu, AVG(mz.guojieshu) guojieshu, AVG(mz.dsyk) dsyk, AVG(mz.zjrzzl) zjrzzl from mzdc mz where mz.mhzhdcid=@m5";
        private const string INSERT_MHZS = "insert into mhzsdc(mhzhdcid,userid,username,ntID,ntmc,dcdate,jd,wd) values(@mhzhdcid,@userid,@username,@ntID,@ntmc,@dcdate,@jd,@wd)";
        private const string INSERT_MZDC = "insert into mzdc(mzdcid,mhzhdcid,zhugao,yeling,guozhishu,lingshu,guojieshu,dsyk,zjrzzl,weizhi) values(@mzdcid,@mhzhdcid,@zhugao,@yeling,@guozhishu,@lingshu,@guojieshu,@dsyk,@zjrzzl,@weizhi)";
        private const string QUERY_JC = "select mqpj, zpcs from mhzsdc where mhzhdcid = @mhzhdcid";

        //统计分析新增
        private const string QUERY_NT_AVG = "select dcdate, AVG(pjzhugao) pjzhugao, AVG(pjyeling) pjyeling, AVG(pjguozhishu) pjguozhishu, AVG(pjlingshu) pjlingshu, AVG(pjguojieshu) pjguojieshu, AVG(pjdsyk) pjdsyk, AVG(pjzjrzzl) pjzjrzzl from (select * from mhzsdc where ntID=@ntID and YEAR(dcdate) = @dcyear) mh group by dcdate order by dcdate desc";
        private const string QUERY_LD_AVG = "select dcdate, AVG(pjzhugao) pjzhugao, AVG(pjyeling) pjyeling, AVG(pjguozhishu) pjguozhishu, AVG(pjlingshu) pjlingshu, AVG(pjguojieshu) pjguojieshu, AVG(pjdsyk) pjdsyk, AVG(pjzjrzzl) pjzjrzzl from (SELECT mhzsdc.*, Liandui.ldid FROM Liandui INNER JOIN ntxx ON Liandui.ldid = ntxx.ldid inner JOIN mhzsdc on mhzsdc.ntID=ntxx.ntID where Liandui.ldid=@ldid and YEAR(mhzsdc.dcdate) = @dcyear) mh group by dcdate order by dcdate desc";
        private const string QUERY_ALL_AVG = "select dcdate, AVG(pjzhugao) pjzhugao, AVG(pjyeling) pjyeling, AVG(pjguozhishu) pjguozhishu, AVG(pjlingshu) pjlingshu, AVG(pjguojieshu) pjguojieshu, AVG(pjdsyk) pjdsyk, AVG(pjzjrzzl) pjzjrzzl from mhzsdc where YEAR(dcdate) = @dcyear group by dcdate order by dcdate desc";
        //private const string Delete_zs = "delete from mhzsdc where mhzhdcid = @mhzhdcid";
        //private const string QUERY_SUM_SF = "select ldnt.ldmc, SUM(sj.bqjfl) bqjfl, sum(sj.dgzfl) dgzfl, sum(sj.tjsdzl) tjsdzl, SUM(sj.tjsll) tjsll from (select nt.ntID ntID, nt.ldid ldid, ld.ldmc ldmc from ntxx nt inner join Liandui ld on nt.ldid = ld.ldid) as ldnt inner join ShifeiJuece as sj on sj.ntID = ldnt.ntID where sj.jcnd=@jcnd group by ldnt.ldmc";
        //private const string QUERY_ALL_SF = "select '合计' as ldmc, SUM(sj.bqjfl) bqjfl, sum(sj.dgzfl) dgzfl, sum(sj.tjsdzl) tjsdzl, SUM(sj.tjsll) tjsll from ShifeiJuece as sj where sj.jcnd=@jcnd";
        //private const string QUERY_SUM_SF = "select ldnt.ldmc, SUM(sj.bqjfl) bqjfl, sum(sj.dgzfl) dgzfl, sum(sj.tjsdzl) tjsdzl, SUM(sj.tjsll) tjsll from (select nt.ntID ntID, nt.ldid ldid, ld.ldmc ldmc from ntxx nt inner join Liandui ld on nt.ldid = ld.ldid) as ldnt inner join ShifeiJuece as sj on sj.ntID = ldnt.ntID where sj.jcnd=@jcnd group by ldnt.ldmc union all select '合计' as ldmc, SUM(sj.bqjfl) bqjfl, sum(sj.dgzfl) dgzfl, sum(sj.tjsdzl) tjsdzl, SUM(sj.tjsll) tjsll from ShifeiJuece as sj where sj.jcnd=@tcjcnd";
       
        //手机在线访问新增
        private const string QUERY_MHZS_BY_ID = "SELECT mhzsdc.*, ntxx.mc as ntmc from mhzsdc INNER JOIN ntxx ON mhzsdc.ntID = ntxx.ntID where mhzsdc.mhzhdcid=@mhzhdcid";
        //private const string SELECT_USER_MHZSDC = "select top 20 m.mhzhdcid dcid, m.dcdate dcdate, nt.mc ntmc from mhzsdc m inner join ntxx nt on m.ntID=nt.ntID where m.userid=@userid order by dcdate desc";
        private const string SELECT_USER_MHZSDC = "select top 20 m.mhzhdcid dcid, m.dcdate dcdate, nt.mc ntmc from ntxx nt inner join  mhzsdc m on m.ntID=nt.ntID where m.ntID in(select ntID from usernt where usernt.userid=@userid) order by dcdate desc";
        private const string QUERY_MHZS_ORIGIN_BY_ID = "select * from mzdc where mzdc.mhzhdcid=@mhzhdcid";

        

        /// <summary>
        /// 插入棉花长势主表
        /// </summary>
        /// <param name="mhzhdcid">长势调查id</param>
        /// <param name="userid">用户id</param>
        /// <param name="ntID">农田id</param>
        /// <param name="dcdate">调查日期</param>
        /// <param name="jd">精度</param>
        /// <param name="wd">纬度</param>
        /// <returns></returns>
        public bool Insert_mhzs(string mhzhdcid, int userid, string username, int ntID, string ntmc, DateTime dcdate, decimal jd, decimal wd)
        {
            SqlParameter[] p_nh ={
                new SqlParameter("@mhzhdcid",SqlDbType.VarChar, 14),
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@username",SqlDbType.VarChar, 10),
                new SqlParameter("@ntID",SqlDbType.Int),
                new SqlParameter("@ntmc",SqlDbType.VarChar, 20),
                new SqlParameter("@dcdate",SqlDbType.Date),
                new SqlParameter("@jd",SqlDbType.Decimal),
                new SqlParameter("@wd",SqlDbType.Decimal)
                                };
            p_nh[0].Value = mhzhdcid;
            p_nh[1].Value = userid;
            p_nh[2].Value = username;
            p_nh[3].Value = ntID;
            p_nh[4].Value = ntmc;
            p_nh[5].Value = dcdate;
            p_nh[6].Value = jd;
            p_nh[7].Value = wd;

            int val = SqlHelper.ExecuteNonQuery(SqlHelper.ConStr, CommandType.Text, INSERT_MHZS, p_nh);
            return val > 0;
        }

        /// <summary>
        /// 插入棉花长势主表
        /// </summary>
        /// <param name="zhangshi">棉花长势对象</param>
        /// <returns></returns>
        public bool Insert_mhzs(Zhangshi zhangshi)
        {
            return Insert_mhzs(zhangshi.mhzhdcid, zhangshi.userid, zhangshi.username, zhangshi.ntID, zhangshi.ntmc, zhangshi.dcdate, zhangshi.jd, zhangshi.wd);
        }

        /// <summary>
        /// 插入棉花长势子表
        /// </summary>
        /// <param name="mzdcid">棉株调查id</param>
        /// <param name="mhzhdcid">长势调查id（主表）</param>
        /// <param name="zhugao">株高</param>
        /// <param name="yeling">叶龄</param>
        /// <param name="guozhishu">果枝数</param>
        /// <param name="lingshu">铃数</param>
        /// <param name="guojieshu">果节数</param>
        /// <param name="dsyk">倒四叶宽</param>
        /// <param name="zjrzzl">主茎日增长量</param>
        /// <param name="weizhi">调查位置</param>
        /// <returns></returns>
        public bool Insert_mzdc(string mzdcid, string mhzhdcid, decimal zhugao, decimal yeling, decimal guozhishu, decimal lingshu, decimal guojieshu, decimal dsyk, decimal zjrzzl, string weizhi)
        {
            SqlParameter[] p_nh ={
                new SqlParameter("@mzdcid",SqlDbType.VarChar, 14),
                new SqlParameter("@mhzhdcid",SqlDbType.VarChar, 14),
                new SqlParameter("@zhugao",SqlDbType.Decimal),
                new SqlParameter("@yeling",SqlDbType.Decimal),
                new SqlParameter("@guozhishu",SqlDbType.Decimal),
                new SqlParameter("@lingshu",SqlDbType.Decimal),
                new SqlParameter("@guojieshu",SqlDbType.Decimal),
                new SqlParameter("@dsyk",SqlDbType.Decimal),
                new SqlParameter("@zjrzzl",SqlDbType.Decimal),
                new SqlParameter("@weizhi",SqlDbType.VarChar, 10)
                                };
            p_nh[0].Value = mzdcid;
            p_nh[1].Value = mhzhdcid;
            p_nh[2].Value = zhugao;
            p_nh[3].Value = yeling;
            p_nh[4].Value = guozhishu;
            p_nh[5].Value = lingshu;
            p_nh[6].Value = guojieshu;
            p_nh[7].Value = dsyk;
            p_nh[8].Value = zjrzzl;
            p_nh[9].Value = weizhi;

            int val = SqlHelper.ExecuteNonQuery(SqlHelper.ConStr, CommandType.Text, INSERT_MZDC, p_nh);
            return val > 0;
        }

        /// <summary>
        /// 插入棉株调查子表
        /// </summary>
        /// <param name="mianzhu">棉株调查对象</param>
        /// <returns></returns>
        public bool Insert_mzdc(Mianzhu mianzhu)
        {
            return Insert_mzdc(mianzhu.mzdcid, mianzhu.mhzhdcid, mianzhu.zhugao, mianzhu.yeling, mianzhu.guozhishu, mianzhu.lingshu, mianzhu.guojieshu, mianzhu.dsyk, mianzhu.zjrzzl, mianzhu.weizhi);
        }

        /// <summary>
        /// 取得棉田一次调查的详细信息，包括平均值以及专家决策，适用于手机查看
        /// </summary>
        /// <param name="mhzhdcid">主键id</param>
        /// <returns></returns>
        public DataSet query_mhzs(string mhzhdcid)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_ZS_MHID, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@mhzhdcid", mhzhdcid) });
            return ds_nh;
        }

        /// <summary>
        /// 取得某年度一块棉田的所有长势调查记录
        /// </summary>
        /// <param name="ntmc">农田编号</param>
        /// <param name="dcyear">调查年度</param>
        /// <returns></returns>
        public DataSet query_sum_mhzs(string ntmc, int dcyear)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_ZS, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@ntmc", ntmc), new SqlParameter("@dcyear", dcyear) });
            return ds_nh;
        }


        /// <summary>
        /// 取得某年度一块棉田的所有长势调查记录
        /// </summary>
        /// <param name="ntmc">农田编号</param>
        /// <param name="dcyear">调查年度</param>
        /// <returns></returns>
        public DataSet query_sum_mhzs(int ntID, int dcyear)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_ZS_NTID, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@ntID", ntID), new SqlParameter("@dcyear", dcyear) });
            return ds_nh;
        }

        /// <summary>
        /// 取得某年度一块棉田的平均长势调查记录，调查点的平均，用于统计图表
        /// </summary>
        /// <param name="ntID">农田id</param>
        /// <param name="dcyear">调查年度</param>
        /// <returns></returns>
        public DataSet query_nt_avg_mhzs(int ntID, int dcyear)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_NT_AVG, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@ntID", ntID), new SqlParameter("@dcyear", dcyear) });
            return ds_nh;
        }


        /// <summary>
        /// 取得某年度某连队平均长势调查数据，用于统计图表
        /// </summary>
        /// <param name="ldid">连队id</param>
        /// <param name="dcyear">调查年度</param>
        /// <returns></returns>
        public DataSet query_ld_avg_mhzs(int ldid, int dcyear)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_LD_AVG, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@ldid", ldid), new SqlParameter("@dcyear", dcyear) });
            return ds_nh;
        }


        /// <summary>
        /// 取得某年度某团场总体平均长势调查数据，用于统计图表
        /// </summary>
        /// <param name="dcyear">调查年度</param>
        /// <returns></returns>
        public DataSet query_all_avg_mhzs(int dcyear)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_ALL_AVG, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@dcyear", dcyear) });
            return ds_nh;
        }

        /// <summary>
        /// 取得一次调查的专家决策信息
        /// </summary>
        /// <param name="mhzhdcid">调查id</param>
        /// <returns></returns>
        public DataSet query_jc(string mhzhdcid)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_JC, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@mhzhdcid", mhzhdcid) });
            return ds_nh;
        }

        /// <summary>
        /// 取得某棉田一个调查点的详细记录，包括子表调查情况
        /// </summary>
        /// <param name="mhzhdcid">长势调查的主表id</param>
        /// <returns></returns>
        public DataSet query_mzxq(string mhzhdcid)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, 
                CommandType.Text, 
                QUERY_MZZS, ds_nh, 
                Tname,
                new SqlParameter[] { new SqlParameter("@m1", mhzhdcid), new SqlParameter("@m2", mhzhdcid), new SqlParameter("@m3", mhzhdcid), new SqlParameter("@m4", mhzhdcid), new SqlParameter("@m5", mhzhdcid) });
            return ds_nh;
        }

        /// <summary>
        /// 更新苗情评价信息
        /// </summary>
        /// <param name="mqpj">苗情评价信息</param>
        /// <returns></returns>
        public bool Update_mqpj(string mqpj, string mhzhdcid)
        {
            SqlParameter[] p_nh ={
                new SqlParameter("@mqpj",SqlDbType.VarChar, 1000),
                new SqlParameter("@mhzhdcid",SqlDbType.VarChar, 14)
                                 };
            p_nh[0].Value = mqpj;
            p_nh[1].Value = mhzhdcid;
            string sql = "update mhzsdc set mqpj = @mqpj where mhzhdcid = @mhzhdcid";
            int val = SqlHelper.ExecuteNonQuery(SqlHelper.ConStr, CommandType.Text, sql, p_nh);
            if (val > 0)
            { return true; }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新栽培措施信息
        /// </summary>
        /// <param name="zpcs">栽培措施信息</param>
        /// <returns></returns>
        public bool Update_zpcs(string zpcs, string mhzhdcid)
        {
            SqlParameter[] p_nh ={
                new SqlParameter("@zpcs",SqlDbType.VarChar, 2000),
                new SqlParameter("@mhzhdcid",SqlDbType.VarChar, 14)
                                 };
            p_nh[0].Value = zpcs;
            p_nh[1].Value = mhzhdcid;
            string sql = "update mhzsdc set zpcs = @zpcs where mhzhdcid = @mhzhdcid";
            int val = SqlHelper.ExecuteNonQuery(SqlHelper.ConStr, CommandType.Text, sql, p_nh);
            if (val > 0)
            { return true; }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除长势调查记录，先删除所有子表，再删除主表
        /// </summary>
        /// <param name="mhzhdcid">长势调查主表的id</param>
        /// <returns></returns>
        public bool Delete_mhzs(string mhzhdcid)
        {
            SqlParameter[] p_nh ={
                new SqlParameter("@mhzhdcid",SqlDbType.VarChar,14)
                                };
            p_nh[0].Value = mhzhdcid;

            string del_mhzsdc = "delete from mhzsdc where mhzhdcid = @mhzhdcid";
            int val = SqlHelper.ExecuteNonQuery(SqlHelper.ConStr, CommandType.Text, del_mhzsdc, p_nh);
            return val > 0;

            //string del_mzdc = "delete from mzdc where mhzhdcid = @mhzhdcid";
            //int val = SqlHelper.ExecuteNonQuery(SqlHelper.ConStr, CommandType.Text, del_mzdc, p_nh);
            //if (val <= 0)
            //{ 
            //    return false;
            //}
            //else
            //{
            //    string del_mhzsdc = "delete from mhzsdc where mhzhdcid = @mhzhdcid";
            //    val = SqlHelper.ExecuteNonQuery(SqlHelper.ConStr, CommandType.Text, del_mhzsdc, p_nh);
            //    if (val > 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
        }


        /// <summary>
        /// 获取棉株调查列表以及按照边行和中间行统计的详情
        /// </summary>
        /// <param name="madcid"></param>
        /// <returns></returns>
        public DataSet get_zhdc_by_id(string mhzhdcid)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_MHZS_BY_ID, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@mhzhdcid", mhzhdcid) });
            //SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_NTYF + sql_txt, ds_nh, Tname);
            return ds_nh;
        }



        /// <summary>
        /// 获取棉株调查原始数据列表，不添加统计功能
        /// </summary>
        /// <param name="madcid"></param>
        /// <returns></returns>
        public DataSet get_zhdc_origin_by_id(string mhzhdcid)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_MHZS_ORIGIN_BY_ID, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@mhzhdcid", mhzhdcid) });
            //SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_NTYF + sql_txt, ds_nh, Tname);
            return ds_nh;
        }

        /// <summary>
        /// 获取调查列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable get_dclist(int userid)
        {
            DataSet ds_nh = new DataSet();
            string[] Tname = { "Tnh" };
            SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, SELECT_USER_MHZSDC, ds_nh, Tname, new SqlParameter[] { new SqlParameter("@userid", userid) });
            //SqlHelper.FillDataset(SqlHelper.ConStr, CommandType.Text, QUERY_NTYF + sql_txt, ds_nh, Tname);
            return ds_nh.Tables[0];
        }


        //public bool Delete_mhzsdc(string mhzhdcid)
        //{
        //    SqlParameter[] p_my ={
        //        new SqlParameter("@mhzhdcid",SqlDbType.VarChar, 14)
        //                        };
        //    p_my[0].Value = mhzhdcid;
        //    int val = SqlHelper.ExecuteNonQuery(SqlHelper.ConStr, CommandType.Text, Delete_zs, p_my);
        //    if (val > 0)
        //    { return true; }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
