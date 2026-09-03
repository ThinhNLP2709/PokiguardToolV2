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
	internal class Operand : AstNode // TypeDefIndex: 7305
	{
		// Fields
		private XPathResultType _type; // 0x10
		private object _val; // 0x18
	
		// Properties
		public override AstType Type { get; } // 0x000000018071E4A0-0x000000018071E4B0 
		public override XPathResultType ReturnType { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public Operand(string val); // 0x0000000181A20FE0-0x0000000181A21020
		public Operand(double val); // 0x0000000181A21020-0x0000000181A21080
	}
}
