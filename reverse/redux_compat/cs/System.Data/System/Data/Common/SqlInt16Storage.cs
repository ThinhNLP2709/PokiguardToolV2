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
	internal sealed class SqlInt16Storage : DataStorage // TypeDefIndex: 11398
	{
		// Fields
		private SqlInt16[] _values; // 0x50
	
		// Constructors
		public SqlInt16Storage(DataColumn column); // 0x000000018191B680-0x000000018191B7A0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181919EE0-0x000000018191AD00
		public override int Compare(int recordNo1, int recordNo2); // 0x000000018191ADB0-0x000000018191AE50
		public override int CompareValueTo(int recordNo, object value); // 0x000000018191AD00-0x000000018191ADB0
		public override object ConvertValue(object value); // 0x000000018191B010-0x000000018191B080
		public override void Copy(int recordNo1, int recordNo2); // 0x000000018191B360-0x000000018191B3A0
		public override object Get(int record); // 0x000000018191B3E0-0x000000018191B450
		public override bool IsNull(int record); // 0x000000018191B450-0x000000018191B4D0
		public override void Set(int record, object value); // 0x000000018191B640-0x000000018191B680
		public override void SetCapacity(int capacity); // 0x000000018191B4D0-0x000000018191B5A0
		public override object ConvertXmlToObject(string s); // 0x000000018191B080-0x000000018191B270
		public override string ConvertObjectToXml(object value); // 0x000000018191AE50-0x000000018191B010
		protected override object GetEmptyStorage(int recordCount); // 0x000000018191B3A0-0x000000018191B3E0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x000000018191B270-0x000000018191B360
		protected override void SetStorage(object store, BitArray nullbits); // 0x000000018191B5A0-0x000000018191B640
	}
}
