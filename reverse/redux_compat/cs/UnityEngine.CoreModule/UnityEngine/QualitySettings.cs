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
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("QualitySettings", PersistentTypeId = 47)]
	[NativeHeader("Runtime/Graphics/QualitySettings.h")]
	[NativeHeader("Runtime/Misc/PlayerSettings.h")]
	[StaticAccessor("GetQualitySettings()", StaticAccessorType.Dot)]
	public sealed class QualitySettings : Object // TypeDefIndex: 7563
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static QualityLevelRemovalScope s_RemovalScope; // 0x00
		[CompilerGenerated]
		private static Action<int, int, int> activeQualityLevelIndexChanged; // 0x08
		[CompilerGenerated]
		private static Action<int, int> activeQualityLevelChanged; // 0x10
	
		// Properties
		[NativeProperty("ShadowmaskMode")]
		public static ShadowmaskMode shadowmaskMode { get; } // 0x00000001821BB550-0x00000001821BB580 
		[NativeProperty("LODBias")]
		public static float lodBias { get; set; } // 0x00000001821BB4C0-0x00000001821BB4F0 0x00000001821BB630-0x00000001821BB670
		[NativeProperty("MeshLODThreshold")]
		public static float meshLodThreshold { get; } // 0x00000001821BB520-0x00000001821BB550 
		public static int maximumLODLevel { get; } // 0x00000001821BB4F0-0x00000001821BB520 
		public static bool enableLODCrossFade { get; set; } // 0x00000001821BB490-0x00000001821BB4C0 0x00000001821BB5F0-0x00000001821BB630
		public static int vSyncCount { get; set; } // 0x00000001821BB580-0x00000001821BB5B0 0x00000001821BB670-0x00000001821BB6B0
		public static int antiAliasing { get; set; } // 0x00000001821BB400-0x00000001821BB430 0x00000001821BB5B0-0x00000001821BB5F0
		public static bool billboardsFaceCameraPosition { get; } // 0x00000001821BB430-0x00000001821BB460 
		public static int count { [NativeName("GetQualitySettingsCount")] get; } // 0x00000001821BB460-0x00000001821BB490 
		public static ColorSpace desiredColorSpace { [NativeName("GetColorSpace")] [StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)] get; } // 0x00000001821A5810-0x00000001821A5840 
		public static ColorSpace activeColorSpace { [NativeName("GetColorSpace")] [StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)] get; } // 0x00000001821BB3D0-0x00000001821BB400 
	
		// Nested types
		internal class QualityLevelRemovalScope // TypeDefIndex: 7564
		{
			// Fields
			[CompilerGenerated]
			private int _qualityLevelIndexBeingRemoved_k__BackingField; // 0x10
	
			// Properties
			public int qualityLevelIndexBeingRemoved { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
		}
	
		// Methods
		[RequiredByNativeCode]
		internal static void OnActiveQualityLevelChanged(int previousQualityLevel, int currentQualityLevel); // 0x00000001821BB2E0-0x00000001821BB3D0
	}
}
