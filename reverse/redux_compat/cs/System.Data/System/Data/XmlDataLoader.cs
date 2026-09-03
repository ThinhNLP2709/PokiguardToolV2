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
	internal sealed class XmlDataLoader // TypeDefIndex: 11332
	{
		// Fields
		private DataSet _dataSet; // 0x10
		private XmlToDatasetMap _nodeToSchemaMap; // 0x18
		private Hashtable _nodeToRowMap; // 0x20
		private Stack _childRowsStack; // 0x28
		private Hashtable _htableExcludedNS; // 0x30
		private bool _fIsXdr; // 0x38
		internal bool _isDiffgram; // 0x39
		private XmlElement _topMostNode; // 0x40
		private bool _ignoreSchema; // 0x48
		private DataTable _dataTable; // 0x50
		private bool _isTableLevel; // 0x58
		private bool _fromInference; // 0x59
		private XmlReader _dataReader; // 0x60
		private object _XSD_XMLNS_NS; // 0x68
		private object _XDR_SCHEMA; // 0x70
		private object _XDRNS; // 0x78
		private object _SQL_SYNC; // 0x80
		private object _UPDGNS; // 0x88
		private object _XSD_SCHEMA; // 0x90
		private object _XSDNS; // 0x98
		private object _DFFNS; // 0xA0
		private object _MSDNS; // 0xA8
		private object _DIFFID; // 0xB0
		private object _HASCHANGES; // 0xB8
		private object _ROWORDER; // 0xC0
	
		// Properties
		internal bool FromInference { get; set; } // 0x00000001802E7880-0x00000001802E7890 0x0000000181727420-0x0000000181727430
	
		// Constructors
		internal XmlDataLoader(DataSet dataset, bool IsXdr, bool ignoreSchema); // 0x00000001818BE500-0x00000001818BE5A0
		internal XmlDataLoader(DataSet dataset, bool IsXdr, XmlElement topNode, bool ignoreSchema); // 0x00000001818BE770-0x00000001818BE860
		internal XmlDataLoader(DataTable datatable, bool IsXdr, bool ignoreSchema); // 0x00000001818BE5A0-0x00000001818BE660
		internal XmlDataLoader(DataTable datatable, bool IsXdr, XmlElement topNode, bool ignoreSchema); // 0x00000001818BE660-0x00000001818BE770
	
		// Methods
		private void AttachRows(DataRow parentRow, XmlNode parentElement); // 0x00000001818B9470-0x00000001818B9600
		private int CountNonNSAttributes(XmlNode node); // 0x00000001818B9600-0x00000001818B97A0
		private string GetValueForTextOnlyColums(XmlNode n); // 0x00000001818B9F40-0x00000001818BA200
		private string GetInitialTextFromNodes(ref XmlNode n); // 0x00000001818B9B10-0x00000001818B9DF0
		private DataColumn GetTextOnlyColumn(DataRow row); // 0x00000001818B9E90-0x00000001818B9F40
		internal DataRow GetRowFromElement(XmlElement e); // 0x00000001818B9DF0-0x00000001818B9E90
		internal bool FColumnElement(XmlElement e); // 0x00000001818B97A0-0x00000001818B98C0
		private bool FExcludedNamespace(string ns); // 0x00000001818B98C0-0x00000001818B9960
		private bool FIgnoreNamespace(XmlNode node); // 0x00000001818B99F0-0x00000001818B9B10
		private bool FIgnoreNamespace(XmlReader node); // 0x00000001818B9960-0x00000001818B99F0
		internal bool IsTextLikeNode(XmlNodeType n); // 0x00000001818BA550-0x00000001818BA5B0
		internal bool IsTextOnly(DataColumn c); // 0x00000001818BA5B0-0x00000001818BA5F0
		internal void LoadData(XmlDocument xdoc); // 0x00000001818BB070-0x00000001818BB360
		private void LoadRowData(DataRow row, XmlElement rowElement); // 0x00000001818BB750-0x00000001818BC560
		private void LoadRows(DataRow parentRow, XmlNode parentElement); // 0x00000001818BC560-0x00000001818BC920
		private void SetRowValueFromXmlText(DataRow row, DataColumn col, string xmlText); // 0x00000001818BE4B0-0x00000001818BE500
		private void InitNameTable(); // 0x00000001818BA200-0x00000001818BA550
		internal void LoadData(XmlReader reader); // 0x00000001818BB360-0x00000001818BB750
		private void LoadTopMostTable(DataTable table); // 0x00000001818BD8D0-0x00000001818BE260
		private void LoadTable(DataTable table, bool isNested); // 0x00000001818BC920-0x00000001818BD8D0
		private void LoadColumn(DataColumn column, object[] foundColumns); // 0x00000001818BA5F0-0x00000001818BB070
		private bool ProcessXsdSchema(); // 0x00000001818BE260-0x00000001818BE4B0
	}
}
