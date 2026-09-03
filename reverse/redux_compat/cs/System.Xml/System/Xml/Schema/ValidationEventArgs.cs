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
	public class ValidationEventArgs : EventArgs // TypeDefIndex: 7155
	{
		// Fields
		private XmlSchemaException ex; // 0x10
		private XmlSeverityType severity; // 0x18
	
		// Properties
		public XmlSeverityType Severity { get; } // 0x0000000180B23260-0x0000000180B23270 
		public XmlSchemaException Exception { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		internal ValidationEventArgs(XmlSchemaException ex); // 0x00000001819C8790-0x00000001819C8800
		internal ValidationEventArgs(XmlSchemaException ex, XmlSeverityType severity); // 0x00000001819C8800-0x00000001819C8880
	}
}
