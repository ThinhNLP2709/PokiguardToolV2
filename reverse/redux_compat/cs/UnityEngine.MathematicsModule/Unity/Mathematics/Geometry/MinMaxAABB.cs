/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

// Image 42: UnityEngine.MathematicsModule.dll - Assembly: UnityEngine.MathematicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15208-15250

namespace Unity.Mathematics.Geometry
{
	[Serializable]
	[Il2CppEagerStaticClassConstruction]
	public struct MinMaxAABB : IEquatable<MinMaxAABB> // TypeDefIndex: 15250
	{
		// Fields
		public float3 Min; // 0x00
		public float3 Max; // 0x0C
	
		// Constructors
		public MinMaxAABB(float3 min, float3 max); // 0x000000018071D330-0x000000018071D350
	
		// Methods
		public void Encapsulate(float3 point); // 0x0000000182109D70-0x000000018210A870
		public bool Equals(MinMaxAABB other); // 0x00000001822B34E0-0x00000001822B3560
		public override string ToString(); // 0x00000001822B3560-0x00000001822B3600
	}
}
