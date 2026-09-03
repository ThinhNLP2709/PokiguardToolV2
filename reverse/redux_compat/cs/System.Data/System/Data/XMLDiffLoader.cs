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
	internal sealed class XMLDiffLoader // TypeDefIndex: 11326
	{
		// Fields
		private ArrayList _tables; // 0x10
		private DataSet _dataSet; // 0x18
		private DataTable _dataTable; // 0x20
	
		// Constructors
		public XMLDiffLoader(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void LoadDiffGram(DataSet ds, XmlReader dataTextReader); // 0x00000001818A6250-0x00000001818A63F0
		private void CreateTablesHierarchy(DataTable dt); // 0x00000001818A5D50-0x00000001818A6040
		internal void LoadDiffGram(DataTable dt, XmlReader dataTextReader); // 0x00000001818A63F0-0x00000001818A6600
		internal void ProcessDiffs(DataSet ds, XmlReader ssync); // 0x00000001818A6600-0x00000001818A69B0
		internal void ProcessDiffs(ArrayList tableList, XmlReader ssync); // 0x00000001818A69B0-0x00000001818A6D10
		internal void ProcessErrors(DataSet ds, XmlReader ssync); // 0x00000001818A7260-0x00000001818A7690
		internal void ProcessErrors(ArrayList dt, XmlReader ssync); // 0x00000001818A6D10-0x00000001818A7260
		private DataTable GetTable(string tableName, string ns); // 0x00000001818A6040-0x00000001818A6250
		private int ReadOldRowData(DataSet ds, ref DataTable table, ref int pos, XmlReader row); // 0x00000001818A7690-0x00000001818A8690
		internal void SkipWhitespaces(XmlReader reader); // 0x00000001818A8690-0x00000001818A8700
	}
}
