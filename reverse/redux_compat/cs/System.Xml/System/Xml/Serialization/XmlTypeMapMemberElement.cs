/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	internal class XmlTypeMapMemberElement : XmlTypeMapMember // TypeDefIndex: 6985
	{
		// Fields
		private XmlTypeMapElementInfoList _elementInfo; // 0x58
		private string _choiceMember; // 0x60
		private bool _isTextCollector; // 0x68
		private TypeData _choiceTypeData; // 0x70
	
		// Properties
		public XmlTypeMapElementInfoList ElementInfo { get; set; } // 0x0000000181ADC3C0-0x0000000181ADC430 0x00000001802F4050-0x00000001802F4060
		public string ChoiceMember { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		public TypeData ChoiceTypeData { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		public bool IsXmlTextCollector { get; set; } // 0x0000000180B25580-0x0000000180B25590 0x0000000180B262C0-0x0000000180B262D0
	
		// Constructors
		public XmlTypeMapMemberElement(); // 0x0000000181ADB750-0x0000000181ADB7B0
	
		// Methods
		public XmlTypeMapElementInfo FindElement(object ob, object memberValue); // 0x0000000181ADBCF0-0x0000000181ADC230
		public void SetChoice(object ob, object choice); // 0x0000000181ADC230-0x0000000181ADC3C0
	}
}
