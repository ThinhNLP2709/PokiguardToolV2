/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.Specialized
{
	public struct BitVector32 // TypeDefIndex: 8949
	{
		// Fields
		private uint _data; // 0x00
	
		// Properties
		public bool this[int bit] { get => default; set {} } // 0x0000000181BC0E50-0x0000000181BC0E70 0x0000000181BC0E70-0x0000000181BC0E90
	
		// Methods
		public static int CreateMask(); // 0x0000000180472790-0x00000001804727A0
		public static int CreateMask(int previous); // 0x0000000181BC0B60-0x0000000181BC0BE0
		public override bool Equals(object o); // 0x0000000181BC0BE0-0x0000000181BC0C60
		public override int GetHashCode(); // 0x0000000181BC0C60-0x0000000181BC0CB0
		public static string ToString(BitVector32 value); // 0x0000000181BC0D80-0x0000000181BC0E50
		public override string ToString(); // 0x0000000181BC0CB0-0x0000000181BC0D80
	}
}
