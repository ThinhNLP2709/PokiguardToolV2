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
	internal class AutoValidator : BaseValidator // TypeDefIndex: 7006
	{
		// Properties
		public override bool PreserveWhitespace { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		public AutoValidator(XmlValidatingReaderImpl reader, XmlSchemaCollection schemaCollection, IValidationEventHandling eventHandling); // 0x0000000181AC4250-0x0000000181AC42F0
	
		// Methods
		public override void Validate(); // 0x0000000181AC4160-0x0000000181AC4250
		public override void CompleteValidation(); // 0x00000001802E76C0-0x00000001802E76D0
		public override object FindId(string name); // 0x00000001802E7860-0x00000001802E7870
		private ValidationType DetectValidationType(); // 0x0000000181AC3D50-0x0000000181AC4160
	}
}
