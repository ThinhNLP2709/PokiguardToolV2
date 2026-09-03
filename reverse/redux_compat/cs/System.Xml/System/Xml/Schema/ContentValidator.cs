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
	internal class ContentValidator // TypeDefIndex: 7035
	{
		// Fields
		private XmlSchemaContentType contentType; // 0x10
		private bool isOpen; // 0x14
		private bool isEmptiable; // 0x15
		public static readonly ContentValidator Empty; // 0x00
		public static readonly ContentValidator TextOnly; // 0x08
		public static readonly ContentValidator Mixed; // 0x10
		public static readonly ContentValidator Any; // 0x18
	
		// Properties
		public XmlSchemaContentType ContentType { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public bool PreserveWhitespace { get; } // 0x0000000181ACB430-0x0000000181ACB450 
		public virtual bool IsEmptiable { get; } // 0x000000018155D200-0x000000018155D210 
		public bool IsOpen { get; set; } // 0x0000000181ACB410-0x0000000181ACB430 0x0000000181541B70-0x0000000181541B80
	
		// Constructors
		public ContentValidator(XmlSchemaContentType contentType); // 0x0000000181ACB390-0x0000000181ACB3C0
		protected ContentValidator(XmlSchemaContentType contentType, bool isOpen, bool isEmptiable); // 0x0000000181ACB3C0-0x0000000181ACB410
		static ContentValidator(); // 0x0000000181ACB220-0x0000000181ACB390
	
		// Methods
		public virtual void InitValidation(ValidationState context); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual object ValidateElement(XmlQualifiedName name, ValidationState context, out int errorCode); // 0x0000000181ACB1F0-0x0000000181ACB220
		public virtual bool CompleteValidation(ValidationState context); // 0x00000001802E7990-0x00000001802E79A0
		public virtual ArrayList ExpectedElements(ValidationState context, bool isRequiredOnly); // 0x00000001802E7860-0x00000001802E7870
		public virtual ArrayList ExpectedParticles(ValidationState context, bool isRequiredOnly, XmlSchemaSet schemaSet); // 0x00000001802E7860-0x00000001802E7870
		public static void AddParticleToExpected(XmlSchemaParticle p, XmlSchemaSet schemaSet, ArrayList particles); // 0x0000000181ACB170-0x0000000181ACB1F0
		public static void AddParticleToExpected(XmlSchemaParticle p, XmlSchemaSet schemaSet, ArrayList particles, bool global); // 0x0000000181ACAED0-0x0000000181ACB170
	}
}
