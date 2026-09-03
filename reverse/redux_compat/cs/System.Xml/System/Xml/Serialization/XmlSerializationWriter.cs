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
using System.Runtime.Serialization;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	public abstract class XmlSerializationWriter : XmlSerializationGeneratedCode // TypeDefIndex: 6971
	{
		// Fields
		private ObjectIDGenerator idGenerator; // 0x10
		private int qnameCount; // 0x18
		private bool topLevelElement; // 0x1C
		private ArrayList namespaces; // 0x20
		private XmlWriter writer; // 0x28
		private Queue referencedElements; // 0x30
		private Hashtable callbacks; // 0x38
		private Hashtable serializedObjects; // 0x40
	
		// Properties
		protected XmlWriter Writer { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		private class WriteCallbackInfo // TypeDefIndex: 6972
		{
			// Fields
			public Type Type; // 0x10
			public string TypeName; // 0x18
			public string TypeNs; // 0x20
			public XmlSerializationWriteCallback Callback; // 0x28
	
			// Constructors
			public WriteCallbackInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		protected XmlSerializationWriter(); // 0x0000000181AC2B20-0x0000000181AC2B90
	
		// Methods
		internal void Initialize(XmlWriter writer, XmlSerializerNamespaces nss); // 0x0000000181ABFDB0-0x0000000181ABFEF0
		protected void AddWriteCallback(Type type, string typeName, string typeNs, XmlSerializationWriteCallback callback); // 0x0000000181ABF5D0-0x0000000181ABF700
		protected Exception CreateUnknownAnyElementException(string name, string ns); // 0x0000000181ABF7C0-0x0000000181ABF840
		protected Exception CreateUnknownTypeException(object o); // 0x0000000181ABF840-0x0000000181ABF8E0
		protected Exception CreateUnknownTypeException(Type type); // 0x0000000181ABF8E0-0x0000000181ABF960
		protected string FromXmlQualifiedName(XmlQualifiedName xmlQualifiedName); // 0x0000000181ABF960-0x0000000181ABFA10
		private string GetId(object o, bool addToReferencesList); // 0x0000000181ABFA10-0x0000000181ABFB10
		private bool AlreadyQueued(object ob); // 0x0000000181ABF700-0x0000000181ABF740
		private string GetNamespacePrefix(string ns); // 0x0000000181ABFB10-0x0000000181ABFC20
		private string GetQualifiedName(string name, string ns); // 0x0000000181ABFC20-0x0000000181ABFDB0
		protected abstract void InitCallbacks();
		protected void TopLevelElement(); // 0x0000000181ABFFD0-0x0000000181ABFFE0
		protected void WriteAttribute(string localName, string ns, string value); // 0x0000000181AC0300-0x0000000181AC0340
		protected void WriteAttribute(string prefix, string localName, string ns, string value); // 0x0000000181AC02C0-0x0000000181AC0300
		private void WriteXmlNode(XmlNode node); // 0x0000000181AC2970-0x0000000181AC2A40
		protected void WriteElementEncoded(XmlNode node, string name, string ns, bool isNullable, bool any); // 0x0000000181AC0340-0x0000000181AC0420
		protected void WriteElementLiteral(XmlNode node, string name, string ns, bool isNullable, bool any); // 0x0000000181AC0420-0x0000000181AC0500
		protected void WriteElementQualifiedName(string localName, string ns, XmlQualifiedName value); // 0x0000000181AC06E0-0x0000000181AC0700
		protected void WriteElementQualifiedName(string localName, string ns, XmlQualifiedName value, XmlQualifiedName xsiType); // 0x0000000181AC0500-0x0000000181AC06E0
		protected void WriteElementString(string localName, string ns, string value); // 0x0000000181AC0700-0x0000000181AC0720
		protected void WriteElementString(string localName, string ns, string value, XmlQualifiedName xsiType); // 0x0000000181AC0720-0x0000000181AC08C0
		protected void WriteEndElement(); // 0x0000000181AA6650-0x0000000181AA6680
		protected void WriteEndElement(object o); // 0x0000000181AC08C0-0x0000000181AC0920
		protected void WriteNamespaceDeclarations(XmlSerializerNamespaces xmlns); // 0x0000000181AC0920-0x0000000181AC0CC0
		protected void WriteNullableQualifiedNameEncoded(string name, string ns, XmlQualifiedName value, XmlQualifiedName xsiType); // 0x0000000181AC0E70-0x0000000181AC0F20
		protected void WriteNullableQualifiedNameLiteral(string name, string ns, XmlQualifiedName value); // 0x0000000181AC0F20-0x0000000181AC0FC0
		protected void WriteNullableStringEncoded(string name, string ns, string value, XmlQualifiedName xsiType); // 0x0000000181AC0FC0-0x0000000181AC0FE0
		protected void WriteNullableStringLiteral(string name, string ns, string value); // 0x0000000181AC0FE0-0x0000000181AC1010
		protected void WriteNullTagEncoded(string name, string ns); // 0x0000000181AC0CC0-0x0000000181AC0D90
		protected void WriteNullTagLiteral(string name, string ns); // 0x0000000181AC0D90-0x0000000181AC0E70
		protected void WritePotentiallyReferencingElement(string n, string ns, object o, Type ambientType, bool suppressReference, bool isNullable); // 0x0000000181AC1010-0x0000000181AC14B0
		protected void WriteReferencedElements(); // 0x0000000181AC14B0-0x0000000181AC1730
		private bool IsPrimitiveArray(TypeData td); // 0x0000000181ABFEF0-0x0000000181ABFFD0
		private void WriteArray(object o, TypeData td); // 0x0000000181ABFFE0-0x0000000181AC02C0
		protected void WriteReferencingElement(string n, string ns, object o, bool isNullable); // 0x0000000181AC1730-0x0000000181AC18A0
		private void CheckReferenceQueue(); // 0x0000000181ABF740-0x0000000181ABF7C0
		protected void WriteSerializable(IXmlSerializable serializable, string name, string ns, bool isNullable); // 0x0000000181AC19E0-0x0000000181AC1B20
		protected void WriteSerializable(IXmlSerializable serializable, string name, string ns, bool isNullable, bool wrapped); // 0x0000000181AC18A0-0x0000000181AC19E0
		protected void WriteStartDocument(); // 0x0000000181AC1B20-0x0000000181AC1B80
		protected void WriteStartElement(string name, string ns); // 0x0000000181AC1BB0-0x0000000181AC1BE0
		protected void WriteStartElement(string name, string ns, bool writePrefixed); // 0x0000000181AC1B80-0x0000000181AC1BB0
		protected void WriteStartElement(string name, string ns, object o); // 0x0000000181AC2290-0x0000000181AC22C0
		protected void WriteStartElement(string name, string ns, object o, bool writePrefixed); // 0x0000000181AC2260-0x0000000181AC2290
		private void WriteStartElement(string name, string ns, object o, bool writePrefixed, ICollection namespaces); // 0x0000000181AC1BE0-0x0000000181AC2260
		protected void WriteTypedPrimitive(string name, string ns, object o, bool xsiType); // 0x0000000181AC22C0-0x0000000181AC2640
		protected void WriteValue(string value); // 0x0000000181AC2640-0x0000000181AC2680
		protected void WriteXmlAttribute(XmlNode node, object container); // 0x0000000181AC2680-0x0000000181AC2970
		protected void WriteXsiType(string name, string ns); // 0x0000000181AC2A40-0x0000000181AC2B20
	}
}
