/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[RequiredByNativeCode]
	internal static class GPUDrivenCallbacks // TypeDefIndex: 8376
	{
		// Methods
		[RequiredByNativeCode(GenerateProxy = true)]
		public static void InvokeGPUDrivenLODGroupDataNativeCallback(IntPtr nativeDataPtr, GPUDrivenLODGroupDataCallback callback); // 0x000000018225ADD0-0x000000018225B020
		[RequiredByNativeCode(GenerateProxy = true)]
		public static void InvokeGPUDrivenRendererDataNativeCallback(IntPtr nativeDataPtr, GPUDrivenRendererDataCallback callback); // 0x000000018225B020-0x000000018225B550
		[RequiredByNativeCode(GenerateProxy = true)]
		public static void InvokeOnFetchMeshesData(IntPtr nativeDataPtr, GPUDrivenFetchMeshesDataCallback callback); // 0x000000018225B550-0x000000018225B6A0
	}
}
