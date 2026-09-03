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

namespace System.Xml.Schema
{
	internal class TypedObject // TypeDefIndex: 7017
	{
		// Fields
		private DecimalStruct dstruct; // 0x10
		private object ovalue; // 0x18
		private string svalue; // 0x20
		private XmlSchemaDatatype xsdtype; // 0x28
		private int dim; // 0x30
		private bool isList; // 0x34
	
		// Properties
		public int Dim { get; } // 0x000000018033D100-0x000000018033D110 
		public bool IsList { get; } // 0x00000001816DAFD0-0x00000001816DAFE0 
		public bool IsDecimal { get; } // 0x0000000181AD4E30-0x0000000181AD4E50 
		public decimal[] Dvalue { get; } // 0x00000001814C98E0-0x00000001814C9900 
		public object Value { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public XmlSchemaDatatype Type { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		private class DecimalStruct // TypeDefIndex: 7018
		{
			// Fields
			private bool isDecimal; // 0x10
			private decimal[] dvalue; // 0x18
	
			// Properties
			public bool IsDecimal { get; set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
			public decimal[] Dvalue { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			public DecimalStruct(); // 0x0000000181ACB4B0-0x0000000181ACB510
			public DecimalStruct(int dim); // 0x0000000181ACB450-0x0000000181ACB4B0
		}
	
		// Constructors
		public TypedObject(object obj, string svalue, XmlSchemaDatatype xsdtype); // 0x0000000181AD4CD0-0x0000000181AD4E30
	
		// Methods
		public override string ToString(); // 0x00000001802F8630-0x00000001802F8640
		public void SetDecimal(); // 0x0000000181AD4A20-0x0000000181AD4CD0
		private bool ListDValueEquals(TypedObject other); // 0x0000000181AD48E0-0x0000000181AD4A20
		public bool Equals(TypedObject other); // 0x0000000181AD4540-0x0000000181AD48E0
	}
}
