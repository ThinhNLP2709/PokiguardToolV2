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
	internal sealed class SqlBooleanStorage : DataStorage // TypeDefIndex: 11404
	{
		// Fields
		private SqlBoolean[] _values; // 0x50
	
		// Constructors
		public SqlBooleanStorage(DataColumn column); // 0x0000000181917940-0x0000000181917A60
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181916BD0-0x0000000181916FC0
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181917070-0x0000000181917110
		public override int CompareValueTo(int recordNo, object value); // 0x0000000181916FC0-0x0000000181917070
		public override object ConvertValue(object value); // 0x00000001819172D0-0x0000000181917340
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181917620-0x0000000181917660
		public override object Get(int record); // 0x00000001819176A0-0x0000000181917710
		public override bool IsNull(int record); // 0x0000000181917710-0x0000000181917790
		public override void Set(int record, object value); // 0x0000000181917900-0x0000000181917940
		public override void SetCapacity(int capacity); // 0x0000000181917790-0x0000000181917860
		public override object ConvertXmlToObject(string s); // 0x0000000181917340-0x0000000181917530
		public override string ConvertObjectToXml(object value); // 0x0000000181917110-0x00000001819172D0
		protected override object GetEmptyStorage(int recordCount); // 0x0000000181917660-0x00000001819176A0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x0000000181917530-0x0000000181917620
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181917860-0x0000000181917900
	}
}
