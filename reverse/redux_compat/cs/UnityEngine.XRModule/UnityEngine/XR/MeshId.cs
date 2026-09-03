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
	[NativeHeader("Modules/XR/Subsystems/Meshing/XRMeshBindings.h")]
	[UsedByNativeCode]
	public struct MeshId : IEquatable<UnityEngine.XR.MeshId> // TypeDefIndex: 15367
	{
		// Fields
		private ulong m_SubId1; // 0x00
		private ulong m_SubId2; // 0x08
	
		// Methods
		public override string ToString(); // 0x00000001825D5F40-0x00000001825D5FC0
		public override int GetHashCode(); // 0x00000001821CCF00-0x00000001821CCF30
		public override bool Equals(object obj); // 0x00000001825D5EB0-0x00000001825D5F40
		public bool Equals(MeshId other); // 0x0000000181EA30E0-0x0000000181EA3100
	}
}
