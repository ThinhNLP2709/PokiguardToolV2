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
	internal sealed class DtdValidator : BaseValidator // TypeDefIndex: 7111
	{
		// Fields
		private static NamespaceManager namespaceManager; // 0x00
		private HWStack validationStack; // 0x80
		private Hashtable attPresence; // 0x88
		private XmlQualifiedName name; // 0x90
		private Hashtable IDs; // 0x98
		private IdRefNode idRefListHead; // 0xA0
		private bool processIdentityConstraints; // 0xA8
	
		// Properties
		public override bool PreserveWhitespace { get; } // 0x00000001819D60C0-0x00000001819D6100 
	
		// Nested types
		private class NamespaceManager : XmlNamespaceManager // TypeDefIndex: 7112
		{
			// Constructors
			public NamespaceManager(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override string LookupNamespace(string prefix); // 0x0000000180A68C50-0x0000000180A68C60
		}
	
		// Constructors
		internal DtdValidator(XmlValidatingReaderImpl reader, IValidationEventHandling eventHandling, bool processIdentityConstraints); // 0x0000000181AF4630-0x0000000181AF4830
		static DtdValidator(); // 0x0000000181AF45B0-0x0000000181AF4630
	
		// Methods
		private void Init(); // 0x0000000181AF28A0-0x0000000181AF2A00
		public override void Validate(); // 0x0000000181AF4230-0x0000000181AF45B0
		private bool MeetsStandAloneConstraint(); // 0x0000000181AF2A00-0x0000000181AF2A90
		private void ValidatePIComment(); // 0x0000000181AF3D20-0x0000000181AF3DD0
		private void ValidateElement(); // 0x0000000181AF3580-0x0000000181AF3980
		private void ValidateChildElement(); // 0x0000000181AF33C0-0x0000000181AF3580
		private void ValidateStartElement(); // 0x0000000181AF3DD0-0x0000000181AF4230
		private void ValidateEndStartElement(); // 0x0000000181AF3B80-0x0000000181AF3D20
		private void ProcessElement(); // 0x0000000181AF2B70-0x0000000181AF2CD0
		public override void CompleteValidation(); // 0x0000000181AF2450-0x0000000181AF25D0
		private void ValidateEndElement(); // 0x0000000181AF3980-0x0000000181AF3B80
		private void ProcessTokenizedType(XmlTokenizedType ttype, string name); // 0x0000000181AF2CD0-0x0000000181AF2FA0
		private void CheckValue(string value, SchemaAttDef attdef); // 0x0000000181AF1F60-0x0000000181AF2450
		internal void AddID(string name, object node); // 0x0000000181AF1A20-0x0000000181AF1AE0
		public override object FindId(string name); // 0x0000000181AF25D0-0x0000000181AF2600
		private bool GenEntity(XmlQualifiedName qname); // 0x0000000181AF2600-0x0000000181AF27F0
		private SchemaEntity GetEntity(XmlQualifiedName qname, bool fParameterEntity); // 0x0000000181AF27F0-0x0000000181AF28A0
		private void CheckForwardRefs(); // 0x0000000181AF1E10-0x0000000181AF1F60
		private void Push(XmlQualifiedName elementName); // 0x0000000181AF2FA0-0x0000000181AF3110
		private bool Pop(); // 0x0000000181AF2A90-0x0000000181AF2B70
		public static void SetDefaultTypedValue(SchemaAttDef attdef, IDtdParserAdapter readerAdapter); // 0x0000000181AF3110-0x0000000181AF33C0
		public static void CheckDefaultValue(SchemaAttDef attdef, SchemaInfo sinfo, IValidationEventHandling eventHandling, string baseUriStr); // 0x0000000181AF1AE0-0x0000000181AF1E10
	}
}
