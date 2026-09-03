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
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal abstract class SchemaDeclBase // TypeDefIndex: 7143
	{
		// Fields
		protected XmlQualifiedName name; // 0x10
		protected string prefix; // 0x18
		protected bool isDeclaredInExternal; // 0x20
		protected Use presence; // 0x24
		protected XmlSchemaType schemaType; // 0x28
		protected XmlSchemaDatatype datatype; // 0x30
		protected string defaultValueRaw; // 0x38
		protected object defaultValueTyped; // 0x40
		protected long maxLength; // 0x48
		protected long minLength; // 0x50
		protected List<string> values; // 0x58
	
		// Properties
		internal XmlQualifiedName Name { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal string Prefix { get; set; } // 0x00000001819BF6F0-0x00000001819BF710 0x00000001802FAF70-0x00000001802FAF80
		internal bool IsDeclaredInExternal { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		internal Use Presence { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		internal long MaxLength { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x000000018172A440-0x000000018172A450
		internal long MinLength { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001819BF710-0x00000001819BF720
		internal XmlSchemaType SchemaType { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		internal XmlSchemaDatatype Datatype { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		internal List<string> Values { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		internal string DefaultValueRaw { get; set; } // 0x00000001819BF6D0-0x00000001819BF6F0 0x000000018033E850-0x000000018033E860
		internal object DefaultValueTyped { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
	
		// Nested types
		internal enum Use // TypeDefIndex: 7144
		{
			Default = 0,
			Required = 1,
			Implied = 2,
			Fixed = 3,
			RequiredFixed = 4
		}
	
		// Constructors
		protected SchemaDeclBase(XmlQualifiedName name, string prefix); // 0x00000001819BF5A0-0x00000001819BF660
		protected SchemaDeclBase(); // 0x00000001819BF660-0x00000001819BF6D0
	
		// Methods
		internal void AddValue(string value); // 0x00000001819BF370-0x00000001819BF470
		internal bool CheckEnumeration(object pVal); // 0x00000001819BF470-0x00000001819BF540
		internal bool CheckValue(object pVal); // 0x00000001819BF540-0x00000001819BF5A0
	}
}
