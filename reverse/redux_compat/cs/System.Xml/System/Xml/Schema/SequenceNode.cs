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
	internal sealed class SequenceNode : InteriorNode // TypeDefIndex: 7028
	{
		// Properties
		public override bool IsNullable { get; } // 0x0000000181AD2DE0-0x0000000181AD2FB0 
	
		// Nested types
		private struct SequenceConstructPosContext // TypeDefIndex: 7029
		{
			// Fields
			public SequenceNode this_; // 0x00
			public BitSet firstpos; // 0x08
			public BitSet lastpos; // 0x10
			public BitSet lastposLeft; // 0x18
			public BitSet firstposRight; // 0x20
	
			// Constructors
			public SequenceConstructPosContext(SequenceNode node, BitSet firstpos, BitSet lastpos); // 0x0000000181AD2590-0x0000000181AD2600
		}
	
		// Constructors
		public SequenceNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override void ConstructPos(BitSet firstpos, BitSet lastpos, BitSet[] followpos); // 0x0000000181AD2600-0x0000000181AD2DE0
		public override void ExpandTree(InteriorNode parent, SymbolsDictionary symbols, Positions positions); // 0x0000000181AC8980-0x0000000181AC8990
	}
}
