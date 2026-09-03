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
	[DefaultProperty("ConstraintName")]
	public class ForeignKeyConstraint : Constraint // TypeDefIndex: 11292
	{
		// Fields
		internal Rule _deleteRule; // 0x38
		internal Rule _updateRule; // 0x3C
		internal AcceptRejectRule _acceptRejectRule; // 0x40
		private DataKey _childKey; // 0x48
		private DataKey _parentKey; // 0x50
		internal string _constraintName; // 0x58
		internal string[] _parentColumnNames; // 0x60
		internal string[] _childColumnNames; // 0x68
		internal string _parentTableName; // 0x70
	
		// Properties
		internal DataKey ChildKey { get; } // 0x00000001818948E0-0x0000000181894900 
		[ReadOnly(true)]
		public virtual DataColumn[] Columns { get; } // 0x0000000181894900-0x0000000181894920 
		[ReadOnly(true)]
		public override DataTable Table { get; } // 0x00000001818949B0-0x00000001818949D0 
		internal string[] ParentColumnNames { get; } // 0x0000000181894940-0x0000000181894950 
		internal string[] ChildColumnNames { get; } // 0x00000001818948D0-0x00000001818948E0 
		[DefaultValue(AcceptRejectRule.None)]
		public virtual AcceptRejectRule AcceptRejectRule { get; set; } // 0x00000001818948B0-0x00000001818948D0 0x00000001818949F0-0x0000000181894A50
		[DefaultValue(Rule.Cascade)]
		public virtual Rule DeleteRule { get; set; } // 0x0000000181894920-0x0000000181894940 0x0000000181894A50-0x0000000181894AB0
		[ReadOnly(true)]
		public virtual DataColumn[] RelatedColumns { get; } // 0x0000000181894970-0x0000000181894990 
		internal DataColumn[] RelatedColumnsReference { get; } // 0x0000000181894950-0x0000000181894970 
		internal DataKey ParentKey { get; } // 0x0000000181894950-0x0000000181894970 
		[ReadOnly(true)]
		public virtual DataTable RelatedTable { get; } // 0x0000000181894990-0x00000001818949B0 
		[DefaultValue(Rule.Cascade)]
		public virtual Rule UpdateRule { get; set; } // 0x00000001818949D0-0x00000001818949F0 0x0000000181894AB0-0x0000000181894B10
	
		// Constructors
		public ForeignKeyConstraint(DataColumn[] parentColumns, DataColumn[] childColumns); // 0x00000001818947E0-0x0000000181894840
		public ForeignKeyConstraint(string constraintName, DataColumn[] parentColumns, DataColumn[] childColumns); // 0x0000000181894840-0x00000001818948B0
		[Browsable(false)]
		public ForeignKeyConstraint(string constraintName, string parentTableName, string[] parentColumnNames, string[] childColumnNames, AcceptRejectRule acceptRejectRule, Rule deleteRule, Rule updateRule); // 0x0000000181894730-0x00000001818947E0
	
		// Methods
		internal override void CheckCanAddToCollection(ConstraintCollection constraints); // 0x00000001818926E0-0x0000000181892860
		internal override bool CanBeRemovedFromCollection(ConstraintCollection constraints, bool fThrowException); // 0x00000001802E7990-0x00000001802E79A0
		internal bool IsKeyNull(object[] values); // 0x00000001818943C0-0x0000000181894480
		internal override bool IsConstraintViolated(); // 0x0000000181894180-0x00000001818943C0
		internal override bool CanEnableConstraint(); // 0x0000000181891680-0x0000000181891830
		internal void CascadeCommit(DataRow row); // 0x0000000181891830-0x00000001818919B0
		internal void CascadeDelete(DataRow row); // 0x00000001818919B0-0x0000000181891F60
		internal void CascadeRollback(DataRow row); // 0x0000000181891F60-0x0000000181892150
		internal void CascadeUpdate(DataRow row); // 0x0000000181892150-0x00000001818926E0
		internal void CheckCanClearParentTable(DataTable table); // 0x0000000181892860-0x0000000181892970
		internal void CheckCanRemoveParentRow(DataRow row); // 0x0000000181892970-0x0000000181892A30
		internal void CheckCascade(DataRow row, DataRowAction action); // 0x0000000181892A30-0x0000000181892D40
		internal override void CheckConstraint(DataRow childRow, DataRowAction action); // 0x0000000181892D40-0x0000000181893030
		private void NonVirtualCheckState(); // 0x0000000181894480-0x0000000181894730
		internal override void CheckState(); // 0x0000000181893030-0x0000000181893040
		internal override bool ContainsColumn(DataColumn column); // 0x0000000181893D00-0x0000000181893D50
		internal override Constraint Clone(DataSet destination); // 0x0000000181893CE0-0x0000000181893D00
		internal override Constraint Clone(DataSet destination, bool ignorNSforTableLookup); // 0x0000000181893040-0x0000000181893720
		internal ForeignKeyConstraint Clone(DataTable destination); // 0x0000000181893720-0x0000000181893CE0
		private void Create(string relationName, DataColumn[] parentColumns, DataColumn[] childColumns); // 0x0000000181893D50-0x0000000181893F70
		public override bool Equals(object key); // 0x0000000181893F70-0x0000000181894090
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		internal DataRelation FindParentRelation(); // 0x0000000181894090-0x0000000181894180
	}
}
