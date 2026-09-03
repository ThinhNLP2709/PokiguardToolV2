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
	public struct double4 : IEquatable<Unity.Mathematics.double4>, IFormattable // TypeDefIndex: 15223
	{
		// Fields
		public double x; // 0x00
		public double y; // 0x08
		public double z; // 0x10
		public double w; // 0x18
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15224
		{
		}
	
		// Constructors
		public double4(double x, double y, double z, double w); // 0x00000001822B4530-0x00000001822B4550
	
		// Methods
		public static double4 operator +(double4 lhs, double4 rhs); // 0x00000001822B4550-0x00000001822B45A0
		public bool Equals(double4 rhs); // 0x00000001822B4030-0x00000001822B4080
		public override bool Equals(object o); // 0x00000001822B3FA0-0x00000001822B4030
		public override int GetHashCode(); // 0x00000001822B4080-0x00000001822B4110
		public override string ToString(); // 0x00000001822B4320-0x00000001822B4530
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B4110-0x00000001822B4320
	}
}
