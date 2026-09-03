/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.Common
{
	internal sealed class Int64Storage : DataStorage // TypeDefIndex: 11387
	{
		// Fields
		private long[] _values; // 0x50
	
		// Constructors
		internal Int64Storage(DataColumn column); // 0x00000001819077B0-0x0000000181907880
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181906790-0x0000000181906F50
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181907030-0x00000001819070B0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181906F50-0x0000000181907030
		public override object ConvertValue(object value); // 0x0000000181907130-0x0000000181907220
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181907380-0x0000000181907410
		public override object Get(int record); // 0x0000000181907450-0x00000001819074D0
		public override void Set(int record, object value); // 0x0000000181907670-0x00000001819077B0
		public override void SetCapacity(int capacity); // 0x00000001819074D0-0x00000001819075B0
		public override object ConvertXmlToObject(string s); // 0x0000000181907220-0x0000000181907280
		public override string ConvertObjectToXml(object value); // 0x00000001819070B0-0x0000000181907130
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181907410-0x0000000181907450
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181907280-0x0000000181907380
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001819075B0-0x0000000181907670
	}
}
