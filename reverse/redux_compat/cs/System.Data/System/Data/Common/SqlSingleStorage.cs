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
	internal sealed class SqlSingleStorage : DataStorage // TypeDefIndex: 11402
	{
		// Fields
		private SqlSingle[] _values; // 0x50
	
		// Constructors
		public SqlSingleStorage(DataColumn column); // 0x0000000181921A30-0x0000000181921B50
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181920320-0x00000001819210E0
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181921190-0x0000000181921230
		public override int CompareValueTo(int recordNo, object value); // 0x00000001819210E0-0x0000000181921190
		public override object ConvertValue(object value); // 0x00000001819213F0-0x0000000181921460
		public override void Copy(int recordNo1, int recordNo2); // 0x000000018191CC10-0x000000018191CC50
		public override object Get(int record); // 0x0000000181921780-0x00000001819217F0
		public override bool IsNull(int record); // 0x00000001819217F0-0x0000000181921870
		public override void Set(int record, object value); // 0x00000001819219E0-0x0000000181921A30
		public override void SetCapacity(int capacity); // 0x0000000181921870-0x0000000181921940
		public override object ConvertXmlToObject(string s); // 0x0000000181921460-0x0000000181921650
		public override string ConvertObjectToXml(object value); // 0x0000000181921230-0x00000001819213F0
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181921740-0x0000000181921780
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181921650-0x0000000181921740
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181921940-0x00000001819219E0
	}
}
