using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using Maticsoft.DBUtility;
using MVC;
using System.Linq;
using System.Text;
namespace Maticsoft.BLL
{
	/// <summary>
	/// Users
	/// </summary>
	public partial class Users
	{
		private readonly Maticsoft.DAL.Users dal=new Maticsoft.DAL.Users();
		public Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Maticsoft.Model.Users model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Users model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Users GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.Users GetModelByCache(int ID)
		{
			
			string CacheKey = "UsersModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.Users)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Users> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.Users> modelList = new List<Maticsoft.Model.Users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.Users model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
        #region  ExtensionMethod

        public bool Login(string LoginName, string LoginPsd)
        {
            string str = string.Format(" Phone='{0}' and UserPSD='{1}'  ", LoginName, LoginPsd);
            List<Maticsoft.Model.Users> list = GetModelList(str);
            if (list.Count != 0)
            {
                Maticsoft.DBUtility.AuthenHelper.Logout();
                AuthenHelper.CreateTicket("学生-" + list[0].UserName, list[0].ID.ToString(), false, DateTime.Now.AddHours(2), "");
                return true;
            }
            else
                return  false;
        }

        public bool Regist(string Phone, string UserPSD,string Name,string QQ)
        {
            List<Maticsoft.Model.Users> list = GetModelList(" Phone='" + Phone + "'");
            if (list.Count != 0)
            {
                return false;
            }
            else
            {
                Maticsoft.Model.Users model = new Model.Users();
                model.UserName = Name;
                model.Phone = Phone;
                model.UserPSD = UserPSD;
                model.QQ = QQ;
                dal.Add(model);
                return true;
            }
        }

        public bool Edit(Model.Users model)
        {
            if (model.ID == 0)
            {
                dal.Add(model);
                return true;
            }
            else
            {

                return dal.Update(model);
            }
        }

        public PagedList<Model.Users> GetPapedList(string strWhere, string orderby, int pageIndex)
        {
            int pageSize = 10;
            int totalItemCount = dal.GetRecordCount(strWhere);
            int startIndex = pageIndex <= 1 ? 1 : ((pageIndex - 1) * pageSize) + 1;
            int endIndex = pageIndex <= 1 ? pageSize : ((pageIndex) * pageSize);
            List<Model.Users> modelList = DataTableToList(dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0]);
            IQueryable<Model.Users> list = modelList.AsQueryable();
            PagedList<Model.Users> pageList = list.OrderByDescending(m => m.ID).ToPagedList(pageIndex, pageSize, totalItemCount);
            return pageList;
        }

        public PagedList<Model.Users> Search(ViewModel.Usersearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder(" 1=1");
            if (!string.IsNullOrEmpty(model.Phone))
            {
                sb.Append(" And Phone like '%" + model.Phone + "%'");
            }
            if (!string.IsNullOrEmpty(model.UsersName))
            {
                sb.Append(" And UsersName like '%" + model.UsersName + "%'");
            }
            return GetPapedList(sb.ToString(), "ID desc", model.PageIndex);
        }

        public bool LogOut()
        {
            try
            {
                AuthenHelper.Logout();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetUsersName()
        {
            return AuthenHelper.GetLoginUserName();
        }

        public static string GetNowUserID()
        {
            return AuthenHelper.GetLoginUsersData();
        }

        public static string GetNowUserSFZ()
        {
            string ID = AuthenHelper.GetLoginUsersData();
            if (string.IsNullOrEmpty(ID))
            {
                return "";
            }
            Maticsoft.DAL.Users dale = new DAL.Users();
            Maticsoft.Model.Users model = dale.GetModel(Convert.ToInt32(ID));
            return model.QQ;


        }
        #endregion  ExtensionMethod
	}
}

