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
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal static class StyleCache // TypeDefIndex: 4973
	{
		// Fields
		private static Dictionary<long, ComputedStyle> s_ComputedStyleCache; // 0x00
		private static Dictionary<int, StyleVariableContext> s_StyleVariableContextCache; // 0x08
		private static Dictionary<int, ComputedTransitionProperty[]> s_ComputedTransitionsCache; // 0x10
	
		// Constructors
		static StyleCache(); // 0x00000001823F9A60-0x00000001823F9C20
	
		// Methods
		public static bool TryGetValue(long hash, out ComputedStyle data); // 0x00000001823F99D0-0x00000001823F9A60
		public static void SetValue(long hash, ref ComputedStyle data); // 0x00000001823F9650-0x00000001823F9790
		public static bool TryGetValue(int hash, out StyleVariableContext data); // 0x00000001823F98B0-0x00000001823F9940
		public static void SetValue(int hash, StyleVariableContext data); // 0x00000001823F9790-0x00000001823F9820
		public static bool TryGetValue(int hash, out ComputedTransitionProperty[] data); // 0x00000001823F9940-0x00000001823F99D0
		public static void SetValue(int hash, ComputedTransitionProperty[] data); // 0x00000001823F9820-0x00000001823F98B0
		public static void ClearStyleCache(); // 0x00000001823F9420-0x00000001823F9650
	}
}
