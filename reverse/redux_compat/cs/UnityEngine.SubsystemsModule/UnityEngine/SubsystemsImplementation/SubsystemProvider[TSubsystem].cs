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
	public abstract class SubsystemProvider<TSubsystem> : SubsystemProvider // TypeDefIndex: 15594
		where TSubsystem : SubsystemWithProvider, new()
	{
		// Constructors
		protected SubsystemProvider();
	
		// Methods
		protected internal virtual bool TryInitialize();
		public abstract void Start();
		public abstract void Stop();
		public abstract void Destroy();
	}
}
