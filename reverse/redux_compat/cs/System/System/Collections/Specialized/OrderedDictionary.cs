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
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.Specialized
{
	[Serializable]
	public class OrderedDictionary : IDictionary, ISerializable, IDeserializationCallback // TypeDefIndex: 8951
	{
		// Fields
		private ArrayList _objectsArray; // 0x10
		private Hashtable _objectsTable; // 0x18
		private int _initialCapacity; // 0x20
		private IEqualityComparer _comparer; // 0x28
		private bool _readOnly; // 0x30
		private object _syncRoot; // 0x38
		private SerializationInfo _siInfo; // 0x40
	
		// Properties
		public int Count { get; } // 0x0000000181BD36B0-0x0000000181BD36F0 
		bool IDictionary.IsFixedSize { get; } // 0x00000001802E8950-0x00000001802E8960 
		public bool IsReadOnly { get; } // 0x00000001802E8950-0x00000001802E8960 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public ICollection Keys { get; } // 0x0000000181BD3730-0x0000000181BD37B0 
		private ArrayList objectsArray { get; } // 0x0000000181BD3830-0x0000000181BD38B0 
		private Hashtable objectsTable { get; } // 0x0000000181BD38B0-0x0000000181BD3940 
		object ICollection.SyncRoot { get; } // 0x0000000181BD34D0-0x0000000181BD3540 
		public object this[object key] { get => default; set {} } // 0x0000000181BD36F0-0x0000000181BD3730 0x0000000181BD3940-0x0000000181BD3BF0
		public ICollection Values { get; } // 0x0000000181BD37B0-0x0000000181BD3830 
	
		// Nested types
		private class OrderedDictionaryEnumerator : IDictionaryEnumerator // TypeDefIndex: 8952
		{
			// Fields
			private int _objectReturnType; // 0x10
			private IEnumerator _arrayEnumerator; // 0x18
	
			// Properties
			public object Current { get; } // 0x0000000181BD21F0-0x0000000181BD23F0 
			public DictionaryEntry Entry { get; } // 0x0000000181BD23F0-0x0000000181BD24F0 
			public object Key { get; } // 0x0000000181BD24F0-0x0000000181BD2570 
			public object Value { get; } // 0x0000000181BD2570-0x0000000181BD25F0 
	
			// Constructors
			internal OrderedDictionaryEnumerator(ArrayList array, int objectReturnType); // 0x0000000181BD2180-0x0000000181BD21F0
	
			// Methods
			public bool MoveNext(); // 0x0000000181BD20E0-0x0000000181BD2130
			public void Reset(); // 0x0000000181BD2130-0x0000000181BD2180
		}
	
		private class OrderedDictionaryKeyValueCollection : ICollection // TypeDefIndex: 8953
		{
			// Fields
			private ArrayList _objects; // 0x10
			private bool _isKeys; // 0x18
	
			// Properties
			int ICollection.Count { get; } // 0x0000000181592F20-0x0000000181592F50 
			bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
			object ICollection.SyncRoot { get; } // 0x0000000181592730-0x0000000181592760 
	
			// Constructors
			public OrderedDictionaryKeyValueCollection(ArrayList array, bool isKeys); // 0x0000000181237140-0x0000000181237190
	
			// Methods
			void ICollection.CopyTo(Array array, int index); // 0x0000000181BD25F0-0x0000000181BD2930
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181BD2930-0x0000000181BD29D0
		}
	
		// Constructors
		public OrderedDictionary(); // 0x0000000181BD3640-0x0000000181BD3670
		public OrderedDictionary(int capacity); // 0x0000000181BD3600-0x0000000181BD3640
		public OrderedDictionary(int capacity, IEqualityComparer comparer); // 0x0000000181BD3670-0x0000000181BD36B0
		protected OrderedDictionary(SerializationInfo info, StreamingContext context); // 0x0000000181298360-0x00000001812983A0
	
		// Methods
		public void Add(object key, object value); // 0x0000000181BD29D0-0x0000000181BD2B00
		public void Clear(); // 0x0000000181BD2B00-0x0000000181BD2BB0
		public bool Contains(object key); // 0x0000000181BD2BB0-0x0000000181BD2BF0
		public void CopyTo(Array array, int index); // 0x0000000181BD2BF0-0x0000000181BD2C40
		private int IndexOfKey(object key); // 0x0000000181BD2EA0-0x0000000181BD3010
		public void Remove(object key); // 0x0000000181BD3390-0x0000000181BD34D0
		public virtual IDictionaryEnumerator GetEnumerator(); // 0x0000000181BD2C40-0x0000000181BD2CE0
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181BD3540-0x0000000181BD35E0
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181BD2CE0-0x0000000181BD2EA0
		void IDeserializationCallback.OnDeserialization(object sender); // 0x0000000181BD35E0-0x0000000181BD3600
		protected virtual void OnDeserialization(object sender); // 0x0000000181BD3010-0x0000000181BD3390
	}
}
