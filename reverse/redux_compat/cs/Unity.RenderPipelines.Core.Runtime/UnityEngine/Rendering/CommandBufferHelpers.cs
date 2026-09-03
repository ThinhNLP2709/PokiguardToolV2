/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.VFX;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public struct CommandBufferHelpers // TypeDefIndex: 5330
	{
		// Fields
		[NoAutoStaticsCleanup]
		internal static RasterCommandBuffer rasterCmd; // 0x00
		[NoAutoStaticsCleanup]
		internal static ComputeCommandBuffer computeCmd; // 0x08
		[NoAutoStaticsCleanup]
		internal static UnsafeCommandBuffer unsafeCmd; // 0x10
	
		// Constructors
		static CommandBufferHelpers(); // 0x0000000181E1EED0-0x0000000181E1F050
	
		// Methods
		public static RasterCommandBuffer GetRasterCommandBuffer(CommandBuffer baseBuffer); // 0x0000000181E1ED10-0x0000000181E1ED90
		public static ComputeCommandBuffer GetComputeCommandBuffer(CommandBuffer baseBuffer); // 0x0000000181E1EC80-0x0000000181E1ED10
		public static UnsafeCommandBuffer GetUnsafeCommandBuffer(CommandBuffer baseBuffer); // 0x0000000181E1ED90-0x0000000181E1EE20
		public static CommandBuffer GetNativeCommandBuffer(UnsafeCommandBuffer baseBuffer); // 0x00000001808586A0-0x00000001808586C0
		public static void VFXManager_ProcessCameraCommand(Camera cam, UnsafeCommandBuffer cmd, VFXCameraXRSettings camXRSettings, CullingResults results); // 0x0000000181E1EE20-0x0000000181E1EED0
	}
}
