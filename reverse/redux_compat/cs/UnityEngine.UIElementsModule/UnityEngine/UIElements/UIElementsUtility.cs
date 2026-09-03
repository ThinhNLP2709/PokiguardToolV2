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
	[VisibleToOtherModules(new string[3] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule", "UnityEditor.GraphToolkitModule" })]
	internal static class UIElementsUtility // TypeDefIndex: 4873
	{
		// Fields
		private static Dictionary<EntityId, Panel> s_UIElementsCache; // 0x00
		internal static Color editorPlayModeTintColor; // 0x08
		internal static float singleLineHeight; // 0x18
		internal static readonly UniqueStyleString hiddenClassNameUnique; // 0x1C
		internal static bool s_EnableOSXContextualMenuEventsOnNonOSXPlatforms; // 0x20
		internal static List<Panel> s_PanelsIterationList; // 0x28
		internal static char[] s_Modifiers; // 0x30
		internal static readonly HashSet<StyleSheet> s_StyleSheetsRequiringRebuilding; // 0x38
		internal static readonly HashSet<string> s_ReimportedStyleSheetsPath; // 0x40
		internal static readonly List<StyleSheet> s_StyleSheetsRebuildList; // 0x48
		internal static readonly List<string> s_ReimportedStyleSheetsPathList; // 0x50
		internal static bool s_StopRecordingStyleSheetUnloads; // 0x58
	
		// Properties
		[VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })]
		public static bool isOSXContextualMenuPlatform { get; } // 0x00000001823DCFA0-0x00000001823DD030 
	
		// Constructors
		static UIElementsUtility(); // 0x00000001823DCC40-0x00000001823DCFA0
	
		// Methods
		public static void RegisterCachedPanel(EntityId entityId, Panel panel); // 0x00000001823DCAA0-0x00000001823DCB30
		public static void RemoveCachedPanel(EntityId entityId); // 0x00000001823DCB30-0x00000001823DCBB0
		public static bool TryGetPanel(EntityId entityId, out Panel panel); // 0x00000001823DCBB0-0x00000001823DCC40
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static void GetAllPanels(List<Panel> panels, ContextType contextType); // 0x00000001823DC3C0-0x00000001823DC520
		internal static Dictionary<EntityId, Panel> GetPanelsIterator(); // 0x00000001823DC520-0x00000001823DC5B0
		internal static float PixelsPerUnitScaleForElement(VisualElement ve, Sprite sprite); // 0x00000001823DC760-0x00000001823DC830
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static void MarkStyleSheetAsChanged(StyleSheet styleSheet); // 0x00000001823DC5B0-0x00000001823DC6B0
		internal static void MarkStyleSheetAsLoaded(StyleSheet styleSheet); // 0x00000001802E76C0-0x00000001802E76D0
		internal static void MarkStyleSheetAsUnloaded(StyleSheet styleSheet); // 0x00000001823DC6B0-0x00000001823DC760
		internal static void RebuildDirtyStyleSheets(); // 0x00000001823DC830-0x00000001823DCAA0
	}
}
