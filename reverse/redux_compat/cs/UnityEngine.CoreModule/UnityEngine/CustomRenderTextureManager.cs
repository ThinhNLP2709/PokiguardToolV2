/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Graphics/CustomRenderTextureManager.h")]
	public static class CustomRenderTextureManager // TypeDefIndex: 7537
	{
		// Fields
		[CompilerGenerated]
		private static Action<CustomRenderTexture> textureLoaded; // 0x00
		[CompilerGenerated]
		private static Action<CustomRenderTexture> textureUnloaded; // 0x08
	
		// Methods
		[RequiredByNativeCode]
		private static void InvokeOnTextureLoaded_Internal(CustomRenderTexture source); // 0x000000018219D1A0-0x000000018219D200
		[RequiredByNativeCode]
		private static void InvokeOnTextureUnloaded_Internal(CustomRenderTexture source); // 0x000000018219D200-0x000000018219D260
	}
}
