/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 53: UnityEngine.SubsystemsModule.dll - Assembly: UnityEngine.SubsystemsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15572-15596

namespace UnityEngine
{
	[Obsolete("Use SubsystemWithProvider instead.", false)]
	public abstract class Subsystem : ISubsystem // TypeDefIndex: 15585
	{
		// Properties
		public abstract bool running { get; }
	
		// Constructors
		protected Subsystem(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract void Start();
		public abstract void Stop();
		public void Destroy(); // 0x00000001822E9A10-0x00000001822E9AF0
		protected abstract void OnDestroy();
	}
}
