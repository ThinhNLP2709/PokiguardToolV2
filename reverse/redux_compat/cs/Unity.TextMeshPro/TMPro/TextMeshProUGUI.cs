/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[AddComponentMenu("UI (Canvas)/TextMeshPro - Text (UI)", 11)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
	[TMPHelpURL("index")]
	public class TextMeshProUGUI : TMP_Text, ILayoutElement // TypeDefIndex: 11943
	{
		// Fields
		private bool m_isRebuildingLayout; // 0x6F0
		private Coroutine m_DelayedGraphicRebuild; // 0x6F8
		private Coroutine m_DelayedMaterialRebuild; // 0x700
		private bool m_ShouldUpdateCulling; // 0x708
		private Rect m_ClipRect; // 0x70C
		private bool m_ValidRect; // 0x71C
		[CompilerGenerated]
		private Action<TMP_TextInfo> OnPreRenderText; // 0x720
		[SerializeField]
		private bool m_hasFontAssetChanged; // 0x728
		protected TMP_SubMeshUI[] m_subTextObjects; // 0x730
		private float m_previousLossyScaleY; // 0x738
		private Vector3[] m_RectTransformCorners; // 0x740
		private CanvasRenderer m_canvasRenderer; // 0x748
		private Canvas m_canvas; // 0x750
		private float m_CanvasScaleFactor; // 0x758
		private bool m_isFirstAllocation; // 0x75C
		private int m_max_characters; // 0x760
		[SerializeField]
		private Material m_baseMaterial; // 0x768
		private bool m_isScrollRegionSet; // 0x770
		[SerializeField]
		private Vector4 m_maskOffset; // 0x774
		private Matrix4x4 m_EnvMapMatrix; // 0x784
		[NonSerialized]
		private bool m_isRegisteredForEvents; // 0x7C4
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
		private Dictionary<int, int> materialIndexPairs; // 0x7C8
	
		// Properties
		public override Material materialForRendering { get; } // 0x00000001820FFC10-0x00000001820FFC70 
		public override bool autoSizeTextContainer { get; set; } // 0x00000001820FFB50-0x00000001820FFB60 0x00000001820FFD40-0x00000001820FFDD0
		public override Mesh mesh { get; } // 0x00000001820AF750-0x00000001820AF760 
		public new CanvasRenderer canvasRenderer { get; } // 0x00000001820FFB60-0x00000001820FFC00 
		public Vector4 maskOffset { get; set; } // 0x00000001820FFC00-0x00000001820FFC10 0x00000001820FFDD0-0x00000001820FFE00
	
		// Events
		public override event Action<TMP_TextInfo> OnPreRenderText {
			add; // 0x00000001820FFA80-0x00000001820FFB50
			remove; // 0x00000001820FFC70-0x00000001820FFD40
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class _DelayedGraphicRebuild_d__18 : IEnumerator<object> // TypeDefIndex: 11944
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TextMeshProUGUI __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DelayedGraphicRebuild_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000182109B20-0x0000000182109C00
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182109C00-0x0000000182109C40
		}
	
		[CompilerGenerated]
		private sealed class _DelayedMaterialRebuild_d__19 : IEnumerator<object> // TypeDefIndex: 11945
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TextMeshProUGUI __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DelayedMaterialRebuild_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000182109C40-0x0000000182109D30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182109D30-0x0000000182109D70
		}
	
		// Constructors
		public TextMeshProUGUI(); // 0x00000001820FF960-0x00000001820FFA80
		static TextMeshProUGUI(); // 0x00000001820FF460-0x00000001820FF960
	
		// Methods
		public void CalculateLayoutInputHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public void CalculateLayoutInputVertical(); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetVerticesDirty(); // 0x00000001820FDD00-0x00000001820FDDD0
		public override void SetLayoutDirty(); // 0x00000001820FCF50-0x00000001820FD030
		public override void SetMaterialDirty(); // 0x00000001820FD030-0x00000001820FD100
		public override void SetAllDirty(); // 0x00000001820F9520-0x00000001820F9570
		[IteratorStateMachine(typeof(_DelayedGraphicRebuild_d__18))]
		private IEnumerator DelayedGraphicRebuild(); // 0x00000001820F6660-0x00000001820F66D0
		[IteratorStateMachine(typeof(_DelayedMaterialRebuild_d__19))]
		private IEnumerator DelayedMaterialRebuild(); // 0x00000001820F66D0-0x00000001820F6740
		public override void Rebuild(CanvasUpdate update); // 0x00000001820F9300-0x00000001820F93E0
		private void UpdateSubObjectPivot(); // 0x00000001820FED50-0x00000001820FEE70
		public override Material GetModifiedMaterial(Material baseMaterial); // 0x00000001820F75D0-0x00000001820F7730
		protected override void UpdateMaterial(); // 0x00000001820FE820-0x00000001820FE970
		public override void RecalculateClipping(); // 0x00000001820CD8A0-0x00000001820CD8B0
		public override void Cull(Rect clipRect, bool validRect); // 0x00000001820F6400-0x00000001820F6660
		internal override void UpdateCulling(); // 0x00000001820FDDD0-0x00000001820FE100
		public override void UpdateMeshPadding(); // 0x00000001820FE970-0x00000001820FEAA0
		protected override void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha); // 0x00000001820F7BE0-0x00000001820F7D00
		protected override void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale); // 0x00000001820F7B00-0x00000001820F7BE0
		public override void ForceMeshUpdate(bool ignoreActiveState = false /* Metadata: 0x006A2537 */, bool forceTextReparsing = false /* Metadata: 0x006A2538 */); // 0x00000001820F6AD0-0x00000001820F6B80
		public override TMP_TextInfo GetTextInfo(string text); // 0x00000001820F7A00-0x00000001820F7B00
		public override void ClearMesh(); // 0x00000001820F6140-0x00000001820F6280
		public override void UpdateGeometry(Mesh mesh, int index); // 0x00000001820FE360-0x00000001820FE3F0
		public override void UpdateVertexData(TMP_VertexDataUpdateFlags flags); // 0x00000001820FEE70-0x00000001820FF0B0
		public override void UpdateVertexData(); // 0x00000001820FF0B0-0x00000001820FF340
		public void UpdateFontAsset(); // 0x00000001820FE340-0x00000001820FE360
		protected override void Awake(); // 0x00000001820F5E10-0x00000001820F6140
		protected override void OnEnable(); // 0x00000001820F8A00-0x00000001820F8C50
		protected override void OnDisable(); // 0x00000001820F8870-0x00000001820F8A00
		protected override void OnDestroy(); // 0x00000001820F86F0-0x00000001820F8830
		protected override void LoadFontAsset(); // 0x00000001820F7FE0-0x00000001820F85C0
		private Canvas GetCanvas(); // 0x00000001820F6E20-0x00000001820F6F30
		private void ValidateEnvMapProperty(); // 0x00000001820FF340-0x00000001820FF460
		private void UpdateEnvMapMatrix(); // 0x00000001820FE100-0x00000001820FE340
		private void EnableMasking(); // 0x00000001820F6870-0x00000001820F6AD0
		private void DisableMasking(); // 0x00000001802E76C0-0x00000001802E76D0
		private void UpdateMask(); // 0x00000001820FE3F0-0x00000001820FE820
		protected override Material GetMaterial(Material mat); // 0x00000001820F7220-0x00000001820F7380
		protected override Material[] GetMaterials(Material[] mats); // 0x00000001820F7380-0x00000001820F75D0
		protected override void SetSharedMaterial(Material mat); // 0x00000001820FD6F0-0x00000001820FD750
		protected override Material[] GetSharedMaterials(); // 0x00000001820F7730-0x00000001820F7950
		protected override void SetSharedMaterials(Material[] materials); // 0x00000001820FD750-0x00000001820FDD00
		protected override void SetOutlineThickness(float thickness); // 0x00000001820FD360-0x00000001820FD5A0
		protected override void SetFaceColor(Color32 color); // 0x00000001820FCDB0-0x00000001820FCF50
		protected override void SetOutlineColor(Color32 color); // 0x00000001820FD1C0-0x00000001820FD360
		protected override void SetShaderDepth(); // 0x00000001820FD660-0x00000001820FD6F0
		protected override void SetCulling(); // 0x00000001820FCA50-0x00000001820FCDB0
		private void SetPerspectiveCorrection(); // 0x00000001820FD5A0-0x00000001820FD660
		private void SetMeshArrays(int size); // 0x00000001820FD100-0x00000001820FD1C0
		internal override int SetArraySizes(TextProcessingElement[] textProcessingArray); // 0x00000001820F9570-0x00000001820FCA50
		public override void ComputeMarginSize(); // 0x00000001820F6280-0x00000001820F6400
		protected override void OnDidApplyAnimationProperties(); // 0x00000001820F8830-0x00000001820F8870
		protected override void OnCanvasHierarchyChanged(); // 0x00000001820F85C0-0x00000001820F86F0
		protected override void OnTransformParentChanged(); // 0x00000001820F92A0-0x00000001820F9300
		protected override void OnRectTransformDimensionsChange(); // 0x00000001820F8EE0-0x00000001820F92A0
		internal override void InternalUpdate(); // 0x00000001820F7D00-0x00000001820F7FE0
		private void OnPreRenderCanvas(); // 0x00000001820F8C50-0x00000001820F8EE0
		protected virtual void GenerateTextMesh(); // 0x00000001820DEC10-0x00000001820EB650
		protected override Vector3[] GetTextContainerLocalCorners(); // 0x00000001820F7950-0x00000001820F7A00
		protected override void SetActiveSubMeshes(bool state); // 0x00000001820F93E0-0x00000001820F9520
		protected override void DestroySubMeshObjects(); // 0x00000001820F6740-0x00000001820F6870
		protected override Bounds GetCompoundBounds(); // 0x00000001820F6F30-0x00000001820F7220
		internal override Rect GetCanvasSpaceClippingRect(); // 0x00000001820F6B80-0x00000001820F6E20
		private void UpdateSDFScale(float scaleDelta); // 0x00000001820FEAA0-0x00000001820FED50
	}
}
