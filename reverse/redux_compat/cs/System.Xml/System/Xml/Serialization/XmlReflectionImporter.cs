/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	public class XmlReflectionImporter // TypeDefIndex: 6953
	{
		// Fields
		private string initialDefaultNamespace; // 0x10
		private XmlAttributeOverrides attributeOverrides; // 0x18
		private ArrayList includedTypes; // 0x20
		private ReflectionHelper helper; // 0x28
		private int arrayChoiceCount; // 0x30
		private ArrayList relatedMaps; // 0x38
		private bool allowPrivateTypes; // 0x40
		private static readonly string errSimple; // 0x00
		private static readonly string errSimple2; // 0x08
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6954
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<XmlReflectionMember> __9__28_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181AA7BD0-0x0000000181AA7C40
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _ImportClassMapping_b__28_0(XmlReflectionMember m1, XmlReflectionMember m2); // 0x0000000181AA7A50-0x0000000181AA7BD0
		}
	
		// Constructors
		public XmlReflectionImporter(XmlAttributeOverrides attributeOverrides, string defaultNamespace); // 0x0000000181AB3D40-0x0000000181AB3EB0
		static XmlReflectionImporter(); // 0x0000000181AB3C90-0x0000000181AB3D40
	
		// Methods
		public XmlTypeMapping ImportTypeMapping(Type type); // 0x0000000181AB3070-0x0000000181AB3090
		public XmlTypeMapping ImportTypeMapping(Type type, string defaultNamespace); // 0x0000000181AB3090-0x0000000181AB30B0
		public XmlTypeMapping ImportTypeMapping(Type type, XmlRootAttribute root, string defaultNamespace); // 0x0000000181AB30B0-0x0000000181AB3250
		private XmlTypeMapping ImportTypeMapping(TypeData typeData, XmlRootAttribute root, string defaultNamespace); // 0x0000000181AB2C10-0x0000000181AB3070
		private XmlTypeMapping CreateTypeMapping(TypeData typeData, XmlRootAttribute root, string defaultXmlType, string defaultNamespace); // 0x0000000181AAD240-0x0000000181AAD6D0
		private XmlTypeMapping ImportClassMapping(Type type, XmlRootAttribute root, string defaultNamespace, bool isBaseType = false /* Metadata: 0x0069B82C */); // 0x0000000181AAECF0-0x0000000181AAED90
		private XmlTypeMapping ImportClassMapping(TypeData typeData, XmlRootAttribute root, string defaultNamespace, bool isBaseType = false /* Metadata: 0x0069B82D */); // 0x0000000181AAED90-0x0000000181AAFFB0
		private void RegisterDerivedMap(XmlTypeMapping map, XmlTypeMapping derivedMap); // 0x0000000181AB3B80-0x0000000181AB3C90
		private string GetTypeNamespace(TypeData typeData, XmlRootAttribute root, string defaultNamespace); // 0x0000000181AAE680-0x0000000181AAE7C0
		private XmlTypeMapping ImportListMapping(Type type, XmlRootAttribute root, string defaultNamespace, XmlAttributes atts, int nestingLevel); // 0x0000000181AB1810-0x0000000181AB18A0
		private XmlTypeMapping ImportListMapping(TypeData typeData, XmlRootAttribute root, string defaultNamespace, XmlAttributes atts, int nestingLevel); // 0x0000000181AB18A0-0x0000000181AB2710
		private XmlTypeMapping ImportXmlNodeMapping(TypeData typeData, XmlRootAttribute root, string defaultNamespace); // 0x0000000181AB3250-0x0000000181AB3500
		private XmlTypeMapping ImportPrimitiveMapping(TypeData typeData, XmlRootAttribute root, string defaultNamespace); // 0x0000000181AB2710-0x0000000181AB28E0
		private XmlTypeMapping ImportEnumMapping(TypeData typeData, XmlRootAttribute root, string defaultNamespace); // 0x0000000181AB1050-0x0000000181AB16F0
		private XmlTypeMapping ImportXmlSerializableMapping(TypeData typeData, XmlRootAttribute root, string defaultNamespace); // 0x0000000181AB3500-0x0000000181AB3720
		private void ImportIncludedTypes(Type type, string defaultNamespace); // 0x0000000181AB16F0-0x0000000181AB1810
		private List<XmlReflectionMember> GetReflectionMembers(Type type); // 0x0000000181AAD880-0x0000000181AAE680
		private XmlTypeMapMember CreateMapMember(Type declaringType, XmlReflectionMember rmember, string defaultNamespace); // 0x0000000181AAC510-0x0000000181AAD240
		private XmlTypeMapElementInfoList ImportElementInfo(Type cls, string defaultName, string defaultNamespace, Type defaultType, XmlTypeMapMemberElement member, XmlAttributes atts); // 0x0000000181AAFFB0-0x0000000181AB1050
		private XmlTypeMapElementInfoList ImportAnyElementInfo(string defaultNamespace, XmlReflectionMember rmember, XmlTypeMapMemberElement member, XmlAttributes atts); // 0x0000000181AAE7C0-0x0000000181AAECF0
		private void ImportTextElementInfo(XmlTypeMapElementInfoList list, Type defaultType, XmlTypeMapMemberElement member, XmlAttributes atts, string defaultNamespace); // 0x0000000181AB28E0-0x0000000181AB2C10
		private bool CanBeNull(TypeData type); // 0x0000000181AAC4D0-0x0000000181AAC510
		public void IncludeType(Type type); // 0x0000000181AB3720-0x0000000181AB3B80
		private object GetDefaultValue(TypeData typeData, object defaultValue); // 0x0000000181AAD6D0-0x0000000181AAD880
	}
}
