/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Unmanaged
{
	internal static class UnmanagedRefCountedListExtensions // TypeDefIndex: 4998
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4999
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<StylePropertyName, StylePropertyId> __9__6_0; // 0x08
			public static Func<StylePropertyId, StylePropertyName> __9__8_0; // 0x10
			public static Func<FilterFunction, UnmanagedFilterFunction> __9__11_0; // 0x18
			public static Func<UnmanagedFilterFunction, FilterFunction> __9__12_0; // 0x20
			public static Func<UnmanagedFilterFunction, FilterFunction> __9__13_0; // 0x28
			public static Func<MaterialPropertyValue, UnmanagedMaterialPropertyValue> __9__14_0; // 0x30
	
			// Constructors
			static __c(); // 0x00000001823FA280-0x00000001823FA2F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal StylePropertyId _CopyFrom_b__6_0(StylePropertyName name); // 0x0000000180E6B260-0x0000000180E6B270
			internal StylePropertyName _ToManaged_b__8_0(StylePropertyId id); // 0x00000001823FA250-0x00000001823FA280
			internal UnmanagedFilterFunction _CopyFrom_b__11_0(FilterFunction f); // 0x00000001823FA090-0x00000001823FA140
			internal FilterFunction _CopyTo_b__12_0(UnmanagedFilterFunction f); // 0x00000001823FA1A0-0x00000001823FA250
			internal FilterFunction _ToManaged_b__13_0(UnmanagedFilterFunction f); // 0x00000001823FA1A0-0x00000001823FA250
			internal UnmanagedMaterialPropertyValue _CopyFrom_b__14_0(MaterialPropertyValue mpv); // 0x00000001823FA140-0x00000001823FA1A0
		}
	
		// Extension methods
		private static void PrepareWrite<T>(this ref UnmanagedRefCountedList<T> self, int count)
			where T : struct;
		public static void Clear<T>(this ref UnmanagedRefCountedList<T> self)
			where T : struct;
		public static void CopyFrom<T>(this ref UnmanagedRefCountedList<T> self, UnmanagedRefCountedList<T> other)
			where T : struct;
		public static void CopyFrom<T>(this ref UnmanagedRefCountedList<T> self, List<T> other)
			where T : struct;
		public static void CopyFrom<T, TOther>(this ref UnmanagedRefCountedList<T> self, List<TOther> other, Func<TOther, T> convert)
			where T : struct;
		public static void CopyFrom<T>(this ref UnmanagedRefCountedList<T> self, ReadOnlySpan<T> other)
			where T : struct;
		public static void CopyFrom(this ref UnmanagedRefCountedList<StylePropertyId> self, List<StylePropertyName> other); // 0x0000000182400A60-0x0000000182400B70
		public static List<StylePropertyName> ToManaged(this UnmanagedRefCountedList<StylePropertyId> self); // 0x0000000182400FC0-0x00000001824010D0
		public static void CopyFrom(this ref UnmanagedRefCountedList<UnmanagedFilterFunction> self, List<FilterFunction> other); // 0x0000000182400C80-0x0000000182400D90
		public static void CopyTo(this UnmanagedRefCountedList<UnmanagedFilterFunction> self, ref List<FilterFunction> other); // 0x0000000182400D90-0x0000000182400EB0
		public static List<FilterFunction> ToManaged(this UnmanagedRefCountedList<UnmanagedFilterFunction> self); // 0x0000000182400EB0-0x0000000182400FC0
		public static void CopyFrom(this ref UnmanagedRefCountedList<UnmanagedMaterialPropertyValue> self, List<MaterialPropertyValue> other); // 0x0000000182400B70-0x0000000182400C80
	}
}
