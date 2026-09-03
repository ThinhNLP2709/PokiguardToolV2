/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[AddComponentMenu("Mesh/TextMeshPro - Text")]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(MeshRenderer))]
	[TMPHelpURL("index")]
	public class TextMeshPro : TMP_Text, ILayoutElement // TypeDefIndex: 11942
	{
		// Fields
		[SerializeField]
		internal int _SortingLayer; // 0x6F0
		[SerializeField]
		internal int _SortingLayerID; // 0x6F4
		[SerializeField]
		internal int _SortingOrder; // 0x6F8
		[CompilerGenerated]
		private Action<TMP_TextInfo> OnPreRenderText; // 0x700
		[SerializeField]
		private bool m_hasFontAssetChanged; // 0x708
		private float m_previousLossyScaleY; // 0x70C
		[SerializeField]
		private Renderer m_renderer; // 0x710
		private MeshFilter m_meshFilter; // 0x718
		private bool m_isFirstAllocation; // 0x720
		private int m_max_characters; // 0x724
		private int m_max_numberOfLines; // 0x728
		private TMP_SubMesh[] m_subTextObjects; // 0x730
		[SerializeField]
		private MaskingTypes m_maskType; // 0x738
		private Matrix4x4 m_EnvMapMatrix; // 0x73C
		private Vector3[] m_RectTransformCorners; // 0x780
		[NonSerialized]
		private bool m_isRegisteredForEvents; // 0x788
		private static readonly ProfilerMarker k_GenerateTextMarker; // 0x00
		private static readonly ProfilerMarker k_SetArraySizesMarker; // 0x08
		private static readonly ProfilerMarker k_GenerateTextPhaseIMarker; // 0x10
		private static readonly ProfilerMarker k_ParseMarkupTextMarker; // 0x18
		private static readonly ProfilerMarker k_CharacterLookupMarker; // 0x20
		private static readonly ProfilerMarker k_HandleGPOSFeaturesMarker; // 0x28
		private static readonly ProfilerMarker k_CalculateVerticesPositionMarker; // 0x30
		private static readonly ProfilerMarker k_ComputeTextMetricsMarker; // 0x38
		private static readonly ProfilerMarker k_HandleVisibleCharacterMarker; // 0x40
		private static readonly ProfilerMarker k_HandleWhiteSpacesMarker; // 0x48
		private static readonly ProfilerMarker k_HandleHorizontalLineBreakingMarker; // 0x50
		private static readonly ProfilerMarker k_HandleVerticalLineBreakingMarker; // 0x58
		private static readonly ProfilerMarker k_SaveGlyphVertexDataMarker; // 0x60
		private static readonly ProfilerMarker k_ComputeCharacterAdvanceMarker; // 0x68
		private static readonly ProfilerMarker k_HandleCarriageReturnMarker; // 0x70
		private static readonly ProfilerMarker k_HandleLineTerminationMarker; // 0x78
		private static readonly ProfilerMarker k_SavePageInfoMarker; // 0x80
		private static readonly ProfilerMarker k_SaveTextExtentMarker; // 0x88
		private static readonly ProfilerMarker k_SaveProcessingStatesMarker; // 0x90
		private static readonly ProfilerMarker k_GenerateTextPhaseIIMarker; // 0x98
		private static readonly ProfilerMarker k_GenerateTextPhaseIIIMarker; // 0xA0
		private Dictionary<int, int> materialIndexPairs; // 0x790
	
		// Properties
		public int sortingLayerID { get; set; } // 0x0000000182108E40-0x0000000182108ED0 0x00000001821092A0-0x0000000182109470
		public int sortingOrder { get; set; } // 0x0000000182108ED0-0x0000000182108F60 0x0000000182109470-0x0000000182109640
		public override bool autoSizeTextContainer { get; set; } // 0x00000001820FFB50-0x00000001820FFB60 0x00000001821090D0-0x0000000182109290
		[Obsolete("The TextContainer is now obsolete. Use the RectTransform instead.", true)]
		public TextContainer textContainer { get; } // 0x00000001802E7860-0x00000001802E7870 
		public new Transform transform { get; } // 0x0000000182108F60-0x0000000182109000 
		public Renderer renderer { get; } // 0x0000000182108DA0-0x0000000182108E40 
		public override Mesh mesh { get; } // 0x0000000182108CD0-0x0000000182108DA0 
		public MeshFilter meshFilter { get; } // 0x0000000182108BB0-0x0000000182108CD0 
		public MaskingTypes maskType { get; set; } // 0x0000000182108BA0-0x0000000182108BB0 0x0000000182109290-0x00000001821092A0
	
		// Events
		public override event Action<TMP_TextInfo> OnPreRenderText {
			add; // 0x0000000182108AD0-0x0000000182108BA0
			remove; // 0x0000000182109000-0x00000001821090D0
		}
	
		// Constructors
		public TextMeshPro(); // 0x00000001821089A0-0x0000000182108AD0
		static TextMeshPro(); // 0x00000001821084A0-0x00000001821089A0
	
		// Methods
		public void SetMask(MaskingTypes type, Vector4 maskCoords); // 0x0000000182106410-0x00000001821064B0
		public void SetMask(MaskingTypes type, Vector4 maskCoords, float softnessX, float softnessY); // 0x0000000182106660-0x0000000182106770
		public override void SetVerticesDirty(); // 0x00000001821072B0-0x0000000182107490
		public override void SetLayoutDirty(); // 0x00000001821061A0-0x0000000182106270
		public override void SetMaterialDirty(); // 0x00000001815A0090-0x00000001815A00B0
		public override void SetAllDirty(); // 0x00000001820F9520-0x00000001820F9570
		public override void Rebuild(CanvasUpdate update); // 0x00000001821024E0-0x00000001821025C0
		protected override void UpdateMaterial(); // 0x0000000182107830-0x0000000182107950
		public override void UpdateMeshPadding(); // 0x0000000182107950-0x0000000182107A80
		public override void ForceMeshUpdate(bool ignoreActiveState = false /* Metadata: 0x006A2535 */, bool forceTextReparsing = false /* Metadata: 0x006A2536 */); // 0x0000000182100940-0x0000000182100960
		public override TMP_TextInfo GetTextInfo(string text); // 0x00000001821012C0-0x0000000182101340
		public override void ClearMesh(bool updateMesh); // 0x0000000182100170-0x0000000182100260
		public override void UpdateGeometry(Mesh mesh, int index); // 0x00000001821076D0-0x00000001821076F0
		public override void UpdateVertexData(TMP_VertexDataUpdateFlags flags); // 0x0000000182107F50-0x0000000182108140
		public override void UpdateVertexData(); // 0x0000000182108140-0x0000000182108380
		public void UpdateFontAsset(); // 0x00000001820FE340-0x00000001820FE360
		public void CalculateLayoutInputHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public void CalculateLayoutInputVertical(); // 0x00000001802E76C0-0x00000001802E76D0
		protected override void Awake(); // 0x00000001820FFE00-0x0000000182100170
		protected override void OnEnable(); // 0x0000000182101E00-0x0000000182101F00
		protected override void OnDisable(); // 0x0000000182101D60-0x0000000182101E00
		protected override void OnDestroy(); // 0x0000000182101C80-0x0000000182101D30
		protected override void LoadFontAsset(); // 0x0000000182101620-0x0000000182101C80
		private void ValidateEnvMapProperty(); // 0x0000000182108380-0x00000001821084A0
		private void UpdateEnvMapMatrix(); // 0x0000000182107490-0x00000001821076D0
		private void SetMask(MaskingTypes maskType); // 0x00000001821064B0-0x0000000182106660
		private void SetMaskCoordinates(Vector4 coords); // 0x0000000182106380-0x0000000182106410
		private void SetMaskCoordinates(Vector4 coords, float softX, float softY); // 0x0000000182106270-0x0000000182106380
		private void EnableMasking(); // 0x0000000182100820-0x0000000182100940
		private void DisableMasking(); // 0x00000001821005F0-0x0000000182100820
		private void UpdateMask(); // 0x00000001821076F0-0x0000000182107830
		protected override Material GetMaterial(Material mat); // 0x0000000182100C50-0x0000000182100DA0
		protected override Material[] GetMaterials(Material[] mats); // 0x0000000182100DA0-0x0000000182100FF0
		protected override void SetSharedMaterial(Material mat); // 0x00000001820FD6F0-0x00000001820FD750
		protected override Material[] GetSharedMaterials(); // 0x0000000182100FF0-0x0000000182101210
		protected override void SetSharedMaterials(Material[] materials); // 0x0000000182106DA0-0x00000001821072B0
		protected override void SetOutlineThickness(float thickness); // 0x0000000182106B10-0x0000000182106CA0
		protected override void SetFaceColor(Color32 color); // 0x0000000182106010-0x00000001821061A0
		protected override void SetOutlineColor(Color32 color); // 0x0000000182106980-0x0000000182106B10
		private void CreateMaterialInstance(); // 0x00000001821003E0-0x00000001821004C0
		protected override void SetShaderDepth(); // 0x0000000182106D60-0x0000000182106DA0
		protected override void SetCulling(); // 0x0000000182105C70-0x0000000182106010
		private void SetPerspectiveCorrection(); // 0x0000000182106CA0-0x0000000182106D60
		internal override int SetArraySizes(TextProcessingElement[] textProcessingArray); // 0x0000000182102880-0x0000000182105C70
		public override void ComputeMarginSize(); // 0x0000000182100260-0x00000001821003E0
		protected override void OnDidApplyAnimationProperties(); // 0x0000000182101D30-0x0000000182101D60
		protected override void OnTransformParentChanged(); // 0x00000001821024A0-0x00000001821024E0
		protected override void OnRectTransformDimensionsChange(); // 0x00000001821022D0-0x00000001821024A0
		internal override void InternalUpdate(); // 0x0000000182101340-0x0000000182101620
		private void OnPreRenderObject(); // 0x0000000182101F00-0x00000001821022D0
		protected virtual void GenerateTextMesh(); // 0x00000001820D2490-0x00000001820DEC10
		protected override Vector3[] GetTextContainerLocalCorners(); // 0x0000000182101210-0x00000001821012C0
		private void SetMeshFilters(bool state); // 0x0000000182106770-0x0000000182106980
		protected override void SetActiveSubMeshes(bool state); // 0x00000001821025C0-0x0000000182102700
		protected void SetActiveSubTextObjectRenderers(bool state); // 0x0000000182102700-0x0000000182102880
		protected override void DestroySubMeshObjects(); // 0x00000001821004C0-0x00000001821005F0
		internal void UpdateSubMeshSortingLayerID(int id); // 0x0000000182107C90-0x0000000182107DF0
		internal void UpdateSubMeshSortingOrder(int order); // 0x0000000182107DF0-0x0000000182107F50
		protected override Bounds GetCompoundBounds(); // 0x0000000182100960-0x0000000182100C50
		private void UpdateSDFScale(float scaleDelta); // 0x0000000182107A80-0x0000000182107C90
	}
}
