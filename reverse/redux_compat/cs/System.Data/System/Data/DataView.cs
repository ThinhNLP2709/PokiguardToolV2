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
	[DefaultEvent("PositionChanged")]
	[DefaultProperty("Table")]
	public class DataView : MarshalByValueComponent, IBindingList, ITypedList // TypeDefIndex: 11259
	{
		// Fields
		private DataViewManager _dataViewManager; // 0x20
		private DataTable _table; // 0x28
		private bool _locked; // 0x30
		private Index _index; // 0x38
		private Dictionary<string, Index> _findIndexes; // 0x40
		private string _sort; // 0x48
		private Comparison<DataRow> _comparison; // 0x50
		private IFilter _rowFilter; // 0x58
		private DataViewRowState _recordStates; // 0x60
		private bool _shouldOpen; // 0x64
		private bool _open; // 0x65
		private bool _allowNew; // 0x66
		private bool _allowEdit; // 0x67
		private bool _allowDelete; // 0x68
		private bool _applyDefaultSort; // 0x69
		internal DataRow _addNewRow; // 0x70
		private ListChangedEventArgs _addNewMoved; // 0x78
		private ListChangedEventHandler _onListChanged; // 0x80
		internal static ListChangedEventArgs s_resetEventArgs; // 0x00
		private string _delayedSort; // 0x88
		private DataViewRowState _delayedRecordStates; // 0x90
		private bool _fInitInProgress; // 0x94
		private bool _fEndInitInProgress; // 0x95
		private Dictionary<DataRow, DataRowView> _rowViewCache; // 0x98
		private readonly Dictionary<DataRow, DataRowView> _rowViewBuffer; // 0xA0
		private DataViewListener _dvListener; // 0xA8
		private static int s_objectTypeCount; // 0x08
		private readonly int _objectID; // 0xB0
	
		// Properties
		[DefaultValue(true)]
		public bool AllowDelete { get; } // 0x0000000180B25580-0x0000000180B25590 
		[DefaultValue(true)]
		public bool AllowEdit { get; } // 0x0000000181889AF0-0x0000000181889B00 
		[DefaultValue(true)]
		public bool AllowNew { get; } // 0x0000000181889B00-0x0000000181889B10 
		[Browsable(false)]
		public int Count { get; } // 0x000000018188A540-0x000000018188A570 
		private int CountFromIndex { get; } // 0x000000018188A510-0x000000018188A540 
		[Browsable(false)]
		public DataViewManager DataViewManager { get; } // 0x00000001802F8630-0x00000001802F8640 
		[Browsable(false)]
		protected bool IsOpen { get; } // 0x000000018188A570-0x000000018188A580 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		[DefaultValue(DataViewRowState.None | DataViewRowState.Unchanged | DataViewRowState.Added | DataViewRowState.ModifiedCurrent | DataViewRowState.CurrentRows)]
		public DataViewRowState RowStateFilter { get; } // 0x000000018150C180-0x000000018150C190 
		[DefaultValue("")]
		public string Sort { get; set; } // 0x000000018188A580-0x000000018188A5E0 0x000000018188A5E0-0x000000018188A7B0
		internal Comparison<DataRow> SortComparison { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		object ICollection.SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		[DefaultValue(null)]
		[RefreshProperties(RefreshProperties.All)]
		[TypeConverter(typeof(DataTableTypeConverter))]
		public DataTable Table { get; } // 0x000000018033D240-0x000000018033D250 
		object IList.this[int recordIndex] { get => default; set {} } // 0x0000000181889550-0x00000001818895B0 0x00000001818895B0-0x00000001818895E0
		public DataRowView this[int recordIndex] { get => default; } // 0x0000000181889550-0x00000001818895B0 
		bool IList.IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		bool IList.IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		bool IBindingList.AllowNew { get; } // 0x0000000181889B00-0x0000000181889B10 
		bool IBindingList.AllowEdit { get; } // 0x0000000181889AF0-0x0000000181889B00 
		bool IBindingList.AllowRemove { get; } // 0x0000000180B25580-0x0000000180B25590 
		bool IBindingList.SupportsChangeNotification { get; } // 0x00000001802E7990-0x00000001802E79A0 
		bool IBindingList.SupportsSearching { get; } // 0x00000001802E7990-0x00000001802E79A0 
		bool IBindingList.SupportsSorting { get; } // 0x00000001802E7990-0x00000001802E79A0 
		bool IBindingList.IsSorted { get; } // 0x0000000181889B10-0x0000000181889B70 
		PropertyDescriptor IBindingList.SortProperty { get; } // 0x0000000181889BB0-0x0000000181889C40 
		ListSortDirection IBindingList.SortDirection { get; } // 0x0000000181889B70-0x0000000181889BB0 
		internal int ObjectID { get; } // 0x000000018158ACB0-0x000000018158ACC0 
	
		// Nested types
		private sealed class DataRowReferenceComparer : IEqualityComparer<DataRow> // TypeDefIndex: 11260
		{
			// Fields
			internal static readonly DataRowReferenceComparer s_default; // 0x00
	
			// Constructors
			private DataRowReferenceComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static DataRowReferenceComparer(); // 0x0000000181885590-0x0000000181885600
	
			// Methods
			public bool Equals(DataRow x, DataRow y); // 0x000000018171AC80-0x000000018171AC90
			public int GetHashCode(DataRow obj); // 0x0000000181885570-0x0000000181885590
		}
	
		// Constructors
		internal DataView(DataTable table, bool locked); // 0x000000018188A160-0x000000018188A4A0
		public DataView(DataTable table); // 0x000000018188A4A0-0x000000018188A510
		static DataView(); // 0x000000018188A0E0-0x000000018188A160
	
		// Methods
		public virtual DataRowView AddNew(); // 0x0000000181886AC0-0x0000000181886D80
		private void CheckOpen(); // 0x0000000181886D80-0x0000000181886DC0
		private void CheckSort(string sort); // 0x0000000181886DC0-0x0000000181886E20
		protected void Close(); // 0x0000000181887060-0x00000001818870B0
		public void CopyTo(Array array, int index); // 0x0000000181887310-0x0000000181887460
		private void CopyTo(DataRowView[] array, int index); // 0x0000000181887460-0x0000000181887670
		public void Delete(int index); // 0x0000000181887910-0x0000000181887940
		internal void Delete(DataRow row); // 0x0000000181887750-0x0000000181887910
		protected override void Dispose(bool disposing); // 0x0000000181887940-0x00000001818879B0
		internal void FinishAddNew(bool success); // 0x00000001818879B0-0x0000000181887B70
		public IEnumerator GetEnumerator(); // 0x0000000181887B70-0x0000000181887BF0
		int IList.Add(object value); // 0x0000000181889220-0x0000000181889290
		void IList.Clear(); // 0x0000000181889290-0x00000001818892C0
		bool IList.Contains(object value); // 0x00000001818892C0-0x0000000181889350
		int IList.IndexOf(object value); // 0x0000000181889350-0x00000001818893E0
		internal int IndexOf(DataRowView rowview); // 0x0000000181888280-0x00000001818883B0
		private int IndexOfDataRowView(DataRowView rowview); // 0x0000000181888220-0x0000000181888280
		void IList.Insert(int index, object value); // 0x00000001818893E0-0x0000000181889410
		void IList.Remove(object value); // 0x0000000181889410-0x0000000181889550
		void IList.RemoveAt(int index); // 0x0000000181887910-0x0000000181887940
		internal Index GetFindIndex(string column, bool keepIndex); // 0x0000000181887BF0-0x0000000181887DB0
		object IBindingList.AddNew(); // 0x0000000181889630-0x0000000181889650
		internal PropertyDescriptor GetSortProperty(); // 0x0000000181888050-0x00000001818880E0
		void IBindingList.AddIndex(PropertyDescriptor property); // 0x00000001818895E0-0x0000000181889630
		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction); // 0x0000000181889650-0x0000000181889750
		int IBindingList.Find(PropertyDescriptor property, object key); // 0x0000000181889750-0x00000001818899F0
		void IBindingList.RemoveIndex(PropertyDescriptor property); // 0x00000001818899F0-0x0000000181889A40
		void IBindingList.RemoveSort(); // 0x0000000181889A40-0x0000000181889AF0
		private string CreateSortString(PropertyDescriptor property, ListSortDirection direction); // 0x0000000181887670-0x0000000181887750
		string ITypedList.GetListName(PropertyDescriptor[] listAccessors); // 0x0000000181889D10-0x0000000181889D90
		PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors); // 0x0000000181889C40-0x0000000181889D10
		internal virtual IFilter GetFilter(); // 0x00000001802F4000-0x00000001802F4010
		private int GetRecord(int recordIndex); // 0x0000000181887DB0-0x0000000181887E50
		internal DataRow GetRow(int index); // 0x0000000181887F30-0x0000000181888050
		private DataRowView GetRowView(int record); // 0x0000000181887EB0-0x0000000181887F30
		private DataRowView GetRowView(DataRow dr); // 0x0000000181887E50-0x0000000181887EB0
		protected virtual void IndexListChanged(object sender, ListChangedEventArgs e); // 0x0000000181888190-0x0000000181888220
		internal void IndexListChangedInternal(ListChangedEventArgs e); // 0x00000001818880E0-0x0000000181888190
		internal void MaintainDataView(ListChangedType changedType, DataRow row, bool trackAddRemove); // 0x00000001818883B0-0x00000001818886A0
		protected virtual void OnListChanged(ListChangedEventArgs e); // 0x00000001818886A0-0x0000000181888960
		protected void Reset(); // 0x0000000181888E10-0x0000000181888E40
		internal void ResetRowViewCache(); // 0x0000000181888BA0-0x0000000181888E10
		internal void SetDataViewManager(DataViewManager dataViewManager); // 0x0000000181888E40-0x0000000181888FF0
		internal virtual void SetIndex(string newSort, DataViewRowState newRowStates, IFilter newRowFilter); // 0x0000000181889200-0x0000000181889220
		internal void SetIndex2(string newSort, DataViewRowState newRowStates, IFilter newRowFilter, bool fireEvent); // 0x0000000181888FF0-0x0000000181889200
		protected void UpdateIndex(); // 0x000000018188A0B0-0x000000018188A0D0
		protected virtual void UpdateIndex(bool force); // 0x000000018188A0D0-0x000000018188A0E0
		internal void UpdateIndex(bool force, bool fireEvent); // 0x0000000181889D90-0x000000018188A0B0
		internal void ChildRelationCollectionChanged(object sender, CollectionChangeEventArgs e); // 0x0000000181886E20-0x0000000181887060
		internal void ParentRelationCollectionChanged(object sender, CollectionChangeEventArgs e); // 0x0000000181888960-0x0000000181888BA0
		protected virtual void ColumnCollectionChanged(object sender, CollectionChangeEventArgs e); // 0x00000001818870D0-0x0000000181887310
		internal void ColumnCollectionChangedInternal(object sender, CollectionChangeEventArgs e); // 0x00000001818870B0-0x00000001818870D0
	}
}
