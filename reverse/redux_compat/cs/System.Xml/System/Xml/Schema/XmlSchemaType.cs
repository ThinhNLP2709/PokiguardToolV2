/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
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
	public class XmlSchemaType : XmlSchemaAnnotated // TypeDefIndex: 7256
	{
		// Fields
		private string name; // 0x50
		private XmlSchemaDerivationMethod final; // 0x58
		private XmlSchemaDerivationMethod derivedBy; // 0x5C
		private XmlSchemaType baseSchemaType; // 0x60
		private XmlSchemaDatatype datatype; // 0x68
		private XmlSchemaDerivationMethod finalResolved; // 0x70
		private SchemaElementDecl elementDecl; // 0x78
		private XmlQualifiedName qname; // 0x80
		private XmlSchemaType redefined; // 0x88
		private XmlSchemaContentType contentType; // 0x90
	
		// Properties
		[XmlAttribute("name")]
		public string Name { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[DefaultValue(XmlSchemaDerivationMethod.Empty | XmlSchemaDerivationMethod.None)]
		[XmlAttribute("final")]
		public XmlSchemaDerivationMethod Final { get; set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		[XmlIgnore]
		public XmlQualifiedName QualifiedName { get; } // 0x00000001819F1E00-0x00000001819F1E20 
		[XmlIgnore]
		public XmlSchemaDerivationMethod FinalResolved { get; } // 0x0000000180CC2260-0x0000000180CC2270 
		[XmlIgnore]
		public XmlSchemaType BaseXmlSchemaType { get; } // 0x0000000180333260-0x0000000180333490 
		[XmlIgnore]
		public XmlSchemaDerivationMethod DerivedBy { get; } // 0x000000018033D270-0x000000018033D280 
		[XmlIgnore]
		public XmlSchemaDatatype Datatype { get; } // 0x0000000180316960-0x0000000180316970 
		[XmlIgnore]
		public virtual bool IsMixed { get; set; } // 0x00000001802E7840-0x00000001802E7850 0x00000001802E76C0-0x00000001802E76D0
		[XmlIgnore]
		public XmlTypeCode TypeCode { get; } // 0x00000001819F1E20-0x00000001819F1EF0 
		[XmlIgnore]
		internal XmlValueConverter ValueConverter { get; } // 0x00000001819F1EF0-0x00000001819F1F70 
		internal XmlSchemaContentType SchemaContentType { get; } // 0x000000018169CBC0-0x000000018169CBD0 
		internal SchemaElementDecl ElementDecl { get; set; } // 0x00000001819F1DE0-0x00000001819F1E00 0x00000001819F1F70-0x00000001819F1FA0
		[XmlIgnore]
		internal XmlSchemaType Redefined { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
		[XmlIgnore]
		internal override string NameAttribute { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		public XmlSchemaType(); // 0x00000001819F15B0-0x00000001819F1640
	
		// Methods
		public static XmlSchemaSimpleType GetBuiltInSimpleType(XmlQualifiedName qualifiedName); // 0x00000001819F1A20-0x00000001819F1AF0
		public static XmlSchemaSimpleType GetBuiltInSimpleType(XmlTypeCode typeCode); // 0x00000001819F1AF0-0x00000001819F1B40
		public static XmlSchemaComplexType GetBuiltInComplexType(XmlQualifiedName qualifiedName); // 0x00000001819F17E0-0x00000001819F1A20
		internal void SetQualifiedName(XmlQualifiedName value); // 0x00000001819F1DA0-0x00000001819F1DE0
		internal void SetFinalResolved(XmlSchemaDerivationMethod value); // 0x0000000180CC2270-0x0000000180CC2280
		internal void SetBaseSchemaType(XmlSchemaType value); // 0x00000001803780F0-0x0000000180378100
		internal void SetDerivedBy(XmlSchemaDerivationMethod value); // 0x000000018033E880-0x000000018033E890
		internal void SetDatatype(XmlSchemaDatatype value); // 0x0000000180316A40-0x0000000180316A50
		internal void SetContentType(XmlSchemaContentType value); // 0x000000018170C9F0-0x000000018170CA00
		public static bool IsDerivedFrom(XmlSchemaType derivedType, XmlSchemaType baseType, XmlSchemaDerivationMethod except); // 0x00000001819F1C20-0x00000001819F1DA0
		internal static bool IsDerivedFromDatatype(XmlSchemaDatatype derivedDataType, XmlSchemaDatatype baseDataType, XmlSchemaDerivationMethod except); // 0x00000001819F1B40-0x00000001819F1C20
	}
}
