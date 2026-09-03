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
	public struct int4 : IEquatable<Unity.Mathematics.int4>, IFormattable // TypeDefIndex: 15240
	{
		// Fields
		public int x; // 0x00
		public int y; // 0x04
		public int z; // 0x08
		public int w; // 0x0C
		public static readonly int4 zero; // 0x00
	
		// Properties
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 xy { get; } // 0x00000001822BAA30-0x00000001822BAA50 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 xw { get; } // 0x00000001822BAA10-0x00000001822BAA30 
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 zw { get; } // 0x0000000181D8BFD0-0x0000000181D8BFF0 
		public int this[int index] { get => default; } // 0x0000000180A2E9E0-0x0000000180A2E9F0 
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15241
		{
		}
	
		// Constructors
		public int4(int x, int y, int z, int w); // 0x000000018192E480-0x000000018192E4A0
		public int4(float4 v); // 0x00000001822BAA00-0x00000001822BAA10
	
		// Methods
		public static explicit operator int4(float4 v); // 0x00000001822BAA50-0x00000001822BAA90
		public bool Equals(int4 rhs); // 0x00000001815FB130-0x00000001815FB160
		public override bool Equals(object o); // 0x00000001822BA530-0x00000001822BA5B0
		public override int GetHashCode(); // 0x00000001822BA5B0-0x00000001822BA5F0
		public override string ToString(); // 0x00000001822BA5F0-0x00000001822BA7F0
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822BA7F0-0x00000001822BAA00
	}
}
