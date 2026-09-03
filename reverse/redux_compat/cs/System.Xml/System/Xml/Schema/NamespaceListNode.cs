/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class NamespaceListNode : SyntaxTreeNode // TypeDefIndex: 7026
	{
		// Fields
		protected NamespaceList namespaceList; // 0x10
		protected object particle; // 0x18
	
		// Properties
		public override bool IsNullable { get; } // 0x0000000181ACE6F0-0x0000000181ACE730 
	
		// Constructors
		public NamespaceListNode(NamespaceList namespaceList, object particle); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		public virtual ICollection GetResolvedSymbols(SymbolsDictionary symbols); // 0x0000000181ACE6C0-0x0000000181ACE6F0
		public override void ExpandTree(InteriorNode parent, SymbolsDictionary symbols, Positions positions); // 0x0000000181ACE340-0x0000000181ACE6C0
		public override void ConstructPos(BitSet firstpos, BitSet lastpos, BitSet[] followpos); // 0x0000000181ACE300-0x0000000181ACE340
	}
}
