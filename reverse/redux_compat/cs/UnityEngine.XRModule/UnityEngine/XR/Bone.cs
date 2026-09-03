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
	[NativeConditional("ENABLE_VR")]
	[NativeHeader("Modules/XR/XRPrefix.h")]
	[NativeHeader("XRScriptingClasses.h")]
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
	[RequiredByNativeCode]
	[StaticAccessor("XRInputDevices::Get()", StaticAccessorType.Dot)]
	public struct Bone : IEquatable<UnityEngine.XR.Bone> // TypeDefIndex: 15354
	{
		// Fields
		private ulong m_DeviceId; // 0x00
		private uint m_FeatureIndex; // 0x08
	
		// Properties
		internal ulong deviceId { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		internal uint featureIndex { get; } // 0x0000000180732D20-0x0000000180732D30 
	
		// Methods
		public override bool Equals(object obj); // 0x00000001825D32A0-0x00000001825D3340
		public bool Equals(Bone other); // 0x0000000180C10DC0-0x0000000180C10DE0
		public override int GetHashCode(); // 0x00000001825D3340-0x00000001825D3390
	}
}
