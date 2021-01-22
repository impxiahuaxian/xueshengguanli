using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Classes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Classes
	{
		public Classes()
		{}
		#region Model
		private int _id;
		private string _xb;
		private string _bh;
		private string _fdy;
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
		public string XB
		{
			set{ _xb=value;}
			get{return _xb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BH
		{
			set{ _bh=value;}
			get{return _bh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FDY
		{
			set{ _fdy=value;}
			get{return _fdy;}
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

