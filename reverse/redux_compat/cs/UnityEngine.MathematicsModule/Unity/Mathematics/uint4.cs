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
	[Il2CppEagerStaticClassConstruction]
	public struct uint4 : IEquatable<Unity.Mathematics.uint4>, IFormattable // TypeDefIndex: 15248
	{
		// Fields
		public uint x; // 0x00
		public uint y; // 0x04
		public uint z; // 0x08
		public uint w; // 0x0C
	
		// Properties
		public uint this[int index] { set {} } // 0x0000000180A302E0-0x0000000180A302F0
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15249
		{
		}
	
		// Constructors
		public uint4(uint x, uint y, uint z, uint w); // 0x000000018192E480-0x000000018192E4A0
		public uint4(uint v); // 0x00000001822C0240-0x00000001822C0250
	
		// Methods
		public static implicit operator uint4(uint v); // 0x00000001822C0340-0x00000001822C0350
		public static uint4 operator *(uint4 lhs, uint4 rhs); // 0x00000001822C0380-0x00000001822C03B0
		public static uint4 operator *(uint4 lhs, uint rhs); // 0x00000001822C03B0-0x00000001822C03E0
		public static uint4 operator +(uint4 lhs, uint4 rhs); // 0x00000001822C0280-0x00000001822C02B0
		public static uint4 operator +(uint4 lhs, uint rhs); // 0x00000001822C0250-0x00000001822C0280
		public static bool4 operator >(uint4 lhs, uint rhs); // 0x00000001822C0310-0x00000001822C0340
		public static uint4 operator <<(uint4 x, int n); // 0x00000001822C0350-0x00000001822C0380
		public static uint4 operator >>(uint4 x, int n); // 0x00000001822C03E0-0x00000001822C0420
		public static uint4 operator &(uint4 lhs, uint rhs); // 0x00000001822C02B0-0x00000001822C02E0
		public static uint4 operator |(uint4 lhs, uint4 rhs); // 0x00000001822C02E0-0x00000001822C0310
		public bool Equals(uint4 rhs); // 0x00000001815FB130-0x00000001815FB160
		public override bool Equals(object o); // 0x00000001822BFDB0-0x00000001822BFE30
		public override int GetHashCode(); // 0x00000001822BB9D0-0x00000001822BBA20
		public override string ToString(); // 0x00000001822C0040-0x00000001822C0240
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822BFE30-0x00000001822C0040
	}
}
