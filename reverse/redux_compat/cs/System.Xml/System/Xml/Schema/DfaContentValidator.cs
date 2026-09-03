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
	internal sealed class DfaContentValidator : ContentValidator // TypeDefIndex: 7037
	{
		// Fields
		private int[][] transitionTable; // 0x18
		private SymbolsDictionary symbols; // 0x20
	
		// Constructors
		internal DfaContentValidator(int[][] transitionTable, SymbolsDictionary symbols, XmlSchemaContentType contentType, bool isOpen, bool isEmptiable); // 0x0000000181ACBAE0-0x0000000181ACBB90
	
		// Methods
		public override void InitValidation(ValidationState context); // 0x0000000181ACB890-0x0000000181ACB8F0
		public override object ValidateElement(XmlQualifiedName name, ValidationState context, out int errorCode); // 0x0000000181ACB8F0-0x0000000181ACBAE0
		public override bool CompleteValidation(ValidationState context); // 0x0000000181ACB510-0x0000000181ACB530
		public override ArrayList ExpectedElements(ValidationState context, bool isRequiredOnly); // 0x0000000181ACB530-0x0000000181ACB710
		public override ArrayList ExpectedParticles(ValidationState context, bool isRequiredOnly, XmlSchemaSet schemaSet); // 0x0000000181ACB710-0x0000000181ACB890
	}
}
