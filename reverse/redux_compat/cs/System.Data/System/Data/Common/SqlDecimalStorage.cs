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
	internal sealed class SqlDecimalStorage : DataStorage // TypeDefIndex: 11395
	{
		// Fields
		private SqlDecimal[] _values; // 0x50
	
		// Constructors
		public SqlDecimalStorage(DataColumn column); // 0x0000000181915880-0x00000001819159D0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181913FF0-0x0000000181914E40
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181914F10-0x0000000181914FD0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181914E40-0x0000000181914F10
		public override object ConvertValue(object value); // 0x00000001819151A0-0x0000000181915220
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181915520-0x0000000181915570
		public override object Get(int record); // 0x00000001819155B0-0x0000000181915630
		public override bool IsNull(int record); // 0x0000000181915630-0x00000001819156B0
		public override void Set(int record, object value); // 0x0000000181915820-0x0000000181915880
		public override void SetCapacity(int capacity); // 0x00000001819156B0-0x0000000181915780
		public override object ConvertXmlToObject(string s); // 0x0000000181915220-0x0000000181915420
		public override string ConvertObjectToXml(object value); // 0x0000000181914FD0-0x00000001819151A0
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181915570-0x00000001819155B0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181915420-0x0000000181915520
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181915780-0x0000000181915820
	}
}
