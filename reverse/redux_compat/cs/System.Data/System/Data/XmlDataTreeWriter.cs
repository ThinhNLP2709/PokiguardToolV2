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
	internal sealed class XmlDataTreeWriter // TypeDefIndex: 11342
	{
		// Fields
		private XmlWriter _xmlw; // 0x10
		private DataSet _ds; // 0x18
		private DataTable _dt; // 0x20
		private ArrayList _dTables; // 0x28
		private DataTable[] _topLevelTables; // 0x30
		private bool _fFromTable; // 0x38
		private bool _isDiffgram; // 0x39
		private Hashtable _rowsOrder; // 0x40
		private bool _writeHierarchy; // 0x48
	
		// Constructors
		internal XmlDataTreeWriter(DataSet ds); // 0x00000001818CAD40-0x00000001818CAFF0
		internal XmlDataTreeWriter(DataTable dt, bool writeHierarchy); // 0x00000001818CAB40-0x00000001818CAD40
	
		// Methods
		private DataTable[] CreateToplevelTables(); // 0x00000001818C7EF0-0x00000001818C8220
		private void CreateTablesHierarchy(DataTable dt); // 0x00000001818C7C00-0x00000001818C7EF0
		internal static bool RowHasErrors(DataRow row); // 0x00000001818C8570-0x00000001818C8650
		internal void SaveDiffgramData(XmlWriter xw, Hashtable rowsOrder); // 0x00000001818C8650-0x00000001818C8C30
		internal void Save(XmlWriter xw, bool writeSchema); // 0x00000001818C8C30-0x00000001818C9480
		private ArrayList GetNestedChildRelations(DataRow row); // 0x00000001818C8220-0x00000001818C84D0
		internal void XmlDataRowWriter(DataRow row, string encodedTableName); // 0x00000001818C9480-0x00000001818CAB40
		internal static bool PreserveSpace(object value); // 0x00000001818C84D0-0x00000001818C8570
	}
}
