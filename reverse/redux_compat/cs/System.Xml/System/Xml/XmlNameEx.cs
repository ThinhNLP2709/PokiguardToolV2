/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal sealed class XmlNameEx : XmlName // TypeDefIndex: 6831
	{
		// Fields
		private byte flags; // 0x48
		private XmlSchemaSimpleType memberType; // 0x50
		private XmlSchemaType schemaType; // 0x58
		private object decl; // 0x60
	
		// Properties
		public override XmlSchemaValidity Validity { get; } // 0x0000000181A80FD0-0x0000000181A81000 
		public override bool IsDefault { get; } // 0x0000000181A80EB0-0x0000000181A80EC0 
		public override bool IsNil { get; } // 0x0000000181A80EC0-0x0000000181A80ED0 
		public override XmlSchemaSimpleType MemberType { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public override XmlSchemaType SchemaType { get; } // 0x00000001802F4000-0x00000001802F4010 
		public override XmlSchemaElement SchemaElement { get; } // 0x0000000181A80F50-0x0000000181A80FD0 
		public override XmlSchemaAttribute SchemaAttribute { get; } // 0x0000000181A80ED0-0x0000000181A80F50 
	
		// Constructors
		internal XmlNameEx(string prefix, string localName, string ns, int hashCode, XmlDocument ownerDoc, XmlName next, IXmlSchemaInfo schemaInfo); // 0x0000000181A80D00-0x0000000181A80EB0
	
		// Methods
		public void SetValidity(XmlSchemaValidity value); // 0x0000000181A80CF0-0x0000000181A80D00
		public void SetIsDefault(bool value); // 0x0000000181A80C90-0x0000000181A80CC0
		public void SetIsNil(bool value); // 0x0000000181A80CC0-0x0000000181A80CF0
		public override bool Equals(IXmlSchemaInfo schemaInfo); // 0x0000000181A80AB0-0x0000000181A80C90
	}
}
