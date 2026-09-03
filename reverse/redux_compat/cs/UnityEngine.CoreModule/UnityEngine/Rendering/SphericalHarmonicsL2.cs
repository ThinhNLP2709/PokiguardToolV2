/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Export/Math/SphericalHarmonicsL2.bindings.h")]
	[UsedByNativeCode]
	public struct SphericalHarmonicsL2 : IEquatable<UnityEngine.Rendering.SphericalHarmonicsL2> // TypeDefIndex: 8338
	{
		// Fields
		private float shr0; // 0x00
		private float shr1; // 0x04
		private float shr2; // 0x08
		private float shr3; // 0x0C
		private float shr4; // 0x10
		private float shr5; // 0x14
		private float shr6; // 0x18
		private float shr7; // 0x1C
		private float shr8; // 0x20
		private float shg0; // 0x24
		private float shg1; // 0x28
		private float shg2; // 0x2C
		private float shg3; // 0x30
		private float shg4; // 0x34
		private float shg5; // 0x38
		private float shg6; // 0x3C
		private float shg7; // 0x40
		private float shg8; // 0x44
		private float shb0; // 0x48
		private float shb1; // 0x4C
		private float shb2; // 0x50
		private float shb3; // 0x54
		private float shb4; // 0x58
		private float shb5; // 0x5C
		private float shb6; // 0x60
		private float shb7; // 0x64
		private float shb8; // 0x68
	
		// Properties
		public float this[int rgb, int coefficient] { [IsReadOnly] get => default; set {} } // 0x000000018226B0E0-0x000000018226B300 0x000000018226B3C0-0x000000018226B5E0
	
		// Methods
		[IsReadOnly]
		public override int GetHashCode(); // 0x000000018226AE20-0x000000018226B0E0
		[IsReadOnly]
		public override bool Equals(object other); // 0x000000018226AC00-0x000000018226AD60
		[IsReadOnly]
		public bool Equals(SphericalHarmonicsL2 other); // 0x000000018226AD60-0x000000018226AE20
		[IsReadOnly]
		public bool Equals([IsReadOnly] in SphericalHarmonicsL2 other); // 0x000000018226AD60-0x000000018226AE20
		public static bool operator ==(SphericalHarmonicsL2 lhs, SphericalHarmonicsL2 rhs); // 0x0000000180765EC0-0x00000001807660E0
		public static bool operator !=(SphericalHarmonicsL2 lhs, SphericalHarmonicsL2 rhs); // 0x000000018226B300-0x000000018226B3C0
	}
}
