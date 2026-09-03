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
	[IsReadOnly]
	internal struct DataKey // TypeDefIndex: 11232
	{
		// Fields
		private readonly DataColumn[] _columns; // 0x00
	
		// Properties
		internal DataColumn[] ColumnsReference { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		internal bool HasValue { get; } // 0x0000000180A3EC30-0x0000000180A3EC40 
		internal DataTable Table { get; } // 0x000000018186B6B0-0x000000018186B6E0 
	
		// Constructors
		internal DataKey(DataColumn[] columns, bool copyColumns); // 0x000000018186B3E0-0x000000018186B6B0
	
		// Methods
		internal void CheckState(); // 0x000000018186A890-0x000000018186A990
		internal bool ColumnsEqual(DataKey key); // 0x000000018186AA50-0x000000018186AB10
		internal static bool ColumnsEqual(DataColumn[] column1, DataColumn[] column2); // 0x000000018186A990-0x000000018186AA50
		internal bool ContainsColumn(DataColumn column); // 0x000000018186AB10-0x000000018186AB70
		public override int GetHashCode(); // 0x000000018186AE10-0x000000018186AE60
		public override bool Equals(object value); // 0x000000018186AC20-0x000000018186AD30
		internal bool Equals(DataKey value); // 0x000000018186AB70-0x000000018186AC20
		internal string[] GetColumnNames(); // 0x000000018186AD30-0x000000018186AE10
		internal IndexField[] GetIndexDesc(); // 0x000000018186AE60-0x000000018186AF80
		internal object[] GetKeyValues(int record); // 0x000000018186AF80-0x000000018186B0B0
		internal Index GetSortIndex(); // 0x000000018186B210-0x000000018186B220
		internal Index GetSortIndex(DataViewRowState recordStates); // 0x000000018186B0B0-0x000000018186B210
		internal bool RecordsEqual(int record1, int record2); // 0x000000018186B220-0x000000018186B2D0
		internal DataColumn[] ToArray(); // 0x000000018186B2D0-0x000000018186B3E0
	}
}
