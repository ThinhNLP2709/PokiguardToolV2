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

namespace System.Xml.Schema
{
	internal sealed class Parser // TypeDefIndex: 7133
	{
		// Fields
		private SchemaType schemaType; // 0x10
		private XmlNameTable nameTable; // 0x18
		private SchemaNames schemaNames; // 0x20
		private ValidationEventHandler eventHandler; // 0x28
		private XmlNamespaceManager namespaceManager; // 0x30
		private XmlReader reader; // 0x38
		private PositionInfo positionInfo; // 0x40
		private bool isProcessNamespaces; // 0x48
		private int schemaXmlDepth; // 0x4C
		private int markupDepth; // 0x50
		private SchemaBuilder builder; // 0x58
		private XmlSchema schema; // 0x60
		private SchemaInfo xdrSchema; // 0x68
		private XmlResolver xmlResolver; // 0x70
		private XmlDocument dummyDocument; // 0x78
		private bool processMarkup; // 0x80
		private XmlNode parentNode; // 0x88
		private XmlNamespaceManager annotationNSManager; // 0x90
		private string xmlns; // 0x98
		private XmlCharType xmlCharType; // 0xA0
	
		// Properties
		public XmlSchema XmlSchema { get; } // 0x0000000180333260-0x0000000180333490 
		internal XmlResolver XmlResolver { set; } // 0x0000000180434A10-0x0000000180434A20
		public SchemaInfo XdrSchema { get; } // 0x0000000180316960-0x0000000180316970 
	
		// Constructors
		public Parser(SchemaType schemaType, XmlNameTable nameTable, SchemaNames schemaNames, ValidationEventHandler eventHandler); // 0x0000000181979280-0x0000000181979380
	
		// Methods
		public SchemaType Parse(XmlReader reader, string targetNamespace); // 0x0000000181978960-0x00000001819789D0
		public void StartParsing(XmlReader reader, string targetNamespace); // 0x0000000181978D10-0x0000000181979280
		private bool CheckSchemaRoot(SchemaType rootType, out string code); // 0x0000000181977500-0x0000000181977620
		public SchemaType FinishParsing(); // 0x00000001802E64B0-0x00000001802E64C0
		public bool ParseReaderNode(); // 0x0000000181978050-0x0000000181978960
		private void ProcessAppInfoDocMarkup(bool root); // 0x00000001819789D0-0x0000000181978D10
		private XmlElement LoadElementNode(bool root); // 0x0000000181977910-0x0000000181977DE0
		private XmlAttribute CreateXmlNsAttribute(string prefix, string value); // 0x0000000181977620-0x0000000181977750
		private XmlAttribute LoadAttributeNode(); // 0x0000000181977750-0x0000000181977910
		private XmlEntityReference LoadEntityReferenceInAttribute(); // 0x0000000181977DE0-0x0000000181978050
	}
}
