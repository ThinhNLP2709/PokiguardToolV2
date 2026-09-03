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

namespace System.ComponentModel
{
	public class EventDescriptorCollection : IList // TypeDefIndex: 8848
	{
		// Fields
		private EventDescriptor[] _events; // 0x10
		private string[] _namedSort; // 0x18
		private readonly IComparer _comparer; // 0x20
		private bool _eventsOwned; // 0x28
		private bool _needSort; // 0x29
		private readonly bool _readOnly; // 0x2A
		public static readonly EventDescriptorCollection Empty; // 0x00
		[CompilerGenerated]
		private int _Count_k__BackingField; // 0x2C
	
		// Properties
		public int Count { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public virtual EventDescriptor this[int index] { get => default; } // 0x0000000181BAA5C0-0x0000000181BAA640 
		public virtual EventDescriptor this[string name] { get => default; } // 0x0000000181BAA5A0-0x0000000181BAA5C0 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		object ICollection.SyncRoot { get; } // 0x00000001802E7860-0x00000001802E7870 
		int ICollection.Count { get; } // 0x00000001803B5DE0-0x00000001803B5DF0 
		object IList.this[int index] { get => default; set {} } // 0x000000018184CE60-0x000000018184CE80 0x0000000181BAA190-0x0000000181BAA340
		bool IList.IsReadOnly { get; } // 0x000000018052D510-0x000000018052D520 
		bool IList.IsFixedSize { get; } // 0x000000018052D510-0x000000018052D520 
	
		// Nested types
		private class ArraySubsetEnumerator : IEnumerator // TypeDefIndex: 8849
		{
			// Fields
			private readonly Array _array; // 0x10
			private readonly int _total; // 0x18
			private int _current; // 0x1C
	
			// Properties
			public object Current { get; } // 0x0000000181BA37B0-0x0000000181BA3820 
	
			// Constructors
			public ArraySubsetEnumerator(Array array, int count); // 0x0000000181BA3760-0x0000000181BA37B0
	
			// Methods
			public bool MoveNext(); // 0x0000000181BA3730-0x0000000181BA3750
			public void Reset(); // 0x0000000181BA3750-0x0000000181BA3760
		}
	
		// Constructors
		public EventDescriptorCollection(EventDescriptor[] events); // 0x0000000181BAA420-0x0000000181BAA4E0
		public EventDescriptorCollection(EventDescriptor[] events, bool readOnly); // 0x0000000181BAA4E0-0x0000000181BAA5A0
		static EventDescriptorCollection(); // 0x0000000181BAA340-0x0000000181BAA420
	
		// Methods
		public int Add(EventDescriptor value); // 0x0000000181BA8F30-0x0000000181BA9020
		public void Clear(); // 0x0000000181BA9020-0x0000000181BA9080
		public bool Contains(EventDescriptor value); // 0x0000000181BA9080-0x0000000181BA90E0
		void ICollection.CopyTo(Array array, int index); // 0x0000000181BA9B60-0x0000000181BA9BB0
		private void EnsureEventsOwned(); // 0x0000000181BA90E0-0x0000000181BA9190
		private void EnsureSize(int sizeNeeded); // 0x0000000181BA9190-0x0000000181BA92B0
		public virtual EventDescriptor Find(string name, bool ignoreCase); // 0x0000000181BA92B0-0x0000000181BA93F0
		public int IndexOf(EventDescriptor value); // 0x0000000181BA94A0-0x0000000181BA9500
		public void Insert(int index, EventDescriptor value); // 0x0000000181BA9500-0x0000000181BA9610
		public void Remove(EventDescriptor value); // 0x0000000181BA9AB0-0x0000000181BA9B60
		public void RemoveAt(int index); // 0x0000000181BA99F0-0x0000000181BA9AB0
		public IEnumerator GetEnumerator(); // 0x0000000181BA93F0-0x0000000181BA94A0
		protected void InternalSort(string[] names); // 0x0000000181BA9690-0x0000000181BA99F0
		protected void InternalSort(IComparer sorter); // 0x0000000181BA9610-0x0000000181BA9690
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181BA9BB0-0x0000000181BA9C60
		int IList.Add(object value); // 0x0000000181BA9C60-0x0000000181BA9DB0
		bool IList.Contains(object value); // 0x0000000181BA9DB0-0x0000000181BA9E60
		void IList.Clear(); // 0x0000000181BA9020-0x0000000181BA9080
		int IList.IndexOf(object value); // 0x0000000181BA9E60-0x0000000181BA9F10
		void IList.Insert(int index, object value); // 0x0000000181BA9F10-0x0000000181BAA080
		void IList.Remove(object value); // 0x0000000181BAA090-0x0000000181BAA190
		void IList.RemoveAt(int index); // 0x0000000181BAA080-0x0000000181BAA090
	}
}
