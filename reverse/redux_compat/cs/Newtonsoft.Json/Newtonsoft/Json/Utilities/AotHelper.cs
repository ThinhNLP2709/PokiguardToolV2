/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(2)]
	public static class AotHelper // TypeDefIndex: 10087
	{
		// Fields
		private static bool s_alwaysFalse; // 0x00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__1<T> // TypeDefIndex: 10088
			where T : new()
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__1<T> __9;
			[Nullable(0)]
			public static Action __9__1_0;
	
			// Constructors
			static __c__1();
			public __c__1();
	
			// Methods
			internal void _EnsureType_b__1_0();
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__2<T> // TypeDefIndex: 10089
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__2<T> __9;
			[Nullable(0)]
			public static Action __9__2_0;
	
			// Constructors
			static __c__2();
			public __c__2();
	
			// Methods
			internal void _EnsureList_b__2_0();
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__3<TKey, TValue> // TypeDefIndex: 10090
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__3<TKey, TValue> __9;
			[Nullable(0)]
			public static Action __9__3_0;
	
			// Constructors
			static __c__3();
			public __c__3();
	
			// Methods
			internal void _EnsureDictionary_b__3_0();
		}
	
		// Constructors
		static AotHelper(); // 0x00000001816E1950-0x00000001816E19D0
	
		// Methods
		[NullableContext(1)]
		public static void Ensure(Action action); // 0x00000001816E17E0-0x00000001816E1900
		public static void EnsureType<T>()
			where T : new();
		public static void EnsureList<T>();
		public static void EnsureDictionary<TKey, TValue>();
		public static bool IsFalse(); // 0x00000001816E1900-0x00000001816E1950
	}
}
