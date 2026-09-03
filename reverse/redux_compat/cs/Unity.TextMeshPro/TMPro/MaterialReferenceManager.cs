/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public class MaterialReferenceManager // TypeDefIndex: 11780
	{
		// Fields
		private static MaterialReferenceManager s_Instance; // 0x00
		private Dictionary<int, Material> m_FontMaterialReferenceLookup; // 0x10
		private Dictionary<int, TMP_FontAsset> m_FontAssetReferenceLookup; // 0x18
		private Dictionary<int, TMP_SpriteAsset> m_SpriteAssetReferenceLookup; // 0x20
		private Dictionary<int, TMP_ColorGradient> m_ColorGradientReferenceLookup; // 0x28
	
		// Properties
		public static MaterialReferenceManager instance { get; } // 0x000000018206E810-0x000000018206E9E0 
	
		// Constructors
		public MaterialReferenceManager(); // 0x000000018206E6C0-0x000000018206E810
	
		// Methods
		public static void AddFontAsset(TMP_FontAsset fontAsset); // 0x000000018206DBF0-0x000000018206DC20
		private void AddFontAssetInternal(TMP_FontAsset fontAsset); // 0x000000018206DA10-0x000000018206DBF0
		public static void AddSpriteAsset(TMP_SpriteAsset spriteAsset); // 0x000000018206DF10-0x000000018206E060
		private void AddSpriteAssetInternal(TMP_SpriteAsset spriteAsset); // 0x000000018206DD00-0x000000018206DE40
		public static void AddSpriteAsset(int hashCode, TMP_SpriteAsset spriteAsset); // 0x000000018206E060-0x000000018206E140
		private void AddSpriteAssetInternal(int hashCode, TMP_SpriteAsset spriteAsset); // 0x000000018206DE40-0x000000018206DF10
		public static void AddFontMaterial(int hashCode, Material material); // 0x000000018206DC90-0x000000018206DD00
		private void AddFontMaterialInternal(int hashCode, Material material); // 0x000000018206DC20-0x000000018206DC90
		public static void AddColorGradientPreset(int hashCode, TMP_ColorGradient colorGradient); // 0x000000018206D970-0x000000018206DA10
		private void AddColorGradientPreset_Internal(int hashCode, TMP_ColorGradient colorGradient); // 0x000000018206D8E0-0x000000018206D970
		public bool Contains(TMP_FontAsset font); // 0x000000018206E140-0x000000018206E200
		public bool Contains(TMP_SpriteAsset sprite); // 0x000000018206E200-0x000000018206E2C0
		public static bool TryGetFontAsset(int hashCode, out TMP_FontAsset fontAsset); // 0x000000018206E440-0x000000018206E4C0
		private bool TryGetFontAssetInternal(int hashCode, out TMP_FontAsset fontAsset); // 0x000000018206E3C0-0x000000018206E440
		public static bool TryGetSpriteAsset(int hashCode, out TMP_SpriteAsset spriteAsset); // 0x000000018206E640-0x000000018206E6C0
		private bool TryGetSpriteAssetInternal(int hashCode, out TMP_SpriteAsset spriteAsset); // 0x000000018206E5C0-0x000000018206E640
		public static bool TryGetColorGradientPreset(int hashCode, out TMP_ColorGradient gradientPreset); // 0x000000018206E340-0x000000018206E3C0
		private bool TryGetColorGradientPresetInternal(int hashCode, out TMP_ColorGradient gradientPreset); // 0x000000018206E2C0-0x000000018206E340
		public static bool TryGetMaterial(int hashCode, out Material material); // 0x000000018206E540-0x000000018206E5C0
		private bool TryGetMaterialInternal(int hashCode, out Material material); // 0x000000018206E4C0-0x000000018206E540
	}
}
