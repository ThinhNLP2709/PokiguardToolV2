/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	public struct NativeKeyValueArrays<TKey, TValue> : INativeDisposable // TypeDefIndex: 11578
		where TKey : struct
		where TValue : struct
	{
		// Fields
		public NativeArray<TKey> Keys;
		public NativeArray<TValue> Values;
	
		// Properties
		public int Length { get; }
	
		// Constructors
		public NativeKeyValueArrays(int length, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options);
	
		// Methods
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
	}
}
