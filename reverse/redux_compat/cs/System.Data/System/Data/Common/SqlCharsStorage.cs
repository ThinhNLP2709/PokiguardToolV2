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
	internal sealed class SqlCharsStorage : DataStorage // TypeDefIndex: 11393
	{
		// Fields
		private SqlChars[] _values; // 0x50
	
		// Constructors
		public SqlCharsStorage(DataColumn column); // 0x000000018190C270-0x000000018190C350
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x000000018190B930-0x000000018190BAB0
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001802E7860-0x00000001802E7870
		public override int CompareValueTo(int recordNo, object value); // 0x00000001802E7860-0x00000001802E7870
		public override void Copy(int recordNo1, int recordNo2); // 0x000000018190B4F0-0x000000018190B540
		public override object Get(int record); // 0x000000018190B580-0x000000018190B5B0
		public override bool IsNull(int record); // 0x000000018190B5B0-0x000000018190B5F0
		public override void Set(int record, object value); // 0x000000018190C180-0x000000018190C270
		public override void SetCapacity(int capacity); // 0x000000018190C010-0x000000018190C0E0
		public override object ConvertXmlToObject(string s); // 0x000000018190BC80-0x000000018190BEB0
		public override string ConvertObjectToXml(object value); // 0x000000018190BAB0-0x000000018190BC80
		protected override object GetEmptyStorage(int recordCount); // 0x000000018190BFD0-0x000000018190C010
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x000000018190BEB0-0x000000018190BFD0
		protected override void SetStorage(object store, BitArray nullbits); // 0x000000018190C0E0-0x000000018190C180
	}
}
