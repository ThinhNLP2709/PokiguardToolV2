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
	internal sealed class SingleStorage : DataStorage // TypeDefIndex: 11405
	{
		// Fields
		private float[] _values; // 0x50
	
		// Constructors
		public SingleStorage(DataColumn column); // 0x0000000181916B00-0x0000000181916BD0
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181915C00-0x00000001819162D0
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001819163B0-0x0000000181916440
		public override int CompareValueTo(int recordNo, object value); // 0x00000001819162D0-0x00000001819163B0
		public override object ConvertValue(object value); // 0x00000001819164C0-0x00000001819165B0
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181916740-0x00000001819167A0
		public override object Get(int record); // 0x00000001819167E0-0x0000000181916840
		public override void Set(int record, object value); // 0x00000001819169E0-0x0000000181916B00
		public override void SetCapacity(int capacity); // 0x0000000181916840-0x0000000181916920
		public override object ConvertXmlToObject(string s); // 0x00000001819165B0-0x0000000181916620
		public override string ConvertObjectToXml(object value); // 0x0000000181916440-0x00000001819164C0
		protected override object GetEmptyStorage(int recordCount); // 0x00000001819167A0-0x00000001819167E0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181916620-0x0000000181916740
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181916920-0x00000001819169E0
	}
}
