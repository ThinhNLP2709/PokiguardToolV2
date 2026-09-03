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

namespace System.Xml
{
	public abstract class XmlLinkedNode : XmlNode // TypeDefIndex: 6828
	{
		// Fields
		internal XmlLinkedNode next; // 0x18
	
		// Properties
		public override XmlNode PreviousSibling { get; } // 0x0000000181A66700-0x0000000181A66790 
		public override XmlNode NextSibling { get; } // 0x0000000181A666A0-0x0000000181A66700 
	
		// Constructors
		internal XmlLinkedNode(XmlDocument doc); // 0x0000000181A66670-0x0000000181A666A0
	}
}
