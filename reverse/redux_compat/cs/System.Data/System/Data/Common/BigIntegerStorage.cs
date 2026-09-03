/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.Common
{
	internal sealed class BigIntegerStorage : DataStorage // TypeDefIndex: 11375
	{
		// Fields
		private BigInteger[] _values; // 0x50
	
		// Constructors
		internal BigIntegerStorage(DataColumn column); // 0x00000001818F9D40-0x00000001818F9E70
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001818F8910-0x00000001818F8950
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001818F8AA0-0x00000001818F8BB0
		public override int CompareValueTo(int recordNo, object value); // 0x00000001818F8950-0x00000001818F8AA0
		internal static BigInteger ConvertToBigInteger(object value, IFormatProvider formatProvider); // 0x00000001818F91E0-0x00000001818F9600
		internal static object ConvertFromBigInteger(BigInteger value, Type type, IFormatProvider formatProvider); // 0x00000001818F8BB0-0x00000001818F9120
		public override object ConvertValue(object value); // 0x00000001818F9600-0x00000001818F96A0
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001818F9850-0x00000001818F9900
		public override object Get(int record); // 0x00000001818F9940-0x00000001818F9A30
		public override void Set(int record, object value); // 0x00000001818F9BC0-0x00000001818F9D40
		public override void SetCapacity(int capacity); // 0x00000001818F9A30-0x00000001818F9B10
		public override object ConvertXmlToObject(string s); // 0x00000001818F96A0-0x00000001818F9740
		public override string ConvertObjectToXml(object value); // 0x00000001818F9120-0x00000001818F91E0
		protected override object GetEmptyStorage(int recordCount); // 0x00000001818F9900-0x00000001818F9940
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001818F9740-0x00000001818F9850
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001818F9B10-0x00000001818F9BC0
	}
}
