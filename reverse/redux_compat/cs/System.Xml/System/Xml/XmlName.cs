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
	internal class XmlName : IXmlSchemaInfo // TypeDefIndex: 6830
	{
		// Fields
		private string prefix; // 0x10
		private string localName; // 0x18
		private string ns; // 0x20
		private string name; // 0x28
		private int hashCode; // 0x30
		internal XmlDocument ownerDoc; // 0x38
		internal XmlName next; // 0x40
	
		// Properties
		public string LocalName { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string NamespaceURI { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string Prefix { get; } // 0x0000000180377550-0x0000000180377560 
		public int HashCode { get; } // 0x000000018033D100-0x000000018033D110 
		public XmlDocument OwnerDocument { get; } // 0x00000001803272A0-0x00000001803272B0 
		public string Name { get; } // 0x0000000181A81230-0x0000000181A813F0 
		public virtual XmlSchemaValidity Validity { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual bool IsDefault { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsNil { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual XmlSchemaSimpleType MemberType { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual XmlSchemaType SchemaType { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual XmlSchemaElement SchemaElement { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual XmlSchemaAttribute SchemaAttribute { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		internal XmlName(string prefix, string localName, string ns, int hashCode, XmlDocument ownerDoc, XmlName next); // 0x0000000181A81180-0x0000000181A81230
	
		// Methods
		public static XmlName Create(string prefix, string localName, string ns, int hashCode, XmlDocument ownerDoc, XmlName next, IXmlSchemaInfo schemaInfo); // 0x0000000181A81000-0x0000000181A81110
		public virtual bool Equals(IXmlSchemaInfo schemaInfo); // 0x000000018054DF70-0x000000018054DF80
		public static int GetHashCode(string name); // 0x0000000181A81110-0x0000000181A81180
	}
}
