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
	internal sealed class XDRSchema : XMLSchema // TypeDefIndex: 11324
	{
		// Fields
		internal string _schemaName; // 0x10
		internal string _schemaUri; // 0x18
		internal XmlElement _schemaRoot; // 0x20
		internal DataSet _ds; // 0x28
		private static readonly char[] s_colonArray; // 0x00
		private static NameType[] s_mapNameTypeXdr; // 0x08
		private static NameType s_enumerationNameType; // 0x10
	
		// Nested types
		private sealed class NameType : IComparable // TypeDefIndex: 11325
		{
			// Fields
			public string name; // 0x10
			public Type type; // 0x18
	
			// Constructors
			public NameType(string n, Type t); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			public int CompareTo(object obj); // 0x000000018189B650-0x000000018189B6A0
		}
	
		// Constructors
		internal XDRSchema(DataSet ds, bool fInline); // 0x00000001818A5CD0-0x00000001818A5D50
		static XDRSchema(); // 0x00000001818A4A10-0x00000001818A5CD0
	
		// Methods
		internal void LoadSchema(XmlElement schemaRoot, DataSet ds); // 0x00000001818A4650-0x00000001818A48D0
		internal XmlElement FindTypeNode(XmlElement node); // 0x00000001818A1F60-0x00000001818A2420
		internal bool IsTextOnlyContent(XmlElement node); // 0x00000001818A40F0-0x00000001818A42B0
		internal bool IsXDRField(XmlElement node, XmlElement typeNode); // 0x00000001818A42B0-0x00000001818A4650
		internal DataTable HandleTable(XmlElement node); // 0x00000001818A3500-0x00000001818A36B0
		private static NameType FindNameType(string name); // 0x00000001818A1EA0-0x00000001818A1F60
		private Type ParseDataType(string dt, string dtValues); // 0x00000001818A48D0-0x00000001818A4A10
		internal string GetInstanceName(XmlElement node); // 0x00000001818A2420-0x00000001818A2650
		internal void HandleColumn(XmlElement node, DataTable table); // 0x00000001818A2900-0x00000001818A3500
		internal void GetMinMax(XmlElement elNode, ref int minOccurs, ref int maxOccurs); // 0x00000001818A28D0-0x00000001818A2900
		internal void GetMinMax(XmlElement elNode, bool isAttribute, ref int minOccurs, ref int maxOccurs); // 0x00000001818A2650-0x00000001818A28D0
		internal void HandleTypeNode(XmlElement typeNode, DataTable table, ArrayList tableChildren); // 0x00000001818A36B0-0x00000001818A38D0
		internal DataTable InstantiateTable(DataSet dataSet, XmlElement node, XmlElement typeNode); // 0x00000001818A3B30-0x00000001818A40F0
		internal DataTable InstantiateSimpleTable(DataSet dataSet, XmlElement node); // 0x00000001818A38D0-0x00000001818A3B30
	}
}
