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

namespace System.Reflection.Emit
{
	[ComVisible(true)]
	[IsReadOnly]
	public struct OpCode : IEquatable<OpCode> // TypeDefIndex: 3375
	{
		// Fields
		internal readonly byte op1; // 0x00
		internal readonly byte op2; // 0x01
		private readonly byte push; // 0x02
		private readonly byte pop; // 0x03
		private readonly byte size; // 0x04
		private readonly byte type; // 0x05
		private readonly byte args; // 0x06
		private readonly byte flow; // 0x07
	
		// Properties
		public string Name { get; } // 0x0000000181530970-0x0000000181530A30 
	
		// Constructors
		internal OpCode(int p, int q); // 0x0000000181530930-0x0000000181530970
	
		// Methods
		public override int GetHashCode(); // 0x00000001815308E0-0x0000000181530920
		public override bool Equals(object obj); // 0x0000000181530850-0x00000001815308E0
		public bool Equals(OpCode obj); // 0x0000000181530830-0x0000000181530850
		public override string ToString(); // 0x0000000181530920-0x0000000181530930
	}
}
