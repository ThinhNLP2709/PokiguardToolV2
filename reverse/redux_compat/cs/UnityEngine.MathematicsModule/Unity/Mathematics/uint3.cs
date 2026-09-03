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
	[DebuggerTypeProxy(typeof(DebuggerProxy))]
	[DefaultMember("Item")]
	[Il2CppEagerStaticClassConstruction]
	public struct uint3 : IEquatable<Unity.Mathematics.uint3>, IFormattable // TypeDefIndex: 15246
	{
		// Fields
		public uint x; // 0x00
		public uint y; // 0x04
		public uint z; // 0x08
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15247
		{
		}
	
		// Constructors
		public uint3(uint x, uint y, uint z); // 0x0000000180F46690-0x0000000180F466A0
	
		// Methods
		public static uint3 operator *(uint3 lhs, uint3 rhs); // 0x00000001822BFD60-0x00000001822BFD90
		public static uint3 operator +(uint3 lhs, uint3 rhs); // 0x00000001821FD9C0-0x00000001821FD9E0
		public static uint3 operator -(uint3 lhs, uint rhs); // 0x00000001822BFD90-0x00000001822BFDB0
		public static uint3 operator /(uint3 lhs, uint3 rhs); // 0x00000001822BFD10-0x00000001822BFD40
		public static uint3 operator &(uint3 lhs, uint rhs); // 0x00000001822BFCF0-0x00000001822BFD10
		public static uint3 operator ^(uint3 lhs, uint3 rhs); // 0x00000001822BFD40-0x00000001822BFD60
		public bool Equals(uint3 rhs); // 0x00000001821FD540-0x00000001821FD560
		public override bool Equals(object o); // 0x00000001822BFB10-0x00000001822BFB90
		public override int GetHashCode(); // 0x00000001822BBC30-0x00000001822BBC80
		public override string ToString(); // 0x00000001822BFC50-0x00000001822BFCF0
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822BFB90-0x00000001822BFC50
	}
}
