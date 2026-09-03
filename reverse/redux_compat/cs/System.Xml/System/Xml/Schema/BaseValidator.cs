/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class BaseValidator // TypeDefIndex: 7008
	{
		// Fields
		private XmlSchemaCollection schemaCollection; // 0x10
		private IValidationEventHandling eventHandling; // 0x18
		private XmlNameTable nameTable; // 0x20
		private SchemaNames schemaNames; // 0x28
		private PositionInfo positionInfo; // 0x30
		private XmlResolver xmlResolver; // 0x38
		private Uri baseUri; // 0x40
		protected SchemaInfo schemaInfo; // 0x48
		protected XmlValidatingReaderImpl reader; // 0x50
		protected XmlQualifiedName elementName; // 0x58
		protected ValidationState context; // 0x60
		protected StringBuilder textValue; // 0x68
		protected string textString; // 0x70
		protected bool hasSibling; // 0x78
		protected bool checkDatatype; // 0x79
	
		// Properties
		public XmlValidatingReaderImpl Reader { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public XmlSchemaCollection SchemaCollection { get; } // 0x0000000180377550-0x0000000180377560 
		public XmlNameTable NameTable { get; } // 0x00000001802F8630-0x00000001802F8640 
		public SchemaNames SchemaNames { get; } // 0x0000000181AC7840-0x0000000181AC78F0 
		public PositionInfo PositionInfo { get; } // 0x000000018031E110-0x000000018031E120 
		public XmlResolver XmlResolver { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public Uri BaseUri { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public ValidationEventHandler EventHandler { get; } // 0x0000000181AC77C0-0x0000000181AC7840 
		public SchemaInfo SchemaInfo { get; } // 0x00000001803272B0-0x00000001803272C0 
		public IDtdInfo DtdInfo { set; } // 0x0000000181AC78F0-0x0000000181AC79D0
		public virtual bool PreserveWhitespace { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		public BaseValidator(BaseValidator other); // 0x0000000181AC76F0-0x0000000181AC77C0
		public BaseValidator(XmlValidatingReaderImpl reader, XmlSchemaCollection schemaCollection, IValidationEventHandling eventHandling); // 0x0000000181AC75F0-0x0000000181AC76F0
	
		// Methods
		public virtual void Validate(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CompleteValidation(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual object FindId(string name); // 0x00000001802E7860-0x00000001802E7870
		public void ValidateText(); // 0x0000000181AC7130-0x0000000181AC74A0
		public void ValidateWhitespace(); // 0x0000000181AC74A0-0x0000000181AC75F0
		private void SaveTextValue(string value); // 0x0000000181AC6B10-0x0000000181AC6B90
		protected void SendValidationEvent(string code); // 0x0000000181AC6CB0-0x0000000181AC6CD0
		protected void SendValidationEvent(string code, string[] args); // 0x0000000181AC7020-0x0000000181AC7130
		protected void SendValidationEvent(string code, string arg); // 0x0000000181AC6E80-0x0000000181AC6F90
		protected void SendValidationEvent(XmlSchemaException e); // 0x0000000181AC6DF0-0x0000000181AC6E80
		protected void SendValidationEvent(string code, string msg, XmlSeverityType severity); // 0x0000000181AC6CD0-0x0000000181AC6DF0
		protected void SendValidationEvent(string code, string[] args, XmlSeverityType severity); // 0x0000000181AC6B90-0x0000000181AC6CB0
		protected void SendValidationEvent(XmlSchemaException e, XmlSeverityType severity); // 0x0000000181AC6F90-0x0000000181AC7020
		protected static void ProcessEntity(SchemaInfo sinfo, string name, object sender, ValidationEventHandler eventhandler, string baseUri, int lineNumber, int linePosition); // 0x0000000181AC6790-0x0000000181AC6960
		protected static void ProcessEntity(SchemaInfo sinfo, string name, IValidationEventHandling eventHandling, string baseUriStr, int lineNumber, int linePosition); // 0x0000000181AC6960-0x0000000181AC6B10
		public static BaseValidator CreateInstance(ValidationType valType, XmlValidatingReaderImpl reader, XmlSchemaCollection schemaCollection, IValidationEventHandling eventHandling, bool processIdentityConstraints); // 0x0000000181AC65B0-0x0000000181AC6790
	}
}
