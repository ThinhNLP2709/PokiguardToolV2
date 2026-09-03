/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance.Provider
{
	public class AdaptivePerformanceSubsystem : AdaptivePerformanceSubsystemBase<UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystem, UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor, UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystem.APProvider> // TypeDefIndex: 14217
	{
		// Properties
		public override IApplicationLifecycle ApplicationLifecycle { get; } // 0x0000000181813E90-0x0000000181813EC0 
		public override IDevicePerformanceLevelControl PerformanceLevelControl { get; } // 0x0000000181813FE0-0x0000000181814010 
		public override Version Version { get; } // 0x0000000181A398E0-0x0000000181A39910 
		public override Feature Capabilities { get; } // 0x0000000181AA6620-0x0000000181AA6650 
		public override string Stats { get; } // 0x0000000181814010-0x0000000181814040 
		public override bool Initialized { get; } // 0x000000018213EB70-0x000000018213EBA0 
	
		// Nested types
		public abstract class APProvider : SubsystemProvider<AdaptivePerformanceSubsystem> // TypeDefIndex: 14218
		{
			// Fields
			protected bool m_Running; // 0x18
	
			// Properties
			public abstract Feature Capabilities { get; set; }
			public abstract IApplicationLifecycle ApplicationLifecycle { get; }
			public abstract IDevicePerformanceLevelControl PerformanceLevelControl { get; }
			public abstract Version Version { get; }
			public virtual string Stats { get; } // 0x000000018212FAF0-0x000000018212FB20 
			public abstract bool Initialized { get; set; }
	
			// Constructors
			protected APProvider(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
			// Methods
			public abstract PerformanceDataRecord Update();
		}
	
		// Constructors
		public AdaptivePerformanceSubsystem(); // 0x000000018213EB30-0x000000018213EB70
	
		// Methods
		public override PerformanceDataRecord Update(); // 0x000000018213EAD0-0x000000018213EB30
	}
}
