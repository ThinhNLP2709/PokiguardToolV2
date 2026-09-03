/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class Merger // TypeDefIndex: 11296
	{
		// Fields
		private DataSet _dataSet; // 0x10
		private DataTable _dataTable; // 0x18
		private bool _preserveChanges; // 0x20
		private MissingSchemaAction _missingSchemaAction; // 0x24
		private bool _isStandAlonetable; // 0x28
		private bool _IgnoreNSforTableLookup; // 0x29
	
		// Constructors
		internal Merger(DataSet dataSet, bool preserveChanges, MissingSchemaAction missingSchemaAction); // 0x000000018189B5F0-0x000000018189B650
		internal Merger(DataTable dataTable, bool preserveChanges, MissingSchemaAction missingSchemaAction); // 0x000000018189B580-0x000000018189B5F0
	
		// Methods
		internal void MergeDataSet(DataSet source); // 0x0000000181898CF0-0x00000001818999A0
		internal void MergeTable(DataTable src); // 0x000000018189AD20-0x000000018189AF90
		private void MergeTable(DataTable src, DataTable dst); // 0x000000018189AF90-0x000000018189B580
		private DataTable MergeSchema(DataTable table); // 0x000000018189A3B0-0x000000018189AC60
		private void MergeTableData(DataTable src); // 0x000000018189AC60-0x000000018189AD20
		private void MergeConstraints(DataSet source); // 0x0000000181898990-0x0000000181898A20
		private void MergeConstraints(DataTable table); // 0x0000000181898A20-0x0000000181898CF0
		private void MergeRelation(DataRelation relation); // 0x0000000181899B60-0x000000018189A3B0
		private void MergeExtendedProperties(PropertyCollection src, PropertyCollection dst); // 0x00000001818999A0-0x0000000181899B60
		private DataKey GetSrcKey(DataTable src, DataTable dst); // 0x00000001818987F0-0x0000000181898990
	}
}
