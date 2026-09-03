/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	public static class NormalReconstruction // TypeDefIndex: 9898
	{
		// Fields
		private static readonly int s_NormalReconstructionMatrixID; // 0x00
		private static readonly Matrix4x4[] s_NormalReconstructionMatrix; // 0x08
	
		// Constructors
		static NormalReconstruction(); // 0x000000018202F410-0x000000018202F4B0
	
		// Methods
		public static void SetupProperties(CommandBuffer cmd, [IsReadOnly] in CameraData cameraData); // 0x000000018202F330-0x000000018202F410
		public static void SetupProperties(RasterCommandBuffer cmd, [IsReadOnly] in CameraData cameraData); // 0x000000018202EE30-0x000000018202EEB0
		public static void SetupProperties(CommandBuffer cmd, UniversalCameraData cameraData); // 0x000000018202F2A0-0x000000018202F330
		public static void SetupProperties(RasterCommandBuffer cmd, [IsReadOnly] in UniversalCameraData cameraData); // 0x000000018202EEB0-0x000000018202F2A0
	}
}
