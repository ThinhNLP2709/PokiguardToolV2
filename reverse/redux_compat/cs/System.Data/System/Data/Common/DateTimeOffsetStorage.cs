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
	internal sealed class DateTimeOffsetStorage : DataStorage // TypeDefIndex: 11381
	{
		// Fields
		private static readonly DateTimeOffset s_defaultValue; // 0x00
		private DateTimeOffset[] _values; // 0x50
	
		// Constructors
		internal DateTimeOffsetStorage(DataColumn column); // 0x0000000181900C60-0x0000000181900D70
		static DateTimeOffsetStorage(); // 0x0000000181900BF0-0x0000000181900C60
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001818FFD00-0x0000000181900190
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181900310-0x00000001819004A0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181900190-0x0000000181900310
		public override object ConvertValue(object value); // 0x0000000181900530-0x00000001819005C0
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181900730-0x00000001819007C0
		public override object Get(int record); // 0x0000000181900800-0x0000000181900940
		public override void Set(int record, object value); // 0x0000000181900AD0-0x0000000181900BF0
		public override void SetCapacity(int capacity); // 0x0000000181900940-0x0000000181900A20
		public override object ConvertXmlToObject(string s); // 0x00000001819005C0-0x0000000181900640
		public override string ConvertObjectToXml(object value); // 0x00000001819004A0-0x0000000181900530
		protected override object GetEmptyStorage(int recordCount); // 0x00000001819007C0-0x0000000181900800
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181900640-0x0000000181900730
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181900A20-0x0000000181900AD0
	}
}
