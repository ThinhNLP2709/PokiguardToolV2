/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(HashtableDebugView))]
	public class Hashtable : IDictionary, ISerializable, IDeserializationCallback, ICloneable // TypeDefIndex: 3529
	{
		// Fields
		private bucket[] _buckets; // 0x10
		private int _count; // 0x18
		private int _occupancy; // 0x1C
		private int _loadsize; // 0x20
		private float _loadFactor; // 0x24
		private int _version; // 0x28
		private bool _isWriterInProgress; // 0x2C
		private ICollection _keys; // 0x30
		private ICollection _values; // 0x38
		private IEqualityComparer _keycomparer; // 0x40
		private object _syncRoot; // 0x48
		private static ConditionalWeakTable<object, SerializationInfo> s_serializationInfoTable; // 0x00
	
		// Properties
		private static ConditionalWeakTable<object, SerializationInfo> SerializationInfoTable { get; } // 0x00000001815ACBD0-0x00000001815ACC20 
		public virtual object this[object key] { get => default; set {} } // 0x00000001815AC900-0x00000001815ACB50 0x00000001815ACF90-0x00000001815ACFB0
		public virtual bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual ICollection Keys { get; } // 0x00000001815ACB50-0x00000001815ACBD0 
		public virtual ICollection Values { get; } // 0x00000001815ACC20-0x00000001815ACCA0 
		public virtual object SyncRoot { get; } // 0x00000001810CC750-0x00000001810CC7C0 
		public virtual int Count { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Nested types
		private struct bucket // TypeDefIndex: 3530
		{
			// Fields
			public object key; // 0x00
			public object val; // 0x08
			public int hash_coll; // 0x10
		}
	
		[Serializable]
		private class KeyCollection : ICollection // TypeDefIndex: 3531
		{
			// Fields
			private Hashtable _hashtable; // 0x10
	
			// Properties
			public virtual bool IsSynchronized { get; } // 0x00000001815AE920-0x00000001815AE950 
			public virtual object SyncRoot { get; } // 0x00000001815AE950-0x00000001815AE980 
			public virtual int Count { get; } // 0x0000000180B5F570-0x0000000180B5F590 
	
			// Constructors
			internal KeyCollection(Hashtable hashtable); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public virtual void CopyTo(Array array, int arrayIndex); // 0x00000001815AE660-0x00000001815AE880
			public virtual IEnumerator GetEnumerator(); // 0x00000001815AE880-0x00000001815AE920
		}
	
		[Serializable]
		private class ValueCollection : ICollection // TypeDefIndex: 3532
		{
			// Fields
			private Hashtable _hashtable; // 0x10
	
			// Properties
			public virtual bool IsSynchronized { get; } // 0x00000001815AE920-0x00000001815AE950 
			public virtual object SyncRoot { get; } // 0x00000001815AE950-0x00000001815AE980 
			public virtual int Count { get; } // 0x0000000180B5F570-0x0000000180B5F590 
	
			// Constructors
			internal ValueCollection(Hashtable hashtable); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public virtual void CopyTo(Array array, int arrayIndex); // 0x00000001815BB8D0-0x00000001815BBB00
			public virtual IEnumerator GetEnumerator(); // 0x00000001815BBB00-0x00000001815BC210
		}
	
		[Serializable]
		private class SyncHashtable : Hashtable, IEnumerable // TypeDefIndex: 3533
		{
			// Fields
			protected Hashtable _table; // 0x50
	
			// Properties
			public override int Count { get; } // 0x00000001815B8D00-0x00000001815B8D30 
			public override bool IsReadOnly { get; } // 0x00000001815B8D60-0x00000001815B8D90 
			public override bool IsFixedSize { get; } // 0x00000001815B8D30-0x00000001815B8D60 
			public override bool IsSynchronized { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public override object this[object key] { get => default; set {} } // 0x00000001815B8D90-0x00000001815B8DC0 0x00000001815B9010-0x00000001815B9120
			public override object SyncRoot { get; } // 0x00000001815B8ED0-0x00000001815B8F00 
			public override ICollection Keys { get; } // 0x00000001815B8DC0-0x00000001815B8ED0 
			public override ICollection Values { get; } // 0x00000001815B8F00-0x00000001815B9010 
	
			// Constructors
			internal SyncHashtable(Hashtable table); // 0x00000001815B8CC0-0x00000001815B8D00
			internal SyncHashtable(SerializationInfo info, StreamingContext context); // 0x00000001815B8C60-0x00000001815B8CC0
	
			// Methods
			public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815B8B20-0x00000001815B8B60
			public override void Add(object key, object value); // 0x00000001815B8500-0x00000001815B8610
			public override void Clear(); // 0x00000001815B8610-0x00000001815B8700
			public override bool Contains(object key); // 0x00000001815B89B0-0x00000001815B89E0
			public override bool ContainsKey(object key); // 0x00000001815B8900-0x00000001815B89B0
			public override void CopyTo(Array array, int arrayIndex); // 0x00000001815B89E0-0x00000001815B8AF0
			public override object Clone(); // 0x00000001815B8700-0x00000001815B8900
			new IEnumerator IEnumerable.GetEnumerator(); // 0x00000001815B8AF0-0x00000001815B8B20
			public override IDictionaryEnumerator GetEnumerator(); // 0x00000001815B8AF0-0x00000001815B8B20
			public override void Remove(object key); // 0x00000001815B8B60-0x00000001815B8C60
			public override void OnDeserialization(object sender); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		[Serializable]
		private class HashtableEnumerator : IDictionaryEnumerator, ICloneable // TypeDefIndex: 3534
		{
			// Fields
			private Hashtable _hashtable; // 0x10
			private int _bucket; // 0x18
			private int _version; // 0x1C
			private bool _current; // 0x20
			private int _getObjectRetType; // 0x24
			private object _currentKey; // 0x28
			private object _currentValue; // 0x30
	
			// Properties
			public virtual object Key { get; } // 0x00000001815A9DA0-0x00000001815A9E10 
			public virtual DictionaryEntry Entry { get; } // 0x00000001815A9D20-0x00000001815A9DA0 
			public virtual object Current { get; } // 0x00000001815A9C50-0x00000001815A9D20 
			public virtual object Value { get; } // 0x00000001815A9E10-0x00000001815A9E80 
	
			// Constructors
			internal HashtableEnumerator(Hashtable hashtable, int getObjRetType); // 0x00000001815A9BE0-0x00000001815A9C50
	
			// Methods
			public object Clone(); // 0x0000000181560410-0x0000000181560420
			public virtual bool MoveNext(); // 0x00000001815A99D0-0x00000001815A9B10
			public virtual void Reset(); // 0x00000001815A9B10-0x00000001815A9BE0
		}
	
		internal class HashtableDebugView // TypeDefIndex: 3535
		{
		}
	
		// Constructors
		internal Hashtable(bool trash); // 0x00000001802E5CB0-0x00000001802E5CC0
		public Hashtable(); // 0x00000001815AC560-0x00000001815AC580
		public Hashtable(int capacity); // 0x00000001815AC4A0-0x00000001815AC4B0
		public Hashtable(int capacity, float loadFactor); // 0x00000001815AC600-0x00000001815AC880
		public Hashtable(int capacity, float loadFactor, IEqualityComparer equalityComparer); // 0x00000001815AC580-0x00000001815AC5C0
		[Obsolete("Please use Hashtable(IEqualityComparer) instead.")]
		public Hashtable(IHashCodeProvider hcp, IComparer comparer); // 0x00000001815AC360-0x00000001815AC400
		public Hashtable(IEqualityComparer equalityComparer); // 0x00000001815AC320-0x00000001815AC360
		public Hashtable(int capacity, IEqualityComparer equalityComparer); // 0x00000001815AC5C0-0x00000001815AC600
		[Obsolete("Please use Hashtable(int, float, IEqualityComparer) instead.")]
		public Hashtable(int capacity, float loadFactor, IHashCodeProvider hcp, IComparer comparer); // 0x00000001815AC400-0x00000001815AC4A0
		protected Hashtable(SerializationInfo info, StreamingContext context); // 0x00000001815AC4B0-0x00000001815AC560
	
		// Methods
		private uint InitHash(object key, int hashsize, out uint seed, out uint incr); // 0x00000001815AAE00-0x00000001815AAE50
		public virtual void Add(object key, object value); // 0x00000001815A9E80-0x00000001815A9EA0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public virtual void Clear(); // 0x00000001815A9EA0-0x00000001815A9FD0
		public virtual object Clone(); // 0x00000001815A9FD0-0x00000001815AA0F0
		public virtual bool Contains(object key); // 0x00000001815AA280-0x00000001815AA2A0
		public virtual bool ContainsKey(object key); // 0x00000001815AA0F0-0x00000001815AA280
		private void CopyKeys(Array array, int arrayIndex); // 0x00000001815AA3B0-0x00000001815AA450
		private void CopyEntries(Array array, int arrayIndex); // 0x00000001815AA2A0-0x00000001815AA3B0
		public virtual void CopyTo(Array array, int arrayIndex); // 0x00000001815AA450-0x00000001815AA6E0
		private void CopyValues(Array array, int arrayIndex); // 0x00000001815AA6E0-0x00000001815AA780
		private void expand(); // 0x00000001815AC880-0x00000001815AC900
		private void rehash(); // 0x00000001815ACF60-0x00000001815ACF90
		private void UpdateVersion(); // 0x00000001815AC2F0-0x00000001815AC320
		private void rehash(int newsize); // 0x00000001815ACDF0-0x00000001815ACF60
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001815AC260-0x00000001815AC2F0
		public virtual IDictionaryEnumerator GetEnumerator(); // 0x00000001815AA780-0x00000001815AA810
		protected virtual int GetHash(object key); // 0x00000001815AA810-0x00000001815AA8A0
		protected virtual bool KeyEquals(object item, object key); // 0x00000001815AB400-0x00000001815AB540
		private void Insert(object key, object nvalue, bool add); // 0x00000001815AAE50-0x00000001815AB400
		private void putEntry(bucket[] newBuckets, object key, object nvalue, int hashcode); // 0x00000001815ACCA0-0x00000001815ACDF0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public virtual void Remove(object key); // 0x00000001815ABEE0-0x00000001815AC1B0
		public static Hashtable Synchronized(Hashtable table); // 0x00000001815AC1B0-0x00000001815AC260
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815AA8A0-0x00000001815AAE00
		public virtual void OnDeserialization(object sender); // 0x00000001815AB540-0x00000001815ABEE0
	}
}
