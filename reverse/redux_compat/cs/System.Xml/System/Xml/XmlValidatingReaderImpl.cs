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
	internal sealed class XmlValidatingReaderImpl : XmlReader, IXmlLineInfo, IXmlNamespaceResolver // TypeDefIndex: 6783
	{
		// Fields
		private XmlReader coreReader; // 0x10
		private XmlTextReaderImpl coreReaderImpl; // 0x18
		private IXmlNamespaceResolver coreReaderNSResolver; // 0x20
		private ValidationType validationType; // 0x28
		private BaseValidator validator; // 0x30
		private XmlSchemaCollection schemaCollection; // 0x38
		private bool processIdentityConstraints; // 0x40
		private ParsingFunction parsingFunction; // 0x44
		private ValidationEventHandling eventHandling; // 0x48
		private XmlParserContext parserContext; // 0x50
		private ReadContentAsBinaryHelper readBinaryHelper; // 0x58
		private XmlReader outerReader; // 0x60
		private static XmlResolver s_tempResolver; // 0x00
	
		// Properties
		public override XmlReaderSettings Settings { get; } // 0x0000000181A524D0-0x0000000181A525A0 
		public override XmlNodeType NodeType { get; } // 0x00000001818C1870-0x00000001818C18A0 
		public override string Name { get; } // 0x0000000181770170-0x00000001817701A0 
		public override string LocalName { get; } // 0x00000001818C1840-0x00000001818C1870 
		public override string NamespaceURI { get; } // 0x00000001815019E0-0x0000000181501A10 
		public override string Prefix { get; } // 0x0000000181501AD0-0x0000000181501B00 
		public override string Value { get; } // 0x0000000181501AA0-0x0000000181501AD0 
		public override int Depth { get; } // 0x00000001818C1780-0x00000001818C17B0 
		public override string BaseURI { get; } // 0x00000001818C1720-0x00000001818C1750 
		public override bool IsEmptyElement { get; } // 0x00000001818C1810-0x00000001818C1840 
		public override bool IsDefault { get; } // 0x00000001818C17E0-0x00000001818C1810 
		public override char QuoteChar { get; } // 0x0000000181501A70-0x0000000181501AA0 
		public override XmlSpace XmlSpace { get; } // 0x00000001815019B0-0x00000001815019E0 
		public override string XmlLang { get; } // 0x0000000181501A40-0x0000000181501A70 
		public override ReadState ReadState { get; } // 0x0000000181A52490-0x0000000181A524D0 
		public override bool EOF { get; } // 0x00000001818C17B0-0x00000001818C17E0 
		public override XmlNameTable NameTable { get; } // 0x0000000181781A40-0x0000000181781A70 
		public override int AttributeCount { get; } // 0x00000001818C16F0-0x00000001818C1720 
		public override bool CanResolveEntity { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public int LineNumber { get; } // 0x0000000181A52300-0x0000000181A523A0 
		public int LinePosition { get; } // 0x0000000181A523A0-0x0000000181A52440 
		internal ValidationType ValidationType { get; } // 0x0000000180377930-0x0000000180377940 
		internal XmlSchemaCollection Schemas { get; } // 0x00000001803272A0-0x00000001803272B0 
		internal bool Namespaces { get; } // 0x0000000181A52470-0x0000000181A52490 
		internal BaseValidator Validator { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		internal override XmlNamespaceManager NamespaceManager { get; } // 0x0000000181A52440-0x0000000181A52470 
		internal bool StandAlone { get; } // 0x0000000181A525A0-0x0000000181A525C0 
		internal object SchemaTypeObject { set; } // 0x0000000181A525E0-0x0000000181A52600
		internal object TypedValueObject { get; set; } // 0x0000000181A525C0-0x0000000181A525E0 0x0000000181A52600-0x0000000181A52620
		internal override IDtdInfo DtdInfo { get; } // 0x0000000181A522D0-0x0000000181A52300 
	
		// Nested types
		private enum ParsingFunction // TypeDefIndex: 6784
		{
			Read = 0,
			Init = 1,
			ParseDtdFromContext = 2,
			ResolveEntityInternally = 3,
			InReadBinaryContent = 4,
			ReaderClosed = 5,
			Error = 6,
			None = 7
		}
	
		internal class ValidationEventHandling : IValidationEventHandling // TypeDefIndex: 6785
		{
			// Fields
			private XmlValidatingReaderImpl reader; // 0x10
			private ValidationEventHandler eventHandler; // 0x18
	
			// Properties
			object IValidationEventHandling.EventHandler { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			internal ValidationEventHandling(XmlValidatingReaderImpl reader); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			void IValidationEventHandling.SendEvent(Exception exception, XmlSeverityType severity); // 0x0000000181A475A0-0x0000000181A476C0
			internal void AddHandler(ValidationEventHandler handler); // 0x0000000181A47500-0x0000000181A475A0
		}
	
		// Constructors
		internal XmlValidatingReaderImpl(XmlReader reader, ValidationEventHandler settingsEventHandler, bool processIdentityConstraints); // 0x0000000181A51D60-0x0000000181A522D0
	
		// Methods
		public override string GetAttribute(string name); // 0x00000001818C1530-0x00000001818C1560
		public override string GetAttribute(string localName, string namespaceURI); // 0x00000001818C1500-0x00000001818C1530
		public override string GetAttribute(int i); // 0x00000001818C1560-0x00000001818C1590
		public override bool MoveToAttribute(string name); // 0x0000000181A511D0-0x0000000181A51220
		public override void MoveToAttribute(int i); // 0x0000000181A51190-0x0000000181A511D0
		public override bool MoveToFirstAttribute(); // 0x0000000181A51270-0x0000000181A512C0
		public override bool MoveToNextAttribute(); // 0x0000000181A512C0-0x0000000181A51310
		public override bool MoveToElement(); // 0x0000000181A51220-0x0000000181A51270
		public override bool Read(); // 0x0000000181A51740-0x0000000181A518F0
		public override void Close(); // 0x0000000181A50E50-0x0000000181A50E90
		public override string LookupNamespace(string prefix); // 0x0000000181A51040-0x0000000181A51070
		public override bool ReadAttributeValue(); // 0x0000000181A51600-0x0000000181A51670
		public override void ResolveEntity(); // 0x0000000181A519A0-0x0000000181A519E0
		internal void MoveOffEntityReference(); // 0x0000000181A510D0-0x0000000181A51190
		public override string ReadString(); // 0x0000000181A51670-0x0000000181A51740
		public bool HasLineInfo(); // 0x00000001802E7990-0x00000001802E79A0
		IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A50E90-0x0000000181A50F40
		string IXmlNamespaceResolver.LookupNamespace(string prefix); // 0x0000000181972160-0x0000000181972180
		string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x0000000181A51070-0x0000000181A510D0
		internal IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A50E90-0x0000000181A50F40
		internal string LookupPrefix(string namespaceName); // 0x0000000181A51070-0x0000000181A510D0
		private void ParseDtdFromParserContext(); // 0x0000000181A51310-0x0000000181A514E0
		private void ValidateDtd(); // 0x0000000181A51CD0-0x0000000181A51D60
		private void ResolveEntityInternally(); // 0x0000000181A518F0-0x0000000181A519A0
		private void SetupValidation(ValidationType valType); // 0x0000000181A519E0-0x0000000181A51B90
		private XmlResolver GetResolver(); // 0x0000000181A50F40-0x0000000181A51040
		private void ProcessCoreReaderEvent(); // 0x0000000181A514E0-0x0000000181A51600
		internal bool AddDefaultAttribute(SchemaAttDef attdef); // 0x0000000181A50E30-0x0000000181A50E50
		internal void ValidateDefaultAttributeOnUse(IDtdDefaultAttributeInfo defaultAttribute, XmlTextReaderImpl coreReader); // 0x0000000181A51B90-0x0000000181A51CD0
	}
}
