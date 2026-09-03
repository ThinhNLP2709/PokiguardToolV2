/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class BaseProcessor // TypeDefIndex: 7007
	{
		// Fields
		private XmlNameTable nameTable; // 0x10
		private SchemaNames schemaNames; // 0x18
		private ValidationEventHandler eventHandler; // 0x20
		private XmlSchemaCompilationSettings compilationSettings; // 0x28
		private int errorCount; // 0x30
		private string NsXml; // 0x38
	
		// Properties
		protected XmlNameTable NameTable { get; } // 0x0000000180377550-0x0000000180377560 
		protected SchemaNames SchemaNames { get; } // 0x0000000181AC6530-0x0000000181AC65B0 
		protected ValidationEventHandler EventHandler { get; } // 0x00000001802F8630-0x00000001802F8640 
		protected XmlSchemaCompilationSettings CompilationSettings { get; } // 0x000000018033D240-0x000000018033D250 
		protected bool HasErrors { get; } // 0x0000000181487180-0x0000000181487190 
	
		// Constructors
		public BaseProcessor(XmlNameTable nameTable, SchemaNames schemaNames, ValidationEventHandler eventHandler); // 0x0000000181AC6330-0x0000000181AC6450
		public BaseProcessor(XmlNameTable nameTable, SchemaNames schemaNames, ValidationEventHandler eventHandler, XmlSchemaCompilationSettings compilationSettings); // 0x0000000181AC6450-0x0000000181AC6530
	
		// Methods
		protected void AddToTable(XmlSchemaObjectTable table, XmlQualifiedName qname, XmlSchemaObject item); // 0x0000000181AC4F50-0x0000000181AC5610
		private bool IsValidAttributeGroupRedefine(XmlSchemaObject existingObject, XmlSchemaObject item, XmlSchemaObjectTable table); // 0x0000000181AC5610-0x0000000181AC5740
		private bool IsValidGroupRedefine(XmlSchemaObject existingObject, XmlSchemaObject item, XmlSchemaObjectTable table); // 0x0000000181AC5740-0x0000000181AC5870
		private bool IsValidTypeRedefine(XmlSchemaObject existingObject, XmlSchemaObject item, XmlSchemaObjectTable table); // 0x0000000181AC5870-0x0000000181AC59A0
		protected void SendValidationEvent(string code, XmlSchemaObject source); // 0x0000000181AC6020-0x0000000181AC6110
		protected void SendValidationEvent(string code, string msg, XmlSchemaObject source); // 0x0000000181AC5C30-0x0000000181AC5D40
		protected void SendValidationEvent(string code, string msg1, string msg2, XmlSchemaObject source); // 0x0000000181AC6110-0x0000000181AC6280
		protected void SendValidationEvent(string code, string[] args, Exception innerException, XmlSchemaObject source); // 0x0000000181AC5EC0-0x0000000181AC6020
		protected void SendValidationEvent(string code, string msg1, string msg2, string sourceUri, int lineNumber, int linePosition); // 0x0000000181AC5D40-0x0000000181AC5EC0
		protected void SendValidationEvent(string code, XmlSchemaObject source, XmlSeverityType severity); // 0x0000000181AC5B00-0x0000000181AC5B90
		protected void SendValidationEvent(XmlSchemaException e); // 0x0000000181AC6280-0x0000000181AC6330
		protected void SendValidationEvent(string code, string msg, XmlSchemaObject source, XmlSeverityType severity); // 0x0000000181AC5B90-0x0000000181AC5C30
		protected void SendValidationEvent(XmlSchemaException e, XmlSeverityType severity); // 0x0000000181AC5A40-0x0000000181AC5B00
		protected void SendValidationEventNoThrow(XmlSchemaException e, XmlSeverityType severity); // 0x0000000181AC59A0-0x0000000181AC5A40
	}
}
