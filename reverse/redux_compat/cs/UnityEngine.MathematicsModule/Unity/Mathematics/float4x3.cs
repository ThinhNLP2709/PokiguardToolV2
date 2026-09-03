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
	[DefaultMember("Item")]
	[Il2CppEagerStaticClassConstruction]
	public struct float4x3 : IEquatable<Unity.Mathematics.float4x3>, IFormattable // TypeDefIndex: 15233
	{
		// Fields
		public float4 c0; // 0x00
		public float4 c1; // 0x10
		public float4 c2; // 0x20
	
		// Constructors
		public float4x3(float4 c0, float4 c1, float4 c2); // 0x0000000180F466F0-0x0000000180F46710
		public float4x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22, float m30, float m31, float m32); // 0x00000001822B8A40-0x00000001822B8B00
	
		// Methods
		public bool Equals(float4x3 rhs); // 0x00000001822B0C00-0x00000001822B28B0
		public override bool Equals(object o); // 0x00000001822B7F60-0x00000001822B7FE0
		public override int GetHashCode(); // 0x00000001822B7FE0-0x00000001822B8010
		public override string ToString(); // 0x00000001822B8010-0x00000001822B8550
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B8550-0x00000001822B8A40
	}
}
