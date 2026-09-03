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
	internal sealed class SqlInt64Storage : DataStorage // TypeDefIndex: 11400
	{
		// Fields
		private SqlInt64[] _values; // 0x50
	
		// Constructors
		public SqlInt64Storage(DataColumn column); // 0x000000018191E870-0x000000018191E9A0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x000000018191D060-0x000000018191DEA0
		public override int Compare(int recordNo1, int recordNo2); // 0x000000018191DF60-0x000000018191E020
		public override int CompareValueTo(int recordNo, object value); // 0x000000018191DEA0-0x000000018191DF60
		public override object ConvertValue(object value); // 0x000000018191E1E0-0x000000018191E260
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181918E10-0x0000000181918E60
		public override object Get(int record); // 0x000000018191E5A0-0x000000018191E620
		public override bool IsNull(int record); // 0x000000018191E620-0x000000018191E6A0
		public override void Set(int record, object value); // 0x000000018191E810-0x000000018191E870
		public override void SetCapacity(int capacity); // 0x000000018191E6A0-0x000000018191E770
		public override object ConvertXmlToObject(string s); // 0x000000018191E260-0x000000018191E470
		public override string ConvertObjectToXml(object value); // 0x000000018191E020-0x000000018191E1E0
		protected override object GetEmptyStorage(int recordCount); // 0x000000018191E560-0x000000018191E5A0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x000000018191E470-0x000000018191E560
		protected override void SetStorage(object store, BitArray nullbits); // 0x000000018191E770-0x000000018191E810
	}
}
