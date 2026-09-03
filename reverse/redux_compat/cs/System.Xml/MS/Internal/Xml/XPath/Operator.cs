/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.XPath;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace MS.Internal.Xml.XPath
{
	internal class Operator : AstNode // TypeDefIndex: 7306
	{
		// Fields
		private static Op[] s_invertOp; // 0x00
		private Op _opType; // 0x10
		private AstNode _opnd1; // 0x18
		private AstNode _opnd2; // 0x20
	
		// Properties
		public override AstType Type { get; } // 0x0000000180472790-0x00000001804727A0 
		public override XPathResultType ReturnType { get; } // 0x0000000181A21110-0x0000000181A21130 
	
		// Nested types
		public enum Op // TypeDefIndex: 7307
		{
			INVALID = 0,
			OR = 1,
			AND = 2,
			EQ = 3,
			NE = 4,
			LT = 5,
			LE = 6,
			GT = 7,
			GE = 8,
			PLUS = 9,
			MINUS = 10,
			MUL = 11,
			DIV = 12,
			MOD = 13,
			UNION = 14
		}
	
		// Constructors
		public Operator(Op op, AstNode opnd1, AstNode opnd2); // 0x00000001810F81C0-0x00000001810F8220
		static Operator(); // 0x0000000181A21080-0x0000000181A21110
	}
}
