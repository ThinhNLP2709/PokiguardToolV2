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
	internal sealed class CharStorage : DataStorage // TypeDefIndex: 11378
	{
		// Fields
		private char[] _values; // 0x50
	
		// Constructors
		internal CharStorage(DataColumn column); // 0x00000001818FC720-0x00000001818FC7E0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001818FBB10-0x00000001818FBE10
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001818FBF10-0x00000001818FBFB0
		public override int CompareValueTo(int recordNo, object value); // 0x00000001818FBE10-0x00000001818FBF10
		public override object ConvertValue(object value); // 0x00000001818FC030-0x00000001818FC120
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001818FC290-0x00000001818FC320
		public override object Get(int record); // 0x00000001818FC360-0x00000001818FC3E0
		public override void Set(int record, object value); // 0x00000001818FC580-0x00000001818FC720
		public override void SetCapacity(int capacity); // 0x00000001818FC3E0-0x00000001818FC4C0
		public override object ConvertXmlToObject(string s); // 0x00000001818FC120-0x00000001818FC180
		public override string ConvertObjectToXml(object value); // 0x00000001818FBFB0-0x00000001818FC030
		protected override object GetEmptyStorage(int recordCount); // 0x00000001818FC320-0x00000001818FC360
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001818FC180-0x00000001818FC290
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001818FC4C0-0x00000001818FC580
	}
}
