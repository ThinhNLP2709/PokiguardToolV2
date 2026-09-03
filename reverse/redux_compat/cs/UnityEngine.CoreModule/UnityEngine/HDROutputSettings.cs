/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/GfxDevice/HDROutputSettings.h")]
	[UsedByNativeCode]
	public class HDROutputSettings // TypeDefIndex: 7557
	{
		// Fields
		private int m_DisplayIndex; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		public static HDROutputSettings[] displays; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		private static HDROutputSettings _mainDisplay; // 0x08
	
		// Properties
		public static HDROutputSettings main { get; } // 0x00000001821A38F0-0x00000001821A3940 
		public bool active { get; } // 0x00000001821A36C0-0x00000001821A3730 
		public bool available { get; } // 0x00000001821A37A0-0x00000001821A3810 
		public bool automaticHDRTonemapping { get; set; } // 0x00000001821A3730-0x00000001821A37A0 0x00000001821A3B00-0x00000001821A3B80
		public ColorGamut displayColorGamut { get; } // 0x00000001821A3810-0x00000001821A3880 
		public GraphicsFormat graphicsFormat { get; } // 0x00000001821A3880-0x00000001821A38F0 
		public float paperWhiteNits { get; } // 0x00000001821A3A90-0x00000001821A3B00 
		public int maxFullFrameToneMapLuminance { get; } // 0x00000001821A3940-0x00000001821A39B0 
		public int maxToneMapLuminance { get; } // 0x00000001821A39B0-0x00000001821A3A20 
		public int minToneMapLuminance { get; } // 0x00000001821A3A20-0x00000001821A3A90 
		public bool HDRModeChangeRequested { get; } // 0x00000001821A3650-0x00000001821A36C0 
	
		// Constructors
		[VisibleToOtherModules(new string[1] {"UnityEngine.XRModule" })]
		internal HDROutputSettings(); // 0x00000001821A3630-0x00000001821A3650
		[VisibleToOtherModules(new string[1] {"UnityEngine.XRModule" })]
		internal HDROutputSettings(int displayIndex); // 0x00000001802F9040-0x00000001802F9070
		static HDROutputSettings(); // 0x00000001821A3500-0x00000001821A3630
	
		// Methods
		public void RequestHDRModeChange(bool enabled); // 0x00000001821A3440-0x00000001821A34C0
		[FreeFunction("HDROutputSettingsBindings::GetActive", HasExplicitThis = false, ThrowsException = true)]
		private static bool GetActive(int displayIndex); // 0x00000001821A3180-0x00000001821A31C0
		[FreeFunction("HDROutputSettingsBindings::GetAvailable", HasExplicitThis = false, ThrowsException = true)]
		private static bool GetAvailable(int displayIndex); // 0x00000001821A3200-0x00000001821A3240
		[FreeFunction("HDROutputSettingsBindings::GetAutomaticHDRTonemapping", HasExplicitThis = false, ThrowsException = true)]
		private static bool GetAutomaticHDRTonemapping(int displayIndex); // 0x00000001821A31C0-0x00000001821A3200
		[FreeFunction("HDROutputSettingsBindings::SetAutomaticHDRTonemapping", HasExplicitThis = false, ThrowsException = true)]
		private static void SetAutomaticHDRTonemapping(int displayIndex, bool scripted); // 0x00000001821A34C0-0x00000001821A3500
		[FreeFunction("HDROutputSettingsBindings::GetDisplayColorGamut", HasExplicitThis = false, ThrowsException = true)]
		private static ColorGamut GetDisplayColorGamut(int displayIndex); // 0x00000001821A3240-0x00000001821A3280
		[FreeFunction("HDROutputSettingsBindings::GetGraphicsFormat", HasExplicitThis = false, ThrowsException = true)]
		private static GraphicsFormat GetGraphicsFormat(int displayIndex); // 0x00000001821A3280-0x00000001821A32C0
		[FreeFunction("HDROutputSettingsBindings::GetPaperWhiteNits", HasExplicitThis = false, ThrowsException = true)]
		private static float GetPaperWhiteNits(int displayIndex); // 0x00000001821A33C0-0x00000001821A3400
		[FreeFunction("HDROutputSettingsBindings::GetMaxFullFrameToneMapLuminance", HasExplicitThis = false, ThrowsException = true)]
		private static int GetMaxFullFrameToneMapLuminance(int displayIndex); // 0x00000001821A3300-0x00000001821A3340
		[FreeFunction("HDROutputSettingsBindings::GetMaxToneMapLuminance", HasExplicitThis = false, ThrowsException = true)]
		private static int GetMaxToneMapLuminance(int displayIndex); // 0x00000001821A3340-0x00000001821A3380
		[FreeFunction("HDROutputSettingsBindings::GetMinToneMapLuminance", HasExplicitThis = false, ThrowsException = true)]
		private static int GetMinToneMapLuminance(int displayIndex); // 0x00000001821A3380-0x00000001821A33C0
		[FreeFunction("HDROutputSettingsBindings::GetHDRModeChangeRequested", HasExplicitThis = false, ThrowsException = true)]
		private static bool GetHDRModeChangeRequested(int displayIndex); // 0x00000001821A32C0-0x00000001821A3300
		[FreeFunction("HDROutputSettingsBindings::RequestHDRModeChange", HasExplicitThis = false, ThrowsException = true)]
		private static void RequestHDRModeChangeInternal(int displayIndex, bool enabled); // 0x00000001821A3400-0x00000001821A3440
	}
}
