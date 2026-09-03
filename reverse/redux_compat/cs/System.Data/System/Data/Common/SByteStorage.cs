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
	internal sealed class SByteStorage : DataStorage // TypeDefIndex: 11388
	{
		// Fields
		private sbyte[] _values; // 0x50
	
		// Constructors
		public SByteStorage(DataColumn column); // 0x0000000181908800-0x00000001819088D0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181907880-0x0000000181907FD0
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001819080A0-0x0000000181908160
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181907FD0-0x00000001819080A0
		public override object ConvertValue(object value); // 0x00000001819081E0-0x00000001819082D0
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001818FB620-0x00000001818FB6B0
		public override object Get(int record); // 0x0000000181908480-0x0000000181908530
		public override void Set(int record, object value); // 0x00000001819086D0-0x0000000181908800
		public override void SetCapacity(int capacity); // 0x0000000181908530-0x0000000181908610
		public override object ConvertXmlToObject(string s); // 0x00000001819082D0-0x0000000181908330
		public override string ConvertObjectToXml(object value); // 0x0000000181908160-0x00000001819081E0
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181908440-0x0000000181908480
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181908330-0x0000000181908440
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181908610-0x00000001819086D0
	}
}
