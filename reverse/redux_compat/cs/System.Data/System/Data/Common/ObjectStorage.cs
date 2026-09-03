/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
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
	internal sealed class ObjectStorage : DataStorage // TypeDefIndex: 11371
	{
		// Fields
		private static readonly object s_defaultValue; // 0x00
		private object[] _values; // 0x50
		private readonly bool _implementsIXmlSerializable; // 0x58
		private static readonly object s_tempAssemblyCacheLock; // 0x08
		private static Dictionary<KeyValuePair<Type, XmlRootAttribute>, XmlSerializer> s_tempAssemblyCache; // 0x10
		private static readonly XmlSerializerFactory s_serializerFactory; // 0x18
	
		// Nested types
		private enum Families // TypeDefIndex: 11372
		{
			DATETIME = 0,
			NUMBER = 1,
			STRING = 2,
			BOOLEAN = 3,
			ARRAY = 4
		}
	
		private class TempAssemblyComparer : IEqualityComparer<KeyValuePair<Type, XmlRootAttribute>> // TypeDefIndex: 11373
		{
			// Fields
			internal static readonly IEqualityComparer<KeyValuePair<Type, XmlRootAttribute>> s_default; // 0x00
	
			// Constructors
			private TempAssemblyComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static TempAssemblyComparer(); // 0x0000000181915B90-0x0000000181915C00
	
			// Methods
			public bool Equals(KeyValuePair<Type, XmlRootAttribute> x, KeyValuePair<Type, XmlRootAttribute> y); // 0x00000001819159D0-0x0000000181915B20
			public int GetHashCode(KeyValuePair<Type, XmlRootAttribute> obj); // 0x0000000181915B20-0x0000000181915B90
		}
	
		// Constructors
		internal ObjectStorage(DataColumn column, Type type); // 0x00000001818DB400-0x00000001818DB580
		static ObjectStorage(); // 0x00000001818DB310-0x00000001818DB400
	
		// Methods
		public override object Aggregate(int[] records, AggregateType kind); // 0x00000001818D83F0-0x00000001818D8430
		public override int Compare(int recordNo1, int recordNo2); // 0x00000001818D8AB0-0x00000001818D8BD0
		public override int CompareValueTo(int recordNo1, object value); // 0x00000001818D8570-0x00000001818D86F0
		private int CompareTo(object valueNo1, object valueNo2); // 0x00000001818D8430-0x00000001818D8570
		private int CompareWithFamilies(object valueNo1, object valueNo2); // 0x00000001818D86F0-0x00000001818D8AB0
		public override void Copy(int recordNo1, int recordNo2); // 0x00000001818D9E00-0x00000001818D9E90
		public override object Get(int recordNo); // 0x00000001818DA5E0-0x00000001818DA620
		private Families GetFamily(Type dataType); // 0x00000001818D9ED0-0x00000001818D9FD0
		public override bool IsNull(int record); // 0x00000001818DA620-0x00000001818DA650
		public override void Set(int recordNo, object value); // 0x00000001818DA9A0-0x00000001818DB220
		public override void SetCapacity(int capacity); // 0x00000001818DA650-0x00000001818DA720
		public override object ConvertXmlToObject(string s); // 0x00000001818D9190-0x00000001818D9570
		public override object ConvertXmlToObject(XmlReader xmlReader, XmlRootAttribute xmlAttrib); // 0x00000001818D9570-0x00000001818D9BA0
		public override string ConvertObjectToXml(object value); // 0x00000001818D8CF0-0x00000001818D9190
		public override void ConvertObjectToXml(object value, XmlWriter xmlWriter, XmlRootAttribute xmlAttrib); // 0x00000001818D8BD0-0x00000001818D8CF0
		protected override object GetEmptyStorage(int recordCount); // 0x00000001818D9E90-0x00000001818D9ED0
		protected override void CopyValue(int record, object store, BitArray nullbits, int storeIndex); // 0x00000001818D9BA0-0x00000001818D9E00
		protected override void SetStorage(object store, BitArray nullbits); // 0x00000001818DA720-0x00000001818DA9A0
		internal static void VerifyIDynamicMetaObjectProvider(Type type); // 0x00000001818DB220-0x00000001818DB310
		internal static XmlSerializer GetXmlSerializer(Type type); // 0x00000001818D9FD0-0x00000001818DA050
		internal static XmlSerializer GetXmlSerializer(Type type, XmlRootAttribute attribute); // 0x00000001818DA050-0x00000001818DA5E0
	}
}
