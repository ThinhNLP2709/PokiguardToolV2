/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal static class Utils // TypeDefIndex: 14298
	{
		// Methods
		public static void Destroy(UnityEngine.Object obj); // 0x0000000182124DB0-0x0000000182124E10
		[Conditional("UNITY_ASSERTIONS")]
		public static void CheckArgIsNotNull(object obj, string argName); // 0x0000000182124CF0-0x0000000182124D50
		[Conditional("UNITY_ASSERTIONS")]
		public static void CheckArg(bool condition, string message); // 0x0000000182124D50-0x0000000182124DB0
		[Conditional("UNITY_ASSERTIONS")]
		public static void CheckArgRange<T>(T value, T minIncluded, T maxExcluded, string argName)
			where T : IComparable;
	}
}
