/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class UIRRepaintUpdater : BaseVisualTreeUpdater, IPanelRenderer // TypeDefIndex: 4337
	{
		// Fields
		private BaseVisualElementPanel attachedPanel; // 0x28
		internal RenderTreeManager renderTreeManager; // 0x30
		private static readonly string s_Description; // 0x00
		private static readonly ProfilerMarker s_ProfilerMarker; // 0x08
		private bool m_ForceGammaRendering; // 0x38
		private uint m_VertexBudget; // 0x3C
		private TextureSlotCount m_TextureSlotCount; // 0x40
		private ExtraVertexChannels m_ExtraVertexChannels; // 0x44
		[CompilerGenerated]
		private bool _breakBatches_k__BackingField; // 0x48
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x49
	
		// Properties
		public override ProfilerMarker profilerMarker { get; } // 0x00000001824E1580-0x00000001824E15D0 
		public bool forceGammaRendering { get; set; } // 0x0000000180476380-0x0000000180476390 0x00000001824E15E0-0x00000001824E15F0
		public uint vertexBudget { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001824E15F0-0x00000001824E1600
		public TextureSlotCount textureSlotCount { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
		public ExtraVertexChannels extraVertexChannels { get; set; } // 0x000000018033D780-0x000000018033D790 0x00000001824E15D0-0x00000001824E15E0
		public bool breakBatches { [CompilerGenerated] get; } // 0x00000001804EFDA0-0x00000001804EFDB0 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181A42150-0x0000000181A42160 0x0000000182042F70-0x0000000182042F80
	
		// Constructors
		public UIRRepaintUpdater(); // 0x00000001824E14F0-0x00000001824E1580
		static UIRRepaintUpdater(); // 0x00000001824E13E0-0x00000001824E14F0
	
		// Methods
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType); // 0x00000001824E0F60-0x00000001824E1170
		public override void Update(); // 0x00000001824E12C0-0x00000001824E13E0
		public void Render(); // 0x00000001824E1170-0x00000001824E1200
		protected virtual RenderTreeManager CreateRenderChain(); // 0x00000001824E0710-0x00000001824E0770
		private static void OnGraphicsResourcesRecreate(bool recreate); // 0x00000001824E0D10-0x00000001824E0ED0
		private void OnPanelChanged(BaseVisualElementPanel obj); // 0x00000001824E0ED0-0x00000001824E0EF0
		private void AttachToPanel(); // 0x00000001824E02E0-0x00000001824E0710
		private void DetachFromPanel(); // 0x00000001824E07E0-0x00000001824E0C20
		private void InitRenderChain(); // 0x00000001824E0C50-0x00000001824E0D10
		public void Reset(); // 0x00000001824E0770-0x00000001824E07E0
		private void DestroyRenderChain(); // 0x00000001824E0770-0x00000001824E07E0
		private void OnPanelIsFlatChanged(); // 0x00000001824E0770-0x00000001824E07E0
		private void OnPanelAtlasChanged(); // 0x00000001824E0770-0x00000001824E07E0
		private void OnPanelDrawsInCamerasChanged(); // 0x00000001824E0770-0x00000001824E07E0
		private void OnPanelHierarchyChanged(VisualElement ve, HierarchyChangeType changeType, IReadOnlyList<VisualElement> additionalContext = null); // 0x00000001824E0EF0-0x00000001824E0F60
		private void ResetAllElementsDataRecursive(VisualElement ve); // 0x00000001824E1200-0x00000001824E12C0
		protected override void Dispose(bool disposing); // 0x00000001824E0C20-0x00000001824E0C50
	}
}
