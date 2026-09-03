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
	[ListBindable(false)]
	public sealed class DataTableCollection : InternalDataCollectionBase // TypeDefIndex: 11254
	{
		// Fields
		private readonly DataSet _dataSet; // 0x10
		private readonly ArrayList _list; // 0x18
		private int _defaultNameIndex; // 0x20
		private DataTable[] _delayedAddRangeTables; // 0x28
		private CollectionChangeEventHandler _onCollectionChangedDelegate; // 0x30
		private CollectionChangeEventHandler _onCollectionChangingDelegate; // 0x38
		private static int s_objectTypeCount; // 0x00
		private readonly int _objectID; // 0x40
	
		// Properties
		protected override ArrayList List { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal int ObjectID { get; } // 0x000000018033D790-0x000000018033D7A0 
		public DataTable this[int index] { get => default; } // 0x00000001818790B0-0x0000000181879190 
		public DataTable this[string name] { get => default; } // 0x0000000181878FA0-0x00000001818790B0 
		public DataTable this[string name, string tableNamespace] { get => default; } // 0x0000000181879190-0x00000001818792C0 
	
		// Constructors
		internal DataTableCollection(DataSet dataSet); // 0x0000000181878E40-0x0000000181878FA0
	
		// Methods
		internal DataTable GetTable(string name, string ns); // 0x0000000181877E70-0x0000000181877FB0
		internal DataTable GetTableSmart(string name, string ns); // 0x0000000181877D10-0x0000000181877E70
		public void Add(DataTable table); // 0x00000001818767A0-0x00000001818769F0
		private void ArrayAdd(DataTable table); // 0x00000001818769F0-0x0000000181876A20
		internal string AssignName(); // 0x0000000181876A20-0x0000000181876AE0
		private void BaseAdd(DataTable table); // 0x0000000181876AE0-0x0000000181876D20
		private void BaseGroupSwitch(DataTable[] oldArray, int oldLength, DataTable[] newArray, int newLength); // 0x0000000181876D20-0x0000000181876EE0
		private void BaseRemove(DataTable table); // 0x0000000181876EE0-0x00000001818770E0
		internal bool CanRemove(DataTable table, bool fThrowException); // 0x00000001818770E0-0x0000000181877710
		public void Clear(); // 0x0000000181877710-0x00000001818779D0
		public bool Contains(string name); // 0x0000000181877B40-0x0000000181877B60
		internal bool Contains(string name, string tableNamespace, bool checkProperty, bool caseSensitive); // 0x0000000181877B60-0x0000000181877D10
		internal bool Contains(string name, bool caseSensitive); // 0x00000001818779D0-0x0000000181877B40
		public int IndexOf(DataTable table); // 0x0000000181878060-0x0000000181878150
		public int IndexOf(string tableName); // 0x0000000181877FB0-0x0000000181877FD0
		internal int IndexOf(string tableName, string tableNamespace, bool chekforNull); // 0x0000000181877FD0-0x0000000181878060
		internal void ReplaceFromInference(List<DataTable> tableList); // 0x0000000181878C40-0x0000000181878CA0
		internal int InternalIndexOf(string tableName); // 0x0000000181878150-0x00000001818783E0
		internal int InternalIndexOf(string tableName, string tableNamespace); // 0x00000001818783E0-0x00000001818785F0
		private string MakeName(int index); // 0x00000001818785F0-0x0000000181878680
		private void OnCollectionChanged(CollectionChangeEventArgs ccevent); // 0x0000000181878680-0x0000000181878740
		private void OnCollectionChanging(CollectionChangeEventArgs ccevent); // 0x0000000181878740-0x0000000181878800
		internal void RegisterName(string name, string tbNamespace); // 0x0000000181878800-0x0000000181878A90
		public void Remove(DataTable table); // 0x0000000181878A90-0x0000000181878C40
		internal void UnregisterName(string name); // 0x0000000181878CA0-0x0000000181878E40
	}
}
