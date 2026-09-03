/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic.Utils
{
	internal static class CollectionExtensions // TypeDefIndex: 12587
	{
		// Extension methods
		public static TrueReadOnlyCollection<T> AddFirst<T>(this ReadOnlyCollection<T> list, T item);
		public static T[] AddLast<T>(this T[] array, T item);
		public static T[] RemoveFirst<T>(this T[] array);
		public static T[] RemoveLast<T>(this T[] array);
		public static ReadOnlyCollection<T> ToReadOnly<T>(this IEnumerable<T> enumerable);
	}
}
