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
	public class XmlNodeChangedEventArgs : EventArgs // TypeDefIndex: 6836
	{
		// Fields
		private XmlNodeChangedAction action; // 0x10
		private XmlNode node; // 0x18
		private XmlNode oldParent; // 0x20
		private XmlNode newParent; // 0x28
		private string oldValue; // 0x30
		private string newValue; // 0x38
	
		// Properties
		public XmlNodeChangedAction Action { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public XmlNodeChangedEventArgs(XmlNode node, XmlNode oldParent, XmlNode newParent, string oldValue, string newValue, XmlNodeChangedAction action); // 0x0000000181A82260-0x0000000181A82330
	}
}
