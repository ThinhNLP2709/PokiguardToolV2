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
	public class UniqueConstraint : Constraint // TypeDefIndex: 11323
	{
		// Fields
		private DataKey _key; // 0x38
		private Index _constraintIndex; // 0x40
		internal bool _bPrimaryKey; // 0x48
		internal string _constraintName; // 0x50
		internal string[] _columnNames; // 0x58
	
		// Properties
		internal string[] ColumnNames { get; } // 0x00000001818A1DA0-0x00000001818A1DB0 
		internal Index ConstraintIndex { get; } // 0x0000000180377940-0x0000000180377950 
		[ReadOnly(true)]
		public virtual DataColumn[] Columns { get; } // 0x00000001818A1DB0-0x00000001818A1DC0 
		internal DataColumn[] ColumnsReference { get; } // 0x00000001803272A0-0x00000001803272B0 
		public bool IsPrimaryKey { get; } // 0x00000001818A1DC0-0x00000001818A1E20 
		internal override bool InCollection { set; } // 0x00000001818A1E50-0x00000001818A1EA0
		internal DataKey Key { get; } // 0x00000001803272A0-0x00000001803272B0 
		[ReadOnly(true)]
		public override DataTable Table { get; } // 0x00000001818A1E20-0x00000001818A1E50 
	
		// Constructors
		public UniqueConstraint(DataColumn column); // 0x00000001818A1BE0-0x00000001818A1CA0
		public UniqueConstraint(string name, DataColumn[] columns); // 0x00000001818A1CA0-0x00000001818A1CE0
		public UniqueConstraint(DataColumn[] columns); // 0x00000001818A1BA0-0x00000001818A1BE0
		[Browsable(false)]
		public UniqueConstraint(string name, string[] columnNames, bool isPrimaryKey); // 0x00000001818A1D30-0x00000001818A1DA0
		public UniqueConstraint(string name, DataColumn[] columns, bool isPrimaryKey); // 0x00000001818A1CE0-0x00000001818A1D30
	
		// Methods
		internal void ConstraintIndexClear(); // 0x00000001818A1660-0x00000001818A16A0
		internal void ConstraintIndexInitialize(); // 0x00000001818A16A0-0x00000001818A16F0
		internal override void CheckState(); // 0x00000001818A0D30-0x00000001818A0D40
		private void NonVirtualCheckState(); // 0x00000001818A0D30-0x00000001818A0D40
		internal override void CheckCanAddToCollection(ConstraintCollection constraints); // 0x00000001802E76C0-0x00000001802E76D0
		internal override bool CanBeRemovedFromCollection(ConstraintCollection constraints, bool fThrowException); // 0x00000001818A0980-0x00000001818A0B40
		internal override bool CanEnableConstraint(); // 0x00000001818A0B40-0x00000001818A0BA0
		internal override bool IsConstraintViolated(); // 0x00000001818A18E0-0x00000001818A1BA0
		internal override void CheckConstraint(DataRow row, DataRowAction action); // 0x00000001818A0BA0-0x00000001818A0D30
		internal override bool ContainsColumn(DataColumn column); // 0x00000001818A16F0-0x00000001818A1700
		internal override Constraint Clone(DataSet destination); // 0x0000000181893CE0-0x0000000181893D00
		internal override Constraint Clone(DataSet destination, bool ignorNSforTableLookup); // 0x00000001818A1170-0x00000001818A1660
		internal UniqueConstraint Clone(DataTable table); // 0x00000001818A0D40-0x00000001818A1170
		private void Create(string constraintName, DataColumn[] columns); // 0x00000001818A1700-0x00000001818A1810
		public override bool Equals(object key2); // 0x00000001818A1810-0x00000001818A18E0
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
	}
}
