/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.AdaptivePerformance.Provider;

// Image 79: Unity.AdaptivePerformance.Samsung.Android.dll - Assembly: Unity.AdaptivePerformance.Samsung.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15913-15920

namespace UnityEngine.AdaptivePerformance.Samsung.Android
{
	public class SamsungAndroidProviderLoader : AdaptivePerformanceLoaderHelper // TypeDefIndex: 15916
	{
		// Fields
		private static List<AdaptivePerformanceSubsystemDescriptor> s_SamsungGameSDKSubsystemDescriptors; // 0x00
	
		// Properties
		public override bool Initialized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool Running { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		public SamsungAndroidProviderLoader(); // 0x0000000181C63F50-0x0000000181C63F60
		static SamsungAndroidProviderLoader(); // 0x0000000181C63EC0-0x0000000181C63F50
	
		// Methods
		public override ISubsystem GetDefaultSubsystem(); // 0x00000001802E7860-0x00000001802E7870
		public override IAdaptivePerformanceSettings GetSettings(); // 0x0000000181C63E80-0x0000000181C63EC0
		public override bool Initialize(); // 0x00000001802E7840-0x00000001802E7850
		public override bool Start(); // 0x00000001802E7840-0x00000001802E7850
		public override bool Stop(); // 0x00000001802E7840-0x00000001802E7850
		public override bool Deinitialize(); // 0x00000001802E7840-0x00000001802E7850
	}
}
