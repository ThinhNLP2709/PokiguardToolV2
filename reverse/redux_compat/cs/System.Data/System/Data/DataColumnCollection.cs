/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[DefaultEvent("CollectionChanged")]
	public sealed class DataColumnCollection : InternalDataCollectionBase // TypeDefIndex: 11228
	{
		// Fields
		private readonly DataTable _table; // 0x10
		private readonly ArrayList _list; // 0x18
		private int _defaultNameIndex; // 0x20
		private DataColumn[] _delayedAddRangeColumns; // 0x28
		private readonly Dictionary<string, DataColumn> _columnFromName; // 0x30
		private bool _fInClear; // 0x38
		private DataColumn[] _columnsImplementingIChangeTracking; // 0x40
		private int _nColumnsImplementingIChangeTracking; // 0x48
		private int _nColumnsImplementingIRevertibleChangeTracking; // 0x4C
		[CompilerGenerated]
		private CollectionChangeEventHandler CollectionChanged; // 0x50
		[CompilerGenerated]
		private CollectionChangeEventHandler CollectionChanging; // 0x58
		[CompilerGenerated]
		private CollectionChangeEventHandler ColumnPropertyChanged; // 0x60
	
		// Properties
		protected override ArrayList List { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal DataColumn[] ColumnsImplementingIChangeTracking { get; } // 0x0000000180377940-0x0000000180377950 
		internal int ColumnsImplementingIChangeTrackingCount { get; } // 0x000000018033D1C0-0x000000018033D1D0 
		internal int ColumnsImplementingIRevertibleChangeTrackingCount { get; } // 0x000000018033D1B0-0x000000018033D1C0 
		public DataColumn this[int index] { get => default; } // 0x0000000181869520-0x0000000181869600 
		public DataColumn this[string name] { get => default; } // 0x0000000181869600-0x0000000181869770 
		internal DataColumn this[string name, string ns] { get => default; } // 0x0000000181869470-0x0000000181869520 
	
		// Events
		public event CollectionChangeEventHandler CollectionChanged {
			add; // 0x0000000181869330-0x00000001818693D0
			remove; // 0x0000000181869770-0x0000000181869810
		}
		internal event CollectionChangeEventHandler ColumnPropertyChanged {
			add; // 0x00000001818693D0-0x0000000181869470
			remove; // 0x0000000181869810-0x00000001818698B0
		}
	
		// Constructors
		internal DataColumnCollection(DataTable table); // 0x00000001818691E0-0x0000000181869330
	
		// Methods
		public void Add(DataColumn column); // 0x0000000181866CF0-0x0000000181866D00
		internal void AddAt(int index, DataColumn column); // 0x00000001818668C0-0x0000000181866C00
		private void ArrayAdd(DataColumn column); // 0x0000000181866D70-0x0000000181866E10
		private void ArrayAdd(int index, DataColumn column); // 0x0000000181866D00-0x0000000181866D70
		private void ArrayRemove(DataColumn column); // 0x0000000181866E10-0x0000000181867080
		internal string AssignName(); // 0x0000000181867080-0x00000001818671A0
		private void BaseAdd(DataColumn column); // 0x00000001818671A0-0x0000000181867510
		private void BaseGroupSwitch(DataColumn[] oldArray, int oldLength, DataColumn[] newArray, int newLength); // 0x0000000181867510-0x0000000181867740
		private void BaseRemove(DataColumn column); // 0x0000000181867740-0x0000000181867950
		internal bool CanRemove(DataColumn column, bool fThrowException); // 0x00000001818679B0-0x00000001818682C0
		private void CheckIChangeTracking(DataColumn column); // 0x00000001818682C0-0x0000000181868310
		public void Clear(); // 0x0000000181868310-0x0000000181868660
		public bool Contains(string name); // 0x0000000181868720-0x00000001818687B0
		internal bool Contains(string name, bool caseSensitive); // 0x0000000181868660-0x0000000181868720
		public int IndexOf(string columnName); // 0x0000000181868950-0x0000000181868A60
		internal int IndexOfCaseInsensitive(string name); // 0x00000001818687B0-0x0000000181868950
		private string MakeName(int index); // 0x0000000181868A60-0x0000000181868AF0
		private void OnCollectionChanged(CollectionChangeEventArgs ccevent); // 0x0000000181868AF0-0x0000000181868BE0
		private void OnCollectionChanging(CollectionChangeEventArgs ccevent); // 0x000000018136F050-0x000000018136F070
		internal void OnColumnPropertyChanged(CollectionChangeEventArgs ccevent); // 0x0000000181868BE0-0x0000000181868C30
		internal void RegisterColumnName(string name, DataColumn column); // 0x0000000181868C30-0x0000000181868DD0
		internal bool CanRegisterName(string name); // 0x0000000181867950-0x00000001818679B0
		public void Remove(DataColumn column); // 0x0000000181868F30-0x0000000181869040
		internal void UnregisterName(string name); // 0x0000000181869040-0x00000001818691E0
		private void AddColumnsImplementingIChangeTrackingList(DataColumn dataColumn); // 0x0000000181866C00-0x0000000181866CF0
		private void RemoveColumnsImplementingIChangeTrackingList(DataColumn dataColumn); // 0x0000000181868DD0-0x0000000181868F30
	}
}
