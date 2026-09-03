/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 41: UnityEngine.UIModule.dll - Assembly: UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15192-15207

namespace UnityEngine
{
	[NativeClass("UI::CanvasGroup", PersistentTypeId = 225)]
	[NativeHeader("Modules/UI/CanvasGroup.h")]
	[UIModuleHelpURL("class-CanvasGroup")]
	public sealed class CanvasGroup : Behaviour, ICanvasRaycastFilter // TypeDefIndex: 15197
	{
		// Properties
		[NativeProperty("Alpha", false, TargetType.Function)]
		public float alpha { get; set; } // 0x0000000182577EA0-0x0000000182577F00 0x00000001825780D0-0x0000000182578140
		[NativeProperty("Interactable", false, TargetType.Function)]
		public bool interactable { get; set; } // 0x0000000182578020-0x0000000182578080 0x00000001825782F0-0x0000000182578350
		[NativeProperty("BlocksRaycasts", false, TargetType.Function)]
		public bool blocksRaycasts { get; set; } // 0x0000000182577E00-0x0000000182577E60 0x0000000182578190-0x00000001825781F0
		[NativeProperty("IgnoreParentGroups", false, TargetType.Function)]
		public bool ignoreParentGroups { get; set; } // 0x0000000182577F80-0x0000000182577FE0 0x0000000182578240-0x00000001825782A0
	
		// Constructors
		public CanvasGroup(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera); // 0x0000000182577E00-0x0000000182577E60
		private static float get_alpha_Injected(IntPtr _unity_self); // 0x0000000182577E60-0x0000000182577EA0
		private static void set_alpha_Injected(IntPtr _unity_self, float value); // 0x0000000182578080-0x00000001825780D0
		private static bool get_interactable_Injected(IntPtr _unity_self); // 0x0000000182577FE0-0x0000000182578020
		private static void set_interactable_Injected(IntPtr _unity_self, bool value); // 0x00000001825782A0-0x00000001825782F0
		private static bool get_blocksRaycasts_Injected(IntPtr _unity_self); // 0x0000000182577F00-0x0000000182577F40
		private static void set_blocksRaycasts_Injected(IntPtr _unity_self, bool value); // 0x0000000182578140-0x0000000182578190
		private static bool get_ignoreParentGroups_Injected(IntPtr _unity_self); // 0x0000000182577F40-0x0000000182577F80
		private static void set_ignoreParentGroups_Injected(IntPtr _unity_self, bool value); // 0x00000001825781F0-0x0000000182578240
	}
}
