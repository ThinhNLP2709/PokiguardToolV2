/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public abstract class AdaptivePerformanceLoader : ScriptableObject // TypeDefIndex: 14181
	{
		// Properties
		public abstract bool Initialized { get; }
		public abstract bool Running { get; }
	
		// Constructors
		protected AdaptivePerformanceLoader(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public virtual bool Initialize(); // 0x00000001802E7990-0x00000001802E79A0
		public virtual bool Start(); // 0x00000001802E7990-0x00000001802E79A0
		public virtual bool Stop(); // 0x00000001802E7990-0x00000001802E79A0
		public virtual bool Deinitialize(); // 0x00000001802E7990-0x00000001802E79A0
		public abstract T GetLoadedSubsystem<T>()
			where T : class, ISubsystem;
		public abstract ISubsystem GetDefaultSubsystem();
		public abstract IAdaptivePerformanceSettings GetSettings();
	}
}
