/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[GenerateTestsForBurstCompatibility]
	public static class NativeReferenceUnsafeUtility // TypeDefIndex: 11678
	{
		// Extension methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe T* GetUnsafePtr<T>(this NativeReference<T> reference)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe T* GetUnsafeReadOnlyPtr<T>(this NativeReference<T> reference)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe T* GetUnsafePtrWithoutChecks<T>(this NativeReference<T> reference)
			where T : struct;
	}
}
