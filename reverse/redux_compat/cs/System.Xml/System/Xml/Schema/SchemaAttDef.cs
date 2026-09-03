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
	internal sealed class SchemaAttDef : SchemaDeclBase, IDtdDefaultAttributeInfo // TypeDefIndex: 7137
	{
		// Fields
		private string defExpanded; // 0x60
		private int lineNum; // 0x68
		private int linePos; // 0x6C
		private int valueLineNum; // 0x70
		private int valueLinePos; // 0x74
		private Reserve reserved; // 0x78
		private bool defaultValueChecked; // 0x7C
		private XmlSchemaAttribute schemaAttribute; // 0x80
		public static readonly SchemaAttDef Empty; // 0x00
	
		// Properties
		string IDtdAttributeInfo.Prefix { get; } // 0x000000018198E600-0x000000018198E610 
		string IDtdAttributeInfo.LocalName { get; } // 0x0000000180FB1BE0-0x0000000180FB1C00 
		int IDtdAttributeInfo.LineNumber { get; } // 0x00000001803002C0-0x00000001803002D0 
		int IDtdAttributeInfo.LinePosition { get; } // 0x0000000180C55C40-0x0000000180C55C50 
		bool IDtdAttributeInfo.IsNonCDataType { get; } // 0x000000018198E5C0-0x000000018198E5F0 
		bool IDtdAttributeInfo.IsDeclaredInExternal { get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
		bool IDtdAttributeInfo.IsXmlAttribute { get; } // 0x000000018198E5F0-0x000000018198E600 
		string IDtdDefaultAttributeInfo.DefaultValueExpanded { get; } // 0x000000018198E610-0x000000018198E630 
		object IDtdDefaultAttributeInfo.DefaultValueTyped { get; } // 0x0000000180377940-0x0000000180377950 
		int IDtdDefaultAttributeInfo.ValueLineNumber { get; } // 0x0000000180CC2260-0x0000000180CC2270 
		int IDtdDefaultAttributeInfo.ValueLinePosition { get; } // 0x0000000181974810-0x0000000181974820 
		internal int LinePosition { get; set; } // 0x0000000180C55C40-0x0000000180C55C50 0x0000000180C55C60-0x0000000180C55C70
		internal int LineNumber { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001803002E0-0x00000001803002F0
		internal int ValueLinePosition { get; set; } // 0x0000000181974810-0x0000000181974820 0x000000018198E760-0x000000018198E770
		internal int ValueLineNumber { get; set; } // 0x0000000180CC2260-0x0000000180CC2270 0x0000000180CC2270-0x0000000180CC2280
		internal string DefaultValueExpanded { get; set; } // 0x000000018198E6E0-0x000000018198E700 0x00000001803780F0-0x0000000180378100
		internal XmlTokenizedType TokenizedType { get; set; } // 0x000000018198E700-0x000000018198E730 0x000000018198E730-0x000000018198E760
		internal Reserve Reserved { get; set; } // 0x000000018169BB50-0x000000018169BB60 0x00000001805936B0-0x00000001805936C0
		internal bool DefaultValueChecked { get; } // 0x000000018198E6D0-0x000000018198E6E0 
		internal XmlSchemaAttribute SchemaAttribute { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
	
		// Nested types
		internal enum Reserve // TypeDefIndex: 7138
		{
			None = 0,
			XmlSpace = 1,
			XmlLang = 2
		}
	
		// Constructors
		public SchemaAttDef(XmlQualifiedName name, string prefix); // 0x000000018198E6B0-0x000000018198E6C0
		public SchemaAttDef(XmlQualifiedName name); // 0x000000018198E6A0-0x000000018198E6B0
		private SchemaAttDef(); // 0x000000018198E6C0-0x000000018198E6D0
		static SchemaAttDef(); // 0x000000018198E630-0x000000018198E6A0
	
		// Methods
		internal void CheckXmlSpace(IValidationEventHandling validationEventHandling); // 0x000000018198E2D0-0x000000018198E560
		internal SchemaAttDef Clone(); // 0x000000018198E560-0x000000018198E5C0
	}
}
