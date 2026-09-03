/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaInfo : IXmlSchemaInfo // TypeDefIndex: 7229
	{
		// Fields
		private bool isDefault; // 0x10
		private bool isNil; // 0x11
		private XmlSchemaElement schemaElement; // 0x18
		private XmlSchemaAttribute schemaAttribute; // 0x20
		private XmlSchemaType schemaType; // 0x28
		private XmlSchemaSimpleType memberType; // 0x30
		private XmlSchemaValidity validity; // 0x38
		private XmlSchemaContentType contentType; // 0x3C
	
		// Properties
		public XmlSchemaValidity Validity { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		public bool IsDefault { get; set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public bool IsNil { get; set; } // 0x0000000180E38E10-0x0000000180E38E20 0x00000001815C0340-0x00000001815C0350
		public XmlSchemaSimpleType MemberType { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public XmlSchemaType SchemaType { get; set; } // 0x000000018033D240-0x000000018033D250 0x00000001819DEB20-0x00000001819DEB70
		public XmlSchemaElement SchemaElement { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001819DEAE0-0x00000001819DEB20
		public XmlSchemaAttribute SchemaAttribute { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x00000001819DEAA0-0x00000001819DEAE0
		public XmlSchemaContentType ContentType { get; } // 0x00000001804EFAC0-0x00000001804EFAD0 
		internal XmlSchemaType XmlType { get; } // 0x00000001819DEA80-0x00000001819DEAA0 
		internal bool HasDefaultValue { get; } // 0x00000001819DEA00-0x00000001819DEA40 
		internal bool IsUnionType { get; } // 0x00000001819DEA40-0x00000001819DEA80 
	
		// Constructors
		public XmlSchemaInfo(); // 0x00000001819DE990-0x00000001819DEA00
		internal XmlSchemaInfo(XmlSchemaValidity validity); // 0x00000001819DE910-0x00000001819DE990
	
		// Methods
		internal void Clear(); // 0x00000001819DE8A0-0x00000001819DE910
	}
}
