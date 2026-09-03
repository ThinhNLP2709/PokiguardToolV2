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
	internal sealed class AllElementsContentValidator : ContentValidator // TypeDefIndex: 7041
	{
		// Fields
		private Hashtable elements; // 0x18
		private object[] particles; // 0x20
		private BitSet isRequired; // 0x28
		private int countRequired; // 0x30
	
		// Properties
		public override bool IsEmptiable { get; } // 0x0000000181ADE570-0x0000000181ADE590 
	
		// Constructors
		public AllElementsContentValidator(XmlSchemaContentType contentType, int size, bool isEmptiable); // 0x0000000181ADE450-0x0000000181ADE570
	
		// Methods
		public bool AddElement(XmlQualifiedName name, object particle, bool isEmptiable); // 0x0000000181ADD9A0-0x0000000181ADDAF0
		public override void InitValidation(ValidationState context); // 0x0000000181ADE290-0x0000000181ADE330
		public override object ValidateElement(XmlQualifiedName name, ValidationState context, out int errorCode); // 0x0000000181ADE330-0x0000000181ADE450
		public override bool CompleteValidation(ValidationState context); // 0x0000000181ADDAF0-0x0000000181ADDB40
		public override ArrayList ExpectedElements(ValidationState context, bool isRequiredOnly); // 0x0000000181ADDB40-0x0000000181ADDE90
		public override ArrayList ExpectedParticles(ValidationState context, bool isRequiredOnly, XmlSchemaSet schemaSet); // 0x0000000181ADDE90-0x0000000181ADE290
	}
}
