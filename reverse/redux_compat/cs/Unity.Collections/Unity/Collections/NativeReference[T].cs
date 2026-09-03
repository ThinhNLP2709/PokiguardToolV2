/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	[NativeContainer]
	public struct NativeReference<T> : INativeDisposable, IEquatable<Unity.Collections.NativeReference<T>> // TypeDefIndex: 11605
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe void* m_Data;
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;
	
		// Properties
		public T Value { get; set; }
		public bool IsCreated { [IsReadOnly] get; }
	
		// Nested types
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly // TypeDefIndex: 11606
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			private readonly unsafe void* m_Data;
	
			// Properties
			public T Value { get; }
	
			// Constructors
			internal unsafe ReadOnly(void* data);
		}
	
		// Constructors
		public unsafe NativeReference(AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1C42 */);
		public unsafe NativeReference(T value, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		private static void Allocate(AllocatorManager.AllocatorHandle allocator, out NativeReference<T> reference);
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		public void CopyFrom(NativeReference<T> reference);
		public void CopyTo(NativeReference<T> reference);
		[ExcludeFromBurstCompatTesting("Equals boxes because Value does not implement IEquatable<T>")]
		public bool Equals(NativeReference<T> other);
		[ExcludeFromBurstCompatTesting("Takes managed object")]
		public override bool Equals(object obj);
		public override int GetHashCode();
		public static bool operator ==(NativeReference<T> left, NativeReference<T> right);
		public static bool operator !=(NativeReference<T> left, NativeReference<T> right);
		public static void Copy(NativeReference<T> dst, NativeReference<T> src);
		public ReadOnly AsReadOnly();
		public static implicit operator ReadOnly(NativeReference<T> nativeReference);
	}
}
