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
	public struct int3 : IEquatable<Unity.Mathematics.int3>, IFormattable // TypeDefIndex: 15238
	{
		// Fields
		public int x; // 0x00
		public int y; // 0x04
		public int z; // 0x08
	
		// Properties
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 yz { get; } // 0x00000001822BA510-0x00000001822BA530 
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15239
		{
		}
	
		// Constructors
		public int3(int x, int y, int z); // 0x0000000180F46690-0x0000000180F466A0
	
		// Methods
		public bool Equals(int3 rhs); // 0x00000001821FD540-0x00000001821FD560
		public override bool Equals(object o); // 0x00000001822BA2E0-0x00000001822BA360
		public override int GetHashCode(); // 0x00000001822BA360-0x00000001822BA3B0
		public override string ToString(); // 0x00000001822BA470-0x00000001822BA510
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822BA3B0-0x00000001822BA470
	}
}
