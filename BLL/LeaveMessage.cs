using MVC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
   public partial class LeaveMessage
    {
        public LeaveMessage()
        {

        }
        private readonly Maticsoft.DAL.LeaveMessage dal = new DAL.LeaveMessage();
        public bool Add(Maticsoft.Model.LeaveMessage model)
        {
            if (model.ID == 0)
            {
                model.UserID = Maticsoft.BLL.Admin.GetNowUserID();
                model.Time = DateTime.Now.ToLongDateString();
                dal.Add(model);
                return true;
            }
            else
            {
                return false;
            }
        }
        public PagedList<Model.LeaveMessage> Search(ViewModel.LeaveMessageSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder(" 1=1");
            if (!string.IsNullOrEmpty(model.UserName))
            {
                sb.Append(" And Name like '%" + model.UserName + "%'");
            }
            if (!string.IsNullOrEmpty(model.Context))
            {
                sb.Append(" And Teacher like '%" + model.Context + "%'");
            }
            return GetPapedList(sb.ToString(), "ID desc", model.PageIndex);
        }
        public PagedList<Model.LeaveMessage> GetPapedList(string strWhere, string orderby, int pageIndex)
        {
            int pageSize = 10;
            int totalItemCount = dal.GetRecordCount(strWhere);
            int startIndex = pageIndex <= 1 ? 1 : ((pageIndex - 1) * pageSize) + 1;
            int endIndex = pageIndex <= 1 ? pageSize : ((pageIndex) * pageSize);
            List<Model.LeaveMessage> modelList = DataTableToList(dal.GetListByPage(strWhere, orderby, startIndex, endIndex).Tables[0]);
            IQueryable<Model.LeaveMessage> list = modelList.AsQueryable();
            PagedList<Model.LeaveMessage> pageList = list.OrderByDescending(m => m.ID).ToPagedList(pageIndex, pageSize, totalItemCount);
            return pageList;
        }
        public List<Maticsoft.Model.LeaveMessage> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.LeaveMessage> modelList = new List<Maticsoft.Model.LeaveMessage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.LeaveMessage model;
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

    }

    
}
