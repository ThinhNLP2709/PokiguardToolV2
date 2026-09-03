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
	public struct uint2 : IEquatable<Unity.Mathematics.uint2>, IFormattable // TypeDefIndex: 15244
	{
		// Fields
		public uint x; // 0x00
		public uint y; // 0x04
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15245
		{
		}
	
		// Constructors
		public uint2(uint x, uint y); // 0x0000000180C55C70-0x0000000180C55C80
	
		// Methods
		public static uint2 operator *(uint2 lhs, uint2 rhs); // 0x00000001822BFAF0-0x00000001822BFB10
		public static uint2 operator +(uint2 lhs, uint2 rhs); // 0x00000001821FC4C0-0x00000001821FC4E0
		public bool Equals(uint2 rhs); // 0x000000018219A7A0-0x000000018219A7C0
		public override bool Equals(object o); // 0x00000001822BF930-0x00000001822BF990
		public override int GetHashCode(); // 0x00000001822BF990-0x00000001822BF9E0
		public override string ToString(); // 0x00000001822BFA70-0x00000001822BFAF0
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822BF9E0-0x00000001822BFA70
	}
}
