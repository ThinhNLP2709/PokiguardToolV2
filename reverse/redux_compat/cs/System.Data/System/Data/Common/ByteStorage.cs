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
	internal sealed class ByteStorage : DataStorage // TypeDefIndex: 11377
	{
		// Fields
		private byte[] _values; // 0x50
	
		// Constructors
		internal ByteStorage(DataColumn column); // 0x00000001818FBA40-0x00000001818FBB10
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001818FAAA0-0x00000001818FB1F0
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001818FB2C0-0x00000001818FB340
		public override int CompareValueTo(int recordNo, object value); // 0x00000001818FB1F0-0x00000001818FB2C0
		public override object ConvertValue(object value); // 0x00000001818FB3C0-0x00000001818FB4B0
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001818FB620-0x00000001818FB6B0
		public override object Get(int record); // 0x00000001818FB6F0-0x00000001818FB770
		public override void Set(int record, object value); // 0x00000001818FB910-0x00000001818FBA40
		public override void SetCapacity(int capacity); // 0x00000001818FB770-0x00000001818FB850
		public override object ConvertXmlToObject(string s); // 0x00000001818FB4B0-0x00000001818FB510
		public override string ConvertObjectToXml(object value); // 0x00000001818FB340-0x00000001818FB3C0
		protected override object GetEmptyStorage(int recordCount); // 0x00000001818FB6B0-0x00000001818FB6F0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001818FB510-0x00000001818FB620
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001818FB850-0x00000001818FB910
	}
}
