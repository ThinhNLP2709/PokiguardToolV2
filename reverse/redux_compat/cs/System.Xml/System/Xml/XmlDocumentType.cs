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
	public class XmlDocumentType : XmlLinkedNode // TypeDefIndex: 6822
	{
		// Fields
		private string name; // 0x20
		private string publicId; // 0x28
		private string systemId; // 0x30
		private string internalSubset; // 0x38
		private bool namespaces; // 0x40
		private XmlNamedNodeMap entities; // 0x48
		private XmlNamedNodeMap notations; // 0x50
		private SchemaInfo schemaInfo; // 0x58
	
		// Properties
		public override string Name { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override string LocalName { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override XmlNodeType NodeType { get; } // 0x0000000181626E00-0x0000000181626E10 
		public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public XmlNamedNodeMap Entities { get; } // 0x0000000181A5EB00-0x0000000181A5EB70 
		public XmlNamedNodeMap Notations { get; } // 0x0000000181A5EB70-0x0000000181A5EBE0 
		public string PublicId { get; } // 0x000000018033D240-0x000000018033D250 
		public string SystemId { get; } // 0x000000018031E110-0x000000018031E120 
		public string InternalSubset { get; } // 0x00000001803272A0-0x00000001803272B0 
		internal bool ParseWithNamespaces { get; } // 0x00000001803B1170-0x00000001803B1180 
		internal SchemaInfo DtdSchemaInfo { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
	
		// Constructors
		protected internal XmlDocumentType(string name, string publicId, string systemId, string internalSubset, XmlDocument doc); // 0x0000000181A5E9A0-0x0000000181A5EB00
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A5E8F0-0x0000000181A5E950
		public override void WriteTo(XmlWriter w); // 0x0000000181A5E950-0x0000000181A5E9A0
		public override void WriteContentTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
