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

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
	internal static class MaterialManager // TypeDefIndex: 12648
	{
		// Fields
		private static Dictionary<long, Material> s_FallbackMaterials; // 0x00
	
		// Constructors
		static MaterialManager(); // 0x0000000182304AC0-0x0000000182304B50
	
		// Methods
		public static Material GetFallbackMaterial(Material sourceMaterial, Material targetMaterial); // 0x0000000182304140-0x00000001823045B0
		public static Material GetFallbackMaterial(FontAsset fontAsset, Material sourceMaterial, int atlasIndex); // 0x00000001823045B0-0x0000000182304AC0
		private static void CopyMaterialPresetProperties(Material source, Material destination); // 0x0000000182303E80-0x0000000182304140
	}
}
