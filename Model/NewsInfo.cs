using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// NewsInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NewsInfo
	{
		public NewsInfo()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _time;
		private string _newscontent;
		private string _picid;
		private string _UserID;
		private string _str1;
		private string _str2;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicID
		{
			set{ _picid=value;}
			get{return _picid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _UserID=value;}
			get{return _UserID;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str1
		{
			set{ _str1=value;}
			get{return _str1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str2
		{
			set{ _str2=value;}
			get{return _str2;}
		}
		#endregion Model

	}
}

