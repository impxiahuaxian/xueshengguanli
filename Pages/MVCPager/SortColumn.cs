using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace MVC
{
    public class SortColumn
    {
        public SortColumn()
        {
            _DescAsc = DescAsc.Asc;
            _ColumnName = "ID";
        }
        public SortColumn(string ColumnName, DescAsc descAsc)
        {
            _DescAsc = descAsc;
            _ColumnName = ColumnName;
        }
        private string _ColumnName;
        private DescAsc _DescAsc;
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }
        public DescAsc DescAsc
        {
            get { return _DescAsc; }
            set { _DescAsc = value; }
        }
    }

    public enum DescAsc
    {
        Asc = 0,
        Desc = 1
    }
}
