/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class XmlToDatasetMap // TypeDefIndex: 11334
	{
		// Fields
		private XmlNodeIdHashtable _tableSchemaMap; // 0x10
		private TableSchemaInfo _lastTableSchemaInfo; // 0x18
	
		// Nested types
		private sealed class XmlNodeIdentety // TypeDefIndex: 11335
		{
			// Fields
			public string LocalName; // 0x10
			public string NamespaceURI; // 0x18
	
			// Constructors
			public XmlNodeIdentety(string localName, string namespaceURI); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
			public override bool Equals(object obj); // 0x00000001818BEB30-0x00000001818BEBE0
		}
	
		internal sealed class XmlNodeIdHashtable : Hashtable // TypeDefIndex: 11336
		{
			// Fields
			private XmlNodeIdentety _id; // 0x50
	
			// Properties
			public object this[XmlNode node] { get => default; } // 0x00000001818CB1A0-0x00000001818CB250 
			public object this[XmlReader dataReader] { get => default; } // 0x00000001818CB250-0x00000001818CB300 
			public object this[DataTable table] { get => default; } // 0x00000001818CB110-0x00000001818CB1A0 
			public object this[string name] { get => default; } // 0x00000001818CB0A0-0x00000001818CB110 
	
			// Constructors
			public XmlNodeIdHashtable(int capacity); // 0x00000001818CAFF0-0x00000001818CB0A0
		}
	
		private sealed class TableSchemaInfo // TypeDefIndex: 11337
		{
			// Fields
			public DataTable TableSchema; // 0x10
			public XmlNodeIdHashtable ColumnsSchemaMap; // 0x18
	
			// Constructors
			public TableSchemaInfo(DataTable tableSchema); // 0x00000001818C7AD0-0x00000001818C7C00
		}
	
		// Constructors
		public XmlToDatasetMap(DataSet dataSet, XmlNameTable nameTable); // 0x00000001818C13A0-0x00000001818C13E0
		public XmlToDatasetMap(XmlNameTable nameTable, DataSet dataSet); // 0x00000001818C1320-0x00000001818C1360
		public XmlToDatasetMap(DataTable dataTable, XmlNameTable nameTable); // 0x00000001818C13E0-0x00000001818C1460
		public XmlToDatasetMap(XmlNameTable nameTable, DataTable dataTable); // 0x00000001818C1360-0x00000001818C13A0
	
		// Methods
		internal static bool IsMappedColumn(DataColumn c); // 0x00000001818C12F0-0x00000001818C1320
		private TableSchemaInfo AddTableSchema(DataTable table, XmlNameTable nameTable); // 0x00000001818BEF80-0x00000001818BF0E0
		private TableSchemaInfo AddTableSchema(XmlNameTable nameTable, DataTable table); // 0x00000001818BF0E0-0x00000001818BF2C0
		private bool AddColumnSchema(DataColumn col, XmlNameTable nameTable, XmlNodeIdHashtable columns); // 0x00000001818BEBE0-0x00000001818BED60
		private bool AddColumnSchema(XmlNameTable nameTable, DataColumn col, XmlNodeIdHashtable columns); // 0x00000001818BED60-0x00000001818BEF80
		private void BuildIdentityMap(DataSet dataSet, XmlNameTable nameTable); // 0x00000001818BF2C0-0x00000001818BF6C0
		private void BuildIdentityMap(XmlNameTable nameTable, DataSet dataSet); // 0x00000001818BF990-0x00000001818C0160
		private void BuildIdentityMap(DataTable dataTable, XmlNameTable nameTable); // 0x00000001818BF6C0-0x00000001818BF990
		private void BuildIdentityMap(XmlNameTable nameTable, DataTable dataTable); // 0x00000001818C0160-0x00000001818C08D0
		private ArrayList GetSelfAndDescendants(DataTable dt); // 0x00000001818C0D60-0x00000001818C1060
		public object GetColumnSchema(XmlNode node, bool fIgnoreNamespace); // 0x00000001818C08D0-0x00000001818C0AE0
		public object GetColumnSchema(DataTable table, XmlReader dataReader, bool fIgnoreNamespace); // 0x00000001818C0AE0-0x00000001818C0C60
		public object GetSchemaForNode(XmlNode node, bool fIgnoreNamespace); // 0x00000001818C0C60-0x00000001818C0D60
		public DataTable GetTableForNode(XmlReader node, bool fIgnoreNamespace); // 0x00000001818C1060-0x00000001818C1150
		private void HandleSpecialColumn(DataColumn col, XmlNameTable nameTable, XmlNodeIdHashtable columns); // 0x00000001818C1150-0x00000001818C12F0
	}
}
