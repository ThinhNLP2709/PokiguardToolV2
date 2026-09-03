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
	[ExecuteAlways]
	[RequireComponent(typeof(MeshRenderer))]
	[TMPHelpURL("index")]
	public class TMP_SubMesh : MonoBehaviour // TypeDefIndex: 11883
	{
		// Fields
		[SerializeField]
		private TMP_FontAsset m_fontAsset; // 0x20
		[SerializeField]
		private TMP_SpriteAsset m_spriteAsset; // 0x28
		[SerializeField]
		private Material m_material; // 0x30
		[SerializeField]
		private Material m_sharedMaterial; // 0x38
		private Material m_fallbackMaterial; // 0x40
		private Material m_fallbackSourceMaterial; // 0x48
		[SerializeField]
		private bool m_isDefaultMaterial; // 0x50
		[SerializeField]
		private float m_padding; // 0x54
		[SerializeField]
		private Renderer m_renderer; // 0x58
		private MeshFilter m_meshFilter; // 0x60
		private Mesh m_mesh; // 0x68
		[SerializeField]
		private TextMeshPro m_TextComponent; // 0x70
		[NonSerialized]
		private bool m_isRegisteredForEvents; // 0x78
	
		// Properties
		public TMP_FontAsset fontAsset { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public TMP_SpriteAsset spriteAsset { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public Material material { get; set; } // 0x00000001820CEFA0-0x00000001820CEFB0 0x00000001820CF3D0-0x00000001820CF470
		public Material sharedMaterial { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x00000001820CED30-0x00000001820CED70
		public Material fallbackMaterial { get; set; } // 0x0000000180377940-0x0000000180377950 0x00000001820CF290-0x00000001820CF3D0
		public Material fallbackSourceMaterial { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public bool isDefaultMaterial { get; set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
		public float padding { get; set; } // 0x0000000181D8CC70-0x0000000181D8CC80 0x00000001820CF470-0x00000001820CF480
		public Renderer renderer { get; } // 0x00000001820CF170-0x00000001820CF200 
		public MeshFilter meshFilter { get; } // 0x00000001820CEFB0-0x00000001820CF0B0 
		public Mesh mesh { get; set; } // 0x00000001820CF0B0-0x00000001820CF170 0x0000000180316A40-0x0000000180316A50
		public TMP_Text textComponent { get; } // 0x00000001820CF200-0x00000001820CF290 
	
		// Constructors
		public TMP_SubMesh(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public static TMP_SubMesh AddSubTextObject(TextMeshPro textComponent, MaterialReference materialReference); // 0x00000001820CE1D0-0x00000001820CE4A0
		private void OnEnable(); // 0x00000001820CEA90-0x00000001820CED20
		private void OnDisable(); // 0x00000001820CE9D0-0x00000001820CEA90
		private void OnDestroy(); // 0x00000001820CE8C0-0x00000001820CE9D0
		public void DestroySelf(); // 0x00000001820CE560-0x00000001820CE5C0
		private Material GetMaterial(Material mat); // 0x00000001820CE5C0-0x00000001820CE790
		private Material CreateMaterialInstance(Material source); // 0x00000001820CE4A0-0x00000001820CE560
		private Material GetSharedMaterial(); // 0x00000001820CE820-0x00000001820CE8C0
		private void SetSharedMaterial(Material mat); // 0x00000001820CED30-0x00000001820CED70
		public float GetPaddingForMaterial(); // 0x00000001820CE790-0x00000001820CE820
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold); // 0x00000001820CEF20-0x00000001820CEFA0
		public void SetVerticesDirty(); // 0x00000001802E76C0-0x00000001802E76D0
		public void SetMaterialDirty(); // 0x00000001820CED20-0x00000001820CED30
		protected void UpdateMaterial(); // 0x00000001820CED70-0x00000001820CEF20
	}
}
