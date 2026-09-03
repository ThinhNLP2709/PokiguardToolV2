/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	public class DataRow // TypeDefIndex: 11238
	{
		// Fields
		private readonly DataTable _table; // 0x10
		private readonly DataColumnCollection _columns; // 0x18
		internal int _oldRecord; // 0x20
		internal int _newRecord; // 0x24
		internal int _tempRecord; // 0x28
		internal long _rowID; // 0x30
		internal DataRowAction _action; // 0x38
		internal bool _inChangingEvent; // 0x3C
		internal bool _inDeletingEvent; // 0x3D
		internal bool _inCascade; // 0x3E
		private DataColumn _lastChangedColumn; // 0x40
		private int _countColumnChange; // 0x48
		private DataError _error; // 0x50
		private int _rbTreeNodeId; // 0x58
		private static int s_objectTypeCount; // 0x00
		internal readonly int _objectID; // 0x5C
	
		// Properties
		internal DataColumn LastChangedColumn { get; set; } // 0x0000000181874D30-0x0000000181874D40 0x0000000181875810-0x0000000181875820
		internal bool HasPropertyChanged { get; } // 0x0000000181874B30-0x0000000181874B40 
		internal int RBTreeNodeId { get; set; } // 0x000000018033D260-0x000000018033D270 0x0000000181875820-0x00000001818758D0
		public string RowError { get; set; } // 0x0000000181874D40-0x0000000181874D70 0x00000001818758D0-0x0000000181875AA0
		internal long rowID { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181875AA0-0x0000000181875AE0
		public DataRowState RowState { get; } // 0x0000000181874D70-0x0000000181874F30 
		public DataTable Table { get; } // 0x0000000180377550-0x0000000180377560 
		public object this[string columnName] { set {} } // 0x0000000181875370-0x0000000181875410
		public object this[DataColumn column] { get => default; set {} } // 0x0000000181874C20-0x0000000181874D30 0x0000000181875410-0x0000000181875810
		public object this[DataColumn column, DataRowVersion version] { get => default; } // 0x0000000181874B40-0x0000000181874C20 
		public object[] ItemArray { set; } // 0x0000000181874F30-0x0000000181875370
		public bool HasErrors { get; } // 0x0000000181874AF0-0x0000000181874B30 
	
		// Constructors
		protected internal DataRow(DataRowBuilder builder); // 0x0000000181874A40-0x0000000181874AF0
	
		// Methods
		private void RowErrorChanged(); // 0x0000000181873E50-0x0000000181873EA0
		internal void CheckForLoops(DataRelation rel); // 0x0000000181871E30-0x0000000181871F30
		internal int GetNestedParentCount(); // 0x0000000181872E70-0x0000000181872F40
		public void AcceptChanges(); // 0x0000000181871990-0x0000000181871C10
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void BeginEdit(); // 0x0000000181871CF0-0x0000000181871D00
		private bool BeginEditInternal(); // 0x0000000181871C10-0x0000000181871CF0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void CancelEdit(); // 0x0000000181871D00-0x0000000181871D70
		private void CheckColumn(DataColumn column); // 0x0000000181871D70-0x0000000181871E30
		internal void CheckInTable(); // 0x0000000181871F30-0x0000000181871F70
		public void Delete(); // 0x0000000181872500-0x0000000181872570
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void EndEdit(); // 0x0000000181872570-0x0000000181872670
		public void SetColumnError(int columnIndex, string error); // 0x0000000181874150-0x00000001818741D0
		public void SetColumnError(DataColumn column, string error); // 0x0000000181873EA0-0x0000000181874150
		public string GetColumnError(DataColumn column); // 0x0000000181872880-0x0000000181872A40
		public void ClearErrors(); // 0x0000000181872080-0x0000000181872160
		internal void ClearError(DataColumn column); // 0x0000000181871F70-0x0000000181872080
		public DataColumn[] GetColumnsInError(); // 0x0000000181872AF0-0x0000000181872C70
		public DataRow[] GetChildRows(DataRelation relation); // 0x0000000181872670-0x0000000181872680
		public DataRow[] GetChildRows(DataRelation relation, DataRowVersion version); // 0x0000000181872680-0x0000000181872880
		internal DataColumn GetDataColumn(string columnName); // 0x0000000181872CB0-0x0000000181872D30
		public DataRow GetParentRow(DataRelation relation); // 0x00000001818731D0-0x00000001818731E0
		public DataRow GetParentRow(DataRelation relation, DataRowVersion version); // 0x0000000181873050-0x00000001818731D0
		internal DataRow GetNestedParentRow(DataRowVersion version); // 0x0000000181872F40-0x0000000181873010
		public DataRow[] GetParentRows(DataRelation relation); // 0x00000001818733E0-0x00000001818733F0
		public DataRow[] GetParentRows(DataRelation relation, DataRowVersion version); // 0x00000001818731E0-0x00000001818733E0
		internal object[] GetColumnValues(DataColumn[] columns); // 0x0000000181872AA0-0x0000000181872AF0
		internal object[] GetColumnValues(DataColumn[] columns, DataRowVersion version); // 0x0000000181872A40-0x0000000181872AA0
		internal object[] GetKeyValues(DataKey key); // 0x0000000181872DC0-0x0000000181872E40
		internal object[] GetKeyValues(DataKey key, DataRowVersion version); // 0x0000000181872E40-0x0000000181872E70
		internal int GetCurrentRecordNo(); // 0x0000000181872C70-0x0000000181872CB0
		internal int GetDefaultRecord(); // 0x0000000181872D30-0x0000000181872D90
		internal int GetOriginalRecordNo(); // 0x0000000181873010-0x0000000181873050
		private int GetProposedRecordNo(); // 0x00000001818733F0-0x0000000181873430
		internal int GetRecordFromVersion(DataRowVersion version); // 0x0000000181873430-0x0000000181873520
		internal DataRowVersion GetDefaultRowVersion(DataViewRowState viewState); // 0x0000000181872D90-0x0000000181872DC0
		internal DataViewRowState GetRecordState(int record); // 0x0000000181873520-0x0000000181873570
		internal bool HasKeyChanged(DataKey key); // 0x0000000181873570-0x00000001818735A0
		internal bool HasKeyChanged(DataKey key, DataRowVersion version1, DataRowVersion version2); // 0x00000001818735A0-0x0000000181873680
		public bool HasVersion(DataRowVersion version); // 0x0000000181873680-0x0000000181873710
		internal bool HaveValuesChanged(DataColumn[] columns); // 0x0000000181873710-0x0000000181873840
		internal bool HaveValuesChanged(DataColumn[] columns, DataRowVersion version1, DataRowVersion version2); // 0x0000000181873840-0x0000000181873980
		public void RejectChanges(); // 0x0000000181873980-0x0000000181873E20
		internal void ResetLastChangedColumn(); // 0x0000000181873E20-0x0000000181873E50
		internal void SetKeyValues(DataKey key, object[] keyValues); // 0x00000001818741D0-0x00000001818742F0
		internal void SetNestedParentRow(DataRow parentRow, bool setNonNested); // 0x00000001818742F0-0x0000000181874640
		internal void SetParentRowToDBNull(); // 0x0000000181874640-0x0000000181874880
		internal void SetParentRowToDBNull(DataRelation relation); // 0x0000000181874880-0x0000000181874A40
		internal int CopyValuesIntoStore(ArrayList storeList, ArrayList nullbitList, int storeIndex); // 0x0000000181872160-0x0000000181872500
	}
}
