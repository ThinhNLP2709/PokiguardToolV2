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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Concurrent
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(IProducerConsumerCollectionDebugView<T>))]
	public class ConcurrentQueue<T> : IProducerConsumerCollection<T>, IReadOnlyCollection<T> // TypeDefIndex: 3537
	{
		// Fields
		private object _crossSegmentLock;
		private Segment _tail;
		private Segment _head;
	
		// Properties
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		public bool IsEmpty { get; }
		public int Count { get; }
	
		// Nested types
		[DebuggerDisplay("Capacity = {Capacity}")]
		internal sealed class Segment // TypeDefIndex: 3538
		{
			// Fields
			internal readonly Slot[] _slots;
			internal readonly int _slotsMask;
			internal PaddedHeadAndTail _headAndTail;
			internal bool _preservedForObservation;
			internal bool _frozenForEnqueues;
			internal Segment<T> _nextSegment;
	
			// Properties
			internal int Capacity { get; }
			internal int FreezeOffset { get; }
	
			// Nested types
			[DebuggerDisplay("Item = {Item}, SequenceNumber = {SequenceNumber}")]
			internal struct Slot // TypeDefIndex: 3539
			{
				// Fields
				public T Item;
				public int SequenceNumber;
			}
	
			// Constructors
			public Segment(int boundedLength);
	
			// Methods
			internal void EnsureFrozenForEnqueues();
			public bool TryDequeue(out ref T item);
			public bool TryPeek(out ref T result, bool resultUsed);
			public bool TryEnqueue(T item);
		}
	
		[CompilerGenerated]
		private sealed class _Enumerate_d__28 : IEnumerator<T> // TypeDefIndex: 3540
		{
			// Fields
			private int __1__state;
			private T __2__current;
			public Segment<T> head;
			public Segment<T> tail;
			public int tailTail;
			public int headHead;
			public ConcurrentQueue<T> __4__this;
			private int _headTail_5__2;
			private int _i_5__3;
			private Segment<T> _s_5__4;
			private int _i_5__5;
	
			// Properties
			T IEnumerator<T>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _Enumerate_d__28(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			[DebuggerHidden]
			void IEnumerator.Reset();
		}
	
		// Constructors
		public ConcurrentQueue();
	
		// Methods
		void ICollection.CopyTo(Array array, int index);
		IEnumerator IEnumerable.GetEnumerator();
		bool IProducerConsumerCollection<T>.TryAdd(T item);
		bool IProducerConsumerCollection<T>.TryTake(out ref T item);
		public T[] ToArray();
		private static int GetCount(Segment s, int head, int tail);
		private static long GetCount(Segment head, int headHead, Segment tail, int tailTail);
		public void CopyTo(T[] array, int index);
		public IEnumerator<T> GetEnumerator();
		private void SnapForObservation(out Segment head, out int headHead, out Segment tail, out int tailTail);
		private T GetItemWhenAvailable(Segment segment, int i);
		[IteratorStateMachine(typeof(_Enumerate_d__28))]
		private IEnumerator<T> Enumerate(Segment head, int headHead, Segment tail, int tailTail);
		public void Enqueue(T item);
		private void EnqueueSlow(T item);
		public bool TryDequeue(out ref T result);
		private bool TryDequeueSlow(out ref T item);
		private bool TryPeek(out ref T result, bool resultUsed);
	}
}
