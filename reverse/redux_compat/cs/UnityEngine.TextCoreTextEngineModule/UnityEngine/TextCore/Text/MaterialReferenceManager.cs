/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	internal class MaterialReferenceManager // TypeDefIndex: 12650
	{
		// Fields
		private static MaterialReferenceManager s_Instance; // 0x00
		private Dictionary<int, Material> m_FontMaterialReferenceLookup; // 0x10
		private Dictionary<int, FontAsset> m_FontAssetReferenceLookup; // 0x18
		private Dictionary<int, SpriteAsset> m_SpriteAssetReferenceLookup; // 0x20
		private Dictionary<int, TextColorGradient> m_ColorGradientReferenceLookup; // 0x28
	
		// Properties
		public static MaterialReferenceManager instance { get; } // 0x0000000182305630-0x0000000182305800 
	
		// Constructors
		public MaterialReferenceManager(); // 0x00000001823054E0-0x0000000182305630
	
		// Methods
		public static void AddFontAsset(FontAsset fontAsset); // 0x0000000182304D60-0x0000000182304E50
		private void AddFontAssetInternal(FontAsset fontAsset); // 0x0000000182304C80-0x0000000182304D60
		public static void AddSpriteAsset(int hashCode, SpriteAsset spriteAsset); // 0x0000000182305000-0x00000001823050E0
		private void AddSpriteAssetInternal(int hashCode, SpriteAsset spriteAsset); // 0x0000000182304F30-0x0000000182305000
		public static void AddFontMaterial(int hashCode, Material material); // 0x0000000182304EC0-0x0000000182304F30
		private void AddFontMaterialInternal(int hashCode, Material material); // 0x0000000182304E50-0x0000000182304EC0
		public static void AddColorGradientPreset(int hashCode, TextColorGradient spriteAsset); // 0x0000000182304BE0-0x0000000182304C80
		private void AddColorGradientPreset_Internal(int hashCode, TextColorGradient spriteAsset); // 0x0000000182304B50-0x0000000182304BE0
		public static bool TryGetFontAsset(int hashCode, out FontAsset fontAsset); // 0x0000000182305260-0x00000001823052E0
		private bool TryGetFontAssetInternal(int hashCode, out FontAsset fontAsset); // 0x00000001823051E0-0x0000000182305260
		public static bool TryGetSpriteAsset(int hashCode, out SpriteAsset spriteAsset); // 0x0000000182305460-0x00000001823054E0
		private bool TryGetSpriteAssetInternal(int hashCode, out SpriteAsset spriteAsset); // 0x00000001823053E0-0x0000000182305460
		public static bool TryGetColorGradientPreset(int hashCode, out TextColorGradient gradientPreset); // 0x0000000182305160-0x00000001823051E0
		private bool TryGetColorGradientPresetInternal(int hashCode, out TextColorGradient gradientPreset); // 0x00000001823050E0-0x0000000182305160
		public static bool TryGetMaterial(int hashCode, out Material material); // 0x0000000182305360-0x00000001823053E0
		private bool TryGetMaterialInternal(int hashCode, out Material material); // 0x00000001823052E0-0x0000000182305360
	}
}
