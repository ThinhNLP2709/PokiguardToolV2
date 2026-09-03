/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	internal struct FixedList // TypeDefIndex: 11495
	{
		// Methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal static int PaddingBytes<T>()
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		internal static int StorageBytes<BUFFER, T>()
			where BUFFER : struct
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		internal static int Capacity<BUFFER, T>()
			where BUFFER : struct
			where T : struct;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		internal static void CheckResize<BUFFER, T>(int newLength)
			where BUFFER : struct
			where T : struct;
	}
}
