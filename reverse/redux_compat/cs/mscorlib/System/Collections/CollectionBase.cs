/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections
{
	[Serializable]
	public abstract class CollectionBase : IList // TypeDefIndex: 3508
	{
		// Fields
		private ArrayList _list; // 0x10
	
		// Properties
		protected ArrayList InnerList { get; } // 0x0000000180377550-0x0000000180377560 
		protected IList List { get; } // 0x0000000180370C60-0x0000000180370C70 
		public int Count { get; } // 0x0000000181592F20-0x0000000181592F50 
		bool IList.IsReadOnly { get; } // 0x0000000181592BE0-0x0000000181592C10 
		bool IList.IsFixedSize { get; } // 0x0000000181592BB0-0x0000000181592BE0 
		bool ICollection.IsSynchronized { get; } // 0x0000000181501A10-0x0000000181501A40 
		object ICollection.SyncRoot { get; } // 0x0000000181592730-0x0000000181592760 
		object IList.this[int index] { get => default; set {} } // 0x0000000181592C10-0x0000000181592CE0 0x0000000181592CE0-0x0000000181592EB0
	
		// Constructors
		protected CollectionBase(); // 0x0000000181592EB0-0x0000000181592F20
	
		// Methods
		public void Clear(); // 0x00000001815924A0-0x0000000181592500
		public void RemoveAt(int index); // 0x0000000181592560-0x0000000181592700
		void ICollection.CopyTo(Array array, int index); // 0x0000000181592700-0x0000000181592730
		bool IList.Contains(object value); // 0x0000000181592870-0x00000001815928A0
		int IList.Add(object value); // 0x0000000181592760-0x0000000181592870
		void IList.Remove(object value); // 0x0000000181592A50-0x0000000181592BB0
		int IList.IndexOf(object value); // 0x00000001815928A0-0x00000001815928D0
		void IList.Insert(int index, object value); // 0x00000001815928D0-0x0000000181592A50
		public IEnumerator GetEnumerator(); // 0x0000000181411FF0-0x0000000181412020
		protected virtual void OnSet(int index, object oldValue, object newValue); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnInsert(int index, object value); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnClear(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnRemove(int index, object value); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnValidate(object value); // 0x0000000181592500-0x0000000181592560
		protected virtual void OnSetComplete(int index, object oldValue, object newValue); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnInsertComplete(int index, object value); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnClearComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnRemoveComplete(int index, object value); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
