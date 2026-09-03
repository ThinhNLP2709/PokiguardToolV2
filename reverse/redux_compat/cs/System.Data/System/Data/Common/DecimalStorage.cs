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
	internal sealed class DecimalStorage : DataStorage // TypeDefIndex: 11383
	{
		// Fields
		private static readonly decimal s_defaultValue; // 0x00
		private decimal[] _values; // 0x50
	
		// Constructors
		internal DecimalStorage(DataColumn column); // 0x0000000181903580-0x0000000181903670
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001819021A0-0x0000000181902B90
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181902D10-0x0000000181902E90
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181902B90-0x0000000181902D10
		public override object ConvertValue(object value); // 0x0000000181902F20-0x0000000181903030
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181900730-0x00000001819007C0
		public override object Get(int record); // 0x00000001819031E0-0x0000000181903280
		public override void Set(int record, object value); // 0x0000000181903410-0x0000000181903580
		public override void SetCapacity(int capacity); // 0x0000000181903280-0x0000000181903360
		public override object ConvertXmlToObject(string s); // 0x0000000181903030-0x00000001819030B0
		public override string ConvertObjectToXml(object value); // 0x0000000181902E90-0x0000000181902F20
		protected override object GetEmptyStorage(int recordCount); // 0x00000001819031A0-0x00000001819031E0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001819030B0-0x00000001819031A0
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181903360-0x0000000181903410
	}
}
