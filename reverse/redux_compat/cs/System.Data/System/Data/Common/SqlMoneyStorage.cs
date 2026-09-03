/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.Common
{
	internal sealed class SqlMoneyStorage : DataStorage // TypeDefIndex: 11401
	{
		// Fields
		private SqlMoney[] _values; // 0x50
	
		// Constructors
		public SqlMoneyStorage(DataColumn column); // 0x00000001819201F0-0x0000000181920320
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x000000018191E9A0-0x000000018191F820
		public override int Compare(int recordNo1, int recordNo2); // 0x000000018191F8E0-0x000000018191F9A0
		public override int CompareValueTo(int recordNo, object value); // 0x000000018191F820-0x000000018191F8E0
		public override object ConvertValue(object value); // 0x000000018191FB60-0x000000018191FBE0
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181918E10-0x0000000181918E60
		public override object Get(int record); // 0x000000018191FF20-0x000000018191FFA0
		public override bool IsNull(int record); // 0x000000018191FFA0-0x0000000181920020
		public override void Set(int record, object value); // 0x0000000181920190-0x00000001819201F0
		public override void SetCapacity(int capacity); // 0x0000000181920020-0x00000001819200F0
		public override object ConvertXmlToObject(string s); // 0x000000018191FBE0-0x000000018191FDF0
		public override string ConvertObjectToXml(object value); // 0x000000018191F9A0-0x000000018191FB60
		protected override object GetEmptyStorage(int recordCount); // 0x000000018191FEE0-0x000000018191FF20
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x000000018191FDF0-0x000000018191FEE0
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001819200F0-0x0000000181920190
	}
}
