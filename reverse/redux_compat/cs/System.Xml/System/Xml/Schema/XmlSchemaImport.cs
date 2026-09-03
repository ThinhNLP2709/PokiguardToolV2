/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaImport : XmlSchemaExternal // TypeDefIndex: 7227
	{
		// Fields
		private string ns; // 0x68
		private XmlSchemaAnnotation annotation; // 0x70
	
		// Properties
		[XmlAttribute("namespace", DataType = "anyURI")]
		public string Namespace { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
	
		// Constructors
		public XmlSchemaImport(); // 0x00000001819DE860-0x00000001819DE880
	
		// Methods
		internal override void AddAnnotation(XmlSchemaAnnotation annotation); // 0x0000000180434A10-0x0000000180434A20
	}
}
