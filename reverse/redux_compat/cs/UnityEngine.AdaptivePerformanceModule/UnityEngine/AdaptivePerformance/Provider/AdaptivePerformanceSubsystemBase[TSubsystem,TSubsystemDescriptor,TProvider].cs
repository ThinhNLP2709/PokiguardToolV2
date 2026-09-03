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
	public abstract class AdaptivePerformanceSubsystemBase<TSubsystem, TSubsystemDescriptor, TProvider> : SubsystemWithProvider<TSubsystem, TSubsystemDescriptor, TProvider> // TypeDefIndex: 14216
		where TSubsystem : SubsystemWithProvider, new()
		where TSubsystemDescriptor : SubsystemDescriptorWithProvider
		where TProvider : SubsystemProvider<TSubsystem>
	{
		// Properties
		public abstract Feature Capabilities { get; }
		public abstract IApplicationLifecycle ApplicationLifecycle { get; }
		public abstract IDevicePerformanceLevelControl PerformanceLevelControl { get; }
		public abstract Version Version { get; }
		public abstract string Stats { get; }
		public abstract bool Initialized { get; }
	
		// Constructors
		protected AdaptivePerformanceSubsystemBase();
	
		// Methods
		public abstract PerformanceDataRecord Update();
	}
}
