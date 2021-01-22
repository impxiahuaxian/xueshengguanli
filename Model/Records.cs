using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Records:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Records
	{
		public Records()
		{}
		#region Model
		private int _id;
		private string _cid;
		private string _orderid;
		private string _name;
		private string _phone;
		private string _sgrq;
		private string _xgrq;
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
		public string CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
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
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SGRQ
		{
			set{ _sgrq=value;}
			get{return _sgrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XGRQ
		{
			set{ _xgrq=value;}
			get{return _xgrq;}
		}
		#endregion Model

	}
}

