/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("LightmapSettings", PersistentTypeId = 157)]
	[NativeHeader("Runtime/Graphics/LightmapSettings.h")]
	[StaticAccessor("GetLightmapSettings()")]
	public sealed class LightmapSettings : Object // TypeDefIndex: 7554
	{
		// Properties
		public static LightmapData[] lightmaps { [FreeFunction] get; [FreeFunction(ThrowsException = true)] set; } // 0x00000001821A5900-0x00000001821A5930 0x00000001821A59F0-0x00000001821A5A30
		public static LightmapsMode lightmapsMode { get; [FreeFunction(ThrowsException = true)] set; } // 0x00000001821A58D0-0x00000001821A5900 0x00000001821A59B0-0x00000001821A59F0
		public static LightProbes lightProbes { get; [NativeName("SetLightProbes")] [FreeFunction] set; } // 0x00000001821A5870-0x00000001821A58D0 0x00000001821A5970-0x00000001821A59B0
		[Obsolete("Use lightmapsMode instead.", false)]
		public static LightmapsModeLegacy lightmapsModeLegacy { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x00000001802E76C0-0x00000001802E76D0
		[Obsolete("Use QualitySettings.desiredColorSpace instead.", false)]
		public static ColorSpace bakedColorSpace { get; set; } // 0x00000001821A5810-0x00000001821A5840 0x00000001802E76C0-0x00000001802E76D0
	
		// Constructors
		private LightmapSettings(); // 0x00000001821A57C0-0x00000001821A5810
	
		// Methods
		[NativeName("ResetAndAwakeFromLoad")]
		internal static void Reset(); // 0x00000001821A5790-0x00000001821A57C0
		private static IntPtr get_lightProbes_Injected(); // 0x00000001821A5840-0x00000001821A5870
		private static void set_lightProbes_Injected(IntPtr value); // 0x00000001821A5930-0x00000001821A5970
	}
}
