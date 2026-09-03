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
	public struct float2x2 : IEquatable<Unity.Mathematics.float2x2>, IFormattable // TypeDefIndex: 15227
	{
		// Fields
		public float2 c0; // 0x00
		public float2 c1; // 0x08
		public static readonly float2x2 identity; // 0x00
	
		// Constructors
		public float2x2(float2 c0, float2 c1); // 0x0000000180C13E40-0x0000000180C13E50
		public float2x2(float m00, float m01, float m10, float m11); // 0x00000001822B4F00-0x00000001822B4F20
		static float2x2(); // 0x00000001822B4EE0-0x00000001822B4F00
	
		// Methods
		public bool Equals(float2x2 rhs); // 0x00000001822B49A0-0x00000001822B49F0
		public override bool Equals(object o); // 0x00000001822B4910-0x00000001822B49A0
		public override int GetHashCode(); // 0x00000001822B49F0-0x00000001822B4AC0
		public override string ToString(); // 0x00000001822B4AC0-0x00000001822B4CD0
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B4CD0-0x00000001822B4EE0
	}
}
