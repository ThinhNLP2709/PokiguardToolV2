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
	[NativeHeader("Modules/Subsystems/Subsystem.h")]
	[UsedByNativeCode]
	public class IntegratedSubsystem : ISubsystem // TypeDefIndex: 15576
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEngine.XRModule" })]
		internal IntPtr m_Ptr; // 0x10
		internal ISubsystemDescriptor m_SubsystemDescriptor; // 0x18
	
		// Properties
		public bool running { get; } // 0x00000001822E7FF0-0x00000001822E8040 
		internal bool valid { get; } // 0x0000000181C1F6D0-0x0000000181C1F6E0 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15577
		{
			// Methods
			public static IntPtr ConvertToNative(IntegratedSubsystem integratedSubsystem); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public IntegratedSubsystem(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void SetHandle([UnityMarshalAs(NativeType.ScriptingObjectPtr)] IntegratedSubsystem subsystem); // 0x00000001822E7E50-0x00000001822E7EB0
		public void Start(); // 0x00000001822E7EF0-0x00000001822E7F50
		public void Stop(); // 0x00000001822E7F90-0x00000001822E7FF0
		public void Destroy(); // 0x00000001822E7B90-0x00000001822E7D60
		internal bool IsRunning(); // 0x00000001822E7DA0-0x00000001822E7E00
		private static void SetHandle_Injected(IntPtr _unity_self, IntegratedSubsystem subsystem); // 0x00000001822E7E00-0x00000001822E7E50
		private static void Start_Injected(IntPtr _unity_self); // 0x00000001822E7EB0-0x00000001822E7EF0
		private static void Stop_Injected(IntPtr _unity_self); // 0x00000001822E7F50-0x00000001822E7F90
		private static bool IsRunning_Injected(IntPtr _unity_self); // 0x00000001822E7D60-0x00000001822E7DA0
	}
}
