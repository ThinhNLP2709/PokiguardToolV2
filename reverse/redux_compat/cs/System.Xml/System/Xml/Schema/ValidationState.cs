/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal sealed class ValidationState // TypeDefIndex: 7158
	{
		// Fields
		public bool IsNill; // 0x10
		public bool IsDefault; // 0x11
		public bool NeedValidateChildren; // 0x12
		public bool CheckRequiredAttribute; // 0x13
		public bool ValidationSkipped; // 0x14
		public XmlSchemaContentProcessing ProcessContents; // 0x18
		public XmlSchemaValidity Validity; // 0x1C
		public SchemaElementDecl ElementDecl; // 0x20
		public SchemaElementDecl ElementDeclBeforeXsi; // 0x28
		public string LocalName; // 0x30
		public string Namespace; // 0x38
		public ConstraintStruct[] Constr; // 0x40
		public StateUnion CurrentState; // 0x48
		public bool HasMatched; // 0x4C
		public BitSet[] CurPos; // 0x50
		public BitSet AllElementsSet; // 0x58
		public List<RangePositionInfo> RunningPositions; // 0x60
		public bool TooComplex; // 0x68
	
		// Constructors
		public ValidationState(); // 0x00000001819C8880-0x00000001819C88E0
	}
}
