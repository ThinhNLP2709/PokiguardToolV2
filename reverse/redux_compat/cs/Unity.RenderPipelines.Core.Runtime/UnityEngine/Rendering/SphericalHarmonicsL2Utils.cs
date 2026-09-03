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
	public class SphericalHarmonicsL2Utils // TypeDefIndex: 5632
	{
		// Constructors
		public SphericalHarmonicsL2Utils(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static void GetL1(SphericalHarmonicsL2 sh, out Vector3 L1_R, out Vector3 L1_G, out Vector3 L1_B); // 0x0000000181E898A0-0x0000000181E899E0
		public static void GetL2(SphericalHarmonicsL2 sh, out Vector3 L2_0, out Vector3 L2_1, out Vector3 L2_2, out Vector3 L2_3, out Vector3 L2_4); // 0x0000000181E899E0-0x0000000181E89BD0
		public static void SetL0(ref SphericalHarmonicsL2 sh, Vector3 L0); // 0x0000000181E89C50-0x0000000181E89CC0
		public static void SetL1R(ref SphericalHarmonicsL2 sh, Vector3 L1_R); // 0x0000000181E89DC0-0x0000000181E89E40
		public static void SetL1G(ref SphericalHarmonicsL2 sh, Vector3 L1_G); // 0x0000000181E89D40-0x0000000181E89DC0
		public static void SetL1B(ref SphericalHarmonicsL2 sh, Vector3 L1_B); // 0x0000000181E89CC0-0x0000000181E89D40
		public static void SetL1(ref SphericalHarmonicsL2 sh, Vector3 L1_R, Vector3 L1_G, Vector3 L1_B); // 0x0000000181E89E40-0x0000000181E89F90
		public static void SetCoefficient(ref SphericalHarmonicsL2 sh, int index, Vector3 coefficient); // 0x0000000181E89BD0-0x0000000181E89C50
		public static Vector3 GetCoefficient(SphericalHarmonicsL2 sh, int index); // 0x0000000181E89810-0x0000000181E898A0
	}
}
