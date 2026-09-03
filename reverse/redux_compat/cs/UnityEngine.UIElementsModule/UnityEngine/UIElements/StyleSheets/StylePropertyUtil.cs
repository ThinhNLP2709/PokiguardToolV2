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

namespace UnityEngine.UIElements.StyleSheets
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal static class StylePropertyUtil // TypeDefIndex: 5225
	{
		// Fields
		internal static readonly Dictionary<string, StylePropertyId> s_NameToId; // 0x00
		internal static readonly Dictionary<StylePropertyId, string> s_IdToName; // 0x08
		internal static readonly Dictionary<string, string> s_UssNameToCSharpName; // 0x10
		internal static readonly Dictionary<string, string> s_CSharpNameToUssName; // 0x18
		internal static readonly HashSet<StylePropertyId> s_AnimatableProperties; // 0x20
		internal static readonly Dictionary<StylePropertyId, UsageHints> s_AnimatableWithUsageHintProperties; // 0x28
		internal static readonly VersionChangeType[] s_PropertyToChangeType; // 0x30
	
		// Properties
		internal static Dictionary<string, StylePropertyId> propertyNameToStylePropertyId { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x00000001824638A0-0x00000001824638F0 
		internal static Dictionary<StylePropertyId, string> stylePropertyIdToPropertyName { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x00000001824638F0-0x0000000182463940 
	
		// Constructors
		static StylePropertyUtil(); // 0x000000018245FC90-0x00000001824638A0
	
		// Methods
		public static bool TryGetEnumIntValue(StyleEnumType enumType, string value, out int intValue); // 0x000000018245E8E0-0x000000018245FC90
		public static bool IsMatchingShorthand(StylePropertyId shorthand, StylePropertyId id); // 0x000000018245E7C0-0x000000018245E8E0
		public static bool IsAnimatable(StylePropertyId id); // 0x000000018245E740-0x000000018245E7C0
	}
}
