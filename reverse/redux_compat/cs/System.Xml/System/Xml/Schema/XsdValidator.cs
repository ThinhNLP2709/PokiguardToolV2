/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal sealed class XsdValidator : BaseValidator // TypeDefIndex: 7296
	{
		// Fields
		private int startIDConstraint; // 0x80
		private HWStack validationStack; // 0x88
		private Hashtable attPresence; // 0x90
		private XmlNamespaceManager nsManager; // 0x98
		private bool bManageNamespaces; // 0xA0
		private Hashtable IDs; // 0xA8
		private IdRefNode idRefListHead; // 0xB0
		private Parser inlineSchemaParser; // 0xB8
		private XmlSchemaContentProcessing processContents; // 0xC0
		private static readonly XmlSchemaDatatype dtCDATA; // 0x00
		private static readonly XmlSchemaDatatype dtQName; // 0x08
		private static readonly XmlSchemaDatatype dtStringArray; // 0x10
		private string NsXmlNs; // 0xC8
		private string NsXs; // 0xD0
		private string NsXsi; // 0xD8
		private string XsiType; // 0xE0
		private string XsiNil; // 0xE8
		private string XsiSchemaLocation; // 0xF0
		private string XsiNoNamespaceSchemaLocation; // 0xF8
		private string XsdSchema; // 0x100
	
		// Properties
		private bool IsInlineSchemaStarted { get; } // 0x0000000180D90590-0x0000000180D905A0 
		private bool HasSchema { get; } // 0x00000001819D60A0-0x00000001819D60C0 
		public override bool PreserveWhitespace { get; } // 0x00000001819D60C0-0x00000001819D6100 
		private bool HasIdentityConstraints { get; } // 0x0000000181A33630-0x0000000181A33A10 
	
		// Constructors
		internal XsdValidator(BaseValidator validator); // 0x0000000181A33600-0x0000000181A33630
		internal XsdValidator(XmlValidatingReaderImpl reader, XmlSchemaCollection schemaCollection, IValidationEventHandling eventHandling); // 0x0000000181A335D0-0x0000000181A33600
		static XsdValidator(); // 0x0000000181A334E0-0x0000000181A335D0
	
		// Methods
		private void Init(); // 0x0000000181A2F880-0x0000000181A2FCB0
		public override void Validate(); // 0x0000000181A33400-0x0000000181A334E0
		public override void CompleteValidation(); // 0x0000000181A2E0B0-0x0000000181A2E200
		private void ProcessInlineSchema(); // 0x0000000181A30CB0-0x0000000181A30F10
		private void ValidateElement(); // 0x0000000181A322B0-0x0000000181A32490
		private object ValidateChildElement(); // 0x0000000181A32040-0x0000000181A322B0
		private void ProcessElement(object particle); // 0x0000000181A30520-0x0000000181A30CB0
		private void ProcessXsiAttributes(out XmlQualifiedName xsiType, out string xsiNil); // 0x0000000181A311C0-0x0000000181A31A00
		private void ValidateEndElement(); // 0x0000000181A32490-0x0000000181A327E0
		private SchemaElementDecl FastGetElementDecl(object particle); // 0x0000000181A2F7A0-0x0000000181A2F880
		private SchemaElementDecl ThoroughGetElementDecl(SchemaElementDecl elementDecl, XmlQualifiedName xsiType, string xsiNil); // 0x0000000181A31BA0-0x0000000181A31FD0
		private void ValidateStartElement(); // 0x0000000181A32CE0-0x0000000181A33400
		private void ValidateEndStartElement(); // 0x0000000181A327E0-0x0000000181A32C80
		private void LoadSchemaFromLocation(string uri, string url); // 0x0000000181A2FD00-0x0000000181A30250
		private void LoadSchema(string uri, string url); // 0x0000000181A30250-0x0000000181A30420
		private void ProcessTokenizedType(XmlTokenizedType ttype, string name); // 0x0000000181A30F10-0x0000000181A311C0
		private void CheckValue(string value, SchemaAttDef attdef); // 0x0000000181A2E200-0x0000000181A2E640
		internal void AddID(string name, object node); // 0x0000000181A2D640-0x0000000181A2D700
		public override object FindId(string name); // 0x00000001819D3610-0x00000001819D3640
		public bool IsXSDRoot(string localName, string ns); // 0x0000000181A2FCB0-0x0000000181A2FD00
		private void Push(XmlQualifiedName elementName); // 0x0000000181A31A00-0x0000000181A31BA0
		private void Pop(); // 0x0000000181A30420-0x0000000181A30520
		private void CheckForwardRefs(); // 0x0000000181A2E0B0-0x0000000181A2E200
		private void ValidateStartElementIdentityConstraints(); // 0x0000000181A32C80-0x0000000181A32CE0
		private void AddIdentityConstraints(); // 0x0000000181A2D700-0x0000000181A2DD20
		private void ElementIdentityConstraints(); // 0x0000000181A2E640-0x0000000181A2EA60
		private void AttributeIdentityConstraints(string name, string ns, object obj, string sobj, SchemaAttDef attdef); // 0x0000000181A2DD20-0x0000000181A2E0B0
		private object UnWrapUnion(object typedValue); // 0x0000000181A31FD0-0x0000000181A32040
		private void EndElementIdentityConstraints(); // 0x0000000181A2EA60-0x0000000181A2F7A0
	}
}
