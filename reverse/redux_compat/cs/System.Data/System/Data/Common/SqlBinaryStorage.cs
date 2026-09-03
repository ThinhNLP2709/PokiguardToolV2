/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.Common
{
	internal sealed class SqlBinaryStorage : DataStorage // TypeDefIndex: 11390
	{
		// Fields
		private SqlBinary[] _values; // 0x50
	
		// Constructors
		public SqlBinaryStorage(DataColumn column); // 0x0000000181909450-0x0000000181909570
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001819088D0-0x0000000181908A90
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181908B40-0x0000000181908BE0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181908A90-0x0000000181908B40
		public override object ConvertValue(object value); // 0x0000000181908DB0-0x0000000181908E20
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181909110-0x0000000181909160
		public override object Get(int record); // 0x00000001819091A0-0x0000000181909210
		public override bool IsNull(int record); // 0x0000000181909210-0x0000000181909290
		public override void Set(int record, object value); // 0x0000000181909400-0x0000000181909450
		public override void SetCapacity(int capacity); // 0x0000000181909290-0x0000000181909360
		public override object ConvertXmlToObject(string s); // 0x0000000181908E20-0x0000000181909010
		public override string ConvertObjectToXml(object value); // 0x0000000181908BE0-0x0000000181908DB0
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181909160-0x00000001819091A0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181909010-0x0000000181909110
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181909360-0x0000000181909400
	}
}
