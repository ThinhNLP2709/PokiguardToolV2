/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public sealed class XmlWriterSettings // TypeDefIndex: 6804
	{
		// Fields
		private bool useAsync; // 0x10
		private Encoding encoding; // 0x18
		private bool omitXmlDecl; // 0x20
		private NewLineHandling newLineHandling; // 0x24
		private string newLineChars; // 0x28
		private TriState indent; // 0x30
		private string indentChars; // 0x38
		private bool newLineOnAttributes; // 0x40
		private bool closeOutput; // 0x41
		private NamespaceHandling namespaceHandling; // 0x44
		private ConformanceLevel conformanceLevel; // 0x48
		private bool checkCharacters; // 0x4C
		private bool writeEndDocumentOnClose; // 0x4D
		private XmlOutputMethod outputMethod; // 0x50
		private List<XmlQualifiedName> cdataSections; // 0x58
		private bool doNotEscapeUriAttributes; // 0x60
		private bool mergeCDataSections; // 0x61
		private string mediaType; // 0x68
		private string docTypeSystem; // 0x70
		private string docTypePublic; // 0x78
		private XmlStandalone standalone; // 0x80
		private bool autoXmlDecl; // 0x84
		private bool isReadOnly; // 0x85
	
		// Properties
		public bool Async { get; } // 0x00000001805625D0-0x00000001805625E0 
		public Encoding Encoding { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public bool OmitXmlDeclaration { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x0000000181A6C4C0-0x0000000181A6C510
		public NewLineHandling NewLineHandling { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public string NewLineChars { get; } // 0x000000018033D240-0x000000018033D250 
		public bool Indent { get; set; } // 0x0000000181A6C2D0-0x0000000181A6C2E0 0x0000000181A6C3C0-0x0000000181A6C420
		public string IndentChars { get; } // 0x00000001803272A0-0x00000001803272B0 
		public bool NewLineOnAttributes { get; } // 0x00000001803B1170-0x00000001803B1180 
		public bool CloseOutput { get; } // 0x00000001815B1190-0x00000001815B11A0 
		public ConformanceLevel ConformanceLevel { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x0000000181A6C320-0x0000000181A6C3C0
		public bool CheckCharacters { get; } // 0x00000001803B6550-0x00000001803B6560 
		public NamespaceHandling NamespaceHandling { get; set; } // 0x000000018033D780-0x000000018033D790 0x0000000181A6C420-0x0000000181A6C4C0
		public bool WriteEndDocumentOnClose { get; } // 0x000000018169C650-0x000000018169C660 
		public XmlOutputMethod OutputMethod { get; internal set; } // 0x000000018033D660-0x000000018033D670 0x000000018033EC40-0x000000018033EC50
		internal List<XmlQualifiedName> CDataSectionElements { get; } // 0x00000001802F4000-0x00000001802F4010 
		public bool DoNotEscapeUriAttributes { get; } // 0x000000018033D4F0-0x000000018033D500 
		internal bool MergeCDataSections { get; } // 0x00000001804EFDB0-0x00000001804EFDC0 
		internal string MediaType { get; } // 0x0000000180316960-0x0000000180316970 
		internal string DocTypeSystem { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		internal string DocTypePublic { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		internal XmlStandalone Standalone { get; } // 0x0000000180CC3A10-0x0000000180CC3A20 
		internal bool AutoXmlDeclaration { get; } // 0x0000000181A6C2C0-0x0000000181A6C2D0 
		internal TriState IndentInternal { get; } // 0x000000018033D100-0x000000018033D110 
		internal bool IsQuerySpecific { get; } // 0x0000000181A6C2E0-0x0000000181A6C320 
		internal bool ReadOnly { set; } // 0x0000000181A6C510-0x0000000181A6C520
	
		// Constructors
		public XmlWriterSettings(); // 0x0000000181A6C140-0x0000000181A6C2C0
	
		// Methods
		public XmlWriterSettings Clone(); // 0x0000000181A6B7E0-0x0000000181A6B8D0
		internal XmlWriter CreateWriter(Stream output); // 0x0000000181A6B8D0-0x0000000181A6BD30
		internal XmlWriter CreateWriter(TextWriter output); // 0x0000000181A6BD30-0x0000000181A6C020
		private void CheckReadOnly(string propertyName); // 0x0000000181A6B730-0x0000000181A6B7E0
		private void Initialize(); // 0x0000000181A6C020-0x0000000181A6C140
	}
}
