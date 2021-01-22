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
    /// Students
    /// </summary>
    public partial class Students
    {
        private readonly Maticsoft.DAL.Students dal = new Maticsoft.DAL.Students();
        public Students()
        { }
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
        public int Add(Maticsoft.Model.Students model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.Students model)
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Students GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Students GetModelByCache(int ID)
        {

            string CacheKey = "StudentsModel-" + ID;
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
                catch { }
            }
            return (Maticsoft.Model.Students)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Students> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Students> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Students> modelList = new List<Maticsoft.Model.Students>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Students model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

        public string Login(string LoginName, string LoginPsd, bool IsStay)
        {
            string str = string.Format(" UserSFZ='{0}' and UserPSD='{1}'  ", LoginName, LoginPsd);
            List<Maticsoft.Model.Students> list = GetModelList(str);
            if (list.Count != 0)
            {
                AuthenHelper.Logout();
                AuthenHelper.CreateTicket(list[0].Name, list[0].ID.ToString(), IsStay, DateTime.Now.AddHours(2), "");
                return "1";
            }
            else
                return "0";
        }

        public bool Edit(Model.Students model)
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

        public PagedList<Model.Students> GetPapedList(string strWhere, string orderby, int pageIndex)
        {
            int pageSize = 10;
            int totalItemCount = dal.GetRecordCount(strWhere);
            int startIndex = pageIndex <= 1 ? 1 : ((pageIndex - 1) * pageSize) + 1;
            int endIndex = pageIndex <= 1 ? pageSize : ((pageIndex) * pageSize);
            List<Model.Students> modelList = DataTableToList(dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0]);
            IQueryable<Model.Students> list = modelList.AsQueryable();
            PagedList<Model.Students> pageList = list.OrderByDescending(m => m.ID).ToPagedList(pageIndex, pageSize, totalItemCount);
            return pageList;
        }

        public PagedList<Model.Students> Search(ViewModel.StudentsSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder("  UserSFZ!='admin'");
            if (!string.IsNullOrEmpty(model.UserName))
            {
                sb.Append(" And Name like '%" + model.UserName + "%'");
            }
            if (!string.IsNullOrEmpty(model.UserSFZ))
            {
                sb.Append(" And UserSFZ like '%" + model.UserSFZ + "%'");
            }
            if (!string.IsNullOrEmpty(model.Phone))
            {
                sb.Append(" And Phone like '%" + model.Phone + "%'");
            }
            if (!string.IsNullOrEmpty(model.IsJDLK))
            {
                sb.Append(" And IsJDLK like '%" + model.IsJDLK + "%'");
            }
            if (!string.IsNullOrEmpty(model.IsZJ))
            {
                sb.Append(" And IsZJ like '%" + model.IsZJ + "%'");
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

        public static string GetUserName()
        {
            return AuthenHelper.GetLoginUserName();
        }

       

     

        #endregion  ExtensionMethod
    }
}

