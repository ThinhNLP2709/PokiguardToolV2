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
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(SortedListDebugView))]
	public class SortedList : IDictionary, ICloneable // TypeDefIndex: 3513
	{
		// Fields
		private object[] keys; // 0x10
		private object[] values; // 0x18
		private int _size; // 0x20
		private int version; // 0x24
		private IComparer comparer; // 0x28
		private KeyList keyList; // 0x30
		private ValueList valueList; // 0x38
		[NonSerialized]
		private object _syncRoot; // 0x40
	
		// Properties
		public virtual int Capacity { set; } // 0x00000001815A00B0-0x00000001815A0260
		public virtual int Count { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public virtual ICollection Keys { get; } // 0x00000001815A0070-0x00000001815A0090 
		public virtual ICollection Values { get; } // 0x00000001815A0090-0x00000001815A00B0 
		public virtual bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual object SyncRoot { get; } // 0x0000000180DA7660-0x0000000180DA76D0 
		public virtual object this[object key] { get => default; set {} } // 0x00000001815A0020-0x00000001815A0070 0x00000001815A0260-0x00000001815A03B0
	
		// Nested types
		[Serializable]
		private class SyncSortedList : SortedList // TypeDefIndex: 3514
		{
			// Fields
			private SortedList _list; // 0x48
			private object _root; // 0x50
	
			// Properties
			public override int Count { get; } // 0x00000001815A3640-0x00000001815A3700 
			public override object SyncRoot { get; } // 0x00000001806CCC00-0x00000001806CCC10 
			public override bool IsReadOnly { get; } // 0x00000001815A3730-0x00000001815A3760 
			public override bool IsFixedSize { get; } // 0x00000001815A3700-0x00000001815A3730 
			public override bool IsSynchronized { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public override object this[object key] { get => default; set {} } // 0x00000001815A3760-0x00000001815A3840 0x00000001815A3840-0x00000001815A3920
	
			// Constructors
			internal SyncSortedList(SortedList list); // 0x00000001815A35D0-0x00000001815A3640
	
			// Methods
			public override void Add(object key, object value); // 0x00000001815A2830-0x00000001815A2910
			public override void Clear(); // 0x00000001815A2910-0x00000001815A29D0
			public override object Clone(); // 0x00000001815A29D0-0x00000001815A2AA0
			public override bool Contains(object key); // 0x00000001815A2C60-0x00000001815A2D40
			public override bool ContainsKey(object key); // 0x00000001815A2AA0-0x00000001815A2B80
			public override bool ContainsValue(object key); // 0x00000001815A2B80-0x00000001815A2C60
			public override void CopyTo(Array array, int index); // 0x00000001815A2D40-0x00000001815A2E20
			public override object GetByIndex(int index); // 0x00000001815A2E20-0x00000001815A2EF0
			public override IDictionaryEnumerator GetEnumerator(); // 0x00000001815A2EF0-0x00000001815A2FC0
			public override object GetKey(int index); // 0x00000001815A3090-0x00000001815A3160
			public override IList GetKeyList(); // 0x00000001815A2FC0-0x00000001815A3090
			public override IList GetValueList(); // 0x00000001815A3160-0x00000001815A3230
			public override int IndexOfKey(object key); // 0x00000001815A3230-0x00000001815A3370
			public override int IndexOfValue(object value); // 0x00000001815A3370-0x00000001815A3440
			public override void RemoveAt(int index); // 0x00000001815A3440-0x00000001815A3500
			public override void Remove(object key); // 0x00000001815A3500-0x00000001815A35D0
		}
	
		[Serializable]
		private class SortedListEnumerator : IDictionaryEnumerator, ICloneable // TypeDefIndex: 3515
		{
			// Fields
			private SortedList _sortedList; // 0x10
			private object _key; // 0x18
			private object _value; // 0x20
			private int _index; // 0x28
			private int _startIndex; // 0x2C
			private int _endIndex; // 0x30
			private int _version; // 0x34
			private bool _current; // 0x38
			private int _getObjectRetType; // 0x3C
	
			// Properties
			public virtual object Key { get; } // 0x000000018159EBD0-0x000000018159ECA0 
			public virtual DictionaryEntry Entry { get; } // 0x000000018159EAD0-0x000000018159EBD0 
			public virtual object Current { get; } // 0x000000018159E9D0-0x000000018159EAD0 
			public virtual object Value { get; } // 0x000000018159ECA0-0x000000018159ED70 
	
			// Constructors
			internal SortedListEnumerator(SortedList sortedList, int index, int count, int getObjRetType); // 0x000000018159E950-0x000000018159E9D0
	
			// Methods
			public object Clone(); // 0x0000000181560410-0x0000000181560420
			public virtual bool MoveNext(); // 0x000000018159E790-0x000000018159E8B0
			public virtual void Reset(); // 0x000000018159E8B0-0x000000018159E950
		}
	
		[Serializable]
		[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
		private class KeyList : IList // TypeDefIndex: 3516
		{
			// Fields
			private SortedList sortedList; // 0x10
	
			// Properties
			public virtual int Count { get; } // 0x0000000180F1C220-0x0000000180F1C240 
			public virtual bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public virtual bool IsFixedSize { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public virtual bool IsSynchronized { get; } // 0x000000018159B4F0-0x000000018159B520 
			public virtual object SyncRoot { get; } // 0x0000000181465D40-0x0000000181465D70 
			public virtual object this[int index] { get => default; set {} } // 0x00000001815928A0-0x00000001815928D0 0x000000018159B520-0x000000018159B570
	
			// Constructors
			internal KeyList(SortedList sortedList); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public virtual int Add(object key); // 0x000000018159B0B0-0x000000018159B100
			public virtual void Clear(); // 0x000000018159B100-0x000000018159B150
			public virtual bool Contains(object key); // 0x000000018159B150-0x000000018159B180
			public virtual void CopyTo(Array array, int arrayIndex); // 0x000000018159B180-0x000000018159B260
			public virtual void Insert(int index, object value); // 0x000000018159B400-0x000000018159B450
			public virtual IEnumerator GetEnumerator(); // 0x000000018159B260-0x000000018159B310
			public virtual int IndexOf(object key); // 0x000000018159B310-0x000000018159B400
			public virtual void Remove(object key); // 0x000000018159B4A0-0x000000018159B4F0
			public virtual void RemoveAt(int index); // 0x000000018159B450-0x000000018159B4A0
		}
	
		[Serializable]
		[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
		private class ValueList : IList // TypeDefIndex: 3517
		{
			// Fields
			private SortedList sortedList; // 0x10
	
			// Properties
			public virtual int Count { get; } // 0x0000000180F1C220-0x0000000180F1C240 
			public virtual bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public virtual bool IsFixedSize { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public virtual bool IsSynchronized { get; } // 0x000000018159B4F0-0x000000018159B520 
			public virtual object SyncRoot { get; } // 0x0000000181465D40-0x0000000181465D70 
			public virtual object this[int index] { get => default; set {} } // 0x00000001815A4830-0x00000001815A4860 0x00000001815A4860-0x00000001815A4DD0
	
			// Constructors
			internal ValueList(SortedList sortedList); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public virtual int Add(object key); // 0x00000001815A4450-0x00000001815A44A0
			public virtual void Clear(); // 0x00000001815A44A0-0x00000001815A44F0
			public virtual bool Contains(object value); // 0x00000001815A44F0-0x00000001815A4520
			public virtual void CopyTo(Array array, int arrayIndex); // 0x00000001815A4520-0x00000001815A4600
			public virtual void Insert(int index, object value); // 0x00000001815A4740-0x00000001815A4790
			public virtual IEnumerator GetEnumerator(); // 0x00000001815A4600-0x00000001815A46B0
			public virtual int IndexOf(object value); // 0x00000001815A46B0-0x00000001815A4740
			public virtual void Remove(object value); // 0x00000001815A47E0-0x00000001815A4830
			public virtual void RemoveAt(int index); // 0x00000001815A4790-0x00000001815A47E0
		}
	
		internal class SortedListDebugView // TypeDefIndex: 3518
		{
		}
	
		// Constructors
		public SortedList(); // 0x000000018159FE30-0x000000018159FE50
		public SortedList(int initialCapacity); // 0x000000018159FE50-0x00000001815A0020
		public SortedList(IComparer comparer); // 0x000000018159FDE0-0x000000018159FE30
	
		// Methods
		private void Init(); // 0x000000018159F760-0x000000018159F920
		public virtual void Add(object key, object value); // 0x000000018159ED70-0x000000018159EEB0
		public virtual void Clear(); // 0x000000018159EEB0-0x000000018159EEF0
		public virtual object Clone(); // 0x000000018159EEF0-0x000000018159EFC0
		public virtual bool Contains(object key); // 0x000000018159EFC0-0x000000018159EFF0
		public virtual bool ContainsKey(object key); // 0x000000018159EFC0-0x000000018159EFF0
		public virtual bool ContainsValue(object value); // 0x000000018159EFF0-0x000000018159F020
		public virtual void CopyTo(Array array, int arrayIndex); // 0x000000018159F020-0x000000018159F300
		private void EnsureCapacity(int min); // 0x000000018159F300-0x000000018159F360
		public virtual object GetByIndex(int index); // 0x000000018159F360-0x000000018159F410
		IEnumerator IEnumerable.GetEnumerator(); // 0x000000018159FD50-0x000000018159FDE0
		public virtual IDictionaryEnumerator GetEnumerator(); // 0x000000018159F410-0x000000018159F4A0
		public virtual object GetKey(int index); // 0x000000018159F520-0x000000018159F5D0
		public virtual IList GetKeyList(); // 0x000000018159F4A0-0x000000018159F520
		public virtual IList GetValueList(); // 0x000000018159F5D0-0x000000018159F650
		public virtual int IndexOfKey(object key); // 0x000000018159F650-0x000000018159F700
		public virtual int IndexOfValue(object value); // 0x000000018159F700-0x000000018159F760
		private void Insert(int index, object key, object value); // 0x000000018159F920-0x000000018159FAC0
		public virtual void RemoveAt(int index); // 0x000000018159FAC0-0x000000018159FC20
		public virtual void Remove(object key); // 0x000000018159FC20-0x000000018159FC70
		public static SortedList Synchronized(SortedList list); // 0x000000018159FC70-0x000000018159FD50
	}
}
