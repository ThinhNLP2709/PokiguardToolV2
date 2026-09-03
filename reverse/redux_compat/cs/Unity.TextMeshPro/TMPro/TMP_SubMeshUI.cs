/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[ExecuteAlways]
	[RequireComponent(typeof(CanvasRenderer))]
	[TMPHelpURL("index")]
	public class TMP_SubMeshUI : MaskableGraphic // TypeDefIndex: 11884
	{
		// Fields
		[SerializeField]
		private TMP_FontAsset m_fontAsset; // 0xE0
		[SerializeField]
		private TMP_SpriteAsset m_spriteAsset; // 0xE8
		[SerializeField]
		private Material m_material; // 0xF0
		[SerializeField]
		private Material m_sharedMaterial; // 0xF8
		private Material m_fallbackMaterial; // 0x100
		private Material m_fallbackSourceMaterial; // 0x108
		[SerializeField]
		private bool m_isDefaultMaterial; // 0x110
		[SerializeField]
		private float m_padding; // 0x114
		private Mesh m_mesh; // 0x118
		[SerializeField]
		private TextMeshProUGUI m_TextComponent; // 0x120
		[NonSerialized]
		private bool m_isRegisteredForEvents; // 0x128
		private bool m_materialDirty; // 0x129
		[SerializeField]
		private int m_materialReferenceIndex; // 0x12C
		private Transform m_RootCanvasTransform; // 0x130
	
		// Properties
		public TMP_FontAsset fontAsset { get; set; } // 0x00000001806CCB80-0x00000001806CCB90 0x00000001806CCDC0-0x00000001806CCDE0
		public TMP_SpriteAsset spriteAsset { get; set; } // 0x00000001806BAE70-0x00000001806BAE80 0x00000001806C0C20-0x00000001806C0C40
		public override Texture mainTexture { get; } // 0x00000001820CDC60-0x00000001820CDD20 
		public override Material material { get; set; } // 0x00000001820CDD80-0x00000001820CDD90 0x00000001820CE0A0-0x00000001820CE1C0
		public Material sharedMaterial { get; set; } // 0x0000000180CDCEE0-0x0000000180CDCEF0 0x00000001820CD980-0x00000001820CD9E0
		public Material fallbackMaterial { get; set; } // 0x00000001816A28C0-0x00000001816A28D0 0x00000001820CDF10-0x00000001820CE0A0
		public Material fallbackSourceMaterial { get; set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000180CDC990-0x0000000180CDC9B0
		public override Material materialForRendering { get; } // 0x00000001820CDD20-0x00000001820CDD80 
		public bool isDefaultMaterial { get; set; } // 0x0000000181708F20-0x0000000181708F30 0x0000000181709040-0x0000000181709050
		public float padding { get; set; } // 0x00000001820CDE60-0x00000001820CDE70 0x00000001820CE1C0-0x00000001820CE1D0
		public Mesh mesh { get; set; } // 0x00000001820CDD90-0x00000001820CDE60 0x0000000180504EA0-0x0000000180504EC0
		public TMP_Text textComponent { get; } // 0x00000001820CDE70-0x00000001820CDF10 
	
		// Constructors
		public TMP_SubMeshUI(); // 0x00000001820C8E70-0x00000001820C8E80
	
		// Methods
		public static TMP_SubMeshUI AddSubTextObject(TextMeshProUGUI textComponent, MaterialReference materialReference); // 0x00000001820CCC30-0x00000001820CCF40
		protected override void OnEnable(); // 0x00000001820CD790-0x00000001820CD800
		protected override void OnDisable(); // 0x00000001820CD6D0-0x00000001820CD790
		protected override void OnDestroy(); // 0x00000001820CD540-0x00000001820CD6D0
		protected override void OnTransformParentChanged(); // 0x00000001820CD800-0x00000001820CD860
		public override Material GetModifiedMaterial(Material baseMaterial); // 0x00000001820CD1D0-0x00000001820CD330
		public float GetPaddingForMaterial(); // 0x00000001820CD3C0-0x00000001820CD450
		public float GetPaddingForMaterial(Material mat); // 0x00000001820CD330-0x00000001820CD3C0
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold); // 0x00000001820CDBD0-0x00000001820CDC60
		public override void SetAllDirty(); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetVerticesDirty(); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetLayoutDirty(); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetMaterialDirty(); // 0x00000001820CD8B0-0x00000001820CD900
		public void SetPivotDirty(); // 0x00000001820CD900-0x00000001820CD980
		private Transform GetRootCanvasTransform(); // 0x00000001820CD450-0x00000001820CD510
		public override void Cull(Rect clipRect, bool validRect); // 0x00000001802E76C0-0x00000001802E76D0
		protected override void UpdateGeometry(); // 0x00000001802E76C0-0x00000001802E76D0
		public override void Rebuild(CanvasUpdate update); // 0x00000001820CD860-0x00000001820CD8A0
		public void RefreshMaterial(); // 0x00000001815A0090-0x00000001815A00B0
		protected override void UpdateMaterial(); // 0x00000001820CD9E0-0x00000001820CDBD0
		public override void RecalculateClipping(); // 0x00000001820CD8A0-0x00000001820CD8B0
		private Material GetMaterial(); // 0x0000000180CDCEE0-0x0000000180CDCEF0
		private Material GetMaterial(Material mat); // 0x00000001820CD000-0x00000001820CD1D0
		private Material CreateMaterialInstance(Material source); // 0x00000001820CCF40-0x00000001820CD000
		private Material GetSharedMaterial(); // 0x00000001820CD510-0x00000001820CD540
		private void SetSharedMaterial(Material mat); // 0x00000001820CD980-0x00000001820CD9E0
	}
}
