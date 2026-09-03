/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
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
	internal sealed class SchemaElementDecl : SchemaDeclBase, IDtdAttributeListInfo // TypeDefIndex: 7145
	{
		// Fields
		private Dictionary<XmlQualifiedName, SchemaAttDef> attdefs; // 0x60
		private List<IDtdDefaultAttributeInfo> defaultAttdefs; // 0x68
		private bool isIdDeclared; // 0x70
		private bool hasNonCDataAttribute; // 0x71
		private bool isAbstract; // 0x72
		private bool isNillable; // 0x73
		private bool hasRequiredAttribute; // 0x74
		private bool isNotationDeclared; // 0x75
		private Dictionary<XmlQualifiedName, XmlQualifiedName> prohibitedAttributes; // 0x78
		private ContentValidator contentValidator; // 0x80
		private XmlSchemaAnyAttribute anyAttribute; // 0x88
		private XmlSchemaDerivationMethod block; // 0x90
		private CompiledIdentityConstraint[] constraints; // 0x98
		private XmlSchemaElement schemaElement; // 0xA0
		internal static readonly SchemaElementDecl Empty; // 0x00
	
		// Properties
		bool IDtdAttributeListInfo.HasNonCDataAttributes { get; } // 0x000000018030D9D0-0x000000018030D9E0 
		internal bool IsIdDeclared { get; set; } // 0x0000000180643BD0-0x0000000180643BE0 0x0000000180C4A240-0x0000000180C4A250
		internal bool HasNonCDataAttribute { get; set; } // 0x000000018030D9D0-0x000000018030D9E0 0x00000001803CB1F0-0x00000001803CB200
		internal bool IsAbstract { get; set; } // 0x00000001819C01B0-0x00000001819C01C0 0x00000001819C01E0-0x00000001819C01F0
		internal bool IsNillable { get; set; } // 0x00000001819C01C0-0x00000001819C01D0 0x00000001819C01F0-0x00000001819C0200
		internal XmlSchemaDerivationMethod Block { get; set; } // 0x000000018169CBC0-0x000000018169CBD0 0x000000018170C9F0-0x000000018170CA00
		internal bool IsNotationDeclared { get; set; } // 0x00000001819C01D0-0x00000001819C01E0 0x00000001819C0200-0x00000001819C0210
		internal bool HasDefaultAttribute { get; } // 0x00000001819C0190-0x00000001819C01A0 
		internal bool HasRequiredAttribute { get; } // 0x00000001819C01A0-0x00000001819C01B0 
		internal ContentValidator ContentValidator { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		internal XmlSchemaAnyAttribute AnyAttribute { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
		internal CompiledIdentityConstraint[] Constraints { get; set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		internal XmlSchemaElement SchemaElement { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		internal IList<IDtdDefaultAttributeInfo> DefaultAttDefs { get; } // 0x0000000180316960-0x0000000180316970 
		internal Dictionary<XmlQualifiedName, SchemaAttDef> AttDefs { get; } // 0x0000000180333260-0x0000000180333490 
		internal Dictionary<XmlQualifiedName, XmlQualifiedName> ProhibitedAttributes { get; } // 0x000000018033D4E0-0x000000018033D4F0 
	
		// Constructors
		internal SchemaElementDecl(); // 0x00000001819C0080-0x00000001819C0190
		internal SchemaElementDecl(XmlSchemaDatatype dtype); // 0x00000001819BFDA0-0x00000001819BFF20
		internal SchemaElementDecl(XmlQualifiedName name, string prefix); // 0x00000001819BFF20-0x00000001819C0080
		static SchemaElementDecl(); // 0x00000001819BFD30-0x00000001819BFDA0
	
		// Methods
		internal static SchemaElementDecl CreateAnyTypeElementDecl(); // 0x00000001819BFB20-0x00000001819BFC00
		IDtdAttributeInfo IDtdAttributeListInfo.LookupAttribute(string prefix, string localName); // 0x00000001819BFC80-0x00000001819BFD30
		IEnumerable<IDtdDefaultAttributeInfo> IDtdAttributeListInfo.LookupDefaultAttributes(); // 0x0000000180316960-0x0000000180316970
		internal SchemaElementDecl Clone(); // 0x00000001819BFAC0-0x00000001819BFB20
		internal void AddAttDef(SchemaAttDef attdef); // 0x00000001819BF720-0x00000001819BF870
		internal SchemaAttDef GetAttDef(XmlQualifiedName qname); // 0x00000001819BFC00-0x00000001819BFC80
		internal void CheckAttributes(Hashtable presence, bool standalone); // 0x00000001819BF870-0x00000001819BFAC0
	}
}
