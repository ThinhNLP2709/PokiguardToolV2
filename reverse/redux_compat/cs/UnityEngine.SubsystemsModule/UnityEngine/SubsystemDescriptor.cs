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
	[Obsolete("Use SubsystemDescriptorWithProvider instead.", false)]
	public abstract class SubsystemDescriptor : ISubsystemDescriptor // TypeDefIndex: 15586
	{
		// Fields
		[CompilerGenerated]
		private string _id_k__BackingField; // 0x10
	
		// Properties
		public string id { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		protected SubsystemDescriptor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		ISubsystem ISubsystemDescriptor.Create(); // 0x0000000181884190-0x00000001818841B0
		internal abstract ISubsystem CreateImpl();
	}
}
