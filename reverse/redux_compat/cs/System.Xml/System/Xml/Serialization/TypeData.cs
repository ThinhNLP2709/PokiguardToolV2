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
	internal class TypeData // TypeDefIndex: 6928
	{
		// Fields
		private Type type; // 0x10
		private string elementName; // 0x18
		private SchemaTypes sType; // 0x20
		private Type listItemType; // 0x28
		private string typeName; // 0x30
		private string fullTypeName; // 0x38
		private TypeData listItemTypeData; // 0x40
		private TypeData mappedType; // 0x48
		private XmlSchemaPatternFacet facet; // 0x50
		private MethodInfo typeConvertor; // 0x58
		private bool hasPublicConstructor; // 0x60
		private bool nullableOverride; // 0x61
		private static string[] keywords; // 0x00
	
		// Properties
		public string TypeName { get; } // 0x000000018031E110-0x000000018031E120 
		public string XmlType { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public Type Type { get; } // 0x0000000180377550-0x0000000180377560 
		public string FullTypeName { get; } // 0x00000001803272A0-0x00000001803272B0 
		public SchemaTypes SchemaType { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public bool IsListType { get; } // 0x0000000181A8EB10-0x0000000181A8EB20 
		public bool IsComplexType { get; } // 0x0000000181A8EAE0-0x0000000181A8EB10 
		public bool IsValueType { get; } // 0x0000000181A8EC40-0x0000000181A8ECC0 
		public bool IsNullable { get; set; } // 0x0000000181A8EB20-0x0000000181A8EC40 0x00000001815B84F0-0x00000001815B8500
		public TypeData ListItemTypeData { get; } // 0x0000000181A8ECD0-0x0000000181A8EDD0 
		public Type ListItemType { get; } // 0x0000000181A8EDD0-0x0000000181A8F660 
		public bool IsXsdType { get; } // 0x0000000181A8ECC0-0x0000000181A8ECD0 
		public bool HasPublicConstructor { get; } // 0x000000018033D4F0-0x000000018033D500 
	
		// Constructors
		public TypeData(Type type, string elementName, bool isPrimitive); // 0x0000000181A8EAC0-0x0000000181A8EAE0
		public TypeData(Type type, string elementName, bool isPrimitive, TypeData mappedType, XmlSchemaPatternFacet facet); // 0x0000000181A8E5A0-0x0000000181A8EAC0
		static TypeData(); // 0x0000000181A8D660-0x0000000181A8E5A0
	
		// Methods
		private void LookupTypeConvertor(); // 0x0000000181A8D5B0-0x0000000181A8D660
		internal void ConvertForAssignment(ref object value); // 0x0000000181A8D070-0x0000000181A8D160
		public static PropertyInfo GetIndexerProperty(Type collectionType); // 0x0000000181A8D470-0x0000000181A8D5B0
		private static InvalidOperationException CreateMissingAddMethodException(Type type, string inheritFrom, Type argumentType); // 0x0000000181A8D160-0x0000000181A8D270
		internal static Type GetGenericListItemType(Type type); // 0x0000000181A8D270-0x0000000181A8D470
	}
}
