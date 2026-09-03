/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[Serializable]
	internal sealed class SimpleType : ISerializable // TypeDefIndex: 11322
	{
		// Fields
		private string _baseType; // 0x10
		private SimpleType _baseSimpleType; // 0x18
		private XmlQualifiedName _xmlBaseType; // 0x20
		private string _name; // 0x28
		private int _length; // 0x30
		private int _minLength; // 0x34
		private int _maxLength; // 0x38
		private string _pattern; // 0x40
		private string _ns; // 0x48
		private string _maxExclusive; // 0x50
		private string _maxInclusive; // 0x58
		private string _minExclusive; // 0x60
		private string _minInclusive; // 0x68
		internal string _enumeration; // 0x70
	
		// Properties
		internal string BaseType { get; } // 0x0000000180377550-0x0000000180377560 
		internal XmlQualifiedName XmlBaseType { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal string Name { get; } // 0x000000018033D240-0x000000018033D250 
		internal string Namespace { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal int Length { get; } // 0x000000018033D100-0x000000018033D110 
		internal int MaxLength { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		internal SimpleType BaseSimpleType { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string SimpleTypeQualifiedName { get; } // 0x000000018189FC60-0x000000018189FCC0 
	
		// Constructors
		internal SimpleType(string baseType); // 0x000000018189F940-0x000000018189FA80
		internal SimpleType(XmlSchemaSimpleType node); // 0x000000018189FA80-0x000000018189FC60
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018189F390-0x000000018189F3D0
		internal void LoadTypeValues(XmlSchemaSimpleType node); // 0x000000018189EA90-0x000000018189F320
		internal bool IsPlainString(); // 0x000000018189E980-0x000000018189EA90
		internal string QualifiedName(string name); // 0x000000018189F320-0x000000018189F390
		internal XmlNode ToNode(XmlDocument dc, Hashtable prefixes, bool inRemoting); // 0x000000018189F3D0-0x000000018189F940
		internal static SimpleType CreateEnumeratedType(string values); // 0x000000018189E690-0x000000018189E710
		internal static SimpleType CreateByteArrayType(string encoding); // 0x000000018189E630-0x000000018189E690
		internal static SimpleType CreateLimitedStringType(int length); // 0x000000018189E710-0x000000018189E790
		internal static SimpleType CreateSimpleType(StorageType typeCode, Type type); // 0x000000018189E790-0x000000018189E860
		internal string HasConflictingDefinition(SimpleType otherSimpleType); // 0x000000018189E860-0x000000018189E980
		internal bool CanHaveMaxLength(); // 0x000000018189E510-0x000000018189E580
		internal void ConvertToAnnonymousSimpleType(); // 0x000000018189E580-0x000000018189E630
	}
}
