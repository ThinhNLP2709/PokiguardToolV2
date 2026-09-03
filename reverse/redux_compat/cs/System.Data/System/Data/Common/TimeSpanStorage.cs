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
	internal sealed class TimeSpanStorage : DataStorage // TypeDefIndex: 11409
	{
		// Fields
		private static readonly TimeSpan s_defaultValue; // 0x00
		private TimeSpan[] _values; // 0x50
	
		// Constructors
		public TimeSpanStorage(DataColumn column); // 0x0000000181926310-0x0000000181926420
		static TimeSpanStorage(); // 0x00000001819262A0-0x0000000181926310
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181924B50-0x00000001819257C0
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181925940-0x0000000181925A70
		public override int CompareValueTo(int recordNo, object value); // 0x00000001819257C0-0x0000000181925940
		private static TimeSpan ConvertToTimeSpan(object value); // 0x0000000181925AF0-0x0000000181925C80
		public override object ConvertValue(object value); // 0x0000000181925C80-0x0000000181925D20
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181925E80-0x0000000181925EE0
		public override object Get(int record); // 0x0000000181925F20-0x0000000181926020
		public override void Set(int record, object value); // 0x00000001819261B0-0x00000001819262A0
		public override void SetCapacity(int capacity); // 0x0000000181926020-0x0000000181926100
		public override object ConvertXmlToObject(string s); // 0x0000000181925D20-0x0000000181925D90
		public override string ConvertObjectToXml(object value); // 0x0000000181925A70-0x0000000181925AF0
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181925EE0-0x0000000181925F20
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181925D90-0x0000000181925E80
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181926100-0x00000001819261B0
	}
}
