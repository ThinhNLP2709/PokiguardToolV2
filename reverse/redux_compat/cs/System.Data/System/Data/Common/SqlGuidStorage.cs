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
	internal sealed class SqlGuidStorage : DataStorage // TypeDefIndex: 11397
	{
		// Fields
		private SqlGuid[] _values; // 0x50
	
		// Constructors
		public SqlGuidStorage(DataColumn column); // 0x0000000181919DC0-0x0000000181919EE0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001819192A0-0x0000000181919460
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181919510-0x00000001819195B0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181919460-0x0000000181919510
		public override object ConvertValue(object value); // 0x0000000181919770-0x00000001819197E0
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181909110-0x0000000181909160
		public override object Get(int record); // 0x0000000181919B10-0x0000000181919B80
		public override bool IsNull(int record); // 0x0000000181919B80-0x0000000181919C00
		public override void Set(int record, object value); // 0x0000000181919D70-0x0000000181919DC0
		public override void SetCapacity(int capacity); // 0x0000000181919C00-0x0000000181919CD0
		public override object ConvertXmlToObject(string s); // 0x00000001819197E0-0x00000001819199D0
		public override string ConvertObjectToXml(object value); // 0x00000001819195B0-0x0000000181919770
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181919AD0-0x0000000181919B10
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001819199D0-0x0000000181919AD0
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181919CD0-0x0000000181919D70
	}
}
