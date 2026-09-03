/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.RadeonRays
{
	internal struct Transform // TypeDefIndex: 14253
	{
		// Fields
		public float4 row0; // 0x00
		public float4 row1; // 0x10
		public float4 row2; // 0x20
	
		// Constructors
		public Transform(float4 row0, float4 row1, float4 row2); // 0x0000000180F466F0-0x0000000180F46710
	
		// Methods
		public static Transform Identity(); // 0x0000000182124280-0x00000001821242B0
		public static Transform Translation(float3 translation); // 0x0000000182124870-0x0000000182124900
		public static Transform Scale(float3 scale); // 0x0000000182124620-0x00000001821246A0
		public static Transform TRS(float3 translation, float3 rotation, float3 scale); // 0x00000001821246A0-0x0000000182124870
		public Transform Inverse(); // 0x00000001821242B0-0x0000000182124620
	}
}
