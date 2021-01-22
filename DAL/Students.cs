using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Students
	/// </summary>
	public partial class Students
	{
		public Students()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Students"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Students");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.Students model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Students(");
			strSql.Append("Name,Sex,Age,UserJG,CYName,CYGX,LXDH,Phone,UserSFZ,ZPPic,SFZPic,JKZPic,ZGZPic,BYZPic,IsZJ,IsBX,IsJDLK,IsYXQ,IsJQSG,XYLY,IsJY,JYGZ,SGRQ,XGRQ,Remark,IsHMD,UserPSD,Str1,Str2,Str3,Str4,Str5,Str6,Str7,Str8)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Sex,@Age,@UserJG,@CYName,@CYGX,@LXDH,@Phone,@UserSFZ,@ZPPic,@SFZPic,@JKZPic,@ZGZPic,@BYZPic,@IsZJ,@IsBX,@IsJDLK,@IsYXQ,@IsJQSG,@XYLY,@IsJY,@JYGZ,@SGRQ,@XGRQ,@Remark,@IsHMD,@UserPSD,@Str1,@Str2,@Str3,@Str4,@Str5,@Str6,@Str7,@Str8)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Age", SqlDbType.NVarChar,50),
					new SqlParameter("@UserJG", SqlDbType.NVarChar,50),
					new SqlParameter("@CYName", SqlDbType.NVarChar,50),
					new SqlParameter("@CYGX", SqlDbType.NVarChar,50),
					new SqlParameter("@LXDH", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@UserSFZ", SqlDbType.NVarChar,50),
					new SqlParameter("@ZPPic", SqlDbType.NVarChar,50),
					new SqlParameter("@SFZPic", SqlDbType.NVarChar,50),
					new SqlParameter("@JKZPic", SqlDbType.NVarChar,50),
					new SqlParameter("@ZGZPic", SqlDbType.NVarChar,50),
					new SqlParameter("@BYZPic", SqlDbType.NVarChar,50),
					new SqlParameter("@IsZJ", SqlDbType.NVarChar,50),
					new SqlParameter("@IsBX", SqlDbType.NVarChar,50),
					new SqlParameter("@IsJDLK", SqlDbType.NVarChar,50),
					new SqlParameter("@IsYXQ", SqlDbType.NVarChar,50),
					new SqlParameter("@IsJQSG", SqlDbType.NVarChar,50),
					new SqlParameter("@XYLY", SqlDbType.NVarChar,50),
					new SqlParameter("@IsJY", SqlDbType.NVarChar,50),
					new SqlParameter("@JYGZ", SqlDbType.NVarChar,50),
					new SqlParameter("@SGRQ", SqlDbType.NVarChar,50),
					new SqlParameter("@XGRQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@IsHMD", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPSD", SqlDbType.NVarChar,50),
					new SqlParameter("@Str1", SqlDbType.NVarChar,50),
					new SqlParameter("@Str2", SqlDbType.NVarChar,50),
					new SqlParameter("@Str3", SqlDbType.NVarChar,50),
					new SqlParameter("@Str4", SqlDbType.NVarChar,50),
					new SqlParameter("@Str5", SqlDbType.NVarChar,50),
					new SqlParameter("@Str6", SqlDbType.NVarChar,50),
					new SqlParameter("@Str7", SqlDbType.NVarChar,50),
					new SqlParameter("@Str8", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.Age;
			parameters[3].Value = model.UserJG;
			parameters[4].Value = model.CYName;
			parameters[5].Value = model.CYGX;
			parameters[6].Value = model.LXDH;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.UserSFZ;
			parameters[9].Value = model.ZPPic;
			parameters[10].Value = model.SFZPic;
			parameters[11].Value = model.JKZPic;
			parameters[12].Value = model.ZGZPic;
			parameters[13].Value = model.BYZPic;
			parameters[14].Value = model.IsZJ;
			parameters[15].Value = model.IsBX;
			parameters[16].Value = model.IsJDLK;
			parameters[17].Value = model.IsYXQ;
			parameters[18].Value = model.IsJQSG;
			parameters[19].Value = model.XYLY;
			parameters[20].Value = model.IsJY;
			parameters[21].Value = model.JYGZ;
			parameters[22].Value = model.SGRQ;
			parameters[23].Value = model.XGRQ;
			parameters[24].Value = model.Remark;
			parameters[25].Value = model.IsHMD;
			parameters[26].Value = model.UserPSD;
			parameters[27].Value = model.Str1;
			parameters[28].Value = model.Str2;
			parameters[29].Value = model.Str3;
			parameters[30].Value = model.Str4;
			parameters[31].Value = model.Str5;
			parameters[32].Value = model.Str6;
			parameters[33].Value = model.Str7;
			parameters[34].Value = model.Str8;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Students model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Students set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Age=@Age,");
			strSql.Append("UserJG=@UserJG,");
			strSql.Append("CYName=@CYName,");
			strSql.Append("CYGX=@CYGX,");
			strSql.Append("LXDH=@LXDH,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("UserSFZ=@UserSFZ,");
			strSql.Append("ZPPic=@ZPPic,");
			strSql.Append("SFZPic=@SFZPic,");
			strSql.Append("JKZPic=@JKZPic,");
			strSql.Append("ZGZPic=@ZGZPic,");
			strSql.Append("BYZPic=@BYZPic,");
			strSql.Append("IsZJ=@IsZJ,");
			strSql.Append("IsBX=@IsBX,");
			strSql.Append("IsJDLK=@IsJDLK,");
			strSql.Append("IsYXQ=@IsYXQ,");
			strSql.Append("IsJQSG=@IsJQSG,");
			strSql.Append("XYLY=@XYLY,");
			strSql.Append("IsJY=@IsJY,");
			strSql.Append("JYGZ=@JYGZ,");
			strSql.Append("SGRQ=@SGRQ,");
			strSql.Append("XGRQ=@XGRQ,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("IsHMD=@IsHMD,");
			strSql.Append("UserPSD=@UserPSD,");
			strSql.Append("Str1=@Str1,");
			strSql.Append("Str2=@Str2,");
			strSql.Append("Str3=@Str3,");
			strSql.Append("Str4=@Str4,");
			strSql.Append("Str5=@Str5,");
			strSql.Append("Str6=@Str6,");
			strSql.Append("Str7=@Str7,");
			strSql.Append("Str8=@Str8");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Age", SqlDbType.NVarChar,50),
					new SqlParameter("@UserJG", SqlDbType.NVarChar,50),
					new SqlParameter("@CYName", SqlDbType.NVarChar,50),
					new SqlParameter("@CYGX", SqlDbType.NVarChar,50),
					new SqlParameter("@LXDH", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@UserSFZ", SqlDbType.NVarChar,50),
					new SqlParameter("@ZPPic", SqlDbType.NVarChar,50),
					new SqlParameter("@SFZPic", SqlDbType.NVarChar,50),
					new SqlParameter("@JKZPic", SqlDbType.NVarChar,50),
					new SqlParameter("@ZGZPic", SqlDbType.NVarChar,50),
					new SqlParameter("@BYZPic", SqlDbType.NVarChar,50),
					new SqlParameter("@IsZJ", SqlDbType.NVarChar,50),
					new SqlParameter("@IsBX", SqlDbType.NVarChar,50),
					new SqlParameter("@IsJDLK", SqlDbType.NVarChar,50),
					new SqlParameter("@IsYXQ", SqlDbType.NVarChar,50),
					new SqlParameter("@IsJQSG", SqlDbType.NVarChar,50),
					new SqlParameter("@XYLY", SqlDbType.NVarChar,50),
					new SqlParameter("@IsJY", SqlDbType.NVarChar,50),
					new SqlParameter("@JYGZ", SqlDbType.NVarChar,50),
					new SqlParameter("@SGRQ", SqlDbType.NVarChar,50),
					new SqlParameter("@XGRQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@IsHMD", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPSD", SqlDbType.NVarChar,50),
					new SqlParameter("@Str1", SqlDbType.NVarChar,50),
					new SqlParameter("@Str2", SqlDbType.NVarChar,50),
					new SqlParameter("@Str3", SqlDbType.NVarChar,50),
					new SqlParameter("@Str4", SqlDbType.NVarChar,50),
					new SqlParameter("@Str5", SqlDbType.NVarChar,50),
					new SqlParameter("@Str6", SqlDbType.NVarChar,50),
					new SqlParameter("@Str7", SqlDbType.NVarChar,50),
					new SqlParameter("@Str8", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.Age;
			parameters[3].Value = model.UserJG;
			parameters[4].Value = model.CYName;
			parameters[5].Value = model.CYGX;
			parameters[6].Value = model.LXDH;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.UserSFZ;
			parameters[9].Value = model.ZPPic;
			parameters[10].Value = model.SFZPic;
			parameters[11].Value = model.JKZPic;
			parameters[12].Value = model.ZGZPic;
			parameters[13].Value = model.BYZPic;
			parameters[14].Value = model.IsZJ;
			parameters[15].Value = model.IsBX;
			parameters[16].Value = model.IsJDLK;
			parameters[17].Value = model.IsYXQ;
			parameters[18].Value = model.IsJQSG;
			parameters[19].Value = model.XYLY;
			parameters[20].Value = model.IsJY;
			parameters[21].Value = model.JYGZ;
			parameters[22].Value = model.SGRQ;
			parameters[23].Value = model.XGRQ;
			parameters[24].Value = model.Remark;
			parameters[25].Value = model.IsHMD;
			parameters[26].Value = model.UserPSD;
			parameters[27].Value = model.Str1;
			parameters[28].Value = model.Str2;
			parameters[29].Value = model.Str3;
			parameters[30].Value = model.Str4;
			parameters[31].Value = model.Str5;
			parameters[32].Value = model.Str6;
			parameters[33].Value = model.Str7;
			parameters[34].Value = model.Str8;
			parameters[35].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Students ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Students ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Students GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,Sex,Age,UserJG,CYName,CYGX,LXDH,Phone,UserSFZ,ZPPic,SFZPic,JKZPic,ZGZPic,BYZPic,IsZJ,IsBX,IsJDLK,IsYXQ,IsJQSG,XYLY,IsJY,JYGZ,SGRQ,XGRQ,Remark,IsHMD,UserPSD,Str1,Str2,Str3,Str4,Str5,Str6,Str7,Str8 from Students ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.Students model=new Maticsoft.Model.Students();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Students DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Students model=new Maticsoft.Model.Students();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["Age"]!=null)
				{
					model.Age=row["Age"].ToString();
				}
				if(row["UserJG"]!=null)
				{
					model.UserJG=row["UserJG"].ToString();
				}
				if(row["CYName"]!=null)
				{
					model.CYName=row["CYName"].ToString();
				}
				if(row["CYGX"]!=null)
				{
					model.CYGX=row["CYGX"].ToString();
				}
				if(row["LXDH"]!=null)
				{
					model.LXDH=row["LXDH"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["UserSFZ"]!=null)
				{
					model.UserSFZ=row["UserSFZ"].ToString();
				}
				if(row["ZPPic"]!=null)
				{
					model.ZPPic=row["ZPPic"].ToString();
				}
				if(row["SFZPic"]!=null)
				{
					model.SFZPic=row["SFZPic"].ToString();
				}
				if(row["JKZPic"]!=null)
				{
					model.JKZPic=row["JKZPic"].ToString();
				}
				if(row["ZGZPic"]!=null)
				{
					model.ZGZPic=row["ZGZPic"].ToString();
				}
				if(row["BYZPic"]!=null)
				{
					model.BYZPic=row["BYZPic"].ToString();
				}
				if(row["IsZJ"]!=null)
				{
					model.IsZJ=row["IsZJ"].ToString();
				}
				if(row["IsBX"]!=null)
				{
					model.IsBX=row["IsBX"].ToString();
				}
				if(row["IsJDLK"]!=null)
				{
					model.IsJDLK=row["IsJDLK"].ToString();
				}
				if(row["IsYXQ"]!=null)
				{
					model.IsYXQ=row["IsYXQ"].ToString();
				}
				if(row["IsJQSG"]!=null)
				{
					model.IsJQSG=row["IsJQSG"].ToString();
				}
				if(row["XYLY"]!=null)
				{
					model.XYLY=row["XYLY"].ToString();
				}
				if(row["IsJY"]!=null)
				{
					model.IsJY=row["IsJY"].ToString();
				}
				if(row["JYGZ"]!=null)
				{
					model.JYGZ=row["JYGZ"].ToString();
				}
				if(row["SGRQ"]!=null)
				{
					model.SGRQ=row["SGRQ"].ToString();
				}
				if(row["XGRQ"]!=null)
				{
					model.XGRQ=row["XGRQ"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["IsHMD"]!=null)
				{
					model.IsHMD=row["IsHMD"].ToString();
				}
				if(row["UserPSD"]!=null)
				{
					model.UserPSD=row["UserPSD"].ToString();
				}
				if(row["Str1"]!=null)
				{
					model.Str1=row["Str1"].ToString();
				}
				if(row["Str2"]!=null)
				{
					model.Str2=row["Str2"].ToString();
				}
				if(row["Str3"]!=null)
				{
					model.Str3=row["Str3"].ToString();
				}
				if(row["Str4"]!=null)
				{
					model.Str4=row["Str4"].ToString();
				}
				if(row["Str5"]!=null)
				{
					model.Str5=row["Str5"].ToString();
				}
				if(row["Str6"]!=null)
				{
					model.Str6=row["Str6"].ToString();
				}
				if(row["Str7"]!=null)
				{
					model.Str7=row["Str7"].ToString();
				}
				if(row["Str8"]!=null)
				{
					model.Str8=row["Str8"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,Sex,Age,UserJG,CYName,CYGX,LXDH,Phone,UserSFZ,ZPPic,SFZPic,JKZPic,ZGZPic,BYZPic,IsZJ,IsBX,IsJDLK,IsYXQ,IsJQSG,XYLY,IsJY,JYGZ,SGRQ,XGRQ,Remark,IsHMD,UserPSD,Str1,Str2,Str3,Str4,Str5,Str6,Str7,Str8 ");
			strSql.Append(" FROM Students ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Name,Sex,Age,UserJG,CYName,CYGX,LXDH,Phone,UserSFZ,ZPPic,SFZPic,JKZPic,ZGZPic,BYZPic,IsZJ,IsBX,IsJDLK,IsYXQ,IsJQSG,XYLY,IsJY,JYGZ,SGRQ,XGRQ,Remark,IsHMD,UserPSD,Str1,Str2,Str3,Str4,Str5,Str6,Str7,Str8 ");
			strSql.Append(" FROM Students ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Students ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Students T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Students";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

