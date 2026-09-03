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
	internal sealed class SqlInt32Storage : DataStorage // TypeDefIndex: 11399
	{
		// Fields
		private SqlInt32[] _values; // 0x50
	
		// Constructors
		public SqlInt32Storage(DataColumn column); // 0x000000018191CF40-0x000000018191D060
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x000000018191B7A0-0x000000018191C5B0
		public override int Compare(int recordNo1, int recordNo2); // 0x000000018191C660-0x000000018191C700
		public override int CompareValueTo(int recordNo, object value); // 0x000000018191C5B0-0x000000018191C660
		public override object ConvertValue(object value); // 0x000000018191C8C0-0x000000018191C930
		public override void Copy(int recordNo1, int recordNo2); // 0x000000018191CC10-0x000000018191CC50
		public override object Get(int record); // 0x000000018191CC90-0x000000018191CD00
		public override bool IsNull(int record); // 0x000000018191CD00-0x000000018191CD80
		public override void Set(int record, object value); // 0x000000018191CEF0-0x000000018191CF40
		public override void SetCapacity(int capacity); // 0x000000018191CD80-0x000000018191CE50
		public override object ConvertXmlToObject(string s); // 0x000000018191C930-0x000000018191CB20
		public override string ConvertObjectToXml(object value); // 0x000000018191C700-0x000000018191C8C0
		protected override object GetEmptyStorage(int recordCount); // 0x000000018191CC50-0x000000018191CC90
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x000000018191CB20-0x000000018191CC10
		protected override void SetStorage(object store, BitArray nullbits); // 0x000000018191CE50-0x000000018191CEF0
	}
}
