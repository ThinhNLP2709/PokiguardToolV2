/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class ValueType // TypeDefIndex: 2504
	{
		// Constructors
		protected ValueType(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static bool InternalEquals(object o1, object o2, out object[] fields); // 0x0000000181679240-0x0000000181679250
		internal static bool DefaultEquals(object o1, object o2); // 0x0000000181679000-0x00000001816791B0
		public override bool Equals(object obj); // 0x00000001816355A0-0x00000001816355B0
		internal static int InternalGetHashCode(object o, out object[] fields); // 0x0000000181679250-0x0000000181679260
		public override int GetHashCode(); // 0x00000001816791B0-0x0000000181679240
		public override string ToString(); // 0x0000000181679260-0x0000000181679290
	}
}
