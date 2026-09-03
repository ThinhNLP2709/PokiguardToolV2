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
	[Il2CppEagerStaticClassConstruction]
	public struct float4 : IEquatable<Unity.Mathematics.float4>, IFormattable // TypeDefIndex: 15231
	{
		// Fields
		public float x; // 0x00
		public float y; // 0x04
		public float z; // 0x08
		public float w; // 0x0C
		public static readonly float4 zero; // 0x00
	
		// Properties
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyzx { get; } // 0x00000001822B7D90-0x00000001822B7DB0 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxy { get; } // 0x00000001822B7DD0-0x00000001822B7DF0 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxz { get; } // 0x00000001822B7DF0-0x00000001822B7E10 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyy { get; } // 0x00000001822B7E30-0x00000001822B7E50 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyz { get; } // 0x00000001822B7E50-0x00000001822B7E70 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwwx { get; } // 0x00000001822B7D50-0x00000001822B7D70 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwww { get; } // 0x00000001822B7D30-0x00000001822B7D50 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyz { get; } // 0x0000000181DF5340-0x0000000181DF5360 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxw { get; } // 0x00000001822B7DB0-0x00000001822B7DD0 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zwx { get; } // 0x00000001822B7E10-0x00000001822B7E30 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wzy { get; } // 0x00000001822B7D70-0x00000001822B7D90 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xy { get; } // 0x0000000181E6F9A0-0x0000000181E6F9C0 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 zw { get; } // 0x0000000181DD08D0-0x0000000181DD08F0 
		public float this[int index] { get => default; } // 0x0000000180A2F800-0x0000000180A2F810 
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15232
		{
		}
	
		// Constructors
		public float4(float x, float y, float z, float w); // 0x0000000182082140-0x0000000182082160
		public float4(float2 xy, float z, float w); // 0x00000001822B7D00-0x00000001822B7D30
		public float4(float2 xy, float2 zw); // 0x00000001821934F0-0x0000000182193530
		public float4(float3 xyz, float w); // 0x00000001822B7CE0-0x00000001822B7D00
		public float4(float v); // 0x00000001822B7CD0-0x00000001822B7CE0
		public float4(int4 v); // 0x00000001822B7CC0-0x00000001822B7CD0
	
		// Methods
		public static implicit operator float4(float v); // 0x00000001822B7EC0-0x00000001822B7ED0
		public static implicit operator float4(int4 v); // 0x00000001822B7ED0-0x00000001822B7F20
		public static float4 operator *(float4 lhs, float4 rhs); // 0x00000001821C8670-0x00000001821C86C0
		public static float4 operator *(float4 lhs, float rhs); // 0x0000000182082270-0x0000000182082290
		public static float4 operator +(float4 lhs, float4 rhs); // 0x0000000182082610-0x0000000182082660
		public static float4 operator -(float4 lhs, float4 rhs); // 0x00000001821C86C0-0x00000001821C8710
		public static float4 operator /(float4 lhs, float4 rhs); // 0x00000001822B7E70-0x00000001822B7EC0
		public static float4 operator /(float4 lhs, float rhs); // 0x00000001821FDFC0-0x00000001821FDFE0
		public static bool4 operator <(float4 lhs, float4 rhs); // 0x00000001822B7F20-0x00000001822B7F60
		public bool Equals(float4 rhs); // 0x000000018192E0B0-0x000000018192E0F0
		public override bool Equals(object o); // 0x00000001822B77C0-0x00000001822B7850
		public override int GetHashCode(); // 0x00000001822B7850-0x00000001822B78A0
		public override string ToString(); // 0x00000001822B78A0-0x00000001822B7AB0
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B7AB0-0x00000001822B7CC0
	}
}
