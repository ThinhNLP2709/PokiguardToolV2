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
	internal class LeafNode : SyntaxTreeNode // TypeDefIndex: 7025
	{
		// Fields
		private int pos; // 0x10
	
		// Properties
		public int Pos { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public override bool IsNullable { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		public LeafNode(int pos); // 0x00000001802F9040-0x00000001802F9070
	
		// Methods
		public override void ExpandTree(InteriorNode parent, SymbolsDictionary symbols, Positions positions); // 0x00000001802E76C0-0x00000001802E76D0
		public override void ConstructPos(BitSet firstpos, BitSet lastpos, BitSet[] followpos); // 0x0000000181ACD2F0-0x0000000181ACD3C0
	}
}
