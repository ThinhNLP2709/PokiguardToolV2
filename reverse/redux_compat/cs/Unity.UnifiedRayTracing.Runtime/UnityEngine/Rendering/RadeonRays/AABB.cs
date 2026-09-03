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
	internal struct AABB // TypeDefIndex: 14229
	{
		// Fields
		public float3 Min; // 0x00
		public float3 Max; // 0x0C
		public static readonly AABB Empty; // 0x00
	
		// Constructors
		public AABB(float3 min, float3 max); // 0x000000018071D330-0x000000018071D350
		static AABB(); // 0x000000018210AA10-0x000000018210AA70
	
		// Methods
		public void Encapsulate(AABB aabb); // 0x000000018210A8D0-0x000000018210A9E0
		public void Encapsulate(float3 point); // 0x0000000182109D70-0x000000018210A870
		public bool Contains(AABB rhs); // 0x000000018210A870-0x000000018210A8D0
		public bool IsValid(); // 0x000000018210A9E0-0x000000018210AA10
	}
}
