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
	internal sealed class SqlStringStorage : DataStorage // TypeDefIndex: 11403
	{
		// Fields
		private SqlString[] _values; // 0x50
	
		// Constructors
		public SqlStringStorage(DataColumn column); // 0x0000000181922AB0-0x0000000181922C00
	
		// Methods
		public override object Aggregate(int[] recordNos, AggregateType kind); // 0x0000000181921B50-0x0000000181921E80
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181921F50-0x0000000181921FD0
		public int Compare(SqlString valueNo1, SqlString valueNo2); // 0x0000000181921FD0-0x00000001819220E0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181921E80-0x0000000181921F50
		public override object ConvertValue(object value); // 0x00000001819222A0-0x0000000181922320
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181922650-0x00000001819226C0
		public override object Get(int record); // 0x00000001819227C0-0x0000000181922840
		public override int GetStringLength(int record); // 0x0000000181922700-0x00000001819227C0
		public override bool IsNull(int record); // 0x0000000181922840-0x00000001819228C0
		public override void Set(int record, object value); // 0x0000000181922A30-0x0000000181922AB0
		public override void SetCapacity(int capacity); // 0x00000001819228C0-0x0000000181922990
		public override object ConvertXmlToObject(string s); // 0x0000000181922320-0x0000000181922530
		public override string ConvertObjectToXml(object value); // 0x00000001819220E0-0x00000001819222A0
		protected override object GetEmptyStorage(int recordCount); // 0x00000001819226C0-0x0000000181922700
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181922530-0x0000000181922650
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181922990-0x0000000181922A30
	}
}
