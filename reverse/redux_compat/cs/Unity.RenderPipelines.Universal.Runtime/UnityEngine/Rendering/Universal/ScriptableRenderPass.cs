/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public abstract class ScriptableRenderPass : IRenderGraphRecorder // TypeDefIndex: 9447
	{
		// Fields
		[CompilerGenerated]
		private RenderPassEvent _renderPassEvent_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _requiresIntermediateTexture_k__BackingField; // 0x14
		private ProfilingSampler m_ProfingSampler; // 0x18
		private string m_PassName; // 0x20
		[CompilerGenerated]
		private bool _isBlitRenderPass_k__BackingField; // 0x28
		[CompilerGenerated]
		private int _renderPassQueueIndex_k__BackingField; // 0x2C
		internal NativeArray<int> m_ColorAttachmentIndices; // 0x30
		internal NativeArray<int> m_InputAttachmentIndices; // 0x40
		[CompilerGenerated]
		private GraphicsFormat[] _renderTargetFormat_k__BackingField; // 0x50
		private ScriptableRenderPassInput m_Input; // 0x58
	
		// Properties
		public RenderPassEvent renderPassEvent { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public ScriptableRenderPassInput input { get; } // 0x000000018033D260-0x000000018033D270 
		public bool requiresIntermediateTexture { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181102980-0x0000000181102990 0x0000000181541B70-0x0000000181541B80
		protected internal ProfilingSampler profilingSampler { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x0000000181F7FD20-0x0000000181F7FD90
		protected internal string passName { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal bool isBlitRenderPass { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		internal int renderPassQueueIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		internal GraphicsFormat[] renderTargetFormat { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		public ScriptableRenderPass(); // 0x0000000181F7FBD0-0x0000000181F7FCC0
	
		// Methods
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void FrameCleanup(CommandBuffer cmd); // 0x000000018164FA90-0x000000018164FAB0
		internal static DebugHandler GetActiveDebugHandler(UniversalCameraData cameraData); // 0x0000000181F7F9B0-0x0000000181F7FA20
		public void ConfigureInput(ScriptableRenderPassInput passInput); // 0x000000018033E870-0x000000018033E880
		public virtual void OnCameraCleanup(CommandBuffer cmd); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181F7FB30-0x0000000181F7FBD0
		public DrawingSettings CreateDrawingSettings(ShaderTagId shaderTagId, ref RenderingData renderingData, SortingCriteria sortingCriteria); // 0x0000000181F7F810-0x0000000181F7F9B0
		public DrawingSettings CreateDrawingSettings(ShaderTagId shaderTagId, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, SortingCriteria sortingCriteria); // 0x0000000181F7F430-0x0000000181F7F550
		public DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTagIdList, ref RenderingData renderingData, SortingCriteria sortingCriteria); // 0x0000000181F7F670-0x0000000181F7F810
		public DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTagIdList, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, SortingCriteria sortingCriteria); // 0x0000000181F7F550-0x0000000181F7F670
		public static bool operator <(ScriptableRenderPass lhs, ScriptableRenderPass rhs); // 0x0000000181F7FCF0-0x0000000181F7FD20
		public static bool operator >(ScriptableRenderPass lhs, ScriptableRenderPass rhs); // 0x0000000181F7FCC0-0x0000000181F7FCF0
		internal static int GetRenderPassEventRange(RenderPassEvent renderPassEvent); // 0x0000000181F7FA20-0x0000000181F7FB30
	}
}
