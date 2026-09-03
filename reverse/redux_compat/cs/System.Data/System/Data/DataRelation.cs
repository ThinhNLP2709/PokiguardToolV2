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
	[DefaultProperty("RelationName")]
	[TypeConverter(typeof(RelationshipConverter))]
	public class DataRelation // TypeDefIndex: 11233
	{
		// Fields
		private DataSet _dataSet; // 0x10
		internal PropertyCollection _extendedProperties; // 0x18
		internal string _relationName; // 0x20
		private DataKey _childKey; // 0x28
		private DataKey _parentKey; // 0x30
		private UniqueConstraint _parentKeyConstraint; // 0x38
		private ForeignKeyConstraint _childKeyConstraint; // 0x40
		internal string[] _parentColumnNames; // 0x48
		internal string[] _childColumnNames; // 0x50
		internal string _parentTableName; // 0x58
		internal string _childTableName; // 0x60
		internal string _parentTableNamespace; // 0x68
		internal string _childTableNamespace; // 0x70
		internal bool _nested; // 0x78
		internal bool _createConstraints; // 0x79
		private bool _checkMultipleNested; // 0x7A
		private static int s_objectTypeCount; // 0x00
		private readonly int _objectID; // 0x7C
		[CompilerGenerated]
		private PropertyChangedEventHandler PropertyChanging; // 0x80
	
		// Properties
		public virtual DataColumn[] ChildColumns { get; } // 0x000000018186F5F0-0x000000018186F610 
		internal DataColumn[] ChildColumnsReference { get; } // 0x000000018186F5D0-0x000000018186F5F0 
		internal DataKey ChildKey { get; } // 0x000000018186F5D0-0x000000018186F5F0 
		public virtual DataTable ChildTable { get; } // 0x000000018186F630-0x000000018186F670 
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual DataSet DataSet { get; } // 0x000000018186F670-0x000000018186F690 
		internal string[] ParentColumnNames { get; } // 0x000000018186F720-0x000000018186F730 
		internal string[] ChildColumnNames { get; } // 0x000000018186F5C0-0x000000018186F5D0 
		public virtual DataColumn[] ParentColumns { get; } // 0x000000018186F730-0x000000018186F750 
		internal DataColumn[] ParentColumnsReference { get; } // 0x000000018031E110-0x000000018031E120 
		internal DataKey ParentKey { get; } // 0x000000018186F770-0x000000018186F790 
		public virtual DataTable ParentTable { get; } // 0x000000018186F790-0x000000018186F7D0 
		[DefaultValue("")]
		public virtual string RelationName { get; } // 0x000000018186F7D0-0x000000018186F7F0 
		[DefaultValue(false)]
		public virtual bool Nested { get; set; } // 0x000000018186F700-0x000000018186F720 0x000000018186F800-0x0000000181870730
		public virtual UniqueConstraint ParentKeyConstraint { get; } // 0x000000018186F750-0x000000018186F770 
		public virtual ForeignKeyConstraint ChildKeyConstraint { get; } // 0x000000018186F610-0x000000018186F630 
		[Browsable(false)]
		public PropertyCollection ExtendedProperties { get; } // 0x000000018186F690-0x000000018186F700 
		internal bool CheckMultipleNested { get; set; } // 0x000000018186F5B0-0x000000018186F5C0 0x000000018186F7F0-0x000000018186F800
		internal int ObjectID { get; } // 0x00000001816A5830-0x00000001816A5840 
	
		// Constructors
		public DataRelation(string relationName, DataColumn parentColumn, DataColumn childColumn, bool createConstraints); // 0x000000018186F060-0x000000018186F2B0
		public DataRelation(string relationName, DataColumn[] parentColumns, DataColumn[] childColumns); // 0x000000018186F370-0x000000018186F390
		public DataRelation(string relationName, DataColumn[] parentColumns, DataColumn[] childColumns, bool createConstraints); // 0x000000018186F2B0-0x000000018186F370
		[Browsable(false)]
		public DataRelation(string relationName, string parentTableName, string childTableName, string[] parentColumnNames, string[] childColumnNames, bool nested); // 0x000000018186F4B0-0x000000018186F5B0
		[Browsable(false)]
		public DataRelation(string relationName, string parentTableName, string parentTableNamespace, string childTableName, string childTableNamespace, string[] parentColumnNames, string[] childColumnNames, bool nested); // 0x000000018186F390-0x000000018186F4B0
	
		// Methods
		private static bool IsKeyNull(object[] values); // 0x000000018186E910-0x000000018186E9D0
		internal static DataRow[] GetChildRows(DataKey parentKey, DataKey childKey, DataRow parentRow, DataRowVersion version); // 0x000000018186E3F0-0x000000018186E4D0
		internal static DataRow[] GetParentRows(DataKey parentKey, DataKey childKey, DataRow childRow, DataRowVersion version); // 0x000000018186E670-0x000000018186E750
		internal static DataRow GetParentRow(DataKey parentKey, DataKey childKey, DataRow childRow, DataRowVersion version); // 0x000000018186E4D0-0x000000018186E670
		internal void SetDataSet(DataSet dataSet); // 0x000000018186EBB0-0x000000018186EBD0
		internal void CheckNamespaceValidityForNestedRelations(string ns); // 0x000000018186CF80-0x000000018186D240
		internal void CheckNestedRelations(); // 0x000000018186D240-0x000000018186D6B0
		internal void SetParentKeyConstraint(UniqueConstraint value); // 0x000000018033E850-0x000000018033E860
		internal void SetChildKeyConstraint(ForeignKeyConstraint value); // 0x0000000180378120-0x0000000180378130
		internal void CheckState(); // 0x000000018186D710-0x000000018186D9E0
		protected void CheckStateForProperty(); // 0x000000018186D6B0-0x000000018186D710
		private void Create(string relationName, DataColumn[] parentColumns, DataColumn[] childColumns, bool createConstraints); // 0x000000018186E110-0x000000018186E3F0
		internal DataRelation Clone(DataSet destination); // 0x000000018186D9E0-0x000000018186E110
		protected internal void OnPropertyChanging(PropertyChangedEventArgs pcevent); // 0x000000018186E9D0-0x000000018186EAA0
		protected internal void RaisePropertyChanging(string name); // 0x000000018186EAA0-0x000000018186EBB0
		public override string ToString(); // 0x0000000181648960-0x0000000181648980
		internal void ValidateMultipleNestedRelations(); // 0x000000018186EBD0-0x000000018186F060
		private bool IsAutoGenerated(DataColumn col); // 0x000000018186E750-0x000000018186E910
	}
}
