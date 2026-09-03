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
	internal sealed class SqlDateTimeStorage : DataStorage // TypeDefIndex: 11394
	{
		// Fields
		private SqlDateTime[] _values; // 0x50
	
		// Constructors
		public SqlDateTimeStorage(DataColumn column); // 0x0000000181913EA0-0x0000000181913FF0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181912EA0-0x0000000181913440
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181913510-0x00000001819135E0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181913440-0x0000000181913510
		public override object ConvertValue(object value); // 0x00000001819137B0-0x0000000181913830
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181913B40-0x0000000181913B90
		public override object Get(int record); // 0x0000000181913BD0-0x0000000181913C50
		public override bool IsNull(int record); // 0x0000000181913C50-0x0000000181913CD0
		public override void Set(int record, object value); // 0x0000000181913E40-0x0000000181913EA0
		public override void SetCapacity(int capacity); // 0x0000000181913CD0-0x0000000181913DA0
		public override object ConvertXmlToObject(string s); // 0x0000000181913830-0x0000000181913A40
		public override string ConvertObjectToXml(object value); // 0x00000001819135E0-0x00000001819137B0
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181913B90-0x0000000181913BD0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181913A40-0x0000000181913B40
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181913DA0-0x0000000181913E40
	}
}
