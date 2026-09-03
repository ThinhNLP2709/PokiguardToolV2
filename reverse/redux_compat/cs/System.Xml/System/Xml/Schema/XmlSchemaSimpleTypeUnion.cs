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
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaSimpleTypeUnion : XmlSchemaSimpleTypeContent // TypeDefIndex: 7253
	{
		// Fields
		private XmlSchemaObjectCollection baseTypes; // 0x50
		private XmlQualifiedName[] memberTypes; // 0x58
		private XmlSchemaSimpleType[] baseMemberTypes; // 0x60
	
		// Properties
		[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
		public XmlSchemaObjectCollection BaseTypes { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		[XmlAttribute("memberTypes")]
		public XmlQualifiedName[] MemberTypes { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		[XmlIgnore]
		public XmlSchemaSimpleType[] BaseMemberTypes { get; } // 0x0000000180333260-0x0000000180333490 
	
		// Constructors
		public XmlSchemaSimpleTypeUnion(); // 0x00000001819F1410-0x00000001819F1480
	
		// Methods
		internal void SetBaseMemberTypes(XmlSchemaSimpleType[] baseMemberTypes); // 0x00000001803780F0-0x0000000180378100
		internal override XmlSchemaObject Clone(); // 0x00000001819F1230-0x00000001819F1410
	}
}
