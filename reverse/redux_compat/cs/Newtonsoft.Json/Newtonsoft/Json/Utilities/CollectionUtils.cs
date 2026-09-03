/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
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
	[NullableContext(1)]
	internal static class CollectionUtils // TypeDefIndex: 10098
	{
		// Nested types
		[NullableContext(0)]
		private static class EmptyArrayContainer<T> // TypeDefIndex: 10099
		{
			// Fields
			[Nullable(1)]
			public static readonly T[] Empty;
	
			// Constructors
			static EmptyArrayContainer();
		}
	
		// Methods
		public static bool IsNullOrEmpty<T>(ICollection<T> collection);
		public static bool IsDictionaryType(Type type); // 0x00000001816E5090-0x00000001816E51A0
		public static ConstructorInfo ResolveEnumerableCollectionConstructor(Type collectionType, Type collectionItemType); // 0x00000001816E52A0-0x00000001816E53B0
		public static ConstructorInfo ResolveEnumerableCollectionConstructor(Type collectionType, Type collectionItemType, Type constructorArgumentType); // 0x00000001816E53B0-0x00000001816E5650
		private static IList<int> GetDimensions(IList values, int dimensionsCount); // 0x00000001816E4CF0-0x00000001816E5090
		private static void CopyFromJaggedToMultidimensionalArray(IList values, Array multidimensionalArray, int[] indices); // 0x00000001816E4AB0-0x00000001816E4CF0
		private static object JaggedArrayGetValue(IList values, int[] indices); // 0x00000001816E51A0-0x00000001816E52A0
		public static Array ToMultidimensionalArray(IList values, Type type, int rank); // 0x00000001816E5650-0x00000001816E5860
		public static T[] ArrayEmpty<T>();
	
		// Extension methods
		public static void AddRange<T>(this IList<T> initial, IEnumerable<T> collection);
		public static bool AddDistinct<T>(this IList<T> list, T value);
		public static bool AddDistinct<T>(this IList<T> list, T value, IEqualityComparer<T> comparer);
		public static bool ContainsValue<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer);
		public static bool AddRangeDistinct<T>(this IList<T> list, IEnumerable<T> values, IEqualityComparer<T> comparer);
		public static int IndexOf<T>(this IEnumerable<T> collection, Func<T, bool> predicate);
		public static bool Contains<T>(this List<T> list, T value, IEqualityComparer comparer);
		public static int IndexOfReference<T>(this List<T> list, T item);
		public static void FastReverse<T>(this List<T> list);
	}
}
