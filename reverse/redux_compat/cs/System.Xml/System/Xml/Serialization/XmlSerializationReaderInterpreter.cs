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

namespace System.Xml.Serialization
{
	internal class XmlSerializationReaderInterpreter : XmlSerializationReader // TypeDefIndex: 6967
	{
		// Fields
		private XmlMapping _typeMap; // 0xD0
		private SerializationFormat _format; // 0xD8
		private static readonly XmlQualifiedName AnyType; // 0x00
		private static readonly object[] empty_array; // 0x08
	
		// Nested types
		private class FixupCallbackInfo // TypeDefIndex: 6968
		{
			// Fields
			private XmlSerializationReaderInterpreter _sri; // 0x10
			private ClassMap _map; // 0x18
			private bool _isValueList; // 0x20
	
			// Constructors
			public FixupCallbackInfo(XmlSerializationReaderInterpreter sri, ClassMap map, bool isValueList); // 0x00000001815014B0-0x0000000181501520
	
			// Methods
			public void FixupMembers(object fixup); // 0x0000000181AA7930-0x0000000181AA7970
		}
	
		private class ReaderCallbackInfo // TypeDefIndex: 6969
		{
			// Fields
			private XmlSerializationReaderInterpreter _sri; // 0x10
			private XmlTypeMapping _typeMap; // 0x18
	
			// Constructors
			public ReaderCallbackInfo(XmlSerializationReaderInterpreter sri, XmlTypeMapping typeMap); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			internal object ReadObject(); // 0x0000000181AA7A10-0x0000000181AA7A50
		}
	
		// Constructors
		public XmlSerializationReaderInterpreter(XmlMapping typeMap); // 0x0000000181ABA420-0x0000000181ABA470
		static XmlSerializationReaderInterpreter(); // 0x0000000181ABA340-0x0000000181ABA420
	
		// Methods
		protected override void InitCallbacks(); // 0x0000000181AB4F30-0x0000000181AB5240
		protected override void InitIDs(); // 0x00000001802E76C0-0x00000001802E76D0
		public object ReadRoot(); // 0x0000000181AB9870-0x0000000181AB9B20
		private object ReadEncodedObject(XmlTypeMapping typeMap); // 0x0000000181AB5C60-0x0000000181AB5DD0
		protected virtual object ReadMessage(XmlMembersMapping typeMap); // 0x0000000181AB8AC0-0x0000000181AB9030
		private object ReadRoot(XmlTypeMapping rootMap); // 0x0000000181AB9760-0x0000000181AB9870
		protected virtual object ReadObject(XmlTypeMapping typeMap, bool isNullable, bool checkType); // 0x0000000181AB92F0-0x0000000181AB9530
		protected virtual object ReadClassInstance(XmlTypeMapping typeMap, bool isNullable, bool checkType); // 0x0000000181AB5970-0x0000000181AB5C60
		protected virtual void ReadClassInstanceMembers(XmlTypeMapping typeMap, object ob); // 0x0000000181AB58C0-0x0000000181AB5970
		private void ReadAttributeMembers(ClassMap map, object ob, bool isValueList); // 0x0000000181AB53B0-0x0000000181AB58C0
		private void ReadMembers(ClassMap map, object ob, bool isValueList, bool readBySoapOrder); // 0x0000000181AB65B0-0x0000000181AB8AC0
		private void SetListMembersDefaults(ClassMap map, object ob, bool isValueList); // 0x0000000181AB9EF0-0x0000000181ABA0A0
		internal void FixupMembers(ClassMap map, object obfixup, bool isValueList); // 0x0000000181AB4890-0x0000000181AB4BC0
		protected virtual void ProcessUnknownAttribute(object target); // 0x0000000181AB5340-0x0000000181AB53B0
		protected virtual void ProcessUnknownElement(object target); // 0x0000000181AB5340-0x0000000181AB53B0
		private bool IsReadOnly(XmlTypeMapMember member, TypeData memType, object ob, bool isValueList); // 0x0000000181AB52C0-0x0000000181AB5340
		private void SetMemberValue(XmlTypeMapMember member, object ob, object value, bool isValueList); // 0x0000000181ABA180-0x0000000181ABA340
		private void SetMemberValueFromAttr(XmlTypeMapMember member, object ob, object value, bool isValueList); // 0x0000000181ABA0A0-0x0000000181ABA180
		private object GetMemberValue(XmlTypeMapMember member, object ob, bool isValueList); // 0x0000000181AB4D40-0x0000000181AB4E10
		private object ReadObjectElement(XmlTypeMapElementInfo elem); // 0x0000000181AB9030-0x0000000181AB92F0
		private object ReadPrimitiveValue(XmlTypeMapElementInfo elem); // 0x0000000181AB9600-0x0000000181AB9760
		private object GetValueFromXmlString(string value, TypeData typeData, XmlTypeMapping typeMap); // 0x0000000181AB4E10-0x0000000181AB4F30
		private object ReadListElement(XmlTypeMapping typeMap, bool isNullable, object list, bool canCreateInstance); // 0x0000000181AB5E50-0x0000000181AB6340
		private object ReadListString(XmlTypeMapping typeMap, string values); // 0x0000000181AB6340-0x0000000181AB65B0
		private void AddListValue(TypeData listType, ref object list, int index, object value, bool canCreateInstance); // 0x0000000181AB40A0-0x0000000181AB4400
		private static object CreateInstance(Type type, bool nonPublic); // 0x0000000181AB4760-0x0000000181AB4770
		private object CreateInstance(Type type); // 0x0000000181AB4770-0x0000000181AB47D0
		private object CreateList(Type listType); // 0x0000000181AB47D0-0x0000000181AB4870
		private object InitializeList(TypeData listType); // 0x0000000181AB5240-0x0000000181AB52C0
		private void FillList(object list, object items); // 0x0000000181AB4870-0x0000000181AB4890
		private void CopyEnumerableList(object source, object dest); // 0x0000000181AB4400-0x0000000181AB4760
		private object ReadXmlNodeElement(XmlTypeMapping typeMap, bool isNullable); // 0x0000000181AB9B20-0x0000000181AB9B50
		private object ReadXmlNode(TypeData type, bool wrapped); // 0x0000000181AB9B50-0x0000000181AB9CF0
		private object ReadPrimitiveElement(XmlTypeMapping typeMap, bool isNullable); // 0x0000000181AB9530-0x0000000181AB9600
		private object ReadEnumElement(XmlTypeMapping typeMap, bool isNullable); // 0x0000000181AB5DD0-0x0000000181AB5E50
		private object GetEnumValue(XmlTypeMapping typeMap, string val); // 0x0000000181AB4BC0-0x0000000181AB4D40
		private object ReadXmlSerializableElement(XmlTypeMapping typeMap, bool isNullable); // 0x0000000181AB9CF0-0x0000000181AB9EF0
	}
}
