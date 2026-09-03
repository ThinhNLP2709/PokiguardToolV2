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
	internal sealed class SqlDoubleStorage : DataStorage // TypeDefIndex: 11396
	{
		// Fields
		private SqlDouble[] _values; // 0x50
	
		// Constructors
		public SqlDoubleStorage(DataColumn column); // 0x0000000181919170-0x00000001819192A0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181917A60-0x0000000181918750
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181918810-0x00000001819188D0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181918750-0x0000000181918810
		public override object ConvertValue(object value); // 0x0000000181918A90-0x0000000181918B10
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181918E10-0x0000000181918E60
		public override object Get(int record); // 0x0000000181918EA0-0x0000000181918F20
		public override bool IsNull(int record); // 0x0000000181918F20-0x0000000181918FA0
		public override void Set(int record, object value); // 0x0000000181919110-0x0000000181919170
		public override void SetCapacity(int capacity); // 0x0000000181918FA0-0x0000000181919070
		public override object ConvertXmlToObject(string s); // 0x0000000181918B10-0x0000000181918D20
		public override string ConvertObjectToXml(object value); // 0x00000001819188D0-0x0000000181918A90
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181918E60-0x0000000181918EA0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181918D20-0x0000000181918E10
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181919070-0x0000000181919110
	}
}
