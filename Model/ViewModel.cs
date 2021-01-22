using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.ViewModel
{
    public class AdminSearch
    {
        public string Name { get; set; }
        public int PageIndex { get; set; }
    }
    public class ClassesSearch
    {
        public string XB { get; set; }
        public string BH { get; set; }
        public int PageIndex { get; set; }
    }
    public class RecordsSearch
    {
        public string OrderID { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string TemplateID { get; set; }
        public string CID { get; set; }
        public int PageIndex { get; set; }
    }
    public class StudentsSearch
    {
        public string IsZJ { get; set; }
        public string IsJDLK { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string UserSFZ { get; set; }
        public int PageIndex { get; set; }
    }

    public class NewsInfoSearch
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string UserID { get; set; }
        public int PageIndex { get; set; }
    }

    public class Usersearch
    {
        public string Phone { get; set; }
        public string UsersName { get; set; }
        public int PageIndex { get; set; }
    }

    public class CourseSearch
    {
        public string Name { get; set; }
      
        public string Teacher { get; set; }
     
        
        public int PageIndex { get; set; }
    }
    public class LeaveMessageSearch
    {
        public string UserName { get; set; }

        public string Context { get; set; }
        public int PageIndex { get; set; }
        public int UserID { get; set; }
    }

    public class TeachersSearch
    {
        public string Name { get; set; }

        public string JSH { get; set; }


        public int PageIndex { get; set; }
    }
}
