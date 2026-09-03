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
	internal sealed class Int32Storage : DataStorage // TypeDefIndex: 11386
	{
		// Fields
		private int[] _values; // 0x50
	
		// Constructors
		internal Int32Storage(DataColumn column); // 0x00000001819066C0-0x0000000181906790
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001819056C0-0x0000000181905E70
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181905F50-0x0000000181905FD0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181905E70-0x0000000181905F50
		public override object ConvertValue(object value); // 0x0000000181906050-0x0000000181906140
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001819062A0-0x0000000181906330
		public override object Get(int record); // 0x0000000181906370-0x00000001819063F0
		public override void Set(int record, object value); // 0x0000000181906590-0x00000001819066C0
		public override void SetCapacity(int capacity); // 0x00000001819063F0-0x00000001819064D0
		public override object ConvertXmlToObject(string s); // 0x0000000181906140-0x00000001819061A0
		public override string ConvertObjectToXml(object value); // 0x0000000181905FD0-0x0000000181906050
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181906330-0x0000000181906370
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001819061A0-0x00000001819062A0
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001819064D0-0x0000000181906590
	}
}
