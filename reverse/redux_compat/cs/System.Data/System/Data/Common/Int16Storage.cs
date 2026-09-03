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
	internal sealed class Int16Storage : DataStorage // TypeDefIndex: 11385
	{
		// Fields
		private short[] _values; // 0x50
	
		// Constructors
		internal Int16Storage(DataColumn column); // 0x0000000181905600-0x00000001819056C0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181904680-0x0000000181904E50
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181904F30-0x0000000181904FA0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181904E50-0x0000000181904F30
		public override object ConvertValue(object value); // 0x0000000181905020-0x0000000181905110
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001818FC290-0x00000001818FC320
		public override object Get(int record); // 0x00000001819052B0-0x0000000181905330
		public override void Set(int record, object value); // 0x00000001819054D0-0x0000000181905600
		public override void SetCapacity(int capacity); // 0x0000000181905330-0x0000000181905410
		public override object ConvertXmlToObject(string s); // 0x0000000181905110-0x0000000181905170
		public override string ConvertObjectToXml(object value); // 0x0000000181904FA0-0x0000000181905020
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181905270-0x00000001819052B0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181905170-0x0000000181905270
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181905410-0x00000001819054D0
	}
}
