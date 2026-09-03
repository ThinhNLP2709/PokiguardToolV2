/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.Specialized
{
	public class NotifyCollectionChangedEventArgs : EventArgs // TypeDefIndex: 8957
	{
		// Fields
		private NotifyCollectionChangedAction _action; // 0x10
		private IList _newItems; // 0x18
		private IList _oldItems; // 0x20
		private int _newStartingIndex; // 0x28
		private int _oldStartingIndex; // 0x2C
	
		// Properties
		public NotifyCollectionChangedAction Action { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public IList NewItems { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public int NewStartingIndex { get; } // 0x0000000180377930-0x0000000180377940 
		public int OldStartingIndex { get; } // 0x00000001803B5DE0-0x00000001803B5DF0 
	
		// Constructors
		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action); // 0x0000000181BD1B40-0x0000000181BD1C70
		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index); // 0x0000000181BD1800-0x0000000181BD1B40
		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem, int index); // 0x0000000181BD1E50-0x0000000181BD2070
		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex); // 0x0000000181BD1C70-0x0000000181BD1E50
	
		// Methods
		private void InitializeAddOrRemove(NotifyCollectionChangedAction action, IList changedItems, int startingIndex); // 0x0000000181BD14A0-0x0000000181BD15B0
		private void InitializeAdd(NotifyCollectionChangedAction action, IList newItems, int newStartingIndex); // 0x0000000181BD15B0-0x0000000181BD1650
		private void InitializeRemove(NotifyCollectionChangedAction action, IList oldItems, int oldStartingIndex); // 0x0000000181BD1760-0x0000000181BD1800
		private void InitializeMoveOrReplace(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex, int oldStartingIndex); // 0x0000000181BD1650-0x0000000181BD1760
	}
}
