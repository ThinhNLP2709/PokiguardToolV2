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
	public class XmlSchemaAnyAttribute : XmlSchemaAnnotated // TypeDefIndex: 7179
	{
		// Fields
		private string ns; // 0x50
		private XmlSchemaContentProcessing processContents; // 0x58
		private NamespaceList namespaceList; // 0x60
	
		// Properties
		[XmlAttribute("namespace")]
		public string Namespace { set; } // 0x00000001806CCE80-0x00000001806CCE90
		[DefaultValue(XmlSchemaContentProcessing.None)]
		[XmlAttribute("processContents")]
		public XmlSchemaContentProcessing ProcessContents { get; set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		[XmlIgnore]
		internal NamespaceList NamespaceList { get; } // 0x0000000180333260-0x0000000180333490 
		[XmlIgnore]
		internal XmlSchemaContentProcessing ProcessContentsCorrect { get; } // 0x00000001819D7AE0-0x00000001819D7AF0 
	
		// Constructors
		public XmlSchemaAnyAttribute(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void BuildNamespaceList(string targetNamespace); // 0x00000001819D7850-0x00000001819D78F0
		internal void BuildNamespaceListV1Compat(string targetNamespace); // 0x00000001819D77A0-0x00000001819D7850
		internal bool Allows(XmlQualifiedName qname); // 0x00000001819D7760-0x00000001819D77A0
		internal static bool IsSubset(XmlSchemaAnyAttribute sub, XmlSchemaAnyAttribute super); // 0x00000001819D79D0-0x00000001819D7A00
		internal static XmlSchemaAnyAttribute Intersection(XmlSchemaAnyAttribute o1, XmlSchemaAnyAttribute o2, bool v1Compat); // 0x00000001819D78F0-0x00000001819D79D0
		internal static XmlSchemaAnyAttribute Union(XmlSchemaAnyAttribute o1, XmlSchemaAnyAttribute o2, bool v1Compat); // 0x00000001819D7A00-0x00000001819D7AE0
	}
}
