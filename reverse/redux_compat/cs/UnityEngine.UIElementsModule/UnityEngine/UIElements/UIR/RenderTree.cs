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

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class RenderTree // TypeDefIndex: 5127
	{
		// Fields
		private RenderTreeManager m_RenderTreeManager; // 0x10
		private DepthOrderedDirtyTracking m_DirtyTracker; // 0x18
		private RenderChainCommand m_FirstCommand; // 0x48
		private RenderData m_RootRenderData; // 0x50
		private HashSet<RenderData> m_BackdropFilterRenderDatas; // 0x58
		public TextureId quadTextureId; // 0x60
		public RectInt quadRect; // 0x64
		public Rect quadUVRect; // 0x74
		public bool quadIsGammaEncoded; // 0x84
		public GCHandlePool m_GCHandlePool; // 0x88
		internal RenderTree parent; // 0x90
		internal RenderTree firstChild; // 0x98
		internal RenderTree nextSibling; // 0xA0
		private static readonly ProfilerMarker k_MarkerClipProcessing; // 0x00
		private static readonly ProfilerMarker k_MarkerOpacityProcessing; // 0x08
		private static readonly ProfilerMarker k_MarkerColorsProcessing; // 0x10
		private static readonly ProfilerMarker k_MarkerTransformProcessing; // 0x18
		private static readonly ProfilerMarker k_MarkerVisualsProcessing; // 0x20
		private AllowedClasses m_AllowedDirtyClasses; // 0xA8
	
		// Properties
		internal RenderTreeManager renderTreeManager { get; } // 0x0000000180377550-0x0000000180377560 
		internal RenderData rootRenderData { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal ref DepthOrderedDirtyTracking dirtyTracker { get; } // 0x0000000181DE9910-0x0000000181DE9920 
		internal RenderChainCommand firstCommand { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal bool isRootRenderTree { get; } // 0x0000000182432EE0-0x0000000182432F20 
	
		// Nested types
		[Flags]
		internal enum AllowedClasses // TypeDefIndex: 5128
		{
			Clipping = 1,
			Opacity = 2,
			Color = 4,
			TransformSize = 8,
			Visuals = 16,
			All = 31
		}
	
		// Constructors
		public RenderTree(); // 0x0000000182432E50-0x0000000182432EE0
		static RenderTree(); // 0x0000000182432CE0-0x0000000182432E50
	
		// Methods
		public void Init(RenderTreeManager renderTreeManager, RenderData rootRenderData); // 0x0000000182431B20-0x0000000182431D30
		public void Reset(); // 0x0000000182432BF0-0x0000000182432C80
		public void Dispose(); // 0x0000000182431B00-0x0000000182431B20
		private void DepthFirstResetTextures(RenderData renderData); // 0x0000000182431A40-0x0000000182431B00
		public void OnRenderDataOpacityChanged(RenderData renderData, bool hierarchical = false /* Metadata: 0x00660ACD */); // 0x0000000182431DA0-0x0000000182431E40
		public void OnRenderDataTransformOrSizeChanged(RenderData renderData, bool transformChanged, bool clipRectSizeChanged); // 0x0000000182431E40-0x0000000182431EF0
		public void OnRenderDataVisualsChanged(RenderData renderData, bool hierarchical); // 0x0000000182431EF0-0x0000000182431F90
		public void RegisterBackdropFilter(RenderData renderData); // 0x0000000182432B90-0x0000000182432BF0
		public void UnregisterBackdropFilter(RenderData renderData); // 0x0000000182432C80-0x0000000182432CE0
		public void RefreshBackdropFilterDescendantsOfGroup(RenderData group); // 0x0000000182432A60-0x0000000182432B90
		public void ProcessChanges(ref ChainBuilderStats stats); // 0x0000000182431F90-0x0000000182432A60
		internal void OnRenderCommandAdded(RenderChainCommand command); // 0x0000000182431D30-0x0000000182431D60
		internal void OnRenderCommandsRemoved(RenderChainCommand firstCommand, RenderChainCommand lastCommand); // 0x0000000182431D60-0x0000000182431DA0
		internal void ChildWillBeRemoved(RenderData renderData); // 0x00000001824319A0-0x0000000182431A40
	}
}
