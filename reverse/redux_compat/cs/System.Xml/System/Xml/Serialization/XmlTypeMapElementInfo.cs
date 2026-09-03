/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	internal class XmlTypeMapElementInfo // TypeDefIndex: 6981
	{
		// Fields
		private string _elementName; // 0x10
		private string _namespace; // 0x18
		private XmlSchemaForm _form; // 0x20
		private XmlTypeMapMember _member; // 0x28
		private object _choiceValue; // 0x30
		private bool _isNullable; // 0x38
		private int _nestingLevel; // 0x3C
		private XmlTypeMapping _mappedType; // 0x40
		private TypeData _type; // 0x48
		private bool _wrappedElement; // 0x50
		private int _explicitOrder; // 0x54
	
		// Properties
		public TypeData TypeData { get; } // 0x00000001803272B0-0x00000001803272C0 
		public object ChoiceValue { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public string ElementName { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string Namespace { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string DataTypeNamespace { get; } // 0x0000000181ADB520-0x0000000181ADB580 
		public string DataTypeName { get; } // 0x0000000181ADB4F0-0x0000000181ADB520 
		public XmlSchemaForm Form { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public XmlTypeMapping MappedType { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public bool IsNullable { get; set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public XmlTypeMapMember Member { get; } // 0x000000018033D240-0x000000018033D250 
		public int NestingLevel { set; } // 0x00000001805D5550-0x00000001805D5560
		public bool MultiReferenceType { get; } // 0x0000000181ADB5E0-0x0000000181ADB600 
		public bool WrappedElement { get; set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
		public bool IsTextElement { get; set; } // 0x0000000181ADB580-0x0000000181ADB5C0 0x0000000181ADB610-0x0000000181ADB6C0
		public bool IsUnnamedAnyElement { get; set; } // 0x0000000181ADB5C0-0x0000000181ADB5E0 0x0000000181ADB6C0-0x0000000181ADB750
		public int ExplicitOrder { get; set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x0000000181ADB600-0x0000000181ADB610
	
		// Constructors
		public XmlTypeMapElementInfo(XmlTypeMapMember member, TypeData type); // 0x0000000181ADB430-0x0000000181ADB4F0
	
		// Methods
		public override bool Equals(object other); // 0x0000000181ADB2F0-0x0000000181ADB430
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
	}
}
