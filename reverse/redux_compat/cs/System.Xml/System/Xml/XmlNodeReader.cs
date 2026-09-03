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
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public class XmlNodeReader : XmlReader, IXmlNamespaceResolver // TypeDefIndex: 6841
	{
		// Fields
		private XmlNodeReaderNavigator readerNav; // 0x10
		private XmlNodeType nodeType; // 0x18
		private int curDepth; // 0x1C
		private ReadState readState; // 0x20
		private bool fEOF; // 0x24
		private bool bResolveEntity; // 0x25
		private bool bStartFromDocument; // 0x26
		private bool bInReadBinary; // 0x27
		private ReadContentAsBinaryHelper readBinaryHelper; // 0x28
	
		// Properties
		public override XmlNodeType NodeType { get; } // 0x0000000181A87610-0x0000000181A87620 
		public override string Name { get; } // 0x0000000181A87580-0x0000000181A875C0 
		public override string LocalName { get; } // 0x0000000181A87460-0x0000000181A87560 
		public override string NamespaceURI { get; } // 0x0000000181A875C0-0x0000000181A87610 
		public override string Prefix { get; } // 0x0000000181A87620-0x0000000181A87670 
		public override string Value { get; } // 0x0000000181A876C0-0x0000000181A87700 
		public override int Depth { get; } // 0x0000000180B232F0-0x0000000180B23300 
		public override string BaseURI { get; } // 0x0000000181A872D0-0x0000000181A87310 
		public override bool CanResolveEntity { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool IsEmptyElement { get; } // 0x0000000181A87430-0x0000000181A87460 
		public override bool IsDefault { get; } // 0x0000000181A87350-0x0000000181A87430 
		public override XmlSpace XmlSpace { get; } // 0x0000000181A87750-0x0000000181A877A0 
		public override string XmlLang { get; } // 0x0000000181A87700-0x0000000181A87750 
		public override IXmlSchemaInfo SchemaInfo { get; } // 0x0000000181A87670-0x0000000181A876C0 
		public override int AttributeCount { get; } // 0x0000000181A87290-0x0000000181A872D0 
		public override bool EOF { get; } // 0x0000000181A87340-0x0000000181A87350 
		public override ReadState ReadState { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public override bool HasAttributes { get; } // 0x0000000181A44AE0-0x0000000181A44B10 
		public override XmlNameTable NameTable { get; } // 0x0000000181A87560-0x0000000181A87580 
		internal override IDtdInfo DtdInfo { get; } // 0x0000000181A87310-0x0000000181A87340 
	
		// Constructors
		public XmlNodeReader(XmlNode node); // 0x0000000181A87190-0x0000000181A87290
	
		// Methods
		internal bool IsInReadingStates(); // 0x0000000181A85EA0-0x0000000181A85EB0
		public override string GetAttribute(string name); // 0x0000000181A85E20-0x0000000181A85E50
		public override string GetAttribute(string name, string namespaceURI); // 0x0000000181A85E50-0x0000000181A85EA0
		public override string GetAttribute(int attributeIndex); // 0x0000000181A85DA0-0x0000000181A85E20
		public override bool MoveToAttribute(string name); // 0x0000000181A860B0-0x0000000181A861C0
		public override void MoveToAttribute(int attributeIndex); // 0x0000000181A85EF0-0x0000000181A860B0
		public override bool MoveToFirstAttribute(); // 0x0000000181A86370-0x0000000181A86490
		public override bool MoveToNextAttribute(); // 0x0000000181A86490-0x0000000181A865E0
		public override bool MoveToElement(); // 0x0000000181A861C0-0x0000000181A86370
		public override bool Read(); // 0x0000000181A86CC0-0x0000000181A86CD0
		private bool Read(bool fSkipChildren); // 0x0000000181A86CD0-0x0000000181A86EA0
		private bool ReadNextNode(bool fSkipChildren); // 0x0000000181A86920-0x0000000181A86C10
		private void SetEndOfFile(); // 0x0000000181A86F30-0x0000000181A86F50
		private bool ReadAtZeroLevel(bool fSkipChildren); // 0x0000000181A86610-0x0000000181A866B0
		private bool ReadForward(bool fSkipChildren); // 0x0000000181A86700-0x0000000181A86920
		private void ReSetReadingMarks(); // 0x0000000181A865E0-0x0000000181A86610
		public override void Close(); // 0x0000000181A85D60-0x0000000181A85D70
		public override void Skip(); // 0x0000000181A86F50-0x0000000181A86F60
		public override string ReadString(); // 0x0000000181A86C10-0x0000000181A86CC0
		public override string LookupNamespace(string prefix); // 0x0000000181A85EB0-0x0000000181A85EF0
		public override void ResolveEntity(); // 0x0000000181A86EA0-0x0000000181A86F30
		public override bool ReadAttributeValue(); // 0x0000000181A866B0-0x0000000181A86700
		private void FinishReadBinary(); // 0x0000000181A85D70-0x0000000181A85DA0
		IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A86F60-0x0000000181A86F80
		string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x0000000181A87170-0x0000000181A87190
		string IXmlNamespaceResolver.LookupNamespace(string prefix); // 0x0000000181A86F80-0x0000000181A87170
	}
}
