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

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	public sealed class DataRowCollection : InternalDataCollectionBase // TypeDefIndex: 11243
	{
		// Fields
		private readonly DataTable _table; // 0x10
		private readonly DataRowTree _list; // 0x18
		internal int _nullInList; // 0x20
	
		// Properties
		public override int Count { get; } // 0x0000000181870EF0-0x0000000181870F10 
		public DataRow this[int index] { get => default; } // 0x0000000181870F10-0x0000000181870F70 
	
		// Nested types
		private sealed class DataRowTree : RBTree<DataRow> // TypeDefIndex: 11244
		{
			// Constructors
			internal DataRowTree(); // 0x0000000181870FD0-0x0000000181871010
	
			// Methods
			protected override int CompareNode(DataRow record1, DataRow record2); // 0x0000000181870F70-0x0000000181870FA0
			protected override int CompareSateliteTreeNode(DataRow record1, DataRow record2); // 0x0000000181870FA0-0x0000000181870FD0
		}
	
		// Constructors
		internal DataRowCollection(DataTable table); // 0x0000000181870E20-0x0000000181870EF0
	
		// Methods
		public void Add(DataRow row); // 0x0000000181870830-0x0000000181870860
		internal void DiffInsertAt(DataRow row, int pos); // 0x0000000181870B20-0x0000000181870D40
		public int IndexOf(DataRow row); // 0x0000000181870D90-0x0000000181870E20
		internal DataRow AddWithColumnEvents(params object[] values); // 0x00000001818707B0-0x0000000181870830
		internal void ArrayAdd(DataRow row); // 0x0000000181870860-0x00000001818708D0
		internal void ArrayInsert(DataRow row, int pos); // 0x0000000181870920-0x00000001818709A0
		internal void ArrayClear(); // 0x00000001818708D0-0x0000000181870920
		internal void ArrayRemove(DataRow row); // 0x00000001818709A0-0x0000000181870A40
		public override void CopyTo(Array ar, int index); // 0x0000000181870AB0-0x0000000181870B20
		public void CopyTo(DataRow[] array, int index); // 0x0000000181870A40-0x0000000181870AB0
		public override IEnumerator GetEnumerator(); // 0x0000000181870D40-0x0000000181870D90
	}
}
