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
	[TypeConverter(typeof(ConstraintConverter))]
	public abstract class Constraint // TypeDefIndex: 11219
	{
		// Fields
		private string _schemaName; // 0x10
		private bool _inCollection; // 0x18
		private DataSet _dataSet; // 0x20
		internal string _name; // 0x28
		internal PropertyCollection _extendedProperties; // 0x30
	
		// Properties
		[DefaultValue("")]
		public virtual string ConstraintName { get; set; } // 0x000000018033D240-0x000000018033D250 0x00000001818664C0-0x00000001818666D0
		internal string SchemaName { get; set; } // 0x0000000181866480-0x00000001818664C0 0x0000000181866730-0x0000000181866770
		internal virtual bool InCollection { get; set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001818666D0-0x0000000181866730
		public abstract DataTable Table { get; }
		[Browsable(false)]
		public PropertyCollection ExtendedProperties { get; } // 0x0000000181866410-0x0000000181866480 
		[CLSCompliant(false)]
		protected virtual DataSet _DataSet { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		protected Constraint(); // 0x00000001818663B0-0x0000000181866410
	
		// Methods
		internal abstract bool ContainsColumn(DataColumn column);
		internal abstract bool CanEnableConstraint();
		internal abstract Constraint Clone(DataSet destination);
		internal abstract Constraint Clone(DataSet destination, bool ignoreNSforTableLookup);
		internal void CheckConstraint(); // 0x00000001818662E0-0x0000000181866340
		internal abstract void CheckCanAddToCollection(ConstraintCollection constraint);
		internal abstract bool CanBeRemovedFromCollection(ConstraintCollection constraint, bool fThrowException);
		internal abstract void CheckConstraint(DataRow row, DataRowAction action);
		internal abstract void CheckState();
		protected void CheckStateForProperty(); // 0x0000000181866340-0x00000001818663B0
		internal abstract bool IsConstraintViolated();
		public override string ToString(); // 0x00000001816197C0-0x00000001816197E0
	}
}
