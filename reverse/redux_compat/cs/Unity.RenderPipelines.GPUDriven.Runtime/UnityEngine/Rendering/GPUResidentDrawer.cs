/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.SceneManagement;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile]
	public class GPUResidentDrawer // TypeDefIndex: 12922
	{
		// Fields
		internal const bool EnableValidation = false; // Metadata: 0x006A764D
		internal const bool EnableDeepValidation = false; // Metadata: 0x006A764E
		[CompilerGenerated]
		private static bool _MaintainContext_k__BackingField; // 0x00
		[CompilerGenerated]
		private static bool _ForceOcclusion_k__BackingField; // 0x01
		[AutoStaticsCleanup]
		private static uint s_InstanceVersion; // 0x04
		[AutoStaticsCleanup]
		internal static Action<bool, bool> initializedChanged; // 0x08
		[NoAutoStaticsCleanup]
		private static GPUResidentDrawer s_Instance; // 0x10
		private IntPtr m_ContextIntPtr; // 0x10
		private GPUResidentDrawerSettings m_Settings; // 0x18
		private InternalGPUResidentDrawerSettings m_InternalSettings; // 0x40
		internal GPUDrivenProcessor m_GPUDrivenProcessor; // 0x60
		internal ObjectDispatcher m_ObjectDispatcher; // 0x68
		internal InstanceDataSystem m_InstanceDataSystem; // 0x70
		internal LODGroupDataSystem m_LODGroupDataSystem; // 0x78
		internal InstanceCuller m_Culler; // 0x80
		internal OcclusionCullingCommon m_OcclusionCullingCommon; // 0x88
		internal InstanceCullingBatcher m_Batcher; // 0x90
		internal GPUResidentContext m_GRDContext; // 0x98
		internal SpeedTreeWindGPUDataUpdater m_SpeedTreeWindGPUDataUpdater; // 0xA0
		internal WorldProcessor m_WorldProcessor; // 0xA8
		private DebugDisplayGPUResidentDrawer m_DebugDisplaySettings; // 0xB0
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_UnityEngine_PlayModeScope_Both; // 0x18
	
		// Properties
		[AutoStaticsCleanup]
		internal static bool MaintainContext { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F38480-0x0000000181F384D0 0x0000000181F38590-0x0000000181F385F0
		[AutoStaticsCleanup]
		internal static bool ForceOcclusion { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181F38430-0x0000000181F38480 0x0000000181F38530-0x0000000181F38590
		internal static DebugDisplayGPUResidentDrawer debugDisplaySettings { get; } // 0x0000000181F384D0-0x0000000181F38530 
		internal GPUResidentDrawerSettings settings { get; } // 0x0000000181107130-0x0000000181107150 
	
		// Nested types
		private static class Strings // TypeDefIndex: 12923
		{
			// Fields
			public static readonly string drawerModeDisabled; // 0x00
			public static readonly string allowInEditModeDisabled; // 0x08
			public static readonly string notGPUResidentRenderPipeline; // 0x10
			public static readonly string rawBufferNotSupportedByPlatform; // 0x18
			public static readonly string kernelNotPresent; // 0x20
			public static readonly string batchRendererGroupShaderStrippingModeInvalid; // 0x28
			public static readonly string visionOSNotSupported; // 0x30
	
			// Constructors
			static Strings(); // 0x0000000181F48D90-0x0000000181F48FD0
		}
	
		// Constructors
		internal GPUResidentDrawer([IsReadOnly] in GPUResidentDrawerSettings settings); // 0x0000000181F37890-0x0000000181F37900
		internal GPUResidentDrawer([IsReadOnly] in GPUResidentDrawerSettings settings, [IsReadOnly] in InternalGPUResidentDrawerSettings internalSettings); // 0x0000000181F37900-0x0000000181F38430
		static GPUResidentDrawer(); // 0x0000000181F37780-0x0000000181F37890
	
		// Methods
		internal static bool IsProjectSupported(); // 0x0000000181F36130-0x0000000181F36190
		internal static bool IsProjectSupported(out string message, out LogType severity); // 0x0000000181F36000-0x0000000181F36130
		internal static bool IsGPUResidentDrawerSupportedBySRP(GPUResidentDrawerSettings settings, out string message, out LogType severity); // 0x0000000181F35D00-0x0000000181F35F10
		internal static void LogMessage(string message, LogType severity); // 0x0000000181F36190-0x0000000181F36230
		public static bool IsInstanceOcclusionCullingEnabled(); // 0x0000000181F35F70-0x0000000181F36000
		public static void PostCullBeginCameraRendering(RenderRequestBatcherContext context); // 0x0000000181F36510-0x0000000181F36550
		public static void OnSetupAmbientProbe(); // 0x0000000181F364A0-0x0000000181F36510
		public static void InstanceOcclusionTest(RenderGraph renderGraph, [IsReadOnly] in OcclusionCullingSettings settings, ReadOnlySpan<SubviewOcclusionTest> subviewOcclusionTests); // 0x0000000181F35BD0-0x0000000181F35CB0
		public static void UpdateInstanceOccluders(RenderGraph renderGraph, [IsReadOnly] in OccluderParameters occluderParameters, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates); // 0x0000000181F37590-0x0000000181F37670
		public static void ReinitializeIfNeeded(); // 0x00000001802E76C0-0x00000001802E76D0
		public static void RenderDebugOcclusionTestOverlay(RenderGraph renderGraph, DebugDisplayGPUResidentDrawer debugSettings, EntityId viewID, TextureHandle colorBuffer); // 0x0000000181F372C0-0x0000000181F37380
		public static void RenderDebugOccluderOverlay(RenderGraph renderGraph, DebugDisplayGPUResidentDrawer debugSettings, Vector2 screenPos, float maxHeight, TextureHandle colorBuffer); // 0x0000000181F371F0-0x0000000181F372C0
		public static void SetBatchingTypeDebugView(bool enabled); // 0x00000001802E76C0-0x00000001802E76D0
		internal static bool IsEnabledFromSettings(); // 0x0000000181F35CB0-0x0000000181F35D00
		internal static bool IsInitialized(); // 0x0000000181F35F10-0x0000000181F35F70
		internal static uint GetInstanceVersion(); // 0x0000000181F35690-0x0000000181F356E0
		internal static NativeReference<GPUArchetypeManager> GetGPUArchetypeManager(); // 0x0000000181F35340-0x0000000181F353D0
		internal static ref DefaultGPUComponents GetDefaultGPUComponents(); // 0x0000000181F352D0-0x0000000181F35340
		internal static GPUInstanceDataBuffer.ReadOnly GetInstanceDataBuffer(); // 0x0000000181F355B0-0x0000000181F35690
		internal static GPUInstanceDataBufferReadback<T> ReadbackInstanceDataBuffer<T>()
			where T : struct;
		internal static DebugRendererBatcherStats GetDebugStats(); // 0x0000000181F35260-0x0000000181F352D0
		internal static void PushMeshRendererUpdateBatches(NativeArray<MeshRendererUpdateBatch> batches); // 0x0000000181F36950-0x0000000181F369E0
		internal static void PushLODGroupUpdateBatches(NativeArray<LODGroupUpdateBatch> batches); // 0x0000000181F36830-0x0000000181F368C0
		internal static void PushMeshRendererDeletionBatches(NativeArray<NativeArray<EntityId>> batches); // 0x0000000181F368C0-0x0000000181F36950
		internal static void PushLODGroupDeletionBatches(NativeArray<NativeArray<EntityId>> batches); // 0x0000000181F367A0-0x0000000181F36830
		private void InsertIntoPlayerLoop(); // 0x0000000181F356E0-0x0000000181F35BD0
		private void RemoveFromPlayerLoop(); // 0x0000000181F36E50-0x0000000181F371F0
		internal static GPUResidentDrawerSettings GetGlobalSettingsFromRPAsset(); // 0x0000000181F353D0-0x0000000181F355B0
		internal static bool IsForcedOnViaCommandLine(); // 0x00000001802E7840-0x00000001802E7850
		internal static bool IsOcclusionForcedOnViaCommandLine(); // 0x00000001802E7840-0x00000001802E7850
		internal static void Reinitialize(); // 0x0000000181F36DD0-0x0000000181F36E50
		private static void Cleanup(); // 0x0000000181F34BC0-0x0000000181F34CD0
		private static void Recreate(GPUResidentDrawerSettings settings); // 0x0000000181F369E0-0x0000000181F36DD0
		internal void Dispose(); // 0x0000000181F34DB0-0x0000000181F35260
		private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000181F36480-0x0000000181F364A0
		private static void PostPostLateUpdateStatic(); // 0x0000000181F36550-0x0000000181F366A0
		private void OnBeginContextRendering(ScriptableRenderContext context, List<Camera> cameras); // 0x0000000181F36260-0x0000000181F36330
		private void OnEndContextRendering(ScriptableRenderContext context, List<Camera> cameras); // 0x0000000181F36330-0x0000000181F36410
		private void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera); // 0x0000000181F36230-0x0000000181F36260
		private void OnEndCameraRendering(ScriptableRenderContext context, Camera camera); // 0x0000000181F36230-0x0000000181F36260
		private void OnFinishedCulling(IntPtr customCullingResult); // 0x0000000181F36410-0x0000000181F36480
		private void OnPostCullBeginCameraRendering(RenderRequestBatcherContext context); // 0x00000001802E76C0-0x00000001802E76D0
		private void UpdateAmbientProbeAndGPUBuffer(bool forceUpdate); // 0x0000000181F37380-0x0000000181F37590
		private void CullerUpdateFrame(); // 0x0000000181F34CD0-0x0000000181F34DB0
		private void PostPostLateUpdate(); // 0x0000000181F366A0-0x0000000181F367A0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_UnityEngine_PlayModeScope_Both(); // 0x0000000181F37670-0x0000000181F37780
	}
}
