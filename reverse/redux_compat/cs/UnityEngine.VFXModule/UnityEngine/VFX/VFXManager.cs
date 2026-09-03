/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 57: UnityEngine.VFXModule.dll - Assembly: UnityEngine.VFXModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15667-15684

namespace UnityEngine.VFX
{
	[NativeHeader("Modules/VFX/Public/VFXManager.h")]
	[NativeHeader("Modules/VFX/Public/ScriptBindings/VFXManagerBindings.h")]
	[RequiredByNativeCode]
	[StaticAccessor("GetVFXManager()", StaticAccessorType.Dot)]
	public static class VFXManager // TypeDefIndex: 15677
	{
		// Fields
		private static readonly VFXCameraXRSettings kDefaultCameraXRSettings; // 0x00
	
		// Constructors
		static VFXManager(); // 0x00000001825D2500-0x00000001825D2560
	
		// Methods
		public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, CullingResults results); // 0x00000001825D2260-0x00000001825D23B0
		private static void Internal_ProcessCameraCommand([NotNull] Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, IntPtr cullResults, IntPtr customPassCullResults); // 0x00000001825D2060-0x00000001825D2160
		public static VFXCameraBufferTypes IsCameraBufferNeeded([NotNull] Camera cam); // 0x00000001825D21A0-0x00000001825D2260
		public static void SetCameraBuffer([NotNull] Camera cam, VFXCameraBufferTypes type, Texture buffer, int x, int y, int width, int height); // 0x00000001825D2410-0x00000001825D2500
		private static void Internal_ProcessCameraCommand_Injected(IntPtr cam, IntPtr cmd, in VFXCameraXRSettings camXRSettings, IntPtr cullResults, IntPtr customPassCullResults); // 0x00000001825D1FF0-0x00000001825D2060
		private static VFXCameraBufferTypes IsCameraBufferNeeded_Injected(IntPtr cam); // 0x00000001825D2160-0x00000001825D21A0
		private static void SetCameraBuffer_Injected(IntPtr cam, VFXCameraBufferTypes type, IntPtr buffer, int x, int y, int width, int height); // 0x00000001825D23B0-0x00000001825D2410
	}
}
