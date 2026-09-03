/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 46: UnityEngine.XRModule.dll - Assembly: UnityEngine.XRModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15337-15374

namespace UnityEngine.XR
{
	[NativeConditional("ENABLE_VR")]
	[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
	[NativeHeader("Runtime/Interfaces/IVRDevice.h")]
	[NativeHeader("Modules/XR/ScriptBindings/XR.bindings.h")]
	public static class XRSettings // TypeDefIndex: 15345
	{
		// Properties
		public static bool enabled { [StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType.ArrowWithDefaultReturnIfNull)] get; } // 0x00000001825D8070-0x00000001825D80A0 
		[NativeName("Active")]
		[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType.ArrowWithDefaultReturnIfNull)]
		public static bool isDeviceActive { get; } // 0x00000001825D8190-0x00000001825D81C0 
		[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType.ArrowWithDefaultReturnIfNull)]
		public static int eyeTextureWidth { get; } // 0x00000001825D8160-0x00000001825D8190 
		[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType.ArrowWithDefaultReturnIfNull)]
		public static int eyeTextureHeight { get; } // 0x00000001825D8130-0x00000001825D8160 
		[NativeConditional("ENABLE_VR", "RenderTextureDesc()")]
		[NativeName("IntermediateEyeTextureDesc")]
		[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType.ArrowWithDefaultReturnIfNull)]
		public static RenderTextureDescriptor eyeTextureDesc { get; } // 0x00000001825D80E0-0x00000001825D8130 
		[NativeName("DeviceName")]
		[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType.ArrowWithDefaultReturnIfNull)]
		public static string loadedDeviceName { get; } // 0x00000001825D8200-0x00000001825D82C0 
		public static string[] supportedDevices { get; } // 0x00000001825D82C0-0x00000001825D8420 
	
		// Methods
		private static void get_eyeTextureDesc_Injected(); // 0x00000001825D80A0-0x00000001825D80E0
		private static void get_loadedDeviceName_Injected(); // 0x00000001825D81C0-0x00000001825D8200
	}
}
