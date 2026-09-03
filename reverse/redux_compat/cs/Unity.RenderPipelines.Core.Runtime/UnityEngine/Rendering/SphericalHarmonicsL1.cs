/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public struct SphericalHarmonicsL1 // TypeDefIndex: 5631
	{
		// Fields
		public Vector4 shAr; // 0x00
		public Vector4 shAg; // 0x10
		public Vector4 shAb; // 0x20
		public static readonly SphericalHarmonicsL1 zero; // 0x00
	
		// Constructors
		static SphericalHarmonicsL1(); // 0x0000000181E89180-0x0000000181E891D0
	
		// Methods
		public static SphericalHarmonicsL1 operator +(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs); // 0x0000000181E891D0-0x0000000181E89300
		public static SphericalHarmonicsL1 operator -(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs); // 0x0000000181E896E0-0x0000000181E89810
		public static SphericalHarmonicsL1 operator *(SphericalHarmonicsL1 lhs, float rhs); // 0x0000000181E895F0-0x0000000181E896E0
		public static SphericalHarmonicsL1 operator /(SphericalHarmonicsL1 lhs, float rhs); // 0x0000000181E89300-0x0000000181E893F0
		public static bool operator ==(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs); // 0x0000000181E893F0-0x0000000181E89550
		public static bool operator !=(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs); // 0x0000000181E89550-0x0000000181E895F0
		public override bool Equals(object other); // 0x0000000181E88F30-0x0000000181E89050
		public override int GetHashCode(); // 0x0000000181E89050-0x0000000181E89180
	}
}
