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
	[UsedByNativeCode("SubsystemDescriptorBase")]
	public abstract class IntegratedSubsystemDescriptor : ISubsystemDescriptor // TypeDefIndex: 15580
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEngine.XRModule" })]
		internal IntPtr m_Ptr; // 0x10
	
		// Properties
		public string id { get; } // 0x00000001822E7B80-0x00000001822E7B90 
	
		// Constructors
		protected IntegratedSubsystemDescriptor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		ISubsystem ISubsystemDescriptor.Create(); // 0x0000000181884190-0x00000001818841B0
		internal abstract ISubsystem CreateImpl();
	}
}
