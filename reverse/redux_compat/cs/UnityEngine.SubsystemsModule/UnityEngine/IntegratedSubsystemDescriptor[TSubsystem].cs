/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 53: UnityEngine.SubsystemsModule.dll - Assembly: UnityEngine.SubsystemsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15572-15596

namespace UnityEngine
{
	[NativeHeader("Modules/Subsystems/SubsystemDescriptor.h")]
	[UsedByNativeCode("SubsystemDescriptor")]
	public class IntegratedSubsystemDescriptor<TSubsystem> : IntegratedSubsystemDescriptor // TypeDefIndex: 15581
		where TSubsystem : IntegratedSubsystem
	{
		// Constructors
		public IntegratedSubsystemDescriptor();
	
		// Methods
		internal override ISubsystem CreateImpl();
		public TSubsystem Create();
	}
}
