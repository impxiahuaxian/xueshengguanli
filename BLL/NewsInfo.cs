using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using MVC;
using System.Text;
using System.Linq;
namespace Maticsoft.BLL
{
	/// <summary>
	/// NewsInfo
	/// </summary>
	public partial class NewsInfo
	{
		private readonly Maticsoft.DAL.NewsInfo dal=new Maticsoft.DAL.NewsInfo();
		public NewsInfo()
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
		public int  Add(Maticsoft.Model.NewsInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.NewsInfo model)
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
		public Maticsoft.Model.NewsInfo GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.NewsInfo GetModelByCache(int ID)
		{
			
			string CacheKey = "NewsInfoModel-" + ID;
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
			return (Maticsoft.Model.NewsInfo)objModel;
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
		public List<Maticsoft.Model.NewsInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.NewsInfo> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.NewsInfo> modelList = new List<Maticsoft.Model.NewsInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.NewsInfo model;
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


        public bool Edit(Model.NewsInfo model)
        {
            if (model.ID == 0)
            {
                model.UserID = Maticsoft.BLL.Admin.GetNowUserID();
                model.Time = DateTime.Now.ToShortDateString();
                dal.Add(model);
                return true;
            }
            else
            {
                model.UserID = Maticsoft.BLL.Admin.GetNowUserID();
                model.Time = DateTime.Now.ToShortDateString();
                return dal.Update(model);
            }
        }

        public PagedList<Model.NewsInfo> GetPapedList(string strWhere, string orderby, int pageIndex)
        {
            int pageSize = 10;
            int totalItemCount = dal.GetRecordCount(strWhere);
            int startIndex = pageIndex <= 1 ? 1 : ((pageIndex - 1) * pageSize) + 1;
            int endIndex = pageIndex <= 1 ? pageSize : ((pageIndex) * pageSize);
            List<Model.NewsInfo> modelList = DataTableToList(dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0]);
            IQueryable<Model.NewsInfo> list = modelList.AsQueryable();
            PagedList<Model.NewsInfo> pageList = list.OrderByDescending(m => m.ID).ToPagedList(pageIndex, pageSize, totalItemCount);
            return pageList;
        }

        public PagedList<Model.NewsInfo> Search(ViewModel.NewsInfoSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder(" 1=1");
            if (!string.IsNullOrEmpty(model.Title))
            {
                sb.Append(" And Title like '%" + model.Title + "%'");
            }
            if (!string.IsNullOrEmpty(model.Category))
            {
                sb.Append(" And Str1 like '%" + model.Category + "%'");
            }
            if (!string.IsNullOrEmpty(model.UserID))
            {
                sb.Append(" And UserID='" + model.UserID + "'");
            }
            return GetPapedList(sb.ToString(), "ID desc", model.PageIndex);
        }

        public PagedList<Model.NewsInfo> MSearch(ViewModel.NewsInfoSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder("  UserID='"+Maticsoft.BLL.Users.GetNowUserID()+"'");
            if (!string.IsNullOrEmpty(model.Title))
            {
                sb.Append(" And Title like '%" + model.Title + "%'");
            }
            if (!string.IsNullOrEmpty(model.Category))
            {
                sb.Append(" And Str1 like '%" + model.Category + "%'");
            }
           
            return GetPapedList(sb.ToString(), "ID desc", model.PageIndex);
        }

        #endregion  ExtensionMethod
	}
}

