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
	internal sealed class NfaContentValidator : ContentValidator // TypeDefIndex: 7038
	{
		// Fields
		private BitSet firstpos; // 0x18
		private BitSet[] followpos; // 0x20
		private SymbolsDictionary symbols; // 0x28
		private Positions positions; // 0x30
		private int endMarkerPos; // 0x38
	
		// Constructors
		internal NfaContentValidator(BitSet firstpos, BitSet[] followpos, SymbolsDictionary symbols, Positions positions, int endMarkerPos, XmlSchemaContentType contentType, bool isOpen, bool isEmptiable); // 0x0000000181AFA630-0x0000000181AFA710
	
		// Methods
		public override void InitValidation(ValidationState context); // 0x0000000181AFA380-0x0000000181AFA470
		public override object ValidateElement(XmlQualifiedName name, ValidationState context, out int errorCode); // 0x0000000181AFA470-0x0000000181AFA630
		public override bool CompleteValidation(ValidationState context); // 0x0000000181AF9F90-0x0000000181AF9FE0
		public override ArrayList ExpectedElements(ValidationState context, bool isRequiredOnly); // 0x0000000181AF9FE0-0x0000000181AFA1F0
		public override ArrayList ExpectedParticles(ValidationState context, bool isRequiredOnly, XmlSchemaSet schemaSet); // 0x0000000181AFA1F0-0x0000000181AFA380
	}
}
