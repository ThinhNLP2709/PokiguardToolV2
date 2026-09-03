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
	public abstract class SubsystemWithProvider<TSubsystem, TSubsystemDescriptor, TProvider> : SubsystemWithProvider // TypeDefIndex: 15596
		where TSubsystem : SubsystemWithProvider, new()
		where TSubsystemDescriptor : SubsystemDescriptorWithProvider
		where TProvider : SubsystemProvider<TSubsystem>
	{
		// Fields
		private static readonly ProfilerMarker k_InitializeMarker;
		private static readonly ProfilerMarker k_CreateMarker;
		[CompilerGenerated]
		private TSubsystemDescriptor _subsystemDescriptor_k__BackingField;
		[CompilerGenerated]
		private TProvider _provider_k__BackingField;
	
		// Properties
		public TSubsystemDescriptor subsystemDescriptor { [CompilerGenerated] get; [CompilerGenerated] private set; }
		protected internal TProvider provider { [CompilerGenerated] get; [CompilerGenerated] private set; }
		internal sealed override SubsystemDescriptorWithProvider descriptor { get; }
	
		// Constructors
		protected SubsystemWithProvider();
		static SubsystemWithProvider();
	
		// Methods
		protected virtual void OnCreate();
		protected override void OnStart();
		protected override void OnStop();
		protected override void OnDestroy();
		internal sealed override void Initialize(SubsystemDescriptorWithProvider descriptor, SubsystemProvider provider);
	}
}
