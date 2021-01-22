using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Teachers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Teachers
	{
		public Teachers()
		{}
		#region Model
		private int _id;
		private string _jsh;
		private string _sex;
		private string _psd;
		private string _name;
		private string _szx;
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
		public string JSH
		{
			set{ _jsh=value;}
			get{return _jsh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PSD
		{
			set{ _psd=value;}
			get{return _psd;}
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
		public string SZX
		{
			set{ _szx=value;}
			get{return _szx;}
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

