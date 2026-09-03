/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

// Image 42: UnityEngine.MathematicsModule.dll - Assembly: UnityEngine.MathematicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15208-15250

namespace Unity.Mathematics
{
	[Serializable]
	[Il2CppEagerStaticClassConstruction]
	public struct float3x3 : IEquatable<Unity.Mathematics.float3x3>, IFormattable // TypeDefIndex: 15230
	{
		// Fields
		public float3 c0; // 0x00
		public float3 c1; // 0x0C
		public float3 c2; // 0x18
		public static readonly float3x3 identity; // 0x00
	
		// Properties
		public ref float3 this[int index] { get => default; } // 0x00000001822B7660-0x00000001822B7670 
	
		// Constructors
		public float3x3(float3 c0, float3 c1, float3 c2); // 0x00000001822B7270-0x00000001822B72B0
		public float3x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22); // 0x00000001822B7310-0x00000001822B7370
		public float3x3(float4x4 f4x4); // 0x00000001822B72B0-0x00000001822B7310
		public float3x3(quaternion q); // 0x00000001822B7370-0x00000001822B7660
		static float3x3(); // 0x00000001822B7240-0x00000001822B7270
	
		// Methods
		public static float3x3 operator *(float3x3 lhs, float rhs); // 0x00000001822B76E0-0x00000001822B77C0
		public bool Equals(float3x3 rhs); // 0x00000001822AFF40-0x00000001822B0C00
		public override bool Equals(object o); // 0x00000001822B5450-0x00000001822B54D0
		public override int GetHashCode(); // 0x00000001822B6990-0x00000001822B6A50
		public override string ToString(); // 0x00000001822B6E30-0x00000001822B7240
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B6A50-0x00000001822B6E30
		public static float3x3 EulerXYZ(float3 xyz); // 0x00000001822B54D0-0x00000001822B56D0
		public static float3x3 EulerXZY(float3 xyz); // 0x00000001822B56D0-0x00000001822B58C0
		public static float3x3 EulerYXZ(float3 xyz); // 0x00000001822B58C0-0x00000001822B5AA0
		public static float3x3 EulerYZX(float3 xyz); // 0x00000001822B5AA0-0x00000001822B5C80
		public static float3x3 EulerZXY(float3 xyz); // 0x00000001822B5C80-0x00000001822B5E50
		public static float3x3 EulerZYX(float3 xyz); // 0x00000001822B5E50-0x00000001822B6040
		public static float3x3 Euler(float3 xyz, math.RotationOrder order = math.RotationOrder.ZXY /* Metadata: 0x006A9EF1 */); // 0x00000001822B6040-0x00000001822B6990
		public static explicit operator float3x3(float4x4 f4x4); // 0x00000001822B7670-0x00000001822B76E0
	}
}
