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

// Image 46: UnityEngine.XRModule.dll - Assembly: UnityEngine.XRModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15337-15374

namespace UnityEngine.XR
{
	[NativeConditional("ENABLE_XR")]
	[NativeHeader("Modules/XR/Subsystems/Input/XRInputSubsystem.h")]
	[UsedByNativeCode]
	public class XRInputSubsystem : IntegratedSubsystem<XRInputSubsystemDescriptor> // TypeDefIndex: 15365
	{
		// Fields
		[CompilerGenerated]
		private Action<XRInputSubsystem> trackingOriginUpdated; // 0x20
		[CompilerGenerated]
		private Action<XRInputSubsystem> boundaryChanged; // 0x28
	
		// Constructors
		public XRInputSubsystem(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		[RequiredByNativeCode(GenerateProxy = true)]
		private static void InvokeTrackingOriginUpdatedEvent(IntPtr internalPtr); // 0x00000001825D7CA0-0x00000001825D7D50
		[RequiredByNativeCode(GenerateProxy = true)]
		private static void InvokeBoundaryChangedEvent(IntPtr internalPtr); // 0x00000001825D7BF0-0x00000001825D7CA0
	}
}
