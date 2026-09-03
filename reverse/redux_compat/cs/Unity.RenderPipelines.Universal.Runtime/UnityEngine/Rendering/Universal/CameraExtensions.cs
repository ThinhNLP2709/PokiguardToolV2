/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public static class CameraExtensions // TypeDefIndex: 9812
	{
		// Extension methods
		public static UniversalAdditionalCameraData GetUniversalAdditionalCameraData(this Camera camera); // 0x0000000181FF6280-0x0000000181FF6310
		public static VolumeFrameworkUpdateMode GetVolumeFrameworkUpdateMode(this Camera camera); // 0x0000000181FF6310-0x0000000181FF63B0
		public static void SetVolumeFrameworkUpdateMode(this Camera camera, VolumeFrameworkUpdateMode mode); // 0x0000000181FF6700-0x0000000181FF67F0
		public static void UpdateVolumeStack(this Camera camera); // 0x0000000181FF67F0-0x0000000181FF68A0
		public static void UpdateVolumeStack(this Camera camera, UniversalAdditionalCameraData cameraData); // 0x0000000181FF68A0-0x0000000181FF69E0
		public static void DestroyVolumeStack(this Camera camera); // 0x0000000181FF6180-0x0000000181FF6280
		public static void DestroyVolumeStack(this Camera camera, UniversalAdditionalCameraData cameraData); // 0x0000000181FF6100-0x0000000181FF6180
		internal static void GetVolumeLayerMaskAndTrigger(this Camera camera, UniversalAdditionalCameraData cameraData, out LayerMask layerMask, out Transform trigger); // 0x0000000181FF63B0-0x0000000181FF6700
	}
}
