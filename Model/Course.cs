using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course
	{
		public Course()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _teacher;
		private string _xf;
		private string _sc;
		private string _str1;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher
		{
			set{ _teacher=value;}
			get{return _teacher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XF
		{
			set{ _xf=value;}
			get{return _xf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SC
		{
			set{ _sc=value;}
			get{return _sc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str1
		{
			set{ _str1=value;}
			get{return _str1;}
		}
		#endregion Model

	}
}

