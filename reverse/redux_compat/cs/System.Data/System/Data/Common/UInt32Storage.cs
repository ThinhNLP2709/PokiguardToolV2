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
	internal sealed class UInt32Storage : DataStorage // TypeDefIndex: 11411
	{
		// Fields
		private static readonly uint s_defaultValue; // 0x00
		private uint[] _values; // 0x50
	
		// Constructors
		public UInt32Storage(DataColumn column); // 0x00000001819286D0-0x00000001819287B0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181927690-0x0000000181927E10
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181927F10-0x0000000181927FE0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181927E10-0x0000000181927F10
		public override object ConvertValue(object value); // 0x0000000181928060-0x0000000181928140
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001819282A0-0x0000000181928300
		public override object Get(int record); // 0x0000000181928340-0x0000000181928400
		public override void Set(int record, object value); // 0x00000001819285A0-0x00000001819286D0
		public override void SetCapacity(int capacity); // 0x0000000181928400-0x00000001819284E0
		public override object ConvertXmlToObject(string s); // 0x0000000181928140-0x00000001819281A0
		public override string ConvertObjectToXml(object value); // 0x0000000181927FE0-0x0000000181928060
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181928300-0x0000000181928340
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001819281A0-0x00000001819282A0
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001819284E0-0x00000001819285A0
	}
}
