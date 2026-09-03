/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.Concurrent
{
	[DebuggerDisplay("Count = {Count}, Type = {_collection}")]
	[DebuggerTypeProxy(typeof(BlockingCollectionDebugView<T>))]
	public class BlockingCollection<T> : ICollection, IDisposable, IReadOnlyCollection<T> // TypeDefIndex: 8965
	{
		// Fields
		private IProducerConsumerCollection<T> _collection;
		private int _boundedCapacity;
		private SemaphoreSlim _freeNodes;
		private SemaphoreSlim _occupiedNodes;
		private bool _isDisposed;
		private CancellationTokenSource _consumersCancellationTokenSource;
		private CancellationTokenSource _producersCancellationTokenSource;
		private int _currentAdders;
	
		// Properties
		public bool IsAddingCompleted { get; }
		public bool IsCompleted { get; }
		public int Count { get; }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetConsumingEnumerable_d__68 : IEnumerable<T>, IEnumerator<T> // TypeDefIndex: 8966
		{
			// Fields
			private int __1__state;
			private T __2__current;
			private int __l__initialThreadId;
			private CancellationToken cancellationToken;
			public CancellationToken __3__cancellationToken;
			public BlockingCollection<T> __4__this;
			private CancellationTokenSource _linkedTokenSource_5__2;
	
			// Properties
			T IEnumerator<T>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _GetConsumingEnumerable_d__68(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Constructors
		public BlockingCollection();
		public BlockingCollection(int boundedCapacity);
		public BlockingCollection(IProducerConsumerCollection<T> collection, int boundedCapacity);
		public BlockingCollection(IProducerConsumerCollection<T> collection);
	
		// Methods
		private void Initialize(IProducerConsumerCollection<T> collection, int boundedCapacity, int collectionCount);
		public bool TryAdd(T item);
		private bool TryAddWithNoTimeValidation(T item, int millisecondsTimeout, CancellationToken cancellationToken);
		public bool TryTake(out ref T item);
		public bool TryTake(out ref T item, int millisecondsTimeout, CancellationToken cancellationToken);
		private bool TryTakeWithNoTimeValidation(out ref T item, int millisecondsTimeout, CancellationToken cancellationToken, CancellationTokenSource combinedTokenSource);
		private void CancelWaitingConsumers();
		public void Dispose();
		protected virtual void Dispose(bool disposing);
		void ICollection.CopyTo(Array array, int index);
		public IEnumerable<T> GetConsumingEnumerable();
		[IteratorStateMachine(typeof(_GetConsumingEnumerable_d__68))]
		public IEnumerable<T> GetConsumingEnumerable(CancellationToken cancellationToken);
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		private static void ValidateMillisecondsTimeout(int millisecondsTimeout);
		private void CheckDisposed();
	}
}
