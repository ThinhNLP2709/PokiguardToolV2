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
	public struct double2 : IEquatable<Unity.Mathematics.double2>, IFormattable // TypeDefIndex: 15221
	{
		// Fields
		public double x; // 0x00
		public double y; // 0x08
		public static readonly double2 zero; // 0x00
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15222
		{
		}
	
		// Constructors
		public double2(double x, double y); // 0x00000001822B3F00-0x00000001822B3F10
		public double2(float2 v); // 0x00000001822B3F10-0x00000001822B3F40
	
		// Methods
		public static implicit operator double2(float2 v); // 0x00000001822B3F40-0x00000001822B3F70
		public static double2 operator -(double2 lhs, double2 rhs); // 0x00000001822B3F70-0x00000001822B3FA0
		public bool Equals(double2 rhs); // 0x00000001822B3CC0-0x00000001822B3CE0
		public override bool Equals(object o); // 0x00000001822B3CE0-0x00000001822B3D50
		public override int GetHashCode(); // 0x00000001822B3D50-0x00000001822B3DE0
		public override string ToString(); // 0x00000001822B3E70-0x00000001822B3F00
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B3DE0-0x00000001822B3E70
	}
}
