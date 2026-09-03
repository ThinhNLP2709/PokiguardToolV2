/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	public static class ReadOnlyArrayExtensions // TypeDefIndex: 6634
	{
		// Extension methods
		public static bool Contains<TValue>(this ReadOnlyArray<TValue> array, TValue value)
			where TValue : IComparable<TValue>;
		public static bool ContainsReference<TValue>(this ReadOnlyArray<TValue> array, TValue value)
			where TValue : class;
		public static int IndexOfReference<TValue>(this ReadOnlyArray<TValue> array, TValue value)
			where TValue : class;
		internal static bool HaveEqualReferences<TValue>(this ReadOnlyArray<TValue> array1, IReadOnlyList<TValue> array2, int count = 2147483647 /* Metadata: 0x006991B9 */);
	}
}
