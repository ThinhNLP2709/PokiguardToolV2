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

namespace System.Xml.Serialization
{
	public class XmlTypeMapping : XmlMapping // TypeDefIndex: 6992
	{
		// Fields
		private string xmlType; // 0x48
		private string xmlTypeNamespace; // 0x50
		private TypeData type; // 0x58
		private XmlTypeMapping baseMap; // 0x60
		private bool multiReferenceType; // 0x68
		private bool includeInSchema; // 0x69
		private bool isNullable; // 0x6A
		private bool isAny; // 0x6B
		private ArrayList _derivedTypes; // 0x70
	
		// Properties
		public string TypeFullName { get; } // 0x0000000181ADD950-0x0000000181ADD970 
		internal TypeData TypeData { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal string XmlType { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		internal string XmlTypeNamespace { get; set; } // 0x0000000181ADD970-0x0000000181ADD990 0x00000001806CCE80-0x00000001806CCE90
		internal bool HasXmlTypeNamespace { get; } // 0x0000000180D90580-0x0000000180D90590 
		internal ArrayList DerivedTypes { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		internal bool MultiReferenceType { get; } // 0x0000000180B25580-0x0000000180B25590 
		internal XmlTypeMapping BaseMap { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		internal bool IncludeInSchema { set; } // 0x0000000181A42750-0x0000000181A42760
		internal bool IsNullable { get; set; } // 0x0000000181A42160-0x0000000181A42170 0x0000000181A42500-0x0000000181A42510
		internal bool IsAny { get; set; } // 0x0000000181ADD940-0x0000000181ADD950 0x0000000181ADD990-0x0000000181ADD9A0
	
		// Constructors
		internal XmlTypeMapping(string elementName, string ns, TypeData typeData, string xmlType, string xmlTypeNamespace); // 0x0000000181ADD870-0x0000000181ADD940
	
		// Methods
		internal XmlTypeMapping GetRealTypeMap(Type objectType); // 0x0000000181ADD680-0x0000000181ADD7E0
		internal XmlTypeMapping GetRealElementMap(string name, string ens); // 0x0000000181ADD430-0x0000000181ADD680
		internal void UpdateRoot(XmlQualifiedName qname); // 0x0000000181ADD7E0-0x0000000181ADD870
	}
}
