/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	public static class XRBuiltinShaderConstants // TypeDefIndex: 5308
	{
		// Fields
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoCameraProjection; // 0x00
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoCameraInvProjection; // 0x04
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoMatrixV; // 0x08
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoMatrixInvV; // 0x0C
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoMatrixP; // 0x10
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoMatrixInvP; // 0x14
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoMatrixVP; // 0x18
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoMatrixInvVP; // 0x1C
		[NoAutoStaticsCleanup]
		public static readonly int unity_StereoWorldSpaceCameraPos; // 0x20
		public static readonly int unity_StereoEyeIndex; // 0x24
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_cameraProjMatrix; // 0x28
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_invCameraProjMatrix; // 0x30
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_viewMatrix; // 0x38
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_invViewMatrix; // 0x40
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_projMatrix; // 0x48
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_invProjMatrix; // 0x50
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_viewProjMatrix; // 0x58
		[AutoStaticsCleanup]
		private static Matrix4x4[] s_invViewProjMatrix; // 0x60
		[AutoStaticsCleanup]
		private static Vector4[] s_worldSpaceCameraPos; // 0x68
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_UnityEngine_PlayModeScope_Both; // 0x70
	
		// Constructors
		static XRBuiltinShaderConstants(); // 0x0000000181E2A710-0x0000000181E2ABB0
	
		// Methods
		public static void UpdateBuiltinShaderConstants(Matrix4x4 viewMatrix, Matrix4x4 projMatrix, bool renderIntoTexture, int viewIndex); // 0x0000000181E29700-0x0000000181E29BD0
		public static void SetBuiltinShaderConstants(CommandBuffer cmd); // 0x0000000181E29580-0x0000000181E29700
		public static void SetBuiltinShaderConstants(RasterCommandBuffer cmd); // 0x0000000181E293B0-0x0000000181E29580
		public static void Update(XRPass xrPass, CommandBuffer cmd, bool renderIntoTexture); // 0x0000000181E29BD0-0x0000000181E2A3D0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_UnityEngine_PlayModeScope_Both(); // 0x0000000181E2A3D0-0x0000000181E2A710
	}
}
