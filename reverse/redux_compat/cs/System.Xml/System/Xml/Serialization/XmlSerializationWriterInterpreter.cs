/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	internal class XmlSerializationWriterInterpreter : XmlSerializationWriter // TypeDefIndex: 6973
	{
		// Fields
		private XmlMapping _typeMap; // 0x48
		private SerializationFormat _format; // 0x50
	
		// Nested types
		private class CallbackInfo // TypeDefIndex: 6974
		{
			// Fields
			private XmlSerializationWriterInterpreter _swi; // 0x10
			private XmlTypeMapping _typeMap; // 0x18
	
			// Constructors
			public CallbackInfo(XmlSerializationWriterInterpreter swi, XmlTypeMapping typeMap); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			internal void WriteObject(object ob); // 0x0000000181AC8290-0x0000000181AC82F0
			internal void WriteEnum(object ob); // 0x0000000181AC8230-0x0000000181AC8290
		}
	
		// Constructors
		public XmlSerializationWriterInterpreter(XmlMapping typeMap); // 0x0000000181AD9BD0-0x0000000181AD9C20
	
		// Methods
		protected override void InitCallbacks(); // 0x0000000181AD6200-0x0000000181AD6540
		public void WriteRoot(object ob); // 0x0000000181AD9940-0x0000000181AD9BD0
		protected virtual void WriteObject(XmlTypeMapping typeMap, object ob, string element, string namesp, bool isNullable, bool needType, bool writeWrappingElem); // 0x0000000181AD8C90-0x0000000181AD9430
		protected virtual void WriteMessage(XmlMembersMapping membersMap, object[] parameters); // 0x0000000181AD87E0-0x0000000181AD89E0
		protected virtual void WriteObjectElement(XmlTypeMapping typeMap, object ob, string element, string namesp); // 0x0000000181AD8B40-0x0000000181AD8C90
		protected virtual void WriteObjectElementAttributes(XmlTypeMapping typeMap, object ob); // 0x0000000181AD89E0-0x0000000181AD8A90
		protected virtual void WriteObjectElementElements(XmlTypeMapping typeMap, object ob); // 0x0000000181AD8A90-0x0000000181AD8B40
		private void WriteMembers(ClassMap map, object ob, bool isValueList); // 0x0000000181AD8780-0x0000000181AD87E0
		private void WriteAttributeMembers(ClassMap map, object ob, bool isValueList); // 0x0000000181AD6C20-0x0000000181AD7140
		private void WriteElementMembers(ClassMap map, object ob, bool isValueList); // 0x0000000181AD7140-0x0000000181AD76F0
		private object GetMemberValue(XmlTypeMapMember member, object ob, bool isValueList); // 0x0000000181AD5AE0-0x0000000181AD5BB0
		private bool MemberHasValue(XmlTypeMapMember member, object ob, bool isValueList); // 0x0000000181AD6540-0x0000000181AD6770
		private void WriteMemberElement(XmlTypeMapElementInfo elem, object memberValue); // 0x0000000181AD81C0-0x0000000181AD8780
		internal static object ImplicitConvert(object obj, Type type); // 0x0000000181AD5E80-0x0000000181AD6200
		private void WritePrimitiveValueLiteral(object memberValue, string name, string ns, XmlTypeMapping mappedType, TypeData typeData, bool wrapped, bool isNullable); // 0x0000000181AD96F0-0x0000000181AD9940
		private void WritePrimitiveValueEncoded(object memberValue, string name, string ns, XmlQualifiedName xsiType, XmlTypeMapping mappedType, TypeData typeData, bool wrapped, bool isNullable); // 0x0000000181AD9480-0x0000000181AD96F0
		protected virtual void WriteListElement(XmlTypeMapping typeMap, object ob, string element, string namesp); // 0x0000000181AD7EC0-0x0000000181AD81C0
		private void WriteListContent(object container, TypeData listType, ListMap map, object ob, StringBuilder targetString); // 0x0000000181AD77D0-0x0000000181AD7EC0
		private int GetListCount(TypeData listType, object ob); // 0x0000000181AD59D0-0x0000000181AD5AE0
		private void WriteAnyElementContent(XmlTypeMapMemberAnyElement member, object memberValue); // 0x0000000181AD6770-0x0000000181AD6C20
		protected virtual void WritePrimitiveElement(XmlTypeMapping typeMap, object ob, string element, string namesp); // 0x0000000181AD9430-0x0000000181AD9480
		protected virtual void WriteEnumElement(XmlTypeMapping typeMap, object ob, string element, string namesp); // 0x0000000181AD76F0-0x0000000181AD77D0
		private string GetStringValue(XmlTypeMapping typeMap, TypeData type, object value); // 0x0000000181AD5BB0-0x0000000181AD5E80
		private string GetEnumXmlValue(XmlTypeMapping typeMap, object ob); // 0x0000000181AD5920-0x0000000181AD59D0
	}
}
