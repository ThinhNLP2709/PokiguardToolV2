/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public static class RenderPipelineManager // TypeDefIndex: 8427
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static bool s_CleanUpPipeline; // 0x00
		[NoAutoStaticsCleanup]
		private static RenderPipelineAsset s_CurrentPipelineAsset; // 0x08
		[NoAutoStaticsCleanup]
		private static RenderPipeline s_CurrentPipeline; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		private static bool s_PendingRPAssignationToRaise; // 0x18
		[CompilerGenerated]
		private static Action<ScriptableRenderContext, List<Camera>> beginContextRendering; // 0x20
		[CompilerGenerated]
		private static Action<ScriptableRenderContext, List<Camera>> endContextRendering; // 0x28
		[CompilerGenerated]
		private static Action<ScriptableRenderContext, Camera> beginCameraRendering; // 0x30
		[CompilerGenerated]
		private static Action<ScriptableRenderContext, Camera> endCameraRendering; // 0x38
		[CompilerGenerated]
		private static Action activeRenderPipelineTypeChanged; // 0x40
		[CompilerGenerated]
		private static Action<RenderPipelineAsset, RenderPipelineAsset> activeRenderPipelineAssetChanged; // 0x48
		[CompilerGenerated]
		private static Action activeRenderPipelineCreated; // 0x50
		[CompilerGenerated]
		private static Action activeRenderPipelineDisposed; // 0x58
		[CompilerGenerated]
		private static Action<ScriptableRenderContext, Camera[]> beginFrameRendering; // 0x60
		[CompilerGenerated]
		private static Action<ScriptableRenderContext, Camera[]> endFrameRendering; // 0x68
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x70
	
		// Properties
		public static RenderPipeline currentPipeline { get; private set; } // 0x0000000182261D00-0x0000000182261D50 0x0000000182262650-0x0000000182262710
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<ScriptableRenderContext, List<Camera>> beginContextRendering {
			add; // 0x0000000182261850-0x0000000182261940
			remove; // 0x00000001822621A0-0x0000000182262290
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<ScriptableRenderContext, List<Camera>> endContextRendering {
			add; // 0x0000000182261B20-0x0000000182261C10
			remove; // 0x0000000182262470-0x0000000182262560
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<ScriptableRenderContext, Camera> beginCameraRendering {
			add; // 0x0000000182261760-0x0000000182261850
			remove; // 0x00000001822620B0-0x00000001822621A0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<ScriptableRenderContext, Camera> endCameraRendering {
			add; // 0x0000000182261A30-0x0000000182261B20
			remove; // 0x0000000182262380-0x0000000182262470
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action activeRenderPipelineTypeChanged {
			add; // 0x0000000182261690-0x0000000182261760
			remove; // 0x0000000182261FE0-0x00000001822620B0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<RenderPipelineAsset, RenderPipelineAsset> activeRenderPipelineAssetChanged {
			add; // 0x0000000182261400-0x00000001822614F0
			remove; // 0x0000000182261D50-0x0000000182261E40
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action activeRenderPipelineCreated {
			add; // 0x00000001822614F0-0x00000001822615C0
			remove; // 0x0000000182261E40-0x0000000182261F10
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action activeRenderPipelineDisposed {
			add; // 0x00000001822615C0-0x0000000182261690
			remove; // 0x0000000182261F10-0x0000000182261FE0
		}
		[AutoStaticsCleanupOnCodeReload]
		[Obsolete("beginFrameRendering is deprecated. Use beginContextRendering instead. #from 2023.3", false)]
		public static event Action<ScriptableRenderContext, Camera[]> beginFrameRendering {
			add; // 0x0000000182261940-0x0000000182261A30
			remove; // 0x0000000182262290-0x0000000182262380
		}
		[AutoStaticsCleanupOnCodeReload]
		[Obsolete("endFrameRendering is deprecated. Use endContextRendering instead. #from 2023.3", false)]
		public static event Action<ScriptableRenderContext, Camera[]> endFrameRendering {
			add; // 0x0000000182261C10-0x0000000182261D00
			remove; // 0x0000000182262560-0x0000000182262650
		}
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 8428
		{
			// Fields
			public static Action _0___OnCodeUnloading; // 0x00
		}
	
		// Constructors
		static RenderPipelineManager(); // 0x0000000182261290-0x0000000182261400
	
		// Methods
		internal static void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras); // 0x000000018225F200-0x000000018225F2E0
		internal static void BeginCameraRendering(ScriptableRenderContext context, Camera camera); // 0x000000018225F180-0x000000018225F200
		internal static void EndContextRendering(ScriptableRenderContext context, List<Camera> cameras); // 0x000000018225F950-0x000000018225FA30
		internal static void EndCameraRendering(ScriptableRenderContext context, Camera camera); // 0x000000018225F8D0-0x000000018225F950
		[RequiredByNativeCode]
		private static void OnActiveRenderPipelineAssetChanged(ScriptableObject from, ScriptableObject to, bool raiseTypeChanged); // 0x000000018225FCA0-0x000000018225FEF0
		[RequiredByNativeCode]
		internal static void HandleRenderPipelineChange(RenderPipelineAsset pipelineAsset); // 0x000000018225FA30-0x000000018225FAD0
		[RequiredByNativeCode]
		internal static void RecreateCurrentPipeline(RenderPipelineAsset pipelineAsset); // 0x000000018225FF30-0x000000018225FFE0
		private static void OnCodeUnloading(); // 0x000000018225FEF0-0x000000018225FF30
		[RequiredByNativeCode]
		internal static void CleanupRenderPipeline(); // 0x000000018225F2E0-0x000000018225F550
		[RequiredByNativeCode]
		private static void DoRenderLoop_Internal(RenderPipelineAsset pipelineAsset, IntPtr loopPtr, object renderRequest); // 0x000000018225F550-0x000000018225F8D0
		internal static bool TryPrepareRenderPipeline(RenderPipelineAsset pipelineAsset); // 0x000000018225FFE0-0x00000001822602C0
		[RequiredByNativeCode]
		private static void InitializeGlobalRenderPipelineTag(); // 0x000000018225FAD0-0x000000018225FB60
		[RequiredByNativeCode]
		internal static bool IsCurrentRenderPipelineValid(); // 0x000000018225FB60-0x000000018225FC00
		private static bool IsPipelineRequireCreation(); // 0x000000018225FC00-0x000000018225FCA0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182260410-0x0000000182261290
		[CompilerGenerated]
		internal static void UnityEngine_Rendering_RenderPipelineManager_OnCodeUnloading_RegisterLifecycleMethod(); // 0x00000001822602C0-0x0000000182260410
	}
}
