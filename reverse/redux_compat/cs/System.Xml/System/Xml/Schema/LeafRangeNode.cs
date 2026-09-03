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
	internal sealed class LeafRangeNode : LeafNode // TypeDefIndex: 7034
	{
		// Fields
		private decimal min; // 0x18
		private decimal max; // 0x28
		private BitSet nextIteration; // 0x38
	
		// Properties
		public decimal Max { get; } // 0x0000000180C46B90-0x0000000180C46BA0 
		public decimal Min { get; } // 0x0000000180A5E120-0x0000000180A5E130 
		public BitSet NextIteration { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public override bool IsRangeNode { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		public LeafRangeNode(decimal min, decimal max); // 0x0000000181ACD410-0x0000000181ACD460
		public LeafRangeNode(int pos, decimal min, decimal max); // 0x0000000181ACD460-0x0000000181ACD4B0
	
		// Methods
		public override void ExpandTree(InteriorNode parent, SymbolsDictionary symbols, Positions positions); // 0x0000000181ACD3C0-0x0000000181ACD410
	}
}
