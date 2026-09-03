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
	internal sealed class ChoiceNode : InteriorNode // TypeDefIndex: 7030
	{
		// Properties
		public override bool IsNullable { get; } // 0x0000000181AC8990-0x0000000181AC8A20 
	
		// Constructors
		public ChoiceNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static void ConstructChildPos(SyntaxTreeNode child, BitSet firstpos, BitSet lastpos, BitSet[] followpos); // 0x0000000181AC8500-0x0000000181AC8680
		public override void ConstructPos(BitSet firstpos, BitSet lastpos, BitSet[] followpos); // 0x0000000181AC8680-0x0000000181AC8980
		public override void ExpandTree(InteriorNode parent, SymbolsDictionary symbols, Positions positions); // 0x0000000181AC8980-0x0000000181AC8990
	}
}
