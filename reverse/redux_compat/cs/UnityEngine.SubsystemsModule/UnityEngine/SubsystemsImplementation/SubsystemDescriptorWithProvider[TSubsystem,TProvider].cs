/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 53: UnityEngine.SubsystemsModule.dll - Assembly: UnityEngine.SubsystemsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15572-15596

namespace UnityEngine.SubsystemsImplementation
{
	public class SubsystemDescriptorWithProvider<TSubsystem, TProvider> : SubsystemDescriptorWithProvider // TypeDefIndex: 15592
		where TSubsystem : SubsystemWithProvider, new()
		where TProvider : SubsystemProvider<TSubsystem>
	{
		// Constructors
		public SubsystemDescriptorWithProvider();
	
		// Methods
		internal override ISubsystem CreateImpl();
		public TSubsystem Create();
		internal sealed override void ThrowIfInvalid();
		internal TProvider CreateProvider();
	}
}
