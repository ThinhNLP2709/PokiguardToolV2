/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class DataViewSetting // TypeDefIndex: 11265
	{
		// Fields
		private DataViewManager _dataViewManager; // 0x10
		private DataTable _table; // 0x18
		private string _sort; // 0x20
		private string _rowFilter; // 0x28
		private DataViewRowState _rowStateFilter; // 0x30
		private bool _applyDefaultSort; // 0x34
	
		// Properties
		public bool ApplyDefaultSort { get; } // 0x00000001816DAFD0-0x00000001816DAFE0 
		public string RowFilter { get; } // 0x000000018033D240-0x000000018033D250 
		public DataViewRowState RowStateFilter { get; } // 0x000000018033D100-0x000000018033D110 
		public string Sort { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		internal DataViewSetting(); // 0x0000000181886A60-0x0000000181886AC0
	
		// Methods
		internal void SetDataViewManager(DataViewManager dataViewManager); // 0x000000018186EBB0-0x000000018186EBD0
		internal void SetDataTable(DataTable table); // 0x0000000181886A40-0x0000000181886A60
	}
}
