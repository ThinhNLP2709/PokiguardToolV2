/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class UnloadingUtility // TypeDefIndex: 4871
	{
		// Fields
		private static Action[] s_Subscribers; // 0x00
		private static ProfilerMarker s_CodeUnloadingMarker; // 0x08
		[CompilerGenerated]
		private static bool _isUnloaded_k__BackingField; // 0x10
	
		// Properties
		private static bool isUnloaded { [CompilerGenerated] set; } // 0x00000001823E0E00-0x00000001823E0E60
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 4872
		{
			// Fields
			public static Action _0___OnCodeLoaded; // 0x00
			public static Action _1___OnCodeUnloading; // 0x08
		}
	
		// Constructors
		static UnloadingUtility(); // 0x00000001823E0D50-0x00000001823E0E00
	
		// Methods
		private static void OnCodeLoaded(); // 0x00000001823E06B0-0x00000001823E0740
		private static void OnCodeUnloading(); // 0x00000001823E0740-0x00000001823E09C0
		internal static void SubscribeToUnloading(UnloadingSubscriber subscriber, Action callback); // 0x00000001823E09C0-0x00000001823E0AB0
		[CompilerGenerated]
		internal static void UnityEngine_UIElements_UnloadingUtility_OnCodeLoaded_RegisterLifecycleMethod(); // 0x00000001823E0AB0-0x00000001823E0C00
		[CompilerGenerated]
		internal static void UnityEngine_UIElements_UnloadingUtility_OnCodeUnloading_RegisterLifecycleMethod(); // 0x00000001823E0C00-0x00000001823E0D50
	}
}
