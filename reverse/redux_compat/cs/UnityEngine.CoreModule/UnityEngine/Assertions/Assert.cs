/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Assertions
{
	[DebuggerStepThrough]
	public static class Assert // TypeDefIndex: 8239
	{
		// Fields
		[NoAutoStaticsCleanup]
		[Obsolete("Future versions of Unity are expected to always throw exceptions and not have this field.")]
		public static bool raiseExceptions; // 0x00
	
		// Constructors
		static Assert(); // 0x0000000182229E40-0x0000000182229E80
	
		// Methods
		private static void Fail(string message, string userMessage); // 0x00000001822297B0-0x00000001822298D0
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsTrue(bool condition); // 0x0000000182229DE0-0x0000000182229E40
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsTrue(bool condition, string message); // 0x0000000182229CF0-0x0000000182229DE0
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsFalse(bool condition); // 0x00000001822298D0-0x00000001822299E0
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsFalse(bool condition, string message); // 0x00000001822299E0-0x0000000182229AD0
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual<T>(T expected, T actual);
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual<T>(T expected, T actual, string message);
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual<T>(T expected, T actual, string message, IEqualityComparer<T> comparer);
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(UnityEngine.Object expected, UnityEngine.Object actual, string message); // 0x00000001822295E0-0x0000000182229730
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNull<T>(T value)
			where T : class;
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNull<T>(T value, string message)
			where T : class;
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNull(UnityEngine.Object value, string message); // 0x0000000182229BE0-0x0000000182229CF0
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNotNull<T>(T value)
			where T : class;
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNotNull<T>(T value, string message)
			where T : class;
		[Conditional("UNITY_ASSERTIONS")]
		public static void IsNotNull(UnityEngine.Object value, string message); // 0x0000000182229AD0-0x0000000182229BE0
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(int expected, int actual); // 0x0000000182229570-0x00000001822295E0
		[Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual(int expected, int actual, string message); // 0x0000000182229730-0x00000001822297B0
	}
}
