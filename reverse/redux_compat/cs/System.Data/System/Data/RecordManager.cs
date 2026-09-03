/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class RecordManager // TypeDefIndex: 11309
	{
		// Fields
		private readonly DataTable _table; // 0x10
		private int _lastFreeRecord; // 0x18
		private int _minimumCapacity; // 0x1C
		private int _recordCapacity; // 0x20
		private readonly List<int> _freeRecordList; // 0x28
		private DataRow[] _rows; // 0x30
	
		// Properties
		internal int LastFreeRecord { get; } // 0x0000000180B23260-0x0000000180B23270 
		internal int MinimumCapacity { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x000000018189D090-0x000000018189D0D0
		internal int RecordCapacity { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x000000018189D0D0-0x000000018189D180
		internal DataRow this[int record] { get => default; set {} } // 0x000000018189CFE0-0x000000018189D010 0x000000018189D010-0x000000018189D090
	
		// Constructors
		internal RecordManager(DataTable table); // 0x000000018189CF00-0x000000018189CFE0
	
		// Methods
		private void GrowRecordCapacity(); // 0x000000018189CBB0-0x000000018189CDC0
		internal static int NewCapacity(int capacity); // 0x000000018189CDE0-0x000000018189CDF0
		private int NormalizedMinimumCapacity(int capacity); // 0x000000018189CE80-0x000000018189CEC0
		internal int NewRecordBase(); // 0x000000018189CDF0-0x000000018189CE80
		internal void FreeRecord(ref int record); // 0x000000018189CA40-0x000000018189CBB0
		internal void Clear(bool clearAll); // 0x000000018189C610-0x000000018189C800
		internal int ImportRecord(DataTable src, int record); // 0x000000018189CDC0-0x000000018189CDE0
		internal int CopyRecord(DataTable src, int record, int copy); // 0x000000018189C800-0x000000018189CA40
		internal void SetRowCache(DataRow[] newRows); // 0x000000018189CEC0-0x000000018189CF00
	}
}
