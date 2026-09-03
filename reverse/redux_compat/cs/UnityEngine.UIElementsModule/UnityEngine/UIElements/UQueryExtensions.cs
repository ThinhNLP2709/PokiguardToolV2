/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public static class UQueryExtensions // TypeDefIndex: 4887
	{
		// Fields
		private static UQueryState<VisualElement> SingleElementEmptyQuery; // 0x00
		private static UQueryState<VisualElement> SingleElementNameQuery; // 0x10
		private static UQueryState<VisualElement> SingleElementClassQuery; // 0x20
		private static UQueryState<VisualElement> SingleElementNameAndClassQuery; // 0x30
		private static UQueryState<VisualElement> SingleElementTypeQuery; // 0x40
		private static UQueryState<VisualElement> SingleElementTypeAndNameQuery; // 0x50
		private static UQueryState<VisualElement> SingleElementTypeAndClassQuery; // 0x60
		private static UQueryState<VisualElement> SingleElementTypeAndNameAndClassQuery; // 0x70
	
		// Constructors
		static UQueryExtensions(); // 0x00000001823DF810-0x00000001823DFF40
	
		// Extension methods
		public static VisualElement Q(this VisualElement e, string name = null, params string[] classes); // 0x00000001823DF6E0-0x00000001823DF810
		public static UQueryBuilder<T> Query<T>(this VisualElement e, string name = null, params string[] classes)
			where T : VisualElement;
	}
}
