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
	internal sealed class NewDiffgramGen // TypeDefIndex: 11341
	{
		// Fields
		internal XmlDocument _doc; // 0x10
		internal DataSet _ds; // 0x18
		internal DataTable _dt; // 0x20
		internal XmlWriter _xmlw; // 0x28
		private bool _fBefore; // 0x30
		private bool _fErrors; // 0x31
		internal Hashtable _rowsOrder; // 0x38
		private ArrayList _tables; // 0x40
		private bool _writeHierarchy; // 0x48
	
		// Constructors
		internal NewDiffgramGen(DataSet ds); // 0x00000001818C42B0-0x00000001818C4410
		internal NewDiffgramGen(DataTable dt, bool writeHierarchy); // 0x00000001818C4180-0x00000001818C42B0
	
		// Methods
		private void CreateTableHierarchy(DataTable dt); // 0x00000001818C1D70-0x00000001818C2060
		private void DoAssignments(ArrayList tables); // 0x00000001818C2060-0x00000001818C22D0
		private bool EmptyData(); // 0x00000001818C22D0-0x00000001818C23F0
		internal void Save(XmlWriter xmlw); // 0x00000001818C4170-0x00000001818C4180
		internal void Save(XmlWriter xmlw, DataTable table); // 0x00000001818C3AE0-0x00000001818C4170
		private void GenerateTable(DataTable table); // 0x00000001818C39F0-0x00000001818C3A80
		private void GenerateTableErrors(DataTable table); // 0x00000001818C3400-0x00000001818C39F0
		private void GenerateRow(DataRow row); // 0x00000001818C2DC0-0x00000001818C3400
		private void GenerateColumn(DataRow row, DataColumn col, DataRowVersion version); // 0x00000001818C23F0-0x00000001818C2DC0
		internal static string QualifiedName(string prefix, string name); // 0x00000001818C3A80-0x00000001818C3AE0
	}
}
