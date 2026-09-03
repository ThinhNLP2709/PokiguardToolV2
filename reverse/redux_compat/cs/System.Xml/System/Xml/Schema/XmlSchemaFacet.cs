/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public abstract class XmlSchemaFacet : XmlSchemaAnnotated // TypeDefIndex: 7204
	{
		// Fields
		private string value; // 0x50
		private bool isFixed; // 0x58
		private FacetType facetType; // 0x5C
	
		// Properties
		[XmlAttribute("value")]
		public string Value { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[DefaultValue(false)]
		[XmlAttribute("fixed")]
		public virtual bool IsFixed { get; set; } // 0x0000000181424750-0x0000000181424760 0x00000001819DE310-0x00000001819DE3B0
		internal FacetType FacetType { get; set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
	
		// Constructors
		protected XmlSchemaFacet(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
