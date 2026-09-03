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
	internal sealed class SqlByteStorage : DataStorage // TypeDefIndex: 11391
	{
		// Fields
		private SqlByte[] _values; // 0x50
	
		// Constructors
		public SqlByteStorage(DataColumn column); // 0x000000018190AD40-0x000000018190AE70
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181909570-0x000000018190A3A0
		public override int Compare(int recordNo1, int recordNo2); // 0x000000018190A450-0x000000018190A4F0
		public override int CompareValueTo(int recordNo, object value); // 0x000000018190A3A0-0x000000018190A450
		public override object ConvertValue(object value); // 0x000000018190A6C0-0x000000018190A730
		public override void Copy(int recordNo1, int recordNo2); // 0x000000018190AA10-0x000000018190AA50
		public override object Get(int record); // 0x000000018190AA90-0x000000018190AB00
		public override bool IsNull(int record); // 0x000000018190AB00-0x000000018190AB80
		public override void Set(int record, object value); // 0x000000018190ACF0-0x000000018190AD40
		public override void SetCapacity(int capacity); // 0x000000018190AB80-0x000000018190AC50
		public override object ConvertXmlToObject(string s); // 0x000000018190A730-0x000000018190A920
		public override string ConvertObjectToXml(object value); // 0x000000018190A4F0-0x000000018190A6C0
		protected override object GetEmptyStorage(int recordCount); // 0x000000018190AA50-0x000000018190AA90
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x000000018190A920-0x000000018190AA10
		protected override void SetStorage(object store, BitArray nullbits); // 0x000000018190AC50-0x000000018190ACF0
	}
}
