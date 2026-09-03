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
	public abstract class NameObjectCollectionBase : ICollection, ISerializable, IDeserializationCallback // TypeDefIndex: 8960
	{
		// Fields
		private bool _readOnly; // 0x10
		private ArrayList _entriesArray; // 0x18
		private IEqualityComparer _keyComparer; // 0x20
		private Hashtable _entriesTable; // 0x28
		private NameObjectEntry _nullKeyEntry; // 0x30
		private KeysCollection _keys; // 0x38
		private SerializationInfo _serializationInfo; // 0x40
		private int _version; // 0x48
		[NonSerialized]
		private object _syncRoot; // 0x50
		private static StringComparer defaultComparer; // 0x00
	
		// Properties
		internal IEqualityComparer Comparer { get; } // 0x00000001802F8630-0x00000001802F8640 
		protected bool IsReadOnly { get; } // 0x00000001805625D0-0x00000001805625E0 
		public virtual int Count { get; } // 0x0000000181480EC0-0x0000000181480EF0 
		object ICollection.SyncRoot { get; } // 0x0000000181BCDD80-0x0000000181BCDDF0 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual KeysCollection Keys { get; } // 0x0000000181BCE1A0-0x0000000181BCE220 
	
		// Nested types
		internal class NameObjectEntry // TypeDefIndex: 8961
		{
			// Fields
			internal string Key; // 0x10
			internal object Value; // 0x18
	
			// Constructors
			internal NameObjectEntry(string name, object value); // 0x0000000180CB0730-0x0000000180CB0780
		}
	
		[Serializable]
		internal class NameObjectKeysEnumerator : IEnumerator // TypeDefIndex: 8962
		{
			// Fields
			private int _pos; // 0x10
			private NameObjectCollectionBase _coll; // 0x18
			private int _version; // 0x20
	
			// Properties
			public object Current { get; } // 0x0000000181BCE3E0-0x0000000181BCE4A0 
	
			// Constructors
			internal NameObjectKeysEnumerator(NameObjectCollectionBase coll); // 0x0000000181BCE390-0x0000000181BCE3E0
	
			// Methods
			public bool MoveNext(); // 0x0000000181BCE220-0x0000000181BCE300
			public void Reset(); // 0x0000000181BCE300-0x0000000181BCE390
		}
	
		[Serializable]
		[DefaultMember("Item")]
		public class KeysCollection : ICollection // TypeDefIndex: 8963
		{
			// Fields
			private NameObjectCollectionBase _coll; // 0x10
	
			// Properties
			public int Count { get; } // 0x00000001818C1810-0x00000001818C1840 
			object ICollection.SyncRoot { get; } // 0x0000000181BCB7E0-0x0000000181BCB830 
			bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			internal KeysCollection(NameObjectCollectionBase coll); // 0x00000001803855F0-0x0000000180385630
			internal KeysCollection(); // 0x0000000181BCB830-0x0000000181BCB860
	
			// Methods
			public IEnumerator GetEnumerator(); // 0x0000000181BCB3C0-0x0000000181BCB440
			void ICollection.CopyTo(Array array, int index); // 0x0000000181BCB440-0x0000000181BCB7E0
		}
	
		// Constructors
		protected NameObjectCollectionBase(); // 0x0000000181BCDF60-0x0000000181BCE040
		protected NameObjectCollectionBase(IEqualityComparer equalityComparer); // 0x0000000181BCE040-0x0000000181BCE0E0
		protected NameObjectCollectionBase(int capacity, IEqualityComparer equalityComparer); // 0x0000000181BCDEB0-0x0000000181BCDF60
		protected NameObjectCollectionBase(int capacity); // 0x0000000181BCE0E0-0x0000000181BCE1A0
		internal NameObjectCollectionBase(DBNull dummy); // 0x00000001802E5CB0-0x00000001802E5CC0
		protected NameObjectCollectionBase(SerializationInfo info, StreamingContext context); // 0x0000000181298360-0x00000001812983A0
		static NameObjectCollectionBase(); // 0x0000000181BCDDF0-0x0000000181BCDEB0
	
		// Methods
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181BCC970-0x0000000181BCD080
		public virtual void OnDeserialization(object sender); // 0x0000000181BCD080-0x0000000181BCD880
		private void Reset(); // 0x0000000181BCD880-0x0000000181BCD950
		private void Reset(int capacity); // 0x0000000181BCD950-0x0000000181BCDA30
		private NameObjectEntry FindEntry(string key); // 0x0000000181BCC830-0x0000000181BCC8F0
		protected void BaseAdd(string name, object value); // 0x0000000181BCBFF0-0x0000000181BCC1A0
		protected void BaseRemove(string name); // 0x0000000181BCC4F0-0x0000000181BCC760
		protected void BaseClear(); // 0x0000000181BCC1A0-0x0000000181BCC220
		protected object BaseGet(string name); // 0x0000000181BCC430-0x0000000181BCC450
		protected void BaseSet(string name, object value); // 0x0000000181BCC760-0x0000000181BCC830
		protected object BaseGet(int index); // 0x0000000181BCC450-0x0000000181BCC4F0
		protected string BaseGetKey(int index); // 0x0000000181BCC390-0x0000000181BCC430
		public virtual IEnumerator GetEnumerator(); // 0x0000000181BCC8F0-0x0000000181BCC970
		void ICollection.CopyTo(Array array, int index); // 0x0000000181BCDA30-0x0000000181BCDD80
		protected string[] BaseGetAllKeys(); // 0x0000000181BCC220-0x0000000181BCC390
	}
}
