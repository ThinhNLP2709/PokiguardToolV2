/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class UITKTextHandle : TextHandle // TypeDefIndex: 4823
	{
		// Fields
		internal ATGTextEventHandler m_ATGTextEventHandler; // 0xE0
		private bool uvsAreGenerated; // 0xE8
		private NativeTextBuffer m_ProcessedTextBuffer; // 0xF0
		[CompilerGenerated]
		private float _LastPixelPerPoint_k__BackingField; // 0x108
		[CompilerGenerated]
		private float? _MeasuredWidth_k__BackingField; // 0x10C
		[CompilerGenerated]
		private float _RoundedWidth_k__BackingField; // 0x114
		[CompilerGenerated]
		private float? _ATGMeasuredWidth_k__BackingField; // 0x118
		[CompilerGenerated]
		private float _ATGRoundedWidth_k__BackingField; // 0x120
		internal TextEventHandler m_TextEventHandler; // 0x128
		protected TextElement m_TextElement; // 0x130
		internal static readonly float k_MinPadding; // 0x00
	
		// Properties
		internal float LastPixelPerPoint { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E8FE10-0x0000000181E8FE20 0x00000001823CCAD0-0x00000001823CCAE0
		internal float? MeasuredWidth { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001823CCA20-0x00000001823CCA30 0x00000001823CCAE0-0x00000001823CCEF0
		internal float RoundedWidth { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001820CDE60-0x00000001820CDE70 0x00000001820CE1C0-0x00000001820CE1D0
		internal float? ATGMeasuredWidth { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018171E0D0-0x000000018171E0E0 0x00000001823CCAB0-0x00000001823CCAC0
		internal float ATGRoundedWidth { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001823CC9D0-0x00000001823CC9E0 0x00000001823CCAC0-0x00000001823CCAD0
		public override bool IsPlaceholder { get; } // 0x00000001823CC9E0-0x00000001823CCA20 
	
		// Constructors
		public UITKTextHandle(TextElement te); // 0x00000001823CC900-0x00000001823CC9D0
		static UITKTextHandle(); // 0x00000001823CC8C0-0x00000001823CC900
	
		// Methods
		internal bool TryGetSourceTextPointer(out IntPtr ptr, out int length); // 0x00000001823CC0C0-0x00000001823CC1C0
		private void EnsureNonEmptyBufferForInputField(); // 0x00000001823CB070-0x00000001823CB100
		private void ComputeNativeTextSize([IsReadOnly] in string textToMeasure, float width, VisualElement.MeasureMode widthMode, float height, VisualElement.MeasureMode heightMode, float? fontsize = default); // 0x00000001823C8D60-0x00000001823C8FE0
		public ValueTuple<NativeTextInfo, bool> UpdateNative(); // 0x00000001823CC380-0x00000001823CC8C0
		public void ShapeText(); // 0x00000001823CBE30-0x00000001823CBFF0
		public void ProcessMeshInfos(NativeTextInfo textInfo, ref List<List<List<int>>> textElementIndicesByMesh); // 0x00000001823CB9B0-0x00000001823CBAE0
		public bool HasMissingGlyphs(NativeTextInfo textInfo, ref Dictionary<EntityId, HashSet<uint>> missingGlyphsPerFontAsset); // 0x00000001823CB890-0x00000001823CB940
		private ValueTuple<bool, bool> hasLinkAndHyperlink(); // 0x00000001823CCA30-0x00000001823CCAB0
		internal void UpdateATGTextEventHandler(); // 0x00000001823CC1C0-0x00000001823CC2B0
		internal void EnsureIsReadyForJobs(); // 0x00000001823CAD00-0x00000001823CB070
		[NullableContext(2)]
		internal bool ConvertUssToNativeTextGenerationSettings(string textToMeasure = null, float? fontsize = default); // 0x00000001823C9940-0x00000001823CA510
		internal void SyncLinksFromNative(); // 0x00000001823CBFF0-0x00000001823CC070
		internal override UnityEngine.TextAsset GetICUAsset(); // 0x00000001823CB100-0x00000001823CB2F0
		public override void RemoveFromPermanentCacheATG(); // 0x00000001823CBDC0-0x00000001823CBE10
		protected override float GetPixelsPerPoint(); // 0x00000001823CB2F0-0x00000001823CB310
		public override void SetDirty(); // 0x00000001823CBE10-0x00000001823CBE30
		public Vector2 ComputeTextSize(string textToMeasure, float width, VisualElement.MeasureMode widthMode, float height, VisualElement.MeasureMode heightMode, float? fontsize = default); // 0x00000001823C9360-0x00000001823C97B0
		public Vector2 ComputeTextSize([IsReadOnly] in RenderedText textToMeasure, float width, float height, float? fontsize = default); // 0x00000001823C97B0-0x00000001823C9940
		public void ComputeSettingsAndUpdate(); // 0x00000001823C8FE0-0x00000001823C9360
		public void HandleATag(); // 0x00000001823CB5F0-0x00000001823CB730
		public void HandleLinkTag(); // 0x00000001823CB750-0x00000001823CB890
		public void HandleLinkAndATagCallbacks(); // 0x00000001823CB730-0x00000001823CB750
		public void UpdateMesh(); // 0x00000001823CC2B0-0x00000001823CC380
		public override void AddToPermanentCacheAndGenerateMesh(); // 0x00000001823C8C10-0x00000001823C8D30
		public override void AddToPermanentCache(); // 0x00000001823C8D30-0x00000001823C8D60
		private TextOverflowMode GetTextOverflowMode(); // 0x00000001823CB310-0x00000001823CB3D0
		internal virtual bool ConvertUssToTextGenerationSettings(bool populateScreenRect, float? fontsize = default); // 0x00000001823CA510-0x00000001823CAD00
		internal bool TextLibraryCanElide(); // 0x00000001823CC070-0x00000001823CC0C0
		internal float GetVertexPadding(FontAsset fontAsset); // 0x00000001823CB3D0-0x00000001823CB5F0
		internal override bool IsAdvancedTextEnabledForElement(); // 0x00000001823CB940-0x00000001823CB950
		internal void ReleaseResourcesIfPossible(); // 0x00000001823CBAE0-0x00000001823CBDC0
		public bool IsElided(); // 0x00000001823CB950-0x00000001823CB9B0
	}
}
