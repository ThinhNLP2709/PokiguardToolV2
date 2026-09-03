/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderContext.bindings.h")]
	[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableDrawRenderersUtility.h")]
	[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableRenderContext.h")]
	[NativeHeader("Modules/UI/Canvas.h")]
	[NativeHeader("Modules/UI/CanvasManager.h")]
	[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
	public struct ScriptableRenderContext : IEquatable<ScriptableRenderContext> // TypeDefIndex: 8433
	{
		// Fields
		private static readonly ShaderTagId kRenderTypeTag; // 0x00
		private IntPtr m_Ptr; // 0x00
	
		// Nested types
		private struct CullShadowCastersContext // TypeDefIndex: 8434
		{
			// Fields
			public IntPtr cullResults; // 0x00
			public unsafe ShadowSplitData* splitBuffer; // 0x08
			public int splitBufferLength; // 0x10
			public unsafe LightShadowCasterCullingInfo* perLightInfos; // 0x18
			public int perLightInfoCount; // 0x20
		}
	
		// Constructors
		internal ScriptableRenderContext(IntPtr ptr); // 0x0000000180CBE820-0x0000000180CBE830
		static ScriptableRenderContext(); // 0x0000000182268A40-0x0000000182268A90
	
		// Methods
		[FreeFunction("ScriptableRenderContext::HasInvokeOnRenderObjectCallbacks")]
		private static bool HasInvokeOnRenderObjectCallbacks_Internal(); // 0x0000000182268690-0x00000001822686C0
		[FreeFunction("ScriptableRenderPipeline_Bindings::Internal_Cull")]
		private static void Internal_Cull(ref ScriptableCullingParameters parameters, ScriptableRenderContext renderLoop, IntPtr results); // 0x0000000182268910-0x0000000182268990
		[FreeFunction("ScriptableRenderPipeline_Bindings::Internal_CullShadowCasters")]
		private static void Internal_CullShadowCasters(ScriptableRenderContext renderLoop, IntPtr context); // 0x0000000182268840-0x00000001822688B0
		[FreeFunction("InitializeSortSettings")]
		internal static void InitializeSortSettings(Camera camera, out SortingSettings sortingSettings); // 0x0000000182268770-0x00000001822687F0
		private void Submit_Internal(); // 0x0000000182268990-0x00000001822689D0
		private void GetCameras_Internal(out List<Camera> resultList); // 0x00000001822685C0-0x0000000182268610
		[FreeFunction("PlayerEmitCanvasGeometryForCamera")]
		public static void EmitGeometryForCamera(Camera camera); // 0x0000000182267FC0-0x0000000182268030
		[NativeMethod(ThrowsException = true)]
		private void ExecuteCommandBuffer_Internal(CommandBuffer commandBuffer); // 0x00000001822683E0-0x0000000182268460
		[NativeMethod(ThrowsException = true)]
		private void ExecuteCommandBufferAsync_Internal(CommandBuffer commandBuffer, ComputeQueueType queueType); // 0x0000000182268190-0x0000000182268220
		internal IntPtr Internal_GetPtr(); // 0x00000001808BADD0-0x00000001808BADE0
		private RendererList CreateRendererList_Internal(IntPtr cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ShaderTagId tagName, bool isPassTagName, IntPtr tagValues, IntPtr stateBlocks, int stateCount); // 0x00000001822669F0-0x0000000182266AE0
		private RendererList CreateShadowRendererList_Internal(IntPtr shadowDrawinSettings); // 0x0000000182266D20-0x0000000182266DC0
		private RendererList CreateSkyboxRendererList_Internal([NotNull] Camera camera, int mode, Matrix4x4 proj, Matrix4x4 view, Matrix4x4 projR, Matrix4x4 viewR); // 0x0000000182266F20-0x0000000182267040
		private RendererList CreateGizmoRendererList_Internal([NotNull] Camera camera, GizmoSubset gizmoSubset); // 0x0000000182266720-0x0000000182266820
		private RendererList CreateUIOverlayRendererList_Internal([NotNull] Camera camera, UISubset uiSubset); // 0x00000001822678B0-0x00000001822679B0
		private RendererList CreateWireOverlayRendererList_Internal([NotNull] Camera camera); // 0x0000000182267B60-0x0000000182267C40
		public void Submit(); // 0x00000001822689D0-0x0000000182268A40
		public bool HasInvokeOnRenderObjectCallbacks(); // 0x00000001822686C0-0x0000000182268720
		internal void GetCameras(List<Camera> results); // 0x0000000182268610-0x0000000182268690
		public void ExecuteCommandBuffer(CommandBuffer commandBuffer); // 0x0000000182268460-0x00000001822685C0
		public void ExecuteCommandBufferAsync(CommandBuffer commandBuffer, ComputeQueueType queueType); // 0x0000000182268220-0x0000000182268390
		public CullingResults Cull(ref ScriptableCullingParameters parameters); // 0x0000000182267E90-0x0000000182267F80
		public void CullShadowCasters(CullingResults cullingResults, ShadowCastersCullingInfos infos); // 0x0000000182267D80-0x0000000182267E90
		public bool Equals(ScriptableRenderContext other); // 0x00000001822680F0-0x0000000182268130
		public override bool Equals(object obj); // 0x0000000182268030-0x00000001822680F0
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		public RendererList CreateRendererList(ref RendererListParams param); // 0x0000000182266AE0-0x0000000182266CC0
		public RendererList CreateShadowRendererList(ref ShadowDrawingSettings settings); // 0x0000000182266DC0-0x0000000182266EB0
		public RendererList CreateSkyboxRendererList(Camera camera, Matrix4x4 projectionMatrixL, Matrix4x4 viewMatrixL, Matrix4x4 projectionMatrixR, Matrix4x4 viewMatrixR); // 0x00000001822672C0-0x00000001822674D0
		public RendererList CreateSkyboxRendererList(Camera camera, Matrix4x4 projectionMatrix, Matrix4x4 viewMatrix); // 0x0000000182267040-0x00000001822672C0
		public RendererList CreateSkyboxRendererList(Camera camera); // 0x00000001822674D0-0x0000000182267840
		public RendererList CreateGizmoRendererList(Camera camera, GizmoSubset gizmoSubset); // 0x0000000182266820-0x0000000182266970
		public RendererList CreateUIOverlayRendererList(Camera camera, UISubset uiSubset); // 0x00000001822679B0-0x0000000182267B00
		public RendererList CreateWireOverlayRendererList(Camera camera); // 0x0000000182267C40-0x0000000182267D80
		private static void Internal_Cull_Injected(ref ScriptableCullingParameters parameters, in ScriptableRenderContext renderLoop, IntPtr results); // 0x00000001822688B0-0x0000000182268910
		private static void Internal_CullShadowCasters_Injected(in ScriptableRenderContext renderLoop, IntPtr context); // 0x00000001822687F0-0x0000000182268840
		private static void InitializeSortSettings_Injected(IntPtr camera, out SortingSettings sortingSettings); // 0x0000000182268720-0x0000000182268770
		private static void EmitGeometryForCamera_Injected(IntPtr camera); // 0x0000000182267F80-0x0000000182267FC0
		private static void ExecuteCommandBuffer_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr commandBuffer); // 0x0000000182268390-0x00000001822683E0
		private static void ExecuteCommandBufferAsync_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr commandBuffer, ComputeQueueType queueType); // 0x0000000182268130-0x0000000182268190
		private static void CreateRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, in ShaderTagId tagName, bool isPassTagName, IntPtr tagValues, IntPtr stateBlocks, int stateCount, ); // 0x0000000182266970-0x00000001822669F0
		private static void CreateShadowRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr shadowDrawinSettings, ); // 0x0000000182266CC0-0x0000000182266D20
		private static void CreateSkyboxRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, int mode, in Matrix4x4 proj, in Matrix4x4 view, in Matrix4x4 projR, in Matrix4x4 viewR, ); // 0x0000000182266EB0-0x0000000182266F20
		private static void CreateGizmoRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, GizmoSubset gizmoSubset, ); // 0x00000001822666B0-0x0000000182266720
		private static void CreateUIOverlayRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, UISubset uiSubset, ); // 0x0000000182267840-0x00000001822678B0
		private static void CreateWireOverlayRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr camera, ); // 0x0000000182267B00-0x0000000182267B60
	}
}
