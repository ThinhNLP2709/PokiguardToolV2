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
	[NativeHeader("Modules/XR/Subsystems/Input/Public/XRInputDevices.h")]
	[RequiredByNativeCode]
	public struct InputFeatureUsage : IEquatable<UnityEngine.XR.InputFeatureUsage> // TypeDefIndex: 15350
	{
		// Fields
		internal string m_Name; // 0x00
		[NativeName("m_FeatureType")]
		internal InputFeatureType m_InternalType; // 0x08
	
		// Properties
		public string name { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		internal InputFeatureType internalType { get; } // 0x0000000180732D20-0x0000000180732D30 
	
		// Methods
		public override bool Equals(object obj); // 0x00000001825D46A0-0x00000001825D4750
		public bool Equals(InputFeatureUsage other); // 0x00000001825D4750-0x00000001825D47A0
		public override int GetHashCode(); // 0x00000001825D47A0-0x00000001825D4800
	}
}
