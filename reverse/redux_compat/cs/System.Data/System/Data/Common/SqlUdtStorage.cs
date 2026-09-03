/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.Common
{
	internal sealed class SqlUdtStorage : DataStorage // TypeDefIndex: 11406
	{
		// Fields
		private object[] _values; // 0x50
		private readonly bool _implementsIXmlSerializable; // 0x58
		private readonly bool _implementsIComparable; // 0x59
		private static readonly ConcurrentDictionary<Type, object> s_typeToNull; // 0x00
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 11407
		{
			// Fields
			public Type type; // 0x10
	
			// Constructors
			public __c__DisplayClass6_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal object _GetStaticNullForUdtType_b__0(Type t); // 0x0000000181926420-0x0000000181926560
		}
	
		// Constructors
		public SqlUdtStorage(DataColumn column, Type type); // 0x0000000181924040-0x00000001819242C0
		private SqlUdtStorage(DataColumn column, Type type, object nullValue); // 0x0000000181923EE0-0x0000000181924040
		static SqlUdtStorage(); // 0x0000000181923E50-0x0000000181923EE0
	
		// Methods
		internal static object GetStaticNullForUdtType(Type type); // 0x0000000181923910-0x0000000181923A30
		public override bool IsNull(int record); // 0x0000000181923A30-0x0000000181923AE0
		public override object Aggregate(int[] records, AggregateType kind); // 0x0000000181922C00-0x0000000181922C40
		public override int Compare(int recordNo1, int recordNo2); // 0x0000000181922EB0-0x0000000181922EF0
		public override int CompareValueTo(int recordNo1, object value); // 0x0000000181922C40-0x0000000181922EB0
		public override void Copy(int recordNo1, int recordNo2); // 0x0000000181923830-0x00000001819238D0
		public override object Get(int recordNo); // 0x000000018190B580-0x000000018190B5B0
		public override void Set(int recordNo, object value); // 0x0000000181923C60-0x0000000181923E50
		public override void SetCapacity(int capacity); // 0x0000000181923AE0-0x0000000181923BC0
		public override object ConvertXmlToObject(string s); // 0x0000000181923460-0x00000001819236B0
		public override object ConvertXmlToObject(XmlReader xmlReader, XmlRootAttribute xmlAttrib); // 0x0000000181923230-0x0000000181923460
		public override string ConvertObjectToXml(object value); // 0x0000000181923000-0x0000000181923230
		public override void ConvertObjectToXml(object value, XmlWriter xmlWriter, XmlRootAttribute xmlAttrib); // 0x0000000181922EF0-0x0000000181923000
		protected override object GetEmptyStorage(int recordCount); // 0x00000001819238D0-0x0000000181923910
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001819236B0-0x0000000181923830
		protected override void SetStorage(object store, BitArray nullbits); // 0x0000000181923BC0-0x0000000181923C60
	}
}
