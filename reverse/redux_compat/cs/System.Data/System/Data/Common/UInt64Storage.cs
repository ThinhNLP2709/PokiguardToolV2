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
	internal sealed class UInt64Storage : DataStorage // TypeDefIndex: 11412
	{
		// Fields
		private static readonly ulong s_defaultValue; // 0x00
		private ulong[] _values; // 0x50
	
		// Constructors
		public UInt64Storage(DataColumn column); // 0x0000000181929900-0x00000001819299F0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001819287B0-0x0000000181928FE0
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001819290E0-0x0000000181929200
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181928FE0-0x00000001819290E0
		public override object ConvertValue(object value); // 0x0000000181929280-0x0000000181929360
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001819294C0-0x0000000181929520
		public override object Get(int record); // 0x0000000181929560-0x0000000181929620
		public override void Set(int record, object value); // 0x00000001819297C0-0x0000000181929900
		public override void SetCapacity(int capacity); // 0x0000000181929620-0x0000000181929700
		public override object ConvertXmlToObject(string s); // 0x0000000181929360-0x00000001819293C0
		public override string ConvertObjectToXml(object value); // 0x0000000181929200-0x0000000181929280
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181929520-0x0000000181929560
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001819293C0-0x00000001819294C0
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181929700-0x00000001819297C0
	}
}
