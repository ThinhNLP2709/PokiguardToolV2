/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance.Basic
{
	internal class BasicAdaptivePerformanceSubsystem : AdaptivePerformanceSubsystem // TypeDefIndex: 14223
	{
		// Nested types
		internal class BasicProvider : AdaptivePerformanceSubsystem.APProvider, IApplicationLifecycle, IDevicePerformanceLevelControl // TypeDefIndex: 14224
		{
			// Fields
			private PerformanceDataRecord m_UpdatedPerfRecord; // 0x20
			[CompilerGenerated]
			private bool _Initialized_k__BackingField; // 0x64
			[CompilerGenerated]
			private Feature _Capabilities_k__BackingField; // 0x68
	
			// Properties
			public override IApplicationLifecycle ApplicationLifecycle { get; } // 0x0000000180370C60-0x0000000180370C70 
			public override IDevicePerformanceLevelControl PerformanceLevelControl { get; } // 0x0000000180370C60-0x0000000180370C70 
			public override string Stats { get; } // 0x0000000182142420-0x0000000182142450 
			public override bool Initialized { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181D8CC90-0x0000000181D8CCA0 0x0000000182142490-0x00000001821424A0
			public override Feature Capabilities { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001803002E0-0x00000001803002F0
			public override Version Version { get; } // 0x0000000182142450-0x0000000182142490 
			public int MaxCpuPerformanceLevel { get; } // 0x00000001815418D0-0x00000001815418E0 
			public int MaxGpuPerformanceLevel { get; } // 0x00000001815418D0-0x00000001815418E0 
	
			// Constructors
			public BasicProvider(); // 0x00000001821423D0-0x0000000182142420
	
			// Methods
			protected internal override bool TryInitialize(); // 0x0000000182142310-0x0000000182142350
			public override void Start(); // 0x0000000182142300-0x0000000182142310
			public override void Stop(); // 0x0000000181CF59E0-0x0000000181CF59F0
			public override void Destroy(); // 0x00000001815246F0-0x0000000181524710
			public override PerformanceDataRecord Update(); // 0x0000000182142350-0x00000001821423D0
			public void ApplicationPause(); // 0x00000001802E76C0-0x00000001802E76D0
			public void ApplicationResume(); // 0x00000001802E76C0-0x00000001802E76D0
			public bool SetPerformanceLevel(ref int cpuLevel, ref int gpuLevel); // 0x00000001821422E0-0x0000000182142300
			public bool EnableCpuBoost(); // 0x00000001802E7840-0x00000001802E7850
			public bool EnableGpuBoost(); // 0x00000001802E7840-0x00000001802E7850
		}
	
		// Constructors
		public BasicAdaptivePerformanceSubsystem(); // 0x000000018213EB30-0x000000018213EB70
	}
}
