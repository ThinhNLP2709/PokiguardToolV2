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
	internal sealed class RangeContentValidator : ContentValidator // TypeDefIndex: 7040
	{
		// Fields
		private BitSet firstpos; // 0x18
		private BitSet[] followpos; // 0x20
		private BitSet positionsWithRangeTerminals; // 0x28
		private SymbolsDictionary symbols; // 0x30
		private Positions positions; // 0x38
		private int minMaxNodesCount; // 0x40
		private int endMarkerPos; // 0x44
	
		// Constructors
		internal RangeContentValidator(BitSet firstpos, BitSet[] followpos, SymbolsDictionary symbols, Positions positions, int endMarkerPos, XmlSchemaContentType contentType, bool isEmptiable, BitSet positionsWithRangeTerminals, int minmaxNodesCount); // 0x0000000181AFCB30-0x0000000181AFCC20
	
		// Methods
		public override void InitValidation(ValidationState context); // 0x0000000181AFC090-0x0000000181AFC260
		public override object ValidateElement(XmlQualifiedName name, ValidationState context, out int errorCode); // 0x0000000181AFC260-0x0000000181AFCB30
		public override bool CompleteValidation(ValidationState context); // 0x0000000181AFBBC0-0x0000000181AFBBE0
		public override ArrayList ExpectedElements(ValidationState context, bool isRequiredOnly); // 0x0000000181AFBBE0-0x0000000181AFBE70
		public override ArrayList ExpectedParticles(ValidationState context, bool isRequiredOnly, XmlSchemaSet schemaSet); // 0x0000000181AFBE70-0x0000000181AFC090
	}
}
