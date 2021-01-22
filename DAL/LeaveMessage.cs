using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class LeaveMessage
    {
        public LeaveMessage()
        {

        }
        public int Add(Maticsoft.Model.LeaveMessage model)
        {
            StringBuilder sqlString = new StringBuilder();
            sqlString.Append("insert into LeaveMessage (");
            sqlString.Append("UserName,Context,Time,UserID)");
            sqlString.Append("values(");
            sqlString.Append("@UserName,@Context,@Time,@UserID)");
            sqlString.Append(";select @@IDENTITY");
            SqlParameter[] sqlParameters =  {
            new SqlParameter("@UserName",SqlDbType.NVarChar,50),
            new SqlParameter("@Context", SqlDbType.NVarChar,50),
            new SqlParameter("@Time", SqlDbType.DateTime, 50),
            new SqlParameter("@UserID", SqlDbType.NVarChar, 50)};
            sqlParameters[0].Value = model.UserName;
            sqlParameters[1].Value = model.Context;
            sqlParameters[2].Value = model.Time;
            sqlParameters[3].Value = model.UserID;
            object obj = DbHelperSQL.GetSingle(sqlString.ToString(), sqlParameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM LeaveMessage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public Maticsoft.Model.LeaveMessage DataRowToModel(DataRow row)
        {
            Maticsoft.Model.LeaveMessage model = new Maticsoft.Model.LeaveMessage();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Context"] != null)
                {
                    model.Context = row["Context"].ToString();
                }
                if (row["Time"] != null)
                {
                    model.Time = row["Time"].ToString();
                }
                if (row["UserID"] != null)
                {
                    model.UserID = row["UserID"].ToString();
                }
            }
            return model;
        }
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from LeaveMessage T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
