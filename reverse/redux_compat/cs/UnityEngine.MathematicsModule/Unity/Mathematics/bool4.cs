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
	public struct bool4 : IEquatable<Unity.Mathematics.bool4> // TypeDefIndex: 15219
	{
		// Fields
		public bool x; // 0x00
		public bool y; // 0x01
		public bool z; // 0x02
		public bool w; // 0x03
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15220
		{
		}
	
		// Constructors
		public bool4(bool x, bool y, bool z, bool w); // 0x0000000180F4CB10-0x0000000180F4CB30
		public bool4(bool v); // 0x00000001822B3C60-0x00000001822B3C70
	
		// Methods
		public static bool4 operator |(bool4 lhs, bool4 rhs); // 0x00000001822B3C70-0x00000001822B3CC0
		public bool Equals(bool4 rhs); // 0x00000001822B39D0-0x00000001822B3A00
		public override bool Equals(object o); // 0x00000001822B3950-0x00000001822B39D0
		public override int GetHashCode(); // 0x00000001822B3A00-0x00000001822B3A60
		public override string ToString(); // 0x00000001822B3A60-0x00000001822B3C60
	}
}
