/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal sealed class BitSet // TypeDefIndex: 7009
	{
		// Fields
		private int count; // 0x10
		private uint[] bits; // 0x18
	
		// Properties
		public int Count { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public bool this[int index] { get => default; } // 0x0000000181AC7E60-0x0000000181AC7EB0 
		public bool IsEmpty { get; } // 0x0000000181AC81D0-0x0000000181AC8230 
	
		// Constructors
		private BitSet(); // 0x00000001802E5CB0-0x00000001802E5CC0
		public BitSet(int count); // 0x0000000181AC8160-0x0000000181AC81D0
	
		// Methods
		public void Clear(); // 0x0000000181AC7AB0-0x0000000181AC7B10
		public void Set(int index); // 0x0000000181AC80E0-0x0000000181AC8150
		public bool Get(int index); // 0x0000000181AC7E60-0x0000000181AC7EB0
		public int NextSet(int startFrom); // 0x0000000181AC7FA0-0x0000000181AC8040
		public void And(BitSet other); // 0x0000000181AC79D0-0x0000000181AC7AB0
		public void Or(BitSet other); // 0x0000000181AC8040-0x0000000181AC80E0
		public override int GetHashCode(); // 0x0000000181AC7E20-0x0000000181AC7E60
		public override bool Equals(object obj); // 0x0000000181AC7C90-0x0000000181AC7E20
		public BitSet Clone(); // 0x0000000181AC7B10-0x0000000181AC7C00
		public bool Intersects(BitSet other); // 0x0000000181AC7EB0-0x0000000181AC7FA0
		private int Subscript(int bitIndex); // 0x0000000181AC8150-0x0000000181AC8160
		private void EnsureLength(int nRequiredLength); // 0x0000000181AC7C00-0x0000000181AC7C90
	}
}
