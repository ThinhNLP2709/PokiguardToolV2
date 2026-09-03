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
	public class PropertyDescriptorCollection : IList, IDictionary // TypeDefIndex: 8872
	{
		// Fields
		public static readonly PropertyDescriptorCollection Empty; // 0x00
		private IDictionary _cachedFoundProperties; // 0x10
		private bool _cachedIgnoreCase; // 0x18
		private PropertyDescriptor[] _properties; // 0x20
		private readonly string[] _namedSort; // 0x28
		private readonly IComparer _comparer; // 0x30
		private bool _propsOwned; // 0x38
		private bool _needSort; // 0x39
		private bool _readOnly; // 0x3A
		private readonly object _internalSyncObject; // 0x40
		[CompilerGenerated]
		private int _Count_k__BackingField; // 0x48
	
		// Properties
		public int Count { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
		public virtual PropertyDescriptor this[int index] { get => default; } // 0x0000000181BB0680-0x0000000181BB0700 
		public virtual PropertyDescriptor this[string name] { get => default; } // 0x0000000181BB0700-0x0000000181BB0720 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		object ICollection.SyncRoot { get; } // 0x00000001802E7860-0x00000001802E7870 
		int ICollection.Count { get; } // 0x000000018033D1C0-0x000000018033D1D0 
		bool IDictionary.IsFixedSize { get; } // 0x00000001814CFF20-0x00000001814CFF30 
		bool IDictionary.IsReadOnly { get; } // 0x00000001814CFF20-0x00000001814CFF30 
		object IDictionary.this[object key] { get => default; set {} } // 0x0000000181BAF5F0-0x0000000181BAF650 0x0000000181BAF7F0-0x0000000181BAFC40
		ICollection IDictionary.Keys { get; } // 0x0000000181BAF650-0x0000000181BAF720 
		ICollection IDictionary.Values { get; } // 0x0000000181BAF720-0x0000000181BAF7F0 
		bool IList.IsReadOnly { get; } // 0x00000001814CFF20-0x00000001814CFF30 
		bool IList.IsFixedSize { get; } // 0x00000001814CFF20-0x00000001814CFF30 
		object IList.this[int index] { get => default; set {} } // 0x0000000181BB00A0-0x0000000181BB00C0 0x0000000181BB00C0-0x0000000181BB02F0
	
		// Nested types
		private class PropertyDescriptorEnumerator : IDictionaryEnumerator // TypeDefIndex: 8873
		{
			// Fields
			private PropertyDescriptorCollection _owner; // 0x10
			private int _index; // 0x18
	
			// Properties
			public object Current { get; } // 0x0000000181BB0750-0x0000000181BB0800 
			public DictionaryEntry Entry { get; } // 0x0000000181BB0800-0x0000000181BB0880 
			public object Key { get; } // 0x0000000181BB0880-0x0000000181BB08D0 
			public object Value { get; } // 0x0000000181BB0880-0x0000000181BB08D0 
	
			// Constructors
			public PropertyDescriptorEnumerator(PropertyDescriptorCollection owner); // 0x0000000181A802C0-0x0000000181A80300
	
			// Methods
			public bool MoveNext(); // 0x0000000181BB0720-0x0000000181BB0750
			public void Reset(); // 0x00000001810FCE00-0x00000001810FCE10
		}
	
		// Constructors
		public PropertyDescriptorCollection(PropertyDescriptor[] properties); // 0x0000000181BB0490-0x0000000181BB0580
		public PropertyDescriptorCollection(PropertyDescriptor[] properties, bool readOnly); // 0x0000000181BB0580-0x0000000181BB0680
		private PropertyDescriptorCollection(PropertyDescriptor[] properties, int propCount, string[] namedSort, IComparer comparer); // 0x0000000181BB0360-0x0000000181BB0490
		static PropertyDescriptorCollection(); // 0x0000000181BB02F0-0x0000000181BB0360
	
		// Methods
		public int Add(PropertyDescriptor value); // 0x0000000181BAE290-0x0000000181BAE380
		public void Clear(); // 0x0000000181BAE380-0x0000000181BAE3F0
		public bool Contains(PropertyDescriptor value); // 0x0000000181BAE3F0-0x0000000181BAE450
		public void CopyTo(Array array, int index); // 0x0000000181BAE450-0x0000000181BAE4A0
		private void EnsurePropsOwned(); // 0x0000000181BAE4A0-0x0000000181BAE550
		private void EnsureSize(int sizeNeeded); // 0x0000000181BAE550-0x0000000181BAE670
		public virtual PropertyDescriptor Find(string name, bool ignoreCase); // 0x0000000181BAE670-0x0000000181BAEAF0
		public int IndexOf(PropertyDescriptor value); // 0x0000000181BAEBA0-0x0000000181BAEC00
		public void Insert(int index, PropertyDescriptor value); // 0x0000000181BAEC00-0x0000000181BAED10
		public void Remove(PropertyDescriptor value); // 0x0000000181BAF1B0-0x0000000181BAF260
		public void RemoveAt(int index); // 0x0000000181BAF0F0-0x0000000181BAF1B0
		public virtual PropertyDescriptorCollection Sort(string[] names); // 0x0000000181BAF260-0x0000000181BAF3C0
		protected void InternalSort(string[] names); // 0x0000000181BAED90-0x0000000181BAF0F0
		protected void InternalSort(IComparer sorter); // 0x0000000181BAED10-0x0000000181BAED90
		public virtual IEnumerator GetEnumerator(); // 0x0000000181BAEAF0-0x0000000181BAEBA0
		void IList.Clear(); // 0x0000000181BAE380-0x0000000181BAE3F0
		void IDictionary.Clear(); // 0x0000000181BAE380-0x0000000181BAE3F0
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181625690-0x00000001816256B0
		void IList.RemoveAt(int index); // 0x0000000181BAFF90-0x0000000181BAFFA0
		void IDictionary.Add(object key, object value); // 0x0000000181BAF3C0-0x0000000181BAF480
		bool IDictionary.Contains(object key); // 0x0000000181BAF480-0x0000000181BAF4E0
		IDictionaryEnumerator IDictionary.GetEnumerator(); // 0x0000000181BAF4E0-0x0000000181BAF550
		void IDictionary.Remove(object key); // 0x0000000181BAF550-0x0000000181BAF5F0
		int IList.Add(object value); // 0x0000000181BAFC40-0x0000000181BAFCC0
		bool IList.Contains(object value); // 0x0000000181BAFCC0-0x0000000181BAFD70
		int IList.IndexOf(object value); // 0x0000000181BAFD70-0x0000000181BAFE20
		void IList.Insert(int index, object value); // 0x0000000181BAFE20-0x0000000181BAFF90
		void IList.Remove(object value); // 0x0000000181BAFFA0-0x0000000181BB00A0
	}
}
