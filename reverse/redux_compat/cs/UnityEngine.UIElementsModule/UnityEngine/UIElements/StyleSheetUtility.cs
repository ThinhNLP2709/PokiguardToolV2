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
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal static class StyleSheetUtility // TypeDefIndex: 4806
	{
		// Fields
		private static readonly Dictionary<string, string> SpecialEnumToStringCases; // 0x00
		private static readonly Dictionary<string, string> SpecialStringToEnumCases; // 0x08
	
		// Constructors
		static StyleSheetUtility(); // 0x00000001823B9C00-0x00000001823B9DC0
	
		// Methods
		public static StyleSheet CreateInstanceWithHideFlags(); // 0x00000001823B8B10-0x00000001823B8B70
		public static void TransferStylePropertyHandles(StyleSheet fromStyleSheet, StyleProperty fromStyleProperty, StyleSheet toStyleSheet, StyleProperty toStyleProperty); // 0x00000001823B9570-0x00000001823B9C00
		public static string GetEnumExportString(Enum value); // 0x00000001823B8D30-0x00000001823B8E80
		public static string ConvertCamelToDash(string camel); // 0x00000001823B86A0-0x00000001823B87A0
		public static string ConvertDashToHungarian(string dash); // 0x00000001823B87A0-0x00000001823B87F0
		public static string ConvertDashToUpperNoSpace(string dash, bool firstCase, bool addSpace); // 0x00000001823B87F0-0x00000001823B8B10
		public static string GetDimensionUnitExportString(Dimension.Unit unit); // 0x00000001823B8B70-0x00000001823B8D30
	
		// Extension methods
		public static Dimension ToDimension(this Length length); // 0x00000001823B91C0-0x00000001823B9380
		public static Dimension.Unit ToDimensionUnit(this LengthUnit unit); // 0x00000001823B9000-0x00000001823B90B0
		public static Dimension ToDimension(this Angle angle); // 0x00000001823B9380-0x00000001823B9570
		public static Dimension.Unit ToDimensionUnit(this AngleUnit unit); // 0x00000001823B8F30-0x00000001823B9000
		public static Dimension ToDimension(this TimeValue timeValue); // 0x00000001823B90B0-0x00000001823B91C0
		public static Dimension.Unit ToDimensionUnit(this TimeUnit unit); // 0x00000001823B8E80-0x00000001823B8F30
	}
}
