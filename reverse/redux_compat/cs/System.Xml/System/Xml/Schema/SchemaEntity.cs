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
	internal sealed class SchemaEntity : IDtdEntityInfo // TypeDefIndex: 7146
	{
		// Fields
		private XmlQualifiedName qname; // 0x10
		private string url; // 0x18
		private string pubid; // 0x20
		private string text; // 0x28
		private XmlQualifiedName ndata; // 0x30
		private int lineNumber; // 0x38
		private int linePosition; // 0x3C
		private bool isParameter; // 0x40
		private bool isExternal; // 0x41
		private bool parsingInProgress; // 0x42
		private bool isDeclaredInExternal; // 0x43
		private string baseURI; // 0x48
		private string declaredURI; // 0x50
	
		// Properties
		string IDtdEntityInfo.Name { get; } // 0x0000000180FB1BE0-0x0000000180FB1C00 
		bool IDtdEntityInfo.IsExternal { get; } // 0x00000001815B1190-0x00000001815B11A0 
		bool IDtdEntityInfo.IsDeclaredInExternal { get; } // 0x00000001815B1180-0x00000001815B1190 
		bool IDtdEntityInfo.IsUnparsedEntity { get; } // 0x00000001819C0320-0x00000001819C0350 
		bool IDtdEntityInfo.IsParameterEntity { get; } // 0x00000001803B1170-0x00000001803B1180 
		string IDtdEntityInfo.BaseUriString { get; } // 0x00000001819C02E0-0x00000001819C0300 
		string IDtdEntityInfo.DeclaredUriString { get; } // 0x00000001819C0300-0x00000001819C0320 
		string IDtdEntityInfo.SystemId { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		string IDtdEntityInfo.PublicId { get; } // 0x00000001802F8630-0x00000001802F8640 
		string IDtdEntityInfo.Text { get; } // 0x000000018033D240-0x000000018033D250 
		int IDtdEntityInfo.LineNumber { get; } // 0x000000018047EDE0-0x000000018047EDF0 
		int IDtdEntityInfo.LinePosition { get; } // 0x00000001804EFAC0-0x00000001804EFAD0 
		internal XmlQualifiedName Name { get; } // 0x0000000180377550-0x0000000180377560 
		internal string Url { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001819C0490-0x00000001819C04B0
		internal string Pubid { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		internal bool IsExternal { get; set; } // 0x00000001815B1190-0x00000001815B11A0 0x00000001819C0450-0x00000001819C0460
		internal bool DeclaredInExternal { get; set; } // 0x00000001815B1180-0x00000001815B1190 0x00000001819C0440-0x00000001819C0450
		internal XmlQualifiedName NData { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		internal string Text { get; set; } // 0x000000018033D240-0x000000018033D250 0x00000001819C0470-0x00000001819C0490
		internal int Line { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		internal int Pos { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
		internal string BaseURI { get; set; } // 0x00000001819C03F0-0x00000001819C0410 0x00000001803780C0-0x00000001803780D0
		internal bool ParsingInProgress { get; set; } // 0x00000001819C0430-0x00000001819C0440 0x00000001819C0460-0x00000001819C0470
		internal string DeclaredURI { get; set; } // 0x00000001819C0410-0x00000001819C0430 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		internal SchemaEntity(XmlQualifiedName qname, bool isParameter); // 0x00000001819C0350-0x00000001819C03F0
	
		// Methods
		internal static bool IsPredefinedEntity(string n); // 0x00000001819C0210-0x00000001819C02E0
	}
}
