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

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Collections.Generic
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ICollectionDebugView<T>))]
	public class HashSet<T> : ISet<T>, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback // TypeDefIndex: 12597
	{
		// Fields
		private int[] _buckets;
		private Slot[] _slots;
		private int _count;
		private int _lastIndex;
		private int _freeList;
		private IEqualityComparer<T> _comparer;
		private int _version;
		private SerializationInfo _siInfo;
	
		// Properties
		public int Count { get; }
		bool ICollection<T>.IsReadOnly { get; }
		public IEqualityComparer<T> Comparer { get; }
	
		// Nested types
		internal struct ElementCount // TypeDefIndex: 12598
		{
			// Fields
			internal int uniqueCount;
			internal int unfoundCount;
		}
	
		internal struct Slot // TypeDefIndex: 12599
		{
			// Fields
			internal int hashCode;
			internal int next;
			internal T value;
		}
	
		[Serializable]
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 12600
		{
			// Fields
			private HashSet<T> _set;
			private int _index;
			private int _version;
			private T _current;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(HashSet<T> set);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			void IEnumerator.Reset();
		}
	
		// Constructors
		public HashSet();
		public HashSet(IEqualityComparer<T> comparer);
		public HashSet(int capacity);
		public HashSet(IEnumerable<T> collection);
		public HashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer);
		protected HashSet(SerializationInfo info, StreamingContext context);
		public HashSet(int capacity, IEqualityComparer<T> comparer);
	
		// Methods
		private void CopyFrom(HashSet<T> source);
		void ICollection<T>.Add(T item);
		public void Clear();
		public bool Contains(T item);
		public void CopyTo(T[] array, int arrayIndex);
		public bool Remove(T item);
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		public virtual void OnDeserialization(object sender);
		public bool Add(T item);
		public void UnionWith(IEnumerable<T> other);
		public void IntersectWith(IEnumerable<T> other);
		public bool SetEquals(IEnumerable<T> other);
		public void CopyTo(T[] array);
		public void CopyTo(T[] array, int arrayIndex, int count);
		public int RemoveWhere(Predicate<T> match);
		public void TrimExcess();
		private int Initialize(int capacity);
		private void IncreaseCapacity();
		private void SetCapacity(int newSize);
		private bool AddIfNotPresent(T value);
		private void AddValue(int index, int hashCode, T value);
		private bool ContainsAllElements(IEnumerable<T> other);
		private void IntersectWithHashSetWithSameEC(HashSet<T> other);
		private void IntersectWithEnumerable(IEnumerable<T> other);
		private int InternalIndexOf(T item);
		private ElementCount CheckUniqueAndUnfoundElements(IEnumerable<T> other, bool returnIfUnfound);
		private static bool AreEqualityComparersEqual(HashSet<T> set1, HashSet<T> set2);
		private int InternalGetHashCode(T item);
	}
}
