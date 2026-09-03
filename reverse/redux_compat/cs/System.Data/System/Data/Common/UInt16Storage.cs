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
	internal sealed class UInt16Storage : DataStorage // TypeDefIndex: 11410
	{
		// Fields
		private static readonly ushort s_defaultValue; // 0x00
		private ushort[] _values; // 0x50
	
		// Constructors
		public UInt16Storage(DataColumn column); // 0x00000001819275A0-0x0000000181927690
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181926560-0x0000000181926CE0
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181926DE0-0x0000000181926EA0
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181926CE0-0x0000000181926DE0
		public override object ConvertValue(object value); // 0x0000000181926F20-0x0000000181927000
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181927160-0x00000001819271C0
		public override object Get(int record); // 0x0000000181927200-0x00000001819272C0
		public override void Set(int record, object value); // 0x0000000181927460-0x00000001819275A0
		public override void SetCapacity(int capacity); // 0x00000001819272C0-0x00000001819273A0
		public override object ConvertXmlToObject(string s); // 0x0000000181927000-0x0000000181927060
		public override string ConvertObjectToXml(object value); // 0x0000000181926EA0-0x0000000181926F20
		protected override object GetEmptyStorage(int recordCount); // 0x00000001819271C0-0x0000000181927200
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181927060-0x0000000181927160
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001819273A0-0x0000000181927460
	}
}
