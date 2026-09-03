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

namespace System.Collections.Generic
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ICollectionDebugView<T>))]
	public class LinkedList<T> : ICollection<T>, ICollection, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback // TypeDefIndex: 8973
	{
		// Fields
		internal LinkedListNode<T> head;
		internal int count;
		internal int version;
		private object _syncRoot;
		private SerializationInfo _siInfo;
	
		// Properties
		public int Count { get; }
		public LinkedListNode<T> First { get; }
		public LinkedListNode<T> Last { get; }
		bool ICollection<T>.IsReadOnly { get; }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
	
		// Nested types
		[Serializable]
		public struct Enumerator : IEnumerator<T>, ISerializable, IDeserializationCallback // TypeDefIndex: 8974
		{
			// Fields
			private LinkedList<T> _list;
			private LinkedListNode<T> _node;
			private int _version;
			private T _current;
			private int _index;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(LinkedList<T> list);
			private Enumerator(SerializationInfo info, StreamingContext context);
	
			// Methods
			public bool MoveNext();
			void IEnumerator.Reset();
			public void Dispose();
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context);
			void IDeserializationCallback.OnDeserialization(object sender);
		}
	
		// Constructors
		public LinkedList();
		protected LinkedList(SerializationInfo info, StreamingContext context);
	
		// Methods
		void ICollection<T>.Add(T value);
		public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode);
		public LinkedListNode<T> AddFirst(T value);
		public void AddFirst(LinkedListNode<T> node);
		public LinkedListNode<T> AddLast(T value);
		public void AddLast(LinkedListNode<T> node);
		public void Clear();
		public bool Contains(T value);
		public void CopyTo(T[] array, int index);
		public LinkedListNode<T> Find(T value);
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		public bool Remove(T value);
		public void Remove(LinkedListNode<T> node);
		public void RemoveFirst();
		public void RemoveLast();
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		public virtual void OnDeserialization(object sender);
		private void InternalInsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode);
		private void InternalInsertNodeToEmptyList(LinkedListNode<T> newNode);
		internal void InternalRemoveNode(LinkedListNode<T> node);
		internal void ValidateNewNode(LinkedListNode<T> node);
		internal void ValidateNode(LinkedListNode<T> node);
		void ICollection.CopyTo(Array array, int index);
		IEnumerator IEnumerable.GetEnumerator();
	}
}
