/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[Serializable]
	[DefaultEvent("RowChanging")]
	[DefaultProperty("TableName")]
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	[XmlSchemaProvider("GetDataTableSchema")]
	public class DataTable : MarshalByValueComponent, ISerializable, IXmlSerializable // TypeDefIndex: 11204
	{
		// Fields
		private DataSet _dataSet; // 0x20
		private DataView _defaultView; // 0x28
		internal long _nextRowID; // 0x30
		internal readonly DataRowCollection _rowCollection; // 0x38
		internal readonly DataColumnCollection _columnCollection; // 0x40
		private readonly ConstraintCollection _constraintCollection; // 0x48
		private int _elementColumnCount; // 0x50
		internal DataRelationCollection _parentRelationsCollection; // 0x58
		internal DataRelationCollection _childRelationsCollection; // 0x60
		internal readonly RecordManager _recordManager; // 0x68
		internal readonly List<Index> _indexes; // 0x70
		private List<Index> _shadowIndexes; // 0x78
		private int _shadowCount; // 0x80
		internal PropertyCollection _extendedProperties; // 0x88
		private string _tableName; // 0x90
		internal string _tableNamespace; // 0x98
		private string _tablePrefix; // 0xA0
		internal DataExpression _displayExpression; // 0xA8
		internal bool _fNestedInDataset; // 0xB0
		private CultureInfo _culture; // 0xB8
		private bool _cultureUserSet; // 0xC0
		private CompareInfo _compareInfo; // 0xC8
		private CompareOptions _compareFlags; // 0xD0
		private IFormatProvider _formatProvider; // 0xD8
		private StringComparer _hashCodeProvider; // 0xE0
		private bool _caseSensitive; // 0xE8
		private bool _caseSensitiveUserSet; // 0xE9
		internal string _encodedTableName; // 0xF0
		internal DataColumn _xmlText; // 0xF8
		internal DataColumn _colUnique; // 0x100
		internal decimal _minOccurs; // 0x108
		internal decimal _maxOccurs; // 0x118
		internal bool _repeatableElement; // 0x128
		private object _typeName; // 0x130
		internal UniqueConstraint _primaryKey; // 0x138
		internal IndexField[] _primaryIndex; // 0x140
		private DataColumn[] _delayedSetPrimaryKey; // 0x148
		private Index _loadIndex; // 0x150
		private Index _loadIndexwithOriginalAdded; // 0x158
		private Index _loadIndexwithCurrentDeleted; // 0x160
		private int _suspendIndexEvents; // 0x168
		private bool _inDataLoad; // 0x16C
		private bool _schemaLoading; // 0x16D
		private bool _enforceConstraints; // 0x16E
		internal bool _suspendEnforceConstraints; // 0x16F
		protected internal bool fInitInProgress; // 0x170
		private bool _inLoad; // 0x171
		internal bool _fInLoadDiffgram; // 0x172
		private byte _isTypedDataTable; // 0x173
		private DataRow[] _emptyDataRowArray; // 0x178
		private PropertyDescriptorCollection _propertyDescriptorCollectionCache; // 0x180
		private DataRelation[] _nestedParentRelations; // 0x188
		internal List<DataColumn> _dependentColumns; // 0x190
		private bool _mergingData; // 0x198
		private DataRowChangeEventHandler _onRowChangedDelegate; // 0x1A0
		private DataRowChangeEventHandler _onRowChangingDelegate; // 0x1A8
		private DataRowChangeEventHandler _onRowDeletingDelegate; // 0x1B0
		private DataRowChangeEventHandler _onRowDeletedDelegate; // 0x1B8
		private DataColumnChangeEventHandler _onColumnChangedDelegate; // 0x1C0
		private DataColumnChangeEventHandler _onColumnChangingDelegate; // 0x1C8
		private DataTableClearEventHandler _onTableClearingDelegate; // 0x1D0
		private DataTableClearEventHandler _onTableClearedDelegate; // 0x1D8
		private DataTableNewRowEventHandler _onTableNewRowDelegate; // 0x1E0
		private PropertyChangedEventHandler _onPropertyChangingDelegate; // 0x1E8
		private readonly DataRowBuilder _rowBuilder; // 0x1F0
		internal readonly List<DataView> _delayedViews; // 0x1F8
		private readonly List<DataViewListener> _dataViewListeners; // 0x200
		internal Hashtable _rowDiffId; // 0x208
		internal readonly ReaderWriterLockSlim _indexesLock; // 0x210
		internal int _ukColumnPositionForInference; // 0x218
		private SerializationFormat _remotingFormat; // 0x21C
		private static int s_objectTypeCount; // 0x00
		private readonly int _objectID; // 0x220
	
		// Properties
		public bool CaseSensitive { get; set; } // 0x0000000180718600-0x0000000180718610 0x0000000181840460-0x0000000181840520
		internal bool AreIndexEventsSuspended { get; } // 0x000000018183F830-0x000000018183F840 
		private bool IsTypedDataTable { get; } // 0x000000018183FB30-0x000000018183FBB0 
		internal bool SelfNested { get; } // 0x0000000181840180-0x0000000181840390 
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal List<Index> LiveIndexes { get; } // 0x000000018183FBB0-0x000000018183FC20 
		[DefaultValue(SerializationFormat.Xml)]
		public SerializationFormat RemotingFormat { get; set; } // 0x00000001818400E0-0x00000001818400F0 0x00000001818412F0-0x0000000181841370
		internal int UKColumnPositionForInference { get; set; } // 0x0000000181840450-0x0000000181840460 0x00000001818418C0-0x00000001818418D0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataRelationCollection ChildRelations { get; } // 0x000000018183F840-0x000000018183F8C0 
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public DataColumnCollection Columns { get; } // 0x0000000180377940-0x0000000180377950 
		private CompareInfo CompareInfo { get; } // 0x000000018183F8C0-0x000000018183F930 
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ConstraintCollection Constraints { get; } // 0x00000001803272B0-0x00000001803272C0 
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataSet DataSet { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal string DisplayExpressionInternal { get; } // 0x000000018183F930-0x000000018183F960 
		internal bool EnforceConstraints { get; set; } // 0x000000018183F9F0-0x000000018183FA20 0x0000000181840570-0x00000001818405B0
		internal bool SuspendEnforceConstraints { get; set; } // 0x0000000181840390-0x00000001818403A0 0x0000000181841370-0x0000000181841380
		[Browsable(false)]
		public PropertyCollection ExtendedProperties { get; } // 0x000000018183FA20-0x000000018183FAA0 
		internal IFormatProvider FormatProvider { get; } // 0x000000018183FAA0-0x000000018183FB30 
		public CultureInfo Locale { get; set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001818405B0-0x00000001818409C0
		[DefaultValue(50)]
		public int MinimumCapacity { get; set; } // 0x000000018183FC50-0x000000018183FC70 0x00000001818409F0-0x0000000181840A20
		internal int RecordCapacity { get; } // 0x00000001818400C0-0x00000001818400E0 
		internal int ElementColumnCount { get; set; } // 0x000000018033D660-0x000000018033D670 0x0000000181840520-0x0000000181840570
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataRelationCollection ParentRelations { get; } // 0x000000018183FFA0-0x0000000181840020 
		internal bool MergingData { get; set; } // 0x000000018183FC30-0x000000018183FC40 0x00000001818409D0-0x00000001818409E0
		internal DataRelation[] NestedParentRelations { get; } // 0x000000018033D500-0x000000018033D510 
		internal bool SchemaLoading { get; } // 0x0000000181840170-0x0000000181840180 
		internal int NestedParentsCount { get; } // 0x000000018183FD30-0x000000018183FF90 
		[TypeConverter(typeof(PrimaryKeyTypeConverter))]
		public DataColumn[] PrimaryKey { get; set; } // 0x0000000181840020-0x00000001818400C0 0x0000000181840DF0-0x00000001818412F0
		[Browsable(false)]
		public DataRowCollection Rows { get; } // 0x00000001803272A0-0x00000001803272B0 
		[DefaultValue("")]
		[RefreshProperties(RefreshProperties.All)]
		public string TableName { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000181841380-0x00000001818418A0
		internal string EncodedTableName { get; } // 0x000000018183F960-0x000000018183F9F0 
		public string Namespace { get; set; } // 0x000000018183FC70-0x000000018183FCF0 0x0000000181840A20-0x0000000181840C90
		[DefaultValue("")]
		public string Prefix { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x0000000181840C90-0x0000000181840DF0
		internal DataColumn XmlText { get; set; } // 0x0000000180CDCEE0-0x0000000180CDCEF0 0x00000001818418D0-0x0000000181841DD0
		internal decimal MaxOccurs { get; set; } // 0x000000018183FC20-0x000000018183FC30 0x00000001818409C0-0x00000001818409D0
		internal decimal MinOccurs { get; set; } // 0x000000018183FC40-0x000000018183FC50 0x00000001818409E0-0x00000001818409F0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ISite Site { get; } // 0x0000000180377550-0x0000000180377560 
		internal bool NeedColumnChangeEvents { get; } // 0x000000018183FCF0-0x000000018183FD30 
		internal XmlQualifiedName TypeName { get; set; } // 0x00000001818403A0-0x0000000181840450 0x00000001818418A0-0x00000001818418C0
		internal Hashtable RowDiffId { get; } // 0x00000001818400F0-0x0000000181840170 
		internal int ObjectID { get; } // 0x000000018183FF90-0x000000018183FFA0 
	
		// Nested types
		internal struct RowDiffIdUsageSection // TypeDefIndex: 11205
		{
			// Fields
			private DataTable _targetTable; // 0x00
	
			// Methods
			internal void Prepare(DataTable table); // 0x0000000181861300-0x0000000181861340
		}
	
		internal struct DSRowDiffIdUsageSection // TypeDefIndex: 11206
		{
			// Fields
			private DataSet _targetDS; // 0x00
	
			// Methods
			internal void Prepare(DataSet ds); // 0x0000000181842AD0-0x0000000181842B70
		}
	
		// Constructors
		public DataTable(); // 0x000000018183F130-0x000000018183F640
		public DataTable(string tableName); // 0x000000018183F640-0x000000018183F6B0
		protected DataTable(SerializationInfo info, StreamingContext context); // 0x000000018183F6B0-0x000000018183F830
	
		// Methods
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181832E10-0x0000000181832EF0
		private void SerializeDataTable(SerializationInfo info, StreamingContext context, bool isSingleTable, SerializationFormat remotingFormat); // 0x000000018183B4E0-0x000000018183B7B0
		internal void DeserializeDataTable(SerializationInfo info, StreamingContext context, bool isSingleTable, SerializationFormat remotingFormat); // 0x000000018182E550-0x000000018182E880
		internal void SerializeTableSchema(SerializationInfo info, StreamingContext context, bool isSingleTable); // 0x000000018183BF50-0x000000018183CCD0
		internal void DeserializeTableSchema(SerializationInfo info, StreamingContext context, bool isSingleTable); // 0x000000018182F410-0x0000000181830240
		internal void SerializeConstraints(SerializationInfo info, StreamingContext context, int serIndex, bool allConstraints); // 0x000000018183AD10-0x000000018183B4E0
		internal void DeserializeConstraints(SerializationInfo info, StreamingContext context, int serIndex, bool allConstraints); // 0x000000018182DA30-0x000000018182E550
		internal void SerializeExpressionColumns(SerializationInfo info, StreamingContext context, int serIndex); // 0x000000018183B7B0-0x000000018183B920
		internal void DeserializeExpressionColumns(SerializationInfo info, StreamingContext context, int serIndex); // 0x000000018182E880-0x000000018182EA00
		internal void SerializeTableData(SerializationInfo info, StreamingContext context, int serIndex); // 0x000000018183B920-0x000000018183BF50
		internal void DeserializeTableData(SerializationInfo info, StreamingContext context, int serIndex); // 0x000000018182EA00-0x000000018182F410
		private DataRowState ConvertToRowState(BitArray bitStates, int bitIndex); // 0x000000018182CEF0-0x000000018182CFD0
		internal void GetRowAndColumnErrors(int rowIndex, Hashtable rowErrors, Hashtable colErrors); // 0x0000000181833230-0x00000001818334D0
		private void ConvertToRowError(int rowIndex, Hashtable rowErrors, Hashtable colErrors); // 0x000000018182CC00-0x000000018182CEF0
		internal void RestoreIndexEvents(bool forceReset); // 0x000000018183A970-0x000000018183AC50
		internal void SuspendIndexEvents(); // 0x000000018183E720-0x000000018183E7D0
		internal bool SetCaseSensitiveValue(bool isCaseSensitive, bool userSet, bool resetIndexes); // 0x000000018183CCD0-0x000000018183CF60
		internal bool ShouldSerializeCaseSensitive(); // 0x000000018183E560-0x000000018183E570
		private void ResetConstraints(); // 0x000000018183A4B0-0x000000018183A4D0
		internal void SetDataSet(DataSet dataSet); // 0x000000018183CF60-0x000000018183D040
		internal void EnableConstraints(); // 0x00000001818307A0-0x0000000181830D00
		internal bool SetLocaleValue(CultureInfo culture, bool userSet, bool resetIndexes); // 0x000000018183D0D0-0x000000018183D6E0
		internal bool ShouldSerializeLocale(); // 0x000000018183E570-0x000000018183E580
		internal void CacheNestedParent(); // 0x0000000181829DD0-0x0000000181829E00
		private DataRelation[] FindNestedParentRelations(); // 0x0000000181832240-0x0000000181832580
		private string GetInheritedNamespace(List<DataTable> visitedTables); // 0x0000000181832B80-0x0000000181832E10
		internal bool IsNamespaceInherited(); // 0x0000000181834700-0x0000000181834710
		internal void CheckCascadingNamespaceConflict(string realNamespace); // 0x0000000181829ED0-0x000000018182A1D0
		internal void CheckNamespaceValidityForNestedRelations(string realNamespace); // 0x000000018182A890-0x000000018182ABE0
		internal void CheckNamespaceValidityForNestedParentRelations(string ns, DataTable parentTable); // 0x000000018182A620-0x000000018182A890
		internal void DoRaiseNamespaceChange(); // 0x0000000181830240-0x00000001818307A0
		internal void SetKeyValues(DataKey key, object[] keyValues, int record); // 0x000000018183D040-0x000000018183D0D0
		internal DataRow FindByIndex(Index ndx, object[] key); // 0x00000001818320A0-0x0000000181832140
		internal DataRow FindMergeTarget(DataRow row, DataKey key, Index ndx); // 0x0000000181832140-0x0000000181832240
		private void SetMergeRecords(DataRow row, int newRecord, int oldRecord, DataRowAction action); // 0x000000018183D6E0-0x000000018183D820
		internal DataRow MergeRow(DataRow row, DataRow targetRow, bool preserveChanges, Index idxSearch); // 0x00000001818347D0-0x0000000181834EC0
		protected virtual DataTable CreateInstance(); // 0x000000018182D310-0x000000018182D390
		public virtual DataTable Clone(); // 0x000000018182C7A0-0x000000018182C7B0
		internal DataTable Clone(DataSet cloneDS); // 0x000000018182C5C0-0x000000018182C7A0
		private DataTable IncrementalCloneTo(DataTable sourceTable, DataTable targetTable); // 0x00000001818337A0-0x0000000181833A40
		private DataTable CloneHierarchy(DataTable sourceTable, DataSet ds, Hashtable visitedMap); // 0x000000018182B3D0-0x000000018182B810
		private DataTable CloneTo(DataTable clone, DataSet cloneDS, bool skipExpressionColumns); // 0x000000018182B810-0x000000018182C5C0
		internal void AddRow(DataRow row, int proposedID); // 0x0000000181829AD0-0x0000000181829B00
		internal void InsertRow(DataRow row, int proposedID, int pos); // 0x00000001818344C0-0x00000001818344E0
		internal void InsertRow(DataRow row, long proposedID, int pos, bool fireEvent); // 0x00000001818340D0-0x00000001818344C0
		internal void CheckNotModifying(DataRow row); // 0x000000018182ABE0-0x000000018182AC10
		public void Clear(); // 0x000000018182AC10-0x000000018182AC20
		internal void Clear(bool clearAll); // 0x000000018182AC20-0x000000018182B3D0
		internal void CascadeAll(DataRow row, DataRowAction action); // 0x0000000181829E00-0x0000000181829ED0
		internal void CommitRow(DataRow row); // 0x000000018182C7B0-0x000000018182C900
		internal int Compare(string s1, string s2); // 0x000000018182CAA0-0x000000018182CC00
		internal int Compare(string s1, string s2, CompareInfo comparer); // 0x000000018182C900-0x000000018182CAA0
		internal int IndexOf(string s1, string s2); // 0x0000000181833A40-0x0000000181833B00
		internal bool IsSuffix(string s1, string s2); // 0x0000000181834710-0x00000001818347D0
		internal void DeleteRow(DataRow row); // 0x000000018182D980-0x000000018182DA30
		internal string FormatSortString(IndexField[] indexDesc); // 0x0000000181832580-0x00000001818326C0
		internal void FreeRecord(ref int record); // 0x00000001818326C0-0x00000001818326E0
		internal Index GetIndex(string sort, DataViewRowState recordStates, IFilter rowFilter); // 0x0000000181832B30-0x0000000181832B80
		internal Index GetIndex(IndexField[] indexDesc, DataViewRowState recordStates, IFilter rowFilter); // 0x0000000181832940-0x0000000181832B30
		internal List<DataViewListener> GetListeners(); // 0x000000018033D670-0x000000018033D680
		internal int GetSpecialHashCode(string name); // 0x0000000181833690-0x00000001818337A0
		internal void InsertRow(DataRow row, long proposedID); // 0x0000000181833CD0-0x00000001818340D0
		internal int NewRecord(); // 0x0000000181835270-0x0000000181835280
		internal int NewUninitializedRecord(); // 0x00000001818357D0-0x00000001818357F0
		internal int NewRecord(int sourceRecord); // 0x0000000181835280-0x0000000181835370
		internal DataRow NewEmptyRow(); // 0x0000000181835200-0x0000000181835270
		private DataRow NewUninitializedRow(); // 0x00000001818357F0-0x0000000181835830
		public DataRow NewRow(); // 0x00000001818356D0-0x00000001818357D0
		internal DataRow CreateEmptyRow(); // 0x000000018182CFD0-0x000000018182D310
		private void NewRowCreated(DataRow row); // 0x0000000181835540-0x00000001818355D0
		internal DataRow NewRow(int record); // 0x0000000181835630-0x00000001818356D0
		protected virtual DataRow NewRowFromBuilder(DataRowBuilder builder); // 0x00000001818355D0-0x0000000181835630
		protected virtual Type GetRowType(); // 0x00000001818334D0-0x0000000181833510
		protected internal DataRow[] NewRowArray(int size); // 0x0000000181835370-0x0000000181835540
		protected internal virtual void OnColumnChanging(DataColumnChangeEventArgs e); // 0x0000000181835900-0x00000001818359D0
		protected internal virtual void OnColumnChanged(DataColumnChangeEventArgs e); // 0x0000000181835830-0x0000000181835900
		protected virtual void OnPropertyChanging(PropertyChangedEventArgs pcevent); // 0x00000001818359D0-0x0000000181835AA0
		internal void OnRemoveColumnInternal(DataColumn column); // 0x0000000181835AA0-0x0000000181835AC0
		protected virtual void OnRemoveColumn(DataColumn column); // 0x00000001802E76C0-0x00000001802E76D0
		private DataRowChangeEventArgs OnRowChanged(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction); // 0x0000000181835AC0-0x0000000181835B70
		private DataRowChangeEventArgs OnRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction); // 0x0000000181835C40-0x0000000181835CF0
		protected virtual void OnRowChanged(DataRowChangeEventArgs e); // 0x0000000181835B70-0x0000000181835C40
		protected virtual void OnRowChanging(DataRowChangeEventArgs e); // 0x0000000181835CF0-0x0000000181835DC0
		protected virtual void OnRowDeleting(DataRowChangeEventArgs e); // 0x0000000181835E90-0x0000000181835F60
		protected virtual void OnRowDeleted(DataRowChangeEventArgs e); // 0x0000000181835DC0-0x0000000181835E90
		protected virtual void OnTableCleared(DataTableClearEventArgs e); // 0x0000000181835F60-0x0000000181836030
		protected virtual void OnTableClearing(DataTableClearEventArgs e); // 0x0000000181836030-0x0000000181836100
		protected virtual void OnTableNewRow(DataTableNewRowEventArgs e); // 0x0000000181836100-0x00000001818361D0
		internal IndexField[] ParseSortString(string sortString); // 0x00000001818361D0-0x0000000181836580
		internal void RaisePropertyChanging(string name); // 0x0000000181836580-0x0000000181836600
		internal void RecordChanged(int record); // 0x00000001818399B0-0x0000000181839B10
		internal void RecordChanged(int[] oldIndex, int[] newIndex); // 0x0000000181839B10-0x0000000181839CB0
		internal void RecordStateChanged(int record, DataViewRowState oldState, DataViewRowState newState); // 0x0000000181839EB0-0x000000018183A030
		internal void RecordStateChanged(int record1, DataViewRowState oldState1, DataViewRowState newState1, int record2, DataViewRowState oldState2, DataViewRowState newState2); // 0x0000000181839CB0-0x0000000181839EB0
		internal int[] RemoveRecordFromIndexes(DataRow row, DataRowVersion version); // 0x000000018183A0C0-0x000000018183A2F0
		internal int[] InsertRecordToIndexes(DataRow row, DataRowVersion version); // 0x0000000181833B00-0x0000000181833CD0
		internal void SilentlySetValue(DataRow dr, DataColumn dc, DataRowVersion version, object newValue); // 0x000000018183E580-0x000000018183E720
		internal void RemoveRow(DataRow row, bool check); // 0x000000018183A2F0-0x000000018183A4B0
		public virtual void Reset(); // 0x000000018183A6A0-0x000000018183A910
		internal void ResetIndexes(); // 0x000000018183A4D0-0x000000018183A4E0
		internal void ResetInternalIndexes(DataColumn column); // 0x000000018183A4E0-0x000000018183A6A0
		internal void RollbackRow(DataRow row); // 0x000000018183AC70-0x000000018183AD10
		private DataRowChangeEventArgs RaiseRowChanged(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction); // 0x0000000181836600-0x00000001818367A0
		private DataRowChangeEventArgs RaiseRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction); // 0x0000000181836970-0x0000000181836C30
		private DataRowChangeEventArgs RaiseRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction, bool fireEvent); // 0x00000001818367A0-0x0000000181836970
		internal void SetNewRecord(DataRow row, int proposedRecord, DataRowAction action = DataRowAction.Nothing | DataRowAction.Change /* Metadata: 0x006A1679 */, bool isInMerge = false /* Metadata: 0x006A167A */, bool fireEvent = true /* Metadata: 0x006A167B */, bool suppressEnsurePropertyChanged = false /* Metadata: 0x006A167C */); // 0x000000018183E140-0x000000018183E1C0
		private void SetNewRecordWorker(DataRow row, int proposedRecord, DataRowAction action, bool isInMerge, bool suppressEnsurePropertyChanged, int position, bool fireEvent, out Exception deferredException); // 0x000000018183D820-0x000000018183E140
		internal void SetOldRecord(DataRow row, int proposedRecord); // 0x000000018183E1C0-0x000000018183E480
		private void RestoreShadowIndexes(); // 0x000000018183AC50-0x000000018183AC70
		private void SetShadowIndexes(); // 0x000000018183E480-0x000000018183E4D0
		internal void ShadowIndexCopy(); // 0x000000018183E4D0-0x000000018183E560
		public override string ToString(); // 0x000000018183E8F0-0x000000018183E970
		internal bool UpdatingCurrent(DataRow row, DataRowAction action); // 0x000000018183E990-0x000000018183E9C0
		internal DataColumn AddUniqueKey(int position); // 0x0000000181829B10-0x0000000181829DD0
		internal DataColumn AddUniqueKey(); // 0x0000000181829B00-0x0000000181829B10
		internal DataColumn AddForeignKey(DataColumn parentKey); // 0x0000000181829A10-0x0000000181829AD0
		internal void UpdatePropertyDescriptorCollectionCache(); // 0x000000018183E970-0x000000018183E990
		internal PropertyDescriptorCollection GetPropertyDescriptorCollection(Attribute[] attributes); // 0x0000000181832EF0-0x0000000181833230
		public void Merge(DataTable table); // 0x0000000181834EC0-0x0000000181834EE0
		public void Merge(DataTable table, bool preserveChanges, MissingSchemaAction missingSchemaAction); // 0x0000000181834EE0-0x0000000181835120
		public void WriteXml(XmlWriter writer, XmlWriteMode mode, bool writeHierarchy); // 0x000000018183EDB0-0x000000018183F130
		private bool CheckForClosureOnExpressions(DataTable dt, bool writeHierarchy); // 0x000000018182A510-0x000000018182A620
		private bool CheckForClosureOnExpressionTables(List<DataTable> tableList); // 0x000000018182A1D0-0x000000018182A510
		public void WriteXmlSchema(XmlWriter writer, bool writeHierarchy); // 0x000000018183E9C0-0x000000018183EDB0
		private void RestoreConstraint(bool originalEnforceConstraint); // 0x000000018183A910-0x000000018183A970
		private bool IsEmptyXml(XmlReader reader); // 0x00000001818344E0-0x0000000181834700
		internal XmlReadMode ReadXml(XmlReader reader, XmlReadMode mode, bool denyResolving); // 0x0000000181838990-0x00000001818399B0
		internal void ReadEndElement(XmlReader reader); // 0x0000000181836C30-0x0000000181836CF0
		internal void ReadXDRSchema(XmlReader reader); // 0x0000000181836CF0-0x0000000181836D70
		internal bool MoveToElement(XmlReader reader, int depth); // 0x0000000181835120-0x0000000181835200
		private void ReadXmlDiffgram(XmlReader reader); // 0x0000000181836F90-0x0000000181837990
		internal void ReadXSDSchema(XmlReader reader, bool denyResolving); // 0x0000000181836D70-0x0000000181836F90
		internal void ReadXmlSchema(XmlReader reader, bool denyResolving); // 0x0000000181837990-0x0000000181838970
		private void CreateTableList(DataTable currentTable, List<DataTable> tableList); // 0x000000018182D6A0-0x000000018182D980
		private void CreateRelationList(List<DataTable> tableList, List<DataRelation> relationList); // 0x000000018182D390-0x000000018182D6A0
		public static XmlSchemaComplexType GetDataTableSchema(XmlSchemaSet schemaSet); // 0x00000001818326E0-0x0000000181832940
		XmlSchema IXmlSerializable.GetSchema(); // 0x0000000180B22FB0-0x0000000180B22FD0
		protected virtual XmlSchema GetSchema(); // 0x0000000181833510-0x0000000181833690
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x000000018183E7D0-0x000000018183E8A0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x000000018183E8A0-0x000000018183E8F0
		protected virtual void ReadXmlSerializable(XmlReader reader); // 0x0000000181838970-0x0000000181838990
		internal void AddDependentColumn(DataColumn expressionColumn); // 0x00000001818298D0-0x0000000181829A10
		internal void RemoveDependentColumn(DataColumn expressionColumn); // 0x000000018183A030-0x000000018183A0C0
		internal void EvaluateExpressions(); // 0x00000001818318A0-0x0000000181831B70
		internal void EvaluateExpressions(DataRow row, DataRowAction action, List<DataRow> cachedRows); // 0x0000000181831B70-0x00000001818320A0
		internal void EvaluateExpressions(DataColumn column); // 0x0000000181831630-0x00000001818318A0
		internal void EvaluateDependentExpressions(DataColumn column); // 0x0000000181831520-0x0000000181831630
		internal void EvaluateDependentExpressions(List<DataColumn> columns, DataRow row, DataRowVersion version, List<DataRow> cachedRows); // 0x0000000181830D00-0x0000000181831520
	}
}
