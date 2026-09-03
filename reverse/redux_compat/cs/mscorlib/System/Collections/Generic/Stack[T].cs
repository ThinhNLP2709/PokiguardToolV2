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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(StackDebugView<T>))]
	[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
	public class Stack<T> : ICollection, IReadOnlyCollection<T> // TypeDefIndex: 3597
	{
		// Fields
		private T[] _array;
		private int _size;
		private int _version;
		[NonSerialized]
		private object _syncRoot;
	
		// Properties
		public int Count { get; }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
	
		// Nested types
		[Serializable]
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 3598
		{
			// Fields
			private readonly Stack<T> _stack;
			private readonly int _version;
			private int _index;
			private T _currentElement;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(Stack<T> stack);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			private void ThrowEnumerationNotStartedOrEnded();
			void IEnumerator.Reset();
		}
	
		// Constructors
		public Stack();
		public Stack(int capacity);
	
		// Methods
		public void Clear();
		public bool Contains(T item);
		void ICollection.CopyTo(Array array, int arrayIndex);
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public T Peek();
		public T Pop();
		public bool TryPop(out ref T result);
		public void Push(T item);
		private void PushWithResize(T item);
		public T[] ToArray();
		private void ThrowForEmptyStack();
	}
}
