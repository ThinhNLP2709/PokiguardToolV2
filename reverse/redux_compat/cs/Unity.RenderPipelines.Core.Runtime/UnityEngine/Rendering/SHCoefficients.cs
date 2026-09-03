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
	public struct SHCoefficients : IEquatable<SHCoefficients> // TypeDefIndex: 5729
	{
		// Fields
		public Vector4 SHAr; // 0x00
		public Vector4 SHAg; // 0x10
		public Vector4 SHAb; // 0x20
		public Vector4 SHBr; // 0x30
		public Vector4 SHBg; // 0x40
		public Vector4 SHBb; // 0x50
		public Vector4 SHC; // 0x60
		public Vector4 ProbesOcclusion; // 0x70
	
		// Constructors
		public SHCoefficients(SphericalHarmonicsL2 sh); // 0x0000000181EB8BC0-0x0000000181EB9220
		public SHCoefficients(SphericalHarmonicsL2 sh, Vector4 probesOcclusion); // 0x0000000181EB8B40-0x0000000181EB8BC0
	
		// Methods
		private static Vector4 GetSHA(SphericalHarmonicsL2 sh, int i); // 0x0000000181EB8910-0x0000000181EB89F0
		private static Vector4 GetSHB(SphericalHarmonicsL2 sh, int i); // 0x0000000181EB89F0-0x0000000181EB8AB0
		private static Vector4 GetSHC(SphericalHarmonicsL2 sh); // 0x0000000181EB8AB0-0x0000000181EB8B40
		public bool Equals(SHCoefficients other); // 0x0000000181EB8390-0x0000000181EB86B0
		public override bool Equals(object obj); // 0x0000000181EB86B0-0x0000000181EB87A0
		public override int GetHashCode(); // 0x0000000181EB87A0-0x0000000181EB8910
		public static bool operator ==(SHCoefficients left, SHCoefficients right); // 0x0000000181EB9220-0x0000000181EB9280
		public static bool operator !=(SHCoefficients left, SHCoefficients right); // 0x0000000181EB9280-0x0000000181EB92F0
	}
}
