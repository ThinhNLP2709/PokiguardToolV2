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
	public struct float4x4 : IEquatable<Unity.Mathematics.float4x4>, IFormattable // TypeDefIndex: 15234
	{
		// Fields
		public float4 c0; // 0x00
		public float4 c1; // 0x10
		public float4 c2; // 0x20
		public float4 c3; // 0x30
		public static readonly float4x4 identity; // 0x00
	
		// Properties
		public ref float4 this[int index] { get => default; } // 0x0000000180A2DB00-0x0000000180A2DB10 
	
		// Constructors
		public float4x4(float4 c0, float4 c1, float4 c2, float4 c3); // 0x0000000182109860-0x0000000182109890
		public float4x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33); // 0x00000001822B9B50-0x00000001822B9C50
		public float4x4(float3x3 rotation, float3 translation); // 0x00000001822B9C50-0x00000001822B9D60
		public float4x4(quaternion rotation, float3 translation); // 0x00000001822B9D60-0x00000001822B9EA0
		static float4x4(); // 0x00000001822B9B10-0x00000001822B9B50
	
		// Methods
		public bool Equals(float4x4 rhs); // 0x0000000181C15D20-0x0000000181C15E90
		public override bool Equals(object o); // 0x00000001822B8B00-0x00000001822B8B80
		public override int GetHashCode(); // 0x00000001822B8B80-0x00000001822B8BC0
		public override string ToString(); // 0x00000001822B8DB0-0x00000001822B9490
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B9490-0x00000001822B9B10
		public static float4x4 TRS(float3 translation, quaternion rotation, float3 scale); // 0x00000001822B8BC0-0x00000001822B8DB0
	}
}
