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
	internal sealed class DoubleStorage : DataStorage // TypeDefIndex: 11384
	{
		// Fields
		private double[] _values; // 0x50
	
		// Constructors
		internal DoubleStorage(DataColumn column); // 0x00000001819045B0-0x0000000181904680
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181903670-0x0000000181903D10
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181903DF0-0x0000000181903E80
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181903D10-0x0000000181903DF0
		public override object ConvertValue(object value); // 0x0000000181903F00-0x0000000181903FF0
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181904180-0x0000000181904210
		public override object Get(int record); // 0x0000000181904250-0x00000001819042D0
		public override void Set(int record, object value); // 0x0000000181904470-0x00000001819045B0
		public override void SetCapacity(int capacity); // 0x00000001819042D0-0x00000001819043B0
		public override object ConvertXmlToObject(string s); // 0x0000000181903FF0-0x0000000181904060
		public override string ConvertObjectToXml(object value); // 0x0000000181903E80-0x0000000181903F00
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181904210-0x0000000181904250
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181904060-0x0000000181904180
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001819043B0-0x0000000181904470
	}
}
