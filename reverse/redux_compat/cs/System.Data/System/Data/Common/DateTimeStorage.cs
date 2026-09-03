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
	internal sealed class DateTimeStorage : DataStorage // TypeDefIndex: 11382
	{
		// Fields
		private static readonly DateTime s_defaultValue; // 0x00
		private DateTime[] _values; // 0x50
	
		// Constructors
		internal DateTimeStorage(DataColumn column); // 0x0000000181902090-0x00000001819021A0
		static DateTimeStorage(); // 0x0000000181902020-0x0000000181902090
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181900D70-0x00000001819011C0
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181901320-0x0000000181901450
		public override int CompareValueTo(int recordNo, object value); // 0x00000001819011C0-0x0000000181901320
		public override object ConvertValue(object value); // 0x0000000181901530-0x0000000181901630
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181901840-0x00000001819018D0
		public override object Get(int record); // 0x0000000181901910-0x0000000181901A20
		public override void Set(int record, object value); // 0x0000000181901D50-0x0000000181902020
		public override void SetCapacity(int capacity); // 0x0000000181901A20-0x0000000181901B00
		public override object ConvertXmlToObject(string s); // 0x0000000181901630-0x00000001819016E0
		public override string ConvertObjectToXml(object value); // 0x0000000181901450-0x0000000181901530
		protected override object GetEmptyStorage(int recordCount); // 0x00000001819018D0-0x0000000181901910
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001819016E0-0x0000000181901840
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181901B00-0x0000000181901D50
	}
}
