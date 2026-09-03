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
	public struct float3 : IEquatable<Unity.Mathematics.float3>, IFormattable // TypeDefIndex: 15228
	{
		// Fields
		public float x; // 0x00
		public float y; // 0x04
		public float z; // 0x08
		public static readonly float3 zero; // 0x00
	
		// Properties
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxx { get; } // 0x00000001822B5210-0x00000001822B5230 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxy { get; } // 0x00000001822B5250-0x00000001822B5270 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyy { get; } // 0x00000001822B5270-0x00000001822B5290 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzyz { get; } // 0x00000001822B52D0-0x00000001822B52F0 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzzz { get; } // 0x00000001822B52F0-0x00000001822B5310 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyz { get; } // 0x0000000181DF5340-0x0000000181DF5360 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yzx { get; } // 0x00000001822B5290-0x00000001822B52B0 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zxy { get; } // 0x00000001822B52B0-0x00000001822B52D0 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xy { get; set; } // 0x0000000181E6F9A0-0x0000000181E6F9C0 0x0000000182193770-0x0000000182193790
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xz { get; } // 0x00000001822B5230-0x00000001822B5250 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yz { get; } // 0x0000000180C5D180-0x0000000180C5D1A0 
		public float this[int index] { set {} } // 0x00000001822B5430-0x00000001822B5450
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15229
		{
		}
	
		// Constructors
		public float3(float x, float y, float z); // 0x00000001821E01D0-0x00000001821E01E0
		public float3(float x, float2 yz); // 0x00000001822B5190-0x00000001822B51B0
		public float3(float2 xy, float z); // 0x00000001822B51F0-0x00000001822B5210
		public float3(float v); // 0x00000001822B51E0-0x00000001822B51F0
		public float3(int v); // 0x00000001822B5160-0x00000001822B5190
		public float3(double v); // 0x00000001822B51B0-0x00000001822B51E0
	
		// Methods
		public static implicit operator float3(float v); // 0x00000001822B5380-0x00000001822B53A0
		public static implicit operator float3(int v); // 0x00000001822B53A0-0x00000001822B53D0
		public static float3 operator *(float3 lhs, float3 rhs); // 0x00000001821DFA50-0x00000001821DFA90
		public static float3 operator *(float3 lhs, float rhs); // 0x00000001821E0510-0x00000001821E0540
		public static float3 operator *(float lhs, float3 rhs); // 0x00000001821E04E0-0x00000001821E0510
		public static float3 operator +(float3 lhs, float3 rhs); // 0x00000001803A7CD0-0x00000001803A7D10
		public static float3 operator -(float3 lhs, float3 rhs); // 0x00000001805C0670-0x00000001805C06B0
		public static float3 operator /(float3 lhs, float3 rhs); // 0x00000001822B5310-0x00000001822B5350
		public static float3 operator /(float3 lhs, float rhs); // 0x0000000180313B10-0x0000000180313B40
		public static float3 operator /(float lhs, float3 rhs); // 0x00000001822B5350-0x00000001822B5380
		public static float3 operator -(float3 val); // 0x00000001821E0540-0x00000001821E0580
		public static bool3 operator !=(float3 lhs, float3 rhs); // 0x00000001822B53D0-0x00000001822B5430
		public bool Equals(float3 rhs); // 0x00000001820F4340-0x00000001820F4370
		public override bool Equals(object o); // 0x00000001822B4F20-0x00000001822B4FA0
		public override int GetHashCode(); // 0x00000001822B4FA0-0x00000001822B4FF0
		public override string ToString(); // 0x00000001822B50B0-0x00000001822B5160
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B4FF0-0x00000001822B50B0
	}
}
