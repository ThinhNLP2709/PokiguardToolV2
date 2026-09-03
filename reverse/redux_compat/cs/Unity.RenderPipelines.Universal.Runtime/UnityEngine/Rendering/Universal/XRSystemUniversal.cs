/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal static class XRSystemUniversal // TypeDefIndex: 9879
	{
		// Fields
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_projMatrix; // 0x00
		[AutoStaticsCleanup]
		private static MaterialPropertyBlock s_XRSharedPropertyBlock; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_UnityEngine_PlayModeScope_Both; // 0x10
	
		// Constructors
		static XRSystemUniversal(); // 0x00000001820314E0-0x0000000182031630
	
		// Methods
		internal static MaterialPropertyBlock GetMaterialPropertyBlock(); // 0x0000000182031090-0x00000001820310E0
		internal static void BeginLateLatching(Camera camera, XRPassUniversal xrPass); // 0x0000000182030EE0-0x0000000182030FC0
		internal static void EndLateLatching(Camera camera, XRPassUniversal xrPass); // 0x0000000182030FC0-0x0000000182031090
		internal static void UnmarkShaderProperties(RasterCommandBuffer cmd, XRPassUniversal xrPass); // 0x0000000182031350-0x00000001820313D0
		internal static void MarkShaderProperties(RasterCommandBuffer cmd, XRPassUniversal xrPass, bool renderIntoTexture); // 0x00000001820310E0-0x0000000182031350
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_UnityEngine_PlayModeScope_Both(); // 0x00000001820313D0-0x00000001820314E0
	}
}
