/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using UnityEngine;

// Image 53: UnityEngine.SubsystemsModule.dll - Assembly: UnityEngine.SubsystemsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15572-15596

namespace UnityEngine.SubsystemsImplementation
{
	public abstract class SubsystemWithProvider : ISubsystem // TypeDefIndex: 15595
	{
		// Fields
		private static readonly ProfilerMarker k_StartMarker; // 0x00
		private static readonly ProfilerMarker k_StopMarker; // 0x08
		private static readonly ProfilerMarker k_DestroyMarker; // 0x10
		[CompilerGenerated]
		private bool _running_k__BackingField; // 0x10
		[CompilerGenerated]
		private SubsystemProvider _providerBase_k__BackingField; // 0x18
	
		// Properties
		public bool running { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		internal SubsystemProvider providerBase { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		internal abstract SubsystemDescriptorWithProvider descriptor { get; }
	
		// Constructors
		protected SubsystemWithProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static SubsystemWithProvider(); // 0x00000001822E9930-0x00000001822E9A10
	
		// Methods
		public void Start(); // 0x00000001822E96F0-0x00000001822E9810
		protected abstract void OnStart();
		public void Stop(); // 0x00000001822E9810-0x00000001822E9930
		protected abstract void OnStop();
		public void Destroy(); // 0x00000001822E9560-0x00000001822E96F0
		protected abstract void OnDestroy();
		internal abstract void Initialize(SubsystemDescriptorWithProvider descriptor, SubsystemProvider subsystemProvider);
	}
}
