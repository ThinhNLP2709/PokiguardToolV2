/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public static class TMP_MaterialManager // TypeDefIndex: 11854
	{
		// Fields
		private static readonly List<MaskingMaterial> m_materialList; // 0x00
		private static readonly Dictionary<ValueTuple<EntityId, EntityId>, FallbackMaterial> m_fallbackMaterials; // 0x08
		private static readonly Dictionary<EntityId, ValueTuple<EntityId, EntityId>> m_fallbackMaterialLookup; // 0x10
		private static readonly List<FallbackMaterial> m_fallbackCleanupList; // 0x18
		private static bool isFallbackListDirty; // 0x20
	
		// Nested types
		private class FallbackMaterial // TypeDefIndex: 11855
		{
			// Fields
			public ValueTuple<EntityId, EntityId> fallbackID; // 0x10
			public Material sourceMaterial; // 0x20
			internal int sourceMaterialCRC; // 0x28
			public Material fallbackMaterial; // 0x30
			public int count; // 0x38
	
			// Constructors
			public FallbackMaterial(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class MaskingMaterial // TypeDefIndex: 11856
		{
			// Fields
			public Material baseMaterial; // 0x10
			public Material stencilMaterial; // 0x18
			public int count; // 0x20
			public int stencilID; // 0x24
	
			// Constructors
			public MaskingMaterial(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass11_0 // TypeDefIndex: 11857
		{
			// Fields
			public Material stencilMaterial; // 0x10
	
			// Constructors
			public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddMaskingMaterial_b__0(MaskingMaterial item); // 0x00000001820D20A0-0x00000001820D2110
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass12_0 // TypeDefIndex: 11858
		{
			// Fields
			public Material stencilMaterial; // 0x10
	
			// Constructors
			public __c__DisplayClass12_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveStencilMaterial_b__0(MaskingMaterial item); // 0x00000001820D2110-0x00000001820D2180
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass13_0 // TypeDefIndex: 11859
		{
			// Fields
			public Material baseMaterial; // 0x10
	
			// Constructors
			public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _ReleaseBaseMaterial_b__0(MaskingMaterial item); // 0x00000001820D2180-0x00000001820D21F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 11860
		{
			// Fields
			public Material stencilMaterial; // 0x10
	
			// Constructors
			public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _GetBaseMaterial_b__0(MaskingMaterial item); // 0x00000001820D21F0-0x00000001820D2260
		}
	
		// Constructors
		static TMP_MaterialManager(); // 0x00000001820C4BC0-0x00000001820C4DE0
	
		// Methods
		private static void OnPreRender(); // 0x00000001820C3F40-0x00000001820C3FB0
		public static Material GetStencilMaterial(Material baseMaterial, int stencilID); // 0x00000001820C3B60-0x00000001820C3F40
		public static void ReleaseStencilMaterial(Material stencilMaterial); // 0x00000001820C4600-0x00000001820C4850
		public static Material GetBaseMaterial(Material stencilMaterial); // 0x00000001820C2CE0-0x00000001820C2E20
		public static Material SetStencil(Material material, int stencilID); // 0x00000001820C4B00-0x00000001820C4BC0
		public static void AddMaskingMaterial(Material baseMaterial, Material stencilMaterial, int stencilID); // 0x00000001820C2320-0x00000001820C2590
		public static void RemoveStencilMaterial(Material stencilMaterial); // 0x00000001820C49E0-0x00000001820C4B00
		public static void ReleaseBaseMaterial(Material baseMaterial); // 0x00000001820C3FB0-0x00000001820C4460
		public static void ClearMaterials(); // 0x00000001820C2760-0x00000001820C28D0
		public static int GetStencilID(GameObject obj); // 0x00000001820C3800-0x00000001820C3B60
		public static Material GetMaterialForRendering(MaskableGraphic graphic, Material baseMaterial); // 0x00000001820C3620-0x00000001820C3800
		private static Transform FindRootSortOverrideCanvas(Transform start); // 0x00000001820C2B90-0x00000001820C2CE0
		internal static Material GetFallbackMaterial(TMP_FontAsset fontAsset, Material sourceMaterial, int atlasIndex); // 0x00000001820C32D0-0x00000001820C3620
		public static Material GetFallbackMaterial(Material sourceMaterial, Material targetMaterial); // 0x00000001820C2E20-0x00000001820C32D0
		public static void AddFallbackMaterialReference(Material targetMaterial); // 0x00000001820C21E0-0x00000001820C2320
		public static void RemoveFallbackMaterialReference(Material targetMaterial); // 0x00000001820C4850-0x00000001820C49E0
		public static void CleanupFallbackMaterials(); // 0x00000001820C2590-0x00000001820C2760
		public static void ReleaseFallbackMaterial(Material fallbackMaterial); // 0x00000001820C4460-0x00000001820C4600
		public static void CopyMaterialPresetProperties(Material source, Material destination); // 0x00000001820C28D0-0x00000001820C2B90
	}
}
