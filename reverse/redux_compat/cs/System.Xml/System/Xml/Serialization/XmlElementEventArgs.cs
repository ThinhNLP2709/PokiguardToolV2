/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	public class XmlElementEventArgs : EventArgs // TypeDefIndex: 6915
	{
		// Fields
		private object o; // 0x10
		private XmlElement elem; // 0x18
		private string qnames; // 0x20
		private int lineNumber; // 0x28
		private int linePosition; // 0x2C
	
		// Constructors
		internal XmlElementEventArgs(XmlElement elem, int lineNumber, int linePosition, object o, string qnames); // 0x0000000181AA2D20-0x0000000181AA2DD0
	}
}
