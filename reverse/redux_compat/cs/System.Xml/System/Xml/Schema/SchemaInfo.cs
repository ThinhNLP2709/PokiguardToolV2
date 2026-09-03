/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class SchemaInfo : IDtdInfo // TypeDefIndex: 7148
	{
		// Fields
		private Dictionary<XmlQualifiedName, SchemaElementDecl> elementDecls; // 0x10
		private Dictionary<XmlQualifiedName, SchemaElementDecl> undeclaredElementDecls; // 0x18
		private Dictionary<XmlQualifiedName, SchemaEntity> generalEntities; // 0x20
		private Dictionary<XmlQualifiedName, SchemaEntity> parameterEntities; // 0x28
		private XmlQualifiedName docTypeName; // 0x30
		private string internalDtdSubset; // 0x38
		private bool hasNonCDataAttributes; // 0x40
		private bool hasDefaultAttributes; // 0x41
		private Dictionary<string, bool> targetNamespaces; // 0x48
		private Dictionary<XmlQualifiedName, SchemaAttDef> attributeDecls; // 0x50
		private int errorCount; // 0x58
		private SchemaType schemaType; // 0x5C
		private Dictionary<XmlQualifiedName, SchemaElementDecl> elementDeclsByType; // 0x60
		private Dictionary<string, SchemaNotation> notations; // 0x68
	
		// Properties
		public XmlQualifiedName DocTypeName { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		internal string InternalDtdSubset { set; } // 0x000000018033E850-0x000000018033E860
		internal Dictionary<XmlQualifiedName, SchemaElementDecl> ElementDecls { get; } // 0x0000000180377550-0x0000000180377560 
		internal Dictionary<XmlQualifiedName, SchemaElementDecl> UndeclaredElementDecls { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal Dictionary<XmlQualifiedName, SchemaEntity> GeneralEntities { get; } // 0x00000001819C19E0-0x00000001819C1A60 
		internal Dictionary<XmlQualifiedName, SchemaEntity> ParameterEntities { get; } // 0x00000001819C1AE0-0x00000001819C1B60 
		internal SchemaType SchemaType { get; set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
		internal Dictionary<string, bool> TargetNamespaces { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal Dictionary<XmlQualifiedName, SchemaElementDecl> ElementDeclsByType { get; } // 0x0000000180333260-0x0000000180333490 
		internal Dictionary<XmlQualifiedName, SchemaAttDef> AttributeDecls { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal Dictionary<string, SchemaNotation> Notations { get; } // 0x00000001819C1A60-0x00000001819C1AE0 
		internal int ErrorCount { get; set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		bool IDtdInfo.HasDefaultAttributes { get; } // 0x00000001815B1190-0x00000001815B11A0 
		bool IDtdInfo.HasNonCDataAttributes { get; } // 0x00000001803B1170-0x00000001803B1180 
		XmlQualifiedName IDtdInfo.Name { get; } // 0x000000018031E110-0x000000018031E120 
		string IDtdInfo.InternalDtdSubset { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		internal SchemaInfo(); // 0x00000001819C1810-0x00000001819C19E0
	
		// Methods
		internal SchemaElementDecl GetElementDecl(XmlQualifiedName qname); // 0x00000001819C1480-0x00000001819C1500
		internal SchemaElementDecl GetTypeDecl(XmlQualifiedName qname); // 0x00000001819C1590-0x00000001819C1610
		internal XmlSchemaElement GetElement(XmlQualifiedName qname); // 0x00000001819C1500-0x00000001819C1590
		internal bool HasSchema(string ns); // 0x00000001819C1610-0x00000001819C1670
		internal bool Contains(string ns); // 0x00000001819C0D30-0x00000001819C0D90
		internal SchemaAttDef GetAttributeXdr(SchemaElementDecl ed, XmlQualifiedName qname); // 0x00000001819C0EF0-0x00000001819C10B0
		internal SchemaAttDef GetAttributeXsd(SchemaElementDecl ed, XmlQualifiedName qname, XmlSchemaObject partialValidationType, out AttributeMatchState attributeMatchState); // 0x00000001819C1200-0x00000001819C1480
		internal SchemaAttDef GetAttributeXsd(SchemaElementDecl ed, XmlQualifiedName qname, ref bool skip); // 0x00000001819C10B0-0x00000001819C1200
		internal void Add(SchemaInfo sinfo, ValidationEventHandler eventhandler); // 0x00000001819C04B0-0x00000001819C0D30
		internal void Finish(); // 0x00000001819C0D90-0x00000001819C0EF0
		IDtdAttributeListInfo IDtdInfo.LookupAttributeList(string prefix, string localName); // 0x00000001819C1670-0x00000001819C1740
		IDtdEntityInfo IDtdInfo.LookupEntity(string name); // 0x00000001819C1740-0x00000001819C1810
	}
}
