/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
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
	[DebuggerTypeProxy(typeof(DebuggerProxy))]
	[DefaultMember("Item")]
	[Il2CppEagerStaticClassConstruction]
	public struct float2 : IEquatable<Unity.Mathematics.float2>, IFormattable // TypeDefIndex: 15225
	{
		// Fields
		public float x; // 0x00
		public float y; // 0x04
		public static readonly float2 zero; // 0x00
	
		// Properties
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyx { get; } // 0x00000001822B4800-0x00000001822B4820 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yx { get; } // 0x00000001822B4820-0x00000001822B4840 
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15226
		{
		}
	
		// Constructors
		public float2(float x, float y); // 0x0000000180F37880-0x0000000180F37890
		public float2(float v); // 0x0000000181237540-0x0000000181237550
		public float2(int v); // 0x00000001822B47B0-0x00000001822B47D0
		public float2(int2 v); // 0x00000001822B4790-0x00000001822B47B0
		public float2(uint2 v); // 0x00000001822B47D0-0x00000001822B4800
	
		// Methods
		public static implicit operator float2(int v); // 0x00000001822B48C0-0x00000001822B48E0
		public static implicit operator float2(int2 v); // 0x00000001821FC510-0x00000001821FC530
		public static implicit operator float2(uint2 v); // 0x00000001822B48E0-0x00000001822B4910
		public static float2 operator *(float2 lhs, float2 rhs); // 0x00000001821FCB90-0x00000001821FCBD0
		public static float2 operator *(float2 lhs, float rhs); // 0x00000001821FD3F0-0x00000001821FD420
		public static float2 operator *(float lhs, float2 rhs); // 0x00000001821FD420-0x00000001821FD450
		public static float2 operator +(float2 lhs, float2 rhs); // 0x00000001821FD250-0x00000001821FD290
		public static float2 operator +(float2 lhs, float rhs); // 0x00000001822B4870-0x00000001822B48A0
		public static float2 operator +(float lhs, float2 rhs); // 0x00000001822B4840-0x00000001822B4870
		public static float2 operator -(float2 lhs, float2 rhs); // 0x00000001821FD450-0x00000001821FD490
		public static float2 operator /(float2 lhs, float2 rhs); // 0x00000001821FD2C0-0x00000001821FD300
		public static float2 operator /(float2 lhs, float rhs); // 0x00000001821FD290-0x00000001821FD2C0
		public static float2 operator /(float lhs, float2 rhs); // 0x00000001822B48A0-0x00000001822B48C0
		public static float2 operator -(float2 val); // 0x00000001821FD490-0x00000001821FD4C0
		public bool Equals(float2 rhs); // 0x00000001821FC940-0x00000001821FC970
		public override bool Equals(object o); // 0x00000001822B45A0-0x00000001822B4610
		public override int GetHashCode(); // 0x00000001822B4610-0x00000001822B4670
		public override string ToString(); // 0x00000001822B4700-0x00000001822B4790
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B4670-0x00000001822B4700
	}
}
