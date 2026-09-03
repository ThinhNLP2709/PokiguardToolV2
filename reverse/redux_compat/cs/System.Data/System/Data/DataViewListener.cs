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
	internal sealed class DataViewListener // TypeDefIndex: 11261
	{
		// Fields
		private readonly WeakReference _dvWeak; // 0x10
		private DataTable _table; // 0x18
		private Index _index; // 0x20
		internal readonly int _objectID; // 0x28
	
		// Constructors
		internal DataViewListener(DataView dv); // 0x0000000181886610-0x00000001818866A0
	
		// Methods
		private void ChildRelationCollectionChanged(object sender, CollectionChangeEventArgs e); // 0x0000000181885810-0x00000001818858F0
		private void ParentRelationCollectionChanged(object sender, CollectionChangeEventArgs e); // 0x0000000181885C50-0x0000000181885D30
		private void ColumnCollectionChanged(object sender, CollectionChangeEventArgs e); // 0x0000000181885910-0x0000000181885A00
		internal void MaintainDataView(ListChangedType changedType, DataRow row, bool trackAddRemove); // 0x0000000181885B60-0x0000000181885C50
		internal void IndexListChanged(ListChangedEventArgs e); // 0x0000000181885A00-0x0000000181885B60
		internal void RegisterMetaDataEvents(DataTable table); // 0x0000000181885FF0-0x0000000181886210
		internal void UnregisterMetaDataEvents(); // 0x0000000181886600-0x0000000181886610
		private void UnregisterMetaDataEvents(bool updateListeners); // 0x0000000181886310-0x0000000181886600
		internal void RegisterListChangedEvent(Index index); // 0x0000000181885D30-0x0000000181885E10
		internal void UnregisterListChangedEvent(); // 0x0000000181886210-0x0000000181886310
		private void CleanUp(bool updateListeners); // 0x00000001818858F0-0x0000000181885910
		private void RegisterListener(DataTable table); // 0x0000000181885E10-0x0000000181885FF0
	}
}
