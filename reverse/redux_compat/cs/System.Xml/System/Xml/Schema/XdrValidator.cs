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
	internal sealed class XdrValidator : BaseValidator // TypeDefIndex: 7170
	{
		// Fields
		private HWStack validationStack; // 0x80
		private Hashtable attPresence; // 0x88
		private XmlQualifiedName name; // 0x90
		private XmlNamespaceManager nsManager; // 0x98
		private bool isProcessContents; // 0xA0
		private Hashtable IDs; // 0xA8
		private IdRefNode idRefListHead; // 0xB0
		private Parser inlineSchemaParser; // 0xB8
	
		// Properties
		private bool IsInlineSchemaStarted { get; } // 0x0000000180D90590-0x0000000180D905A0 
		private bool HasSchema { get; } // 0x00000001819D60A0-0x00000001819D60C0 
		public override bool PreserveWhitespace { get; } // 0x00000001819D60C0-0x00000001819D6100 
	
		// Constructors
		internal XdrValidator(BaseValidator validator); // 0x00000001819D6010-0x00000001819D60A0
		internal XdrValidator(XmlValidatingReaderImpl reader, XmlSchemaCollection schemaCollection, IValidationEventHandling eventHandling); // 0x00000001819D5F50-0x00000001819D6010
	
		// Methods
		private void Init(); // 0x00000001819D3640-0x00000001819D3850
		public override void Validate(); // 0x00000001819D5E70-0x00000001819D5F50
		private void ValidateElement(); // 0x00000001819D4F90-0x00000001819D53C0
		private void ValidateChildElement(); // 0x00000001819D4DD0-0x00000001819D4F90
		private void ProcessInlineSchema(); // 0x00000001819D42B0-0x00000001819D44C0
		private void ProcessElement(); // 0x00000001819D41C0-0x00000001819D42B0
		private void ValidateEndElement(); // 0x00000001819D53C0-0x00000001819D56A0
		private SchemaElementDecl ThoroughGetElementDecl(); // 0x00000001819D49C0-0x00000001819D4DD0
		private void ValidateStartElement(); // 0x00000001819D59E0-0x00000001819D5E70
		private void ValidateEndStartElement(); // 0x00000001819D56A0-0x00000001819D59E0
		private void LoadSchemaFromLocation(string uri); // 0x00000001819D3850-0x00000001819D3ED0
		private void LoadSchema(string uri); // 0x00000001819D3ED0-0x00000001819D40F0
		private void ProcessTokenizedType(XmlTokenizedType ttype, string name); // 0x00000001819D44C0-0x00000001819D4770
		public override void CompleteValidation(); // 0x00000001819D33A0-0x00000001819D3610
		private void CheckValue(string value, SchemaAttDef attdef); // 0x00000001819D2E50-0x00000001819D33A0
		public static void CheckDefaultValue(string value, SchemaAttDef attdef, SchemaInfo sinfo, XmlNamespaceManager nsManager, XmlNameTable NameTable, object sender, ValidationEventHandler eventhandler, string baseUri, int lineNo, int linePos); // 0x00000001819D2880-0x00000001819D2D00
		internal void AddID(string name, object node); // 0x00000001819D27C0-0x00000001819D2880
		public override object FindId(string name); // 0x00000001819D3610-0x00000001819D3640
		private void Push(XmlQualifiedName elementName); // 0x00000001819D4770-0x00000001819D4920
		private void Pop(); // 0x00000001819D40F0-0x00000001819D41C0
		private void CheckForwardRefs(); // 0x00000001819D2D00-0x00000001819D2E50
		private XmlQualifiedName QualifiedName(string name, string ns); // 0x00000001819D4920-0x00000001819D49C0
	}
}
