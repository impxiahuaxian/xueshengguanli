using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users()
		{}
		#region Model
		private int _id;
		private string _phone;
		private string _UserPSD;
		private string _UserName;
		private string _picid;
		private string _age;
		private string _sex;
		private string _major;
		private string _remark;
		private string _address;
		private string _qq;
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
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPSD
		{
			set{ _UserPSD=value;}
			get{return _UserPSD;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _UserName=value;}
			get{return _UserName;}
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
		public string Age
		{
			set{ _age=value;}
			get{return _age;}
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
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		#endregion Model

	}
}

