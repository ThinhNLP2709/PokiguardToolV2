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
	internal sealed class StringStorage : DataStorage // TypeDefIndex: 11408
	{
		// Fields
		private string[] _values; // 0x50
	
		// Constructors
		public StringStorage(DataColumn column); // 0x0000000181924A90-0x0000000181924B50
	
		// Methods
		public override object Aggregate(int[] recordNos, AggregateType kind); // 0x00000001819242C0-0x0000000181924570
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181924600-0x0000000181924680
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181924570-0x0000000181924600
		public override object ConvertValue(object value); // 0x00000001819246B0-0x00000001819246E0
		public override void Copy(int recordNo1, int recordNo2); // 0x000000018190B4F0-0x000000018190B540
		public override object Get(int recordNo); // 0x00000001818DA5E0-0x00000001818DA620
		public override int GetStringLength(int record); // 0x0000000181924840-0x0000000181924880
		public override bool IsNull(int record); // 0x00000001818DA620-0x00000001818DA650
		public override void Set(int record, object value); // 0x00000001819249F0-0x0000000181924A90
		public override void SetCapacity(int capacity); // 0x0000000181924880-0x0000000181924950
		public override object ConvertXmlToObject(string s); // 0x0000000180A68C50-0x0000000180A68C60
		public override string ConvertObjectToXml(object value); // 0x0000000181924680-0x00000001819246B0
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181924800-0x0000000181924840
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001819246E0-0x0000000181924800
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181924950-0x00000001819249F0
	}
}
