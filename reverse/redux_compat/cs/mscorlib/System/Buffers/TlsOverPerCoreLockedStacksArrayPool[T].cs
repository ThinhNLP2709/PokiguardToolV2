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

namespace System.Buffers
{
	internal sealed class TlsOverPerCoreLockedStacksArrayPool<T> : ArrayPool<T> // TypeDefIndex: 3629
	{
		// Fields
		private readonly int[] _bucketArraySizes;
		private readonly PerCoreLockedStacks[] _buckets;
		[ThreadStatic]
		private static T[][] t_tlsBuckets;
		private int _callbackCreated;
		private static readonly bool s_trimBuffers;
		private static readonly ConditionalWeakTable<T[][], object> s_allTlsBuckets;
	
		// Properties
		private int Id { get; }
	
		// Nested types
		private enum MemoryPressure // TypeDefIndex: 3630
		{
			Low = 0,
			Medium = 1,
			High = 2
		}
	
		private sealed class PerCoreLockedStacks // TypeDefIndex: 3631
		{
			// Fields
			private readonly LockedStack<T>[] _perCoreStacks;
	
			// Constructors
			public PerCoreLockedStacks();
	
			// Methods
			public void TryPush(T[] array);
			public T[] TryPop();
			public bool Trim(uint tickCount, int id, MemoryPressure<T> pressure, int[] bucketSizes);
		}
	
		private sealed class LockedStack // TypeDefIndex: 3632
		{
			// Fields
			private readonly T[][] _arrays;
			private int _count;
			private uint _firstStackItemMS;
	
			// Constructors
			public LockedStack();
	
			// Methods
			public bool TryPush(T[] array);
			public T[] TryPop();
			public void Trim(uint tickCount, int id, MemoryPressure<T> pressure, int bucketSize);
		}
	
		// Constructors
		public TlsOverPerCoreLockedStacksArrayPool();
		static TlsOverPerCoreLockedStacksArrayPool();
	
		// Methods
		private PerCoreLockedStacks CreatePerCoreLockedStacks(int bucketIndex);
		public override T[] Rent(int minimumLength);
		public override void Return(T[] array, bool clearArray = false /* Metadata: 0x0064F096 */);
		public bool Trim();
		private static bool Gen2GcCallbackFunc(object target);
		private static MemoryPressure GetMemoryPressure();
		private static bool GetTrimBuffers();
	}
}
