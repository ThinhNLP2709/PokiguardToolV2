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
	public class XmlSchemaAny : XmlSchemaParticle // TypeDefIndex: 7178
	{
		// Fields
		private string ns; // 0x78
		private XmlSchemaContentProcessing processContents; // 0x80
		private NamespaceList namespaceList; // 0x88
	
		// Properties
		[XmlAttribute("namespace")]
		public string Namespace { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
		[DefaultValue(XmlSchemaContentProcessing.None)]
		[XmlAttribute("processContents")]
		public XmlSchemaContentProcessing ProcessContents { set; } // 0x0000000180CC3E80-0x0000000180CC3E90
		[XmlIgnore]
		internal NamespaceList NamespaceList { get; } // 0x000000018038B8A0-0x000000018038B8B0 
		[XmlIgnore]
		internal string ResolvedNamespace { get; } // 0x00000001819D8120-0x00000001819D8170 
		[XmlIgnore]
		internal XmlSchemaContentProcessing ProcessContentsCorrect { get; } // 0x00000001819D8100-0x00000001819D8120 
		internal override string NameString { get; } // 0x00000001819D7CF0-0x00000001819D8100 
	
		// Constructors
		public XmlSchemaAny(); // 0x00000001819D7CA0-0x00000001819D7CF0
	
		// Methods
		internal void BuildNamespaceList(string targetNamespace); // 0x00000001819D7BF0-0x00000001819D7CA0
		internal void BuildNamespaceListV1Compat(string targetNamespace); // 0x00000001819D7B30-0x00000001819D7BF0
		internal bool Allows(XmlQualifiedName qname); // 0x00000001819D7AF0-0x00000001819D7B30
	}
}
