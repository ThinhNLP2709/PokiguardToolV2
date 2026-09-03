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
	internal class ChameleonKey // TypeDefIndex: 7010
	{
		// Fields
		internal string targetNS; // 0x10
		internal Uri chameleonLocation; // 0x18
		internal XmlSchema originalSchema; // 0x20
		private int hashCode; // 0x28
	
		// Constructors
		public ChameleonKey(string ns, XmlSchema originalSchema); // 0x0000000181AC8470-0x0000000181AC8500
	
		// Methods
		public override int GetHashCode(); // 0x0000000181AC83D0-0x0000000181AC8470
		public override bool Equals(object obj); // 0x0000000181AC82F0-0x0000000181AC83D0
	}
}
