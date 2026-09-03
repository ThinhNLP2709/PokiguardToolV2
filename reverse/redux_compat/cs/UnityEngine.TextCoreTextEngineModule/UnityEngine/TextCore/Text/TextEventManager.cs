/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	public static class TextEventManager // TypeDefIndex: 12680
	{
		// Fields
		public static readonly FastAction<bool, Material> MATERIAL_PROPERTY_EVENT; // 0x00
		public static readonly FastAction<bool, UnityEngine.Object> FONT_PROPERTY_EVENT; // 0x08
		public static readonly FastAction<bool, UnityEngine.Object> SPRITE_ASSET_PROPERTY_EVENT; // 0x10
		public static readonly FastAction<bool, UnityEngine.Object> TEXTMESHPRO_PROPERTY_EVENT; // 0x18
		public static readonly FastAction<GameObject, Material, Material> DRAG_AND_DROP_MATERIAL_EVENT; // 0x20
		public static readonly FastAction<bool> TEXT_STYLE_PROPERTY_EVENT; // 0x28
		public static readonly FastAction<UnityEngine.Object> COLOR_GRADIENT_PROPERTY_EVENT; // 0x30
		public static readonly FastAction TMP_SETTINGS_PROPERTY_EVENT; // 0x38
		public static readonly FastAction RESOURCE_LOAD_EVENT; // 0x40
		public static readonly FastAction<bool, UnityEngine.Object> TEXTMESHPRO_UGUI_PROPERTY_EVENT; // 0x48
		public static readonly FastAction OnPreRenderObject_Event; // 0x50
		public static readonly FastAction<UnityEngine.Object> TEXT_CHANGED_EVENT; // 0x58
	
		// Constructors
		static TextEventManager(); // 0x0000000182338CB0-0x00000001823390D0
	
		// Methods
		public static void ON_FONT_PROPERTY_CHANGED(bool isChanged, UnityEngine.Object font); // 0x0000000182338C30-0x0000000182338CB0
	}
}
