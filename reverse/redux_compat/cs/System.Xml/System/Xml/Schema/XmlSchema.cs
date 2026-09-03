/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
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
	[XmlRoot("schema", Namespace = "http://www.w3.org/2001/XMLSchema")]
	public class XmlSchema : XmlSchemaObject // TypeDefIndex: 7174
	{
		// Fields
		private XmlSchemaForm attributeFormDefault; // 0x38
		private XmlSchemaForm elementFormDefault; // 0x3C
		private XmlSchemaDerivationMethod blockDefault; // 0x40
		private XmlSchemaDerivationMethod finalDefault; // 0x44
		private string targetNs; // 0x48
		private string version; // 0x50
		private XmlSchemaObjectCollection includes; // 0x58
		private XmlSchemaObjectCollection items; // 0x60
		private string id; // 0x68
		private XmlAttribute[] moreAttributes; // 0x70
		private bool isCompiled; // 0x78
		private bool isCompiledBySet; // 0x79
		private bool isPreprocessed; // 0x7A
		private bool isRedefined; // 0x7B
		private int errorCount; // 0x7C
		private XmlSchemaObjectTable attributes; // 0x80
		private XmlSchemaObjectTable attributeGroups; // 0x88
		private XmlSchemaObjectTable elements; // 0x90
		private XmlSchemaObjectTable types; // 0x98
		private XmlSchemaObjectTable groups; // 0xA0
		private XmlSchemaObjectTable notations; // 0xA8
		private XmlSchemaObjectTable identityConstraints; // 0xB0
		private static int globalIdCounter; // 0x00
		private ArrayList importedSchemas; // 0xB8
		private ArrayList importedNamespaces; // 0xC0
		private int schemaId; // 0xC8
		private Uri baseUri; // 0xD0
		private bool isChameleon; // 0xD8
		private Hashtable ids; // 0xE0
		private XmlDocument document; // 0xE8
	
		// Properties
		[DefaultValue(XmlSchemaForm.None)]
		[XmlAttribute("attributeFormDefault")]
		public XmlSchemaForm AttributeFormDefault { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		[DefaultValue(XmlSchemaDerivationMethod.Empty | XmlSchemaDerivationMethod.None)]
		[XmlAttribute("blockDefault")]
		public XmlSchemaDerivationMethod BlockDefault { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
		[DefaultValue(XmlSchemaDerivationMethod.Empty | XmlSchemaDerivationMethod.None)]
		[XmlAttribute("finalDefault")]
		public XmlSchemaDerivationMethod FinalDefault { get; set; } // 0x000000018033D780-0x000000018033D790 0x000000018033ED00-0x000000018033ED10
		[DefaultValue(XmlSchemaForm.None)]
		[XmlAttribute("elementFormDefault")]
		public XmlSchemaForm ElementFormDefault { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
		[XmlAttribute("targetNamespace", DataType = "anyURI")]
		public string TargetNamespace { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		[XmlAttribute("version", DataType = "token")]
		public string Version { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[XmlElement("import", typeof(XmlSchemaImport))]
		[XmlElement("include", typeof(XmlSchemaInclude))]
		[XmlElement("redefine", typeof(XmlSchemaRedefine))]
		public XmlSchemaObjectCollection Includes { get; } // 0x00000001802F4000-0x00000001802F4010 
		[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroup))]
		[XmlElement("annotation", typeof(XmlSchemaAnnotation))]
		[XmlElement("notation", typeof(XmlSchemaNotation))]
		[XmlElement("attribute", typeof(XmlSchemaAttribute))]
		[XmlElement("group", typeof(XmlSchemaGroup))]
		[XmlElement("element", typeof(XmlSchemaElement))]
		[XmlElement("complexType", typeof(XmlSchemaComplexType))]
		[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
		public XmlSchemaObjectCollection Items { get; } // 0x0000000180333260-0x0000000180333490 
		[XmlIgnore]
		internal bool IsCompiledBySet { get; set; } // 0x00000001819DD3E0-0x00000001819DD3F0 0x00000001819E0730-0x00000001819E0740
		[XmlIgnore]
		internal bool IsPreprocessed { get; set; } // 0x000000018186F5B0-0x000000018186F5C0 0x000000018186F7F0-0x000000018186F800
		[XmlIgnore]
		internal bool IsRedefined { get; set; } // 0x00000001819DD420-0x00000001819DD430 0x00000001819E0740-0x00000001819E09C0
		[XmlIgnore]
		public XmlSchemaObjectTable Attributes { get; } // 0x00000001819E03A0-0x00000001819E0420 
		[XmlIgnore]
		public XmlSchemaObjectTable AttributeGroups { get; } // 0x00000001819E0320-0x00000001819E03A0 
		[XmlIgnore]
		public XmlSchemaObjectTable SchemaTypes { get; } // 0x00000001819E0690-0x00000001819E0710 
		[XmlIgnore]
		public XmlSchemaObjectTable Elements { get; } // 0x00000001819E04A0-0x00000001819E0520 
		[XmlAttribute("id", DataType = "ID")]
		public string Id { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		[XmlIgnore]
		public XmlSchemaObjectTable Groups { get; } // 0x00000001805B5990-0x00000001805B59A0 
		[XmlIgnore]
		public XmlSchemaObjectTable Notations { get; } // 0x000000018033D510-0x000000018033D520 
		[XmlIgnore]
		internal XmlSchemaObjectTable IdentityConstraints { get; } // 0x00000001806BAE60-0x00000001806BAE70 
		[XmlIgnore]
		internal Uri BaseUri { get; set; } // 0x00000001806CCB60-0x00000001806CCB70 0x00000001806CCD80-0x00000001806CCDA0
		[XmlIgnore]
		internal int SchemaId { get; } // 0x00000001819E0620-0x00000001819E0690 
		[XmlIgnore]
		internal bool IsChameleon { get; set; } // 0x0000000180665200-0x0000000180665210 0x00000001819E0720-0x00000001819E0730
		[XmlIgnore]
		internal Hashtable Ids { get; } // 0x00000001806CCB80-0x00000001806CCB90 
		[XmlIgnore]
		internal XmlDocument Document { get; } // 0x00000001819E0420-0x00000001819E04A0 
		[XmlIgnore]
		internal int ErrorCount { get; set; } // 0x00000001816A5830-0x00000001816A5840 0x00000001819E0710-0x00000001819E0720
		[XmlIgnore]
		internal override string IdAttribute { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		internal ArrayList ImportedSchemas { get; } // 0x00000001819E05A0-0x00000001819E0620 
		internal ArrayList ImportedNamespaces { get; } // 0x00000001819E0520-0x00000001819E05A0 
	
		// Constructors
		public XmlSchema(); // 0x00000001819E0110-0x00000001819E0320
		static XmlSchema(); // 0x00000001819E00D0-0x00000001819E0110
	
		// Methods
		public static XmlSchema Read(XmlReader reader, ValidationEventHandler validationEventHandler); // 0x00000001819DFF70-0x00000001819E00D0
		internal bool CompileSchema(XmlSchemaCollection xsc, XmlResolver resolver, SchemaInfo schemaInfo, string ns, ValidationEventHandler validationEventHandler, XmlNameTable nameTable, bool CompileContentModel); // 0x00000001819DF750-0x00000001819DF950
		internal void CompileSchemaInSet(XmlNameTable nameTable, ValidationEventHandler eventHandler, XmlSchemaCompilationSettings compilationSettings); // 0x00000001819DF690-0x00000001819DF750
		internal new XmlSchema Clone(); // 0x00000001819DF540-0x00000001819DF690
		internal XmlSchema DeepClone(); // 0x00000001819DF950-0x00000001819DFDA0
		internal void SetIsCompiled(bool isCompiled); // 0x0000000180B262B0-0x0000000180B262C0
		internal override void SetUnhandledAttributes(XmlAttribute[] moreAttributes); // 0x0000000180434A10-0x0000000180434A20
		internal override void AddAnnotation(XmlSchemaAnnotation annotation); // 0x00000001819DF4D0-0x00000001819DF540
		internal void GetExternalSchemasList(IList extList, XmlSchema schema); // 0x00000001819DFDA0-0x00000001819DFF70
	}
}
