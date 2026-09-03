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
	public class XmlSchemaRedefine : XmlSchemaExternal // TypeDefIndex: 7243
	{
		// Fields
		private XmlSchemaObjectCollection items; // 0x68
		private XmlSchemaObjectTable attributeGroups; // 0x70
		private XmlSchemaObjectTable types; // 0x78
		private XmlSchemaObjectTable groups; // 0x80
	
		// Properties
		[XmlElement("annotation", typeof(XmlSchemaAnnotation))]
		[XmlElement("complexType", typeof(XmlSchemaComplexType))]
		[XmlElement("group", typeof(XmlSchemaGroup))]
		[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
		[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroup))]
		public XmlSchemaObjectCollection Items { get; } // 0x0000000180316960-0x0000000180316970 
		[XmlIgnore]
		public XmlSchemaObjectTable AttributeGroups { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		[XmlIgnore]
		public XmlSchemaObjectTable SchemaTypes { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		[XmlIgnore]
		public XmlSchemaObjectTable Groups { get; } // 0x000000018033D4A0-0x000000018033D4B0 
	
		// Constructors
		public XmlSchemaRedefine(); // 0x00000001819E8E30-0x00000001819E8F30
	
		// Methods
		internal override void AddAnnotation(XmlSchemaAnnotation annotation); // 0x00000001819E8E10-0x00000001819E8E30
	}
}
