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
	public struct int2 : IEquatable<Unity.Mathematics.int2>, IFormattable // TypeDefIndex: 15236
	{
		// Fields
		public int x; // 0x00
		public int y; // 0x04
		public static readonly int2 zero; // 0x00
	
		// Properties
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyxy { get; } // 0x00000001822BA1E0-0x00000001822BA200 
	
		// Nested types
		internal sealed class DebuggerProxy // TypeDefIndex: 15237
		{
		}
	
		// Constructors
		public int2(int x, int y); // 0x0000000180C55C70-0x0000000180C55C80
		public int2(int v); // 0x00000001822BA1D0-0x00000001822BA1E0
	
		// Methods
		public static implicit operator int2(int v); // 0x00000001822BA240-0x00000001822BA250
		public static int2 operator *(int2 lhs, int rhs); // 0x00000001822BA270-0x00000001822BA290
		public static int2 operator +(int2 lhs, int2 rhs); // 0x00000001821FC4C0-0x00000001821FC4E0
		public static int2 operator +(int2 lhs, int rhs); // 0x00000001822BA200-0x00000001822BA220
		public static int2 operator -(int2 lhs, int rhs); // 0x00000001822BA2C0-0x00000001822BA2E0
		public static int2 operator /(int2 lhs, int rhs); // 0x00000001821FC4E0-0x00000001821FC510
		public static bool2 operator <(int2 lhs, int2 rhs); // 0x00000001822BA250-0x00000001822BA270
		public static int2 operator >>(int2 x, int n); // 0x00000001822BA290-0x00000001822BA2C0
		public static int2 operator |(int2 lhs, int2 rhs); // 0x00000001822BA220-0x00000001822BA240
		public bool Equals(int2 rhs); // 0x000000018219A7A0-0x000000018219A7C0
		public override bool Equals(object o); // 0x00000001822BA010-0x00000001822BA070
		public override int GetHashCode(); // 0x00000001822BA070-0x00000001822BA0C0
		public override string ToString(); // 0x00000001822BA0C0-0x00000001822BA140
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822BA140-0x00000001822BA1D0
	}
}
