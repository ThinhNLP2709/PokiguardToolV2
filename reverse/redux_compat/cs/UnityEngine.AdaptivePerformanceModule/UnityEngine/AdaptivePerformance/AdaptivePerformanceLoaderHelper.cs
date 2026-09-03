/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public abstract class AdaptivePerformanceLoaderHelper : AdaptivePerformanceLoader // TypeDefIndex: 14182
	{
		// Fields
		protected Dictionary<Type, ISubsystem> m_SubsystemInstanceMap; // 0x18
	
		// Constructors
		protected AdaptivePerformanceLoaderHelper(); // 0x0000000182134080-0x0000000182134100
	
		// Methods
		public override T GetLoadedSubsystem<T>();
		protected void StartSubsystem<T>()
			where T : class, ISubsystem;
		protected void StopSubsystem<T>()
			where T : class, ISubsystem;
		protected void DestroySubsystem<T>()
			where T : class, ISubsystem;
		protected void CreateSubsystem<TDescriptor, TSubsystem>(List<TDescriptor> descriptors, string id)
			where TDescriptor : ISubsystemDescriptor
			where TSubsystem : ISubsystem;
		public override bool Deinitialize(); // 0x0000000182134050-0x0000000182134080
	}
}
