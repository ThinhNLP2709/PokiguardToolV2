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
	internal sealed class BooleanStorage : DataStorage // TypeDefIndex: 11376
	{
		// Fields
		private bool[] _values; // 0x50
	
		// Constructors
		internal BooleanStorage(DataColumn column); // 0x00000001818FA9D0-0x00000001818FAAA0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001818F9E70-0x00000001818FA130
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001818FA220-0x00000001818FA2C0
		public override int CompareValueTo(int recordNo, object value); // 0x00000001818FA130-0x00000001818FA220
		public override object ConvertValue(object value); // 0x00000001818FA340-0x00000001818FA430
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001818FA5B0-0x00000001818FA640
		public override object Get(int record); // 0x00000001818FA680-0x00000001818FA700
		public override void Set(int record, object value); // 0x00000001818FA8A0-0x00000001818FA9D0
		public override void SetCapacity(int capacity); // 0x00000001818FA700-0x00000001818FA7E0
		public override object ConvertXmlToObject(string s); // 0x00000001818FA430-0x00000001818FA490
		public override string ConvertObjectToXml(object value); // 0x00000001818FA2C0-0x00000001818FA340
		protected override object GetEmptyStorage(int recordCount); // 0x00000001818FA640-0x00000001818FA680
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001818FA490-0x00000001818FA5B0
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001818FA7E0-0x00000001818FA8A0
	}
}
