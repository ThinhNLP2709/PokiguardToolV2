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

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Collections
{
	[VisibleToOtherModules]
	internal static class CollectionExtensions // TypeDefIndex: 7411
	{
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void AddToArray<T>(ref ref T[] array, T item);
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void InsertIntoArray<T>(ref ref T[] array, int index, T item);
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEditor.UIBuilderModule" })]
		internal static void RemoveFromArray<T>(ref ref T[] array, int index);
	
		// Extension methods
		internal static string SerializedView<T>([DisallowNull] this IEnumerable<T> collection, [DisallowNull] Func<T, string> serializeElement);
	}
}
