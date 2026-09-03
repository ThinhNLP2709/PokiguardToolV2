/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	internal sealed class Index // TypeDefIndex: 11315
	{
		// Fields
		private readonly DataTable _table; // 0x10
		internal readonly IndexField[] _indexFields; // 0x18
		private readonly Comparison<DataRow> _comparison; // 0x20
		private readonly DataViewRowState _recordStates; // 0x28
		private WeakReference _rowFilter; // 0x30
		private IndexTree _records; // 0x38
		private int _recordCount; // 0x40
		private int _refCount; // 0x44
		private Listeners<DataViewListener> _listeners; // 0x48
		private bool _suspendEvents; // 0x50
		private readonly bool _isSharable; // 0x51
		private readonly bool _hasRemoteAggregate; // 0x52
		private static int s_objectTypeCount; // 0x00
		private readonly int _objectID; // 0x54
	
		// Properties
		internal bool HasRemoteAggregate { get; } // 0x00000001818986C0-0x00000001818986D0 
		internal int ObjectID { get; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 
		public DataViewRowState RecordStates { get; } // 0x0000000180377930-0x0000000180377940 
		public IFilter RowFilter { get; } // 0x00000001818986D0-0x0000000181898760 
		public bool HasDuplicates { get; } // 0x00000001818986A0-0x00000001818986C0 
		public int RecordCount { get; } // 0x000000018033D790-0x000000018033D7A0 
		public int RefCount { get; } // 0x000000018033D780-0x000000018033D790 
		private bool DoListChanged { get; } // 0x0000000181898650-0x00000001818986A0 
		internal DataTable Table { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		private sealed class IndexTree : RBTree<int> // TypeDefIndex: 11316
		{
			// Fields
			private readonly Index _index; // 0x40
	
			// Constructors
			internal IndexTree(Index index); // 0x0000000181894C60-0x0000000181894CC0
	
			// Methods
			protected override int CompareNode(int record1, int record2); // 0x0000000181894C20-0x0000000181894C40
			protected override int CompareSateliteTreeNode(int record1, int record2); // 0x0000000181894C40-0x0000000181894C60
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 11317
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Listeners<DataViewListener, DataViewListener, bool> __9__22_0; // 0x08
			public static Listeners<DataViewListener, DataViewListener, ListChangedEventArgs, bool, bool> __9__85_0; // 0x10
	
			// Constructors
			static __c(); // 0x000000018189FD30-0x000000018189FDA0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _.ctor_b__22_0(DataViewListener listener); // 0x000000018052BB00-0x000000018052BB10
			internal void _OnListChanged_b__85_0(DataViewListener listener, ListChangedEventArgs args, bool arg2, bool arg3); // 0x000000018189FCC0-0x000000018189FCF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass86_0 // TypeDefIndex: 11318
		{
			// Fields
			public ListChangedType changedType; // 0x10
	
			// Constructors
			public __c__DisplayClass86_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _MaintainDataView_b__0(DataViewListener listener, ListChangedType type, DataRow row, bool track); // 0x000000018189FCF0-0x000000018189FD30
		}
	
		// Constructors
		public Index(DataTable table, IndexField[] indexFields, DataViewRowState recordStates, IFilter rowFilter); // 0x0000000181898620-0x0000000181898650
		public Index(DataTable table, Comparison<DataRow> comparison, DataViewRowState recordStates, IFilter rowFilter); // 0x00000001818981A0-0x0000000181898300
		private Index(DataTable table, IndexField[] indexFields, Comparison<DataRow> comparison, DataViewRowState recordStates, IFilter rowFilter); // 0x0000000181898300-0x0000000181898620
	
		// Methods
		private static IndexField[] GetAllFields(DataColumnCollection columns); // 0x0000000181895FB0-0x00000001818960C0
		public bool Equal(IndexField[] indexDesc, DataViewRowState recordStates, IFilter rowFilter); // 0x0000000181895800-0x00000001818958D0
		public int GetRecord(int recordIndex); // 0x00000001818964E0-0x0000000181896540
		private bool AcceptRecord(int record); // 0x0000000181894E10-0x0000000181894E40
		private bool AcceptRecord(int record, IFilter filter); // 0x0000000181894CC0-0x0000000181894E10
		internal void ListChangedAdd(DataViewListener listener); // 0x0000000181897250-0x00000001818972B0
		internal void ListChangedRemove(DataViewListener listener); // 0x00000001818972B0-0x0000000181897310
		public void AddRef(); // 0x0000000181894E40-0x0000000181895050
		public int RemoveRef(); // 0x0000000181897E20-0x0000000181897FE0
		private void ApplyChangeAction(int record, int action, int changeRecord); // 0x0000000181895050-0x0000000181895120
		public bool CheckUnique(); // 0x0000000181895120-0x0000000181895150
		private int CompareRecords(int record1, int record2); // 0x00000001818954C0-0x00000001818956C0
		private int CompareDataRows(int record1, int record2); // 0x0000000181895150-0x00000001818951D0
		private int CompareDuplicateRecords(int record1, int record2); // 0x00000001818951D0-0x00000001818953D0
		private int CompareRecordToKey(int record1, object[] vals); // 0x00000001818953D0-0x00000001818954C0
		public void DeleteRecordFromIndex(int recordIndex); // 0x00000001818956C0-0x00000001818956D0
		private void DeleteRecord(int recordIndex); // 0x00000001818957F0-0x0000000181895800
		private void DeleteRecord(int recordIndex, bool fireEvent); // 0x00000001818956D0-0x00000001818957F0
		public RBTree<int> GetEnumerator(int startIndex); // 0x00000001818960E0-0x0000000181896150
		public int GetIndex(int record); // 0x0000000181896150-0x00000001818961B0
		private int GetIndex(int record, int changeRecord); // 0x00000001818961B0-0x0000000181896380
		public object[] GetUniqueKeyValues(); // 0x0000000181896810-0x0000000181896910
		private int FindNodeByKey(object originalKey); // 0x0000000181895970-0x0000000181895B10
		private int FindNodeByKeys(object[] originalKey); // 0x0000000181895B10-0x0000000181895E00
		private int FindNodeByKeyRecord(int record); // 0x00000001818958D0-0x0000000181895970
		private Range GetRangeFromNode(int nodeId); // 0x0000000181896380-0x00000001818964E0
		public Range FindRecords(object key); // 0x0000000181895E50-0x0000000181895EA0
		public Range FindRecords(object[] key); // 0x0000000181895E00-0x0000000181895E50
		internal void FireResetEvent(); // 0x0000000181895EA0-0x0000000181895FB0
		private int GetChangeAction(DataViewRowState oldState, DataViewRowState newState); // 0x00000001818960C0-0x00000001818960E0
		private static int GetReplaceAction(DataViewRowState oldState); // 0x0000000181896540-0x0000000181896560
		public DataRow GetRow(int i); // 0x0000000181896560-0x00000001818965F0
		public DataRow[] GetRows(object[] values); // 0x00000001818967C0-0x0000000181896810
		public DataRow[] GetRows(Range range); // 0x00000001818965F0-0x00000001818967C0
		private void InitRecords(IFilter filter); // 0x0000000181896B20-0x0000000181896EB0
		public int InsertRecordToIndex(int record); // 0x0000000181896EB0-0x0000000181896F10
		private int InsertRecord(int record, bool fireEvent); // 0x0000000181896F10-0x0000000181897170
		public bool IsKeyInIndex(object key); // 0x0000000181897170-0x0000000181897190
		public bool IsKeyInIndex(object[] key); // 0x0000000181897190-0x00000001818971B0
		public bool IsKeyRecordInIndex(int record); // 0x00000001818971B0-0x0000000181897250
		private void OnListChanged(ListChangedType changedType, int newIndex, int oldIndex); // 0x00000001818974E0-0x00000001818975B0
		private void OnListChanged(ListChangedType changedType, int index); // 0x0000000181897430-0x00000001818974E0
		private void OnListChanged(ListChangedEventArgs e); // 0x00000001818975B0-0x0000000181897730
		private void MaintainDataView(ListChangedType changedType, int record, bool trackAddRemove); // 0x0000000181897310-0x0000000181897430
		public void Reset(); // 0x0000000181897FE0-0x00000001818981A0
		public void RecordChanged(int record); // 0x0000000181897870-0x0000000181897990
		public void RecordChanged(int oldIndex, int newIndex); // 0x0000000181897730-0x0000000181897870
		public void RecordStateChanged(int record, DataViewRowState oldState, DataViewRowState newState); // 0x0000000181897D10-0x0000000181897E20
		public void RecordStateChanged(int oldRecord, DataViewRowState oldOldState, DataViewRowState oldNewState, int newRecord, DataViewRowState newOldState, DataViewRowState newNewState); // 0x0000000181897990-0x0000000181897D10
		private void GetUniqueKeyValues(List<object[]> list, int curNodeId); // 0x0000000181896910-0x0000000181896B20
		internal static int IndexOfReference<T>(List<T> list, T item)
			where T : class;
	}
}
