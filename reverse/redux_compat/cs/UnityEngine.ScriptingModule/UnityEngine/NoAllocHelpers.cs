/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 49: UnityEngine.ScriptingModule.dll - Assembly: UnityEngine.ScriptingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15445-15504

namespace UnityEngine
{
	[VisibleToOtherModules]
	internal static class NoAllocHelpers // TypeDefIndex: 15464
	{
		// Nested types
		private class ListPrivateFieldAccess<T> // TypeDefIndex: 15465
		{
			// Fields
			internal T[] _items;
			internal int _size;
			internal int _version;
		}
	
		// Methods
		public static void EnsureListElemCount<T>(List<T> list, int count);
		public static int SafeLength(Array values); // 0x000000018080AEF0-0x000000018080AF00
		public static int SafeLength<T>(List<T> values);
		public static T[] ExtractArrayFromList<T>(List<T> list);
		public static Span<T> CreateSpan<T>(List<T> list);
		public static ReadOnlySpan<T> CreateReadOnlySpan<T>(List<T> list);
		public static void ResetListSize<T>(List<T> list, int size);
		public static void InvalidateListEnumerators<T>(List<T> list);
	}
}
