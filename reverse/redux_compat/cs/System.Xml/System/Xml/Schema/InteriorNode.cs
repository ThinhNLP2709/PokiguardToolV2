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
	internal abstract class InteriorNode : SyntaxTreeNode // TypeDefIndex: 7027
	{
		// Fields
		private SyntaxTreeNode leftChild; // 0x10
		private SyntaxTreeNode rightChild; // 0x18
	
		// Properties
		public SyntaxTreeNode LeftChild { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public SyntaxTreeNode RightChild { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		protected InteriorNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected void ExpandTreeNoRecursive(InteriorNode parent, SymbolsDictionary symbols, Positions positions); // 0x0000000181ACC780-0x0000000181ACC990
		public override void ExpandTree(InteriorNode parent, SymbolsDictionary symbols, Positions positions); // 0x0000000181ACC990-0x0000000181ACCA10
	}
}
