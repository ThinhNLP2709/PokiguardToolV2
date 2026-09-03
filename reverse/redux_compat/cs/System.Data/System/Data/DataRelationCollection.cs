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
	[DefaultEvent("CollectionChanged")]
	[DefaultProperty("Table")]
	public abstract class DataRelationCollection : InternalDataCollectionBase // TypeDefIndex: 11234
	{
		// Fields
		private DataRelation _inTransition; // 0x10
		private int _defaultNameIndex; // 0x18
		private CollectionChangeEventHandler _onCollectionChangedDelegate; // 0x20
		private CollectionChangeEventHandler _onCollectionChangingDelegate; // 0x28
		private static int s_objectTypeCount; // 0x00
		private readonly int _objectID; // 0x30
	
		// Properties
		internal int ObjectID { get; } // 0x000000018033D100-0x000000018033D110 
		public abstract DataRelation this[int index] { get => default; }
		public abstract DataRelation this[string name] { get => default; }
	
		// Events
		public event CollectionChangeEventHandler CollectionChanged {
			add; // 0x000000018186CB80-0x000000018186CC90
			remove; // 0x000000018186CC90-0x000000018186CDA0
		}
	
		// Nested types
		internal sealed class DataTableRelationCollection : DataRelationCollection // TypeDefIndex: 11235
		{
			// Fields
			private readonly DataTable _table; // 0x38
			private readonly ArrayList _relations; // 0x40
			private readonly bool _fParentCollection; // 0x48
			[CompilerGenerated]
			private CollectionChangeEventHandler RelationPropertyChanged; // 0x50
	
			// Properties
			protected override ArrayList List { get; } // 0x0000000180377940-0x0000000180377950 
			public override DataRelation this[int index] { get => default; } // 0x00000001818799E0-0x0000000181879AF0 
			public override DataRelation this[string name] { get => default; } // 0x00000001818798E0-0x00000001818799E0 
	
			// Events
			internal event CollectionChangeEventHandler RelationPropertyChanged {
				add; // 0x0000000181879840-0x00000001818798E0
				remove; // 0x0000000181879AF0-0x0000000181879B90
			}
	
			// Constructors
			internal DataTableRelationCollection(DataTable table, bool fParentCollection); // 0x0000000181879780-0x0000000181879840
	
			// Methods
			private void EnsureDataSet(); // 0x0000000181879430-0x0000000181879480
			protected override DataSet GetDataSet(); // 0x0000000181879480-0x00000001818794D0
			private void AddCache(DataRelation relation); // 0x00000001818792C0-0x0000000181879310
			protected override void AddCore(DataRelation relation); // 0x0000000181879310-0x0000000181879430
			private void RemoveCache(DataRelation relation); // 0x00000001818794D0-0x00000001818795C0
			protected override void RemoveCore(DataRelation relation); // 0x00000001818795C0-0x0000000181879780
		}
	
		internal sealed class DataSetRelationCollection : DataRelationCollection // TypeDefIndex: 11236
		{
			// Fields
			private readonly DataSet _dataSet; // 0x38
			private readonly ArrayList _relations; // 0x40
			private DataRelation[] _delayLoadingRelations; // 0x48
	
			// Properties
			protected override ArrayList List { get; } // 0x0000000180377940-0x0000000180377950 
			public override DataRelation this[int index] { get => default; } // 0x0000000181876620-0x0000000181876730 
			public override DataRelation this[string name] { get => default; } // 0x0000000181876520-0x0000000181876620 
	
			// Constructors
			internal DataSetRelationCollection(DataSet dataSet); // 0x0000000181876480-0x0000000181876520
	
			// Methods
			public override void Clear(); // 0x0000000181876110-0x0000000181876160
			protected override DataSet GetDataSet(); // 0x00000001803272A0-0x00000001803272B0
			protected override void AddCore(DataRelation relation); // 0x0000000181875AE0-0x0000000181876110
			protected override void RemoveCore(DataRelation relation); // 0x0000000181876160-0x0000000181876480
		}
	
		// Constructors
		protected DataRelationCollection(); // 0x000000018186CB00-0x000000018186CB80
	
		// Methods
		public void Add(DataRelation relation); // 0x000000018186BA00-0x000000018186BC90
		protected virtual void AddCore(DataRelation relation); // 0x000000018186B6E0-0x000000018186BA00
		internal string AssignName(); // 0x000000018186BC90-0x000000018186BCB0
		public virtual void Clear(); // 0x000000018186BCB0-0x000000018186BEB0
		public virtual bool Contains(string name); // 0x000000018186BEB0-0x000000018186BED0
		internal int InternalIndexOf(string name); // 0x000000018186BED0-0x000000018186C0E0
		protected abstract DataSet GetDataSet();
		private string MakeName(int index); // 0x000000018186C0E0-0x000000018186C170
		protected virtual void OnCollectionChanged(CollectionChangeEventArgs ccevent); // 0x000000018186C170-0x000000018186C230
		protected virtual void OnCollectionChanging(CollectionChangeEventArgs ccevent); // 0x000000018186C230-0x000000018186C2F0
		internal void RegisterName(string name); // 0x000000018186C2F0-0x000000018186C4D0
		public void Remove(DataRelation relation); // 0x000000018186C750-0x000000018186C940
		public void RemoveAt(int index); // 0x000000018186C4D0-0x000000018186C550
		protected virtual void RemoveCore(DataRelation relation); // 0x000000018186C550-0x000000018186C750
		internal void UnregisterName(string name); // 0x000000018186C940-0x000000018186CB00
	}
}
