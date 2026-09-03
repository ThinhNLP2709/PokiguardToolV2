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
	public abstract class SubsystemDescriptorWithProvider : ISubsystemDescriptor // TypeDefIndex: 15591
	{
		// Fields
		[CompilerGenerated]
		private string _id_k__BackingField; // 0x10
		[CompilerGenerated]
		private Type _providerType_k__BackingField; // 0x18
		[CompilerGenerated]
		private Type _subsystemTypeOverride_k__BackingField; // 0x20
	
		// Properties
		public string id { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		protected internal Type providerType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		protected internal Type subsystemTypeOverride { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Constructors
		protected SubsystemDescriptorWithProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal abstract ISubsystem CreateImpl();
		ISubsystem ISubsystemDescriptor.Create(); // 0x0000000181884190-0x00000001818841B0
		internal abstract void ThrowIfInvalid();
	}
}
