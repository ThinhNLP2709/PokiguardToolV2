/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public static class TMPro_EventManager // TypeDefIndex: 11925
	{
		// Fields
		public static readonly FastAction<object, Compute_DT_EventArgs> COMPUTE_DT_EVENT; // 0x00
		public static readonly FastAction<bool, Material> MATERIAL_PROPERTY_EVENT; // 0x08
		public static readonly FastAction<bool, UnityEngine.Object> FONT_PROPERTY_EVENT; // 0x10
		public static readonly FastAction<bool, UnityEngine.Object> SPRITE_ASSET_PROPERTY_EVENT; // 0x18
		public static readonly FastAction<bool, UnityEngine.Object> TEXTMESHPRO_PROPERTY_EVENT; // 0x20
		public static readonly FastAction<GameObject, Material, Material> DRAG_AND_DROP_MATERIAL_EVENT; // 0x28
		public static readonly FastAction<bool> TEXT_STYLE_PROPERTY_EVENT; // 0x30
		public static readonly FastAction<UnityEngine.Object> COLOR_GRADIENT_PROPERTY_EVENT; // 0x38
		public static readonly FastAction TMP_SETTINGS_PROPERTY_EVENT; // 0x40
		public static readonly FastAction RESOURCE_LOAD_EVENT; // 0x48
		public static readonly FastAction<bool, UnityEngine.Object> TEXTMESHPRO_UGUI_PROPERTY_EVENT; // 0x50
		public static readonly FastAction<UnityEngine.Object> TEXT_CHANGED_EVENT; // 0x58
	
		// Constructors
		static TMPro_EventManager(); // 0x00000001820F3E40-0x00000001820F4270
	
		// Methods
		public static void ON_MATERIAL_PROPERTY_CHANGED(bool isChanged, Material mat); // 0x00000001820F3AA0-0x00000001820F3B20
		public static void ON_FONT_PROPERTY_CHANGED(bool isChanged, UnityEngine.Object obj); // 0x00000001820F3A20-0x00000001820F3AA0
		public static void ON_SPRITE_ASSET_PROPERTY_CHANGED(bool isChanged, UnityEngine.Object obj); // 0x00000001820F3B80-0x00000001820F3C00
		public static void ON_TEXTMESHPRO_PROPERTY_CHANGED(bool isChanged, UnityEngine.Object obj); // 0x00000001820F3C00-0x00000001820F3C80
		public static void ON_DRAG_AND_DROP_MATERIAL_CHANGED(GameObject sender, Material currentMaterial, Material newMaterial); // 0x00000001820F3990-0x00000001820F3A20
		public static void ON_TEXT_STYLE_PROPERTY_CHANGED(bool isChanged); // 0x00000001820F3D70-0x00000001820F3DE0
		public static void ON_COLOR_GRADIENT_PROPERTY_CHANGED(UnityEngine.Object obj); // 0x00000001820F38A0-0x00000001820F3910
		public static void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x00000001820F3D00-0x00000001820F3D70
		public static void ON_TMP_SETTINGS_CHANGED(); // 0x00000001820F3DE0-0x00000001820F3E40
		public static void ON_RESOURCES_LOADED(); // 0x00000001820F3B20-0x00000001820F3B80
		public static void ON_TEXTMESHPRO_UGUI_PROPERTY_CHANGED(bool isChanged, UnityEngine.Object obj); // 0x00000001820F3C80-0x00000001820F3D00
		public static void ON_COMPUTE_DT_EVENT(object Sender, Compute_DT_EventArgs e); // 0x00000001820F3910-0x00000001820F3990
	}
}
