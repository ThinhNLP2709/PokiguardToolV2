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
	[MonoTODO]
	public abstract class XmlSerializationReader : XmlSerializationGeneratedCode // TypeDefIndex: 6962
	{
		// Fields
		private XmlDocument document; // 0x10
		private XmlReader reader; // 0x18
		private ArrayList fixups; // 0x20
		private Hashtable collFixups; // 0x28
		private ArrayList collItemFixups; // 0x30
		private Hashtable typesCallbacks; // 0x38
		private ArrayList noIDTargets; // 0x40
		private Hashtable targets; // 0x48
		private Hashtable delayedListFixups; // 0x50
		private XmlSerializer eventSource; // 0x58
		private int delayedFixupId; // 0x60
		private Hashtable referencedObjects; // 0x68
		private int readCount; // 0x70
		private int whileIterationCount; // 0x74
		private string w3SchemaNS; // 0x78
		private string w3InstanceNS; // 0x80
		private string w3InstanceNS2000; // 0x88
		private string w3InstanceNS1999; // 0x90
		private string soapNS; // 0x98
		private string wsdlNS; // 0xA0
		private string nullX; // 0xA8
		private string nil; // 0xB0
		private string typeX; // 0xB8
		private string arrayType; // 0xC0
		private XmlQualifiedName arrayQName; // 0xC8
	
		// Properties
		protected XmlDocument Document { get; } // 0x0000000181ABF530-0x0000000181ABF5D0 
		protected XmlReader Reader { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		private class WriteCallbackInfo // TypeDefIndex: 6963
		{
			// Fields
			public Type Type; // 0x10
			public string TypeName; // 0x18
			public string TypeNs; // 0x20
			public XmlSerializationReadCallback Callback; // 0x28
	
			// Constructors
			public WriteCallbackInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		protected class CollectionFixup // TypeDefIndex: 6964
		{
			// Fields
			private XmlSerializationCollectionFixupCallback callback; // 0x10
			private object collection; // 0x18
			private object collectionItems; // 0x20
			private string id; // 0x28
	
			// Properties
			public XmlSerializationCollectionFixupCallback Callback { get; } // 0x0000000180377550-0x0000000180377560 
			public object Collection { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			internal object Id { get; } // 0x000000018033D240-0x000000018033D250 
			public object CollectionItems { get; internal set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
			// Constructors
			internal CollectionFixup(object collection, XmlSerializationCollectionFixupCallback callback, string id); // 0x0000000181AA78C0-0x0000000181AA7930
		}
	
		protected class Fixup // TypeDefIndex: 6965
		{
			// Fields
			private object source; // 0x10
			private string[] ids; // 0x18
			private XmlSerializationFixupCallback callback; // 0x20
	
			// Properties
			public XmlSerializationFixupCallback Callback { get; } // 0x00000001802F8630-0x00000001802F8640 
			public string[] Ids { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public object Source { get; } // 0x0000000180377550-0x0000000180377560 
	
			// Constructors
			public Fixup(object o, XmlSerializationFixupCallback callback, int count); // 0x0000000181AA7970-0x0000000181AA7A10
		}
	
		private class CollectionItemFixup // TypeDefIndex: 6966
		{
			// Fields
			private Array list; // 0x10
			private int index; // 0x18
			private string id; // 0x20
	
			// Properties
			public Array Collection { get; } // 0x0000000180377550-0x0000000180377560 
			public int Index { get; } // 0x0000000180B23260-0x0000000180B23270 
			public string Id { get; } // 0x00000001802F8630-0x00000001802F8640 
	
			// Constructors
			public CollectionItemFixup(Array list, int index, string id); // 0x0000000181696D70-0x0000000181696DD0
		}
	
		// Constructors
		protected XmlSerializationReader(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void Initialize(XmlReader reader, XmlSerializer eventSource); // 0x0000000181ABB470-0x0000000181ABB900
		private ArrayList EnsureArrayList(ArrayList list); // 0x0000000181ABAEF0-0x0000000181ABAF40
		private Hashtable EnsureHashtable(Hashtable hash); // 0x0000000181ABAF40-0x0000000181ABAF90
		protected void AddFixup(CollectionFixup fixup); // 0x0000000181ABA470-0x0000000181ABA590
		protected void AddFixup(Fixup fixup); // 0x0000000181ABA630-0x0000000181ABA6D0
		private void AddFixup(CollectionItemFixup fixup); // 0x0000000181ABA590-0x0000000181ABA630
		protected void AddReadCallback(string name, string ns, Type type, XmlSerializationReadCallback read); // 0x0000000181ABA6D0-0x0000000181ABA840
		protected void AddTarget(string id, object o); // 0x0000000181ABA840-0x0000000181ABA9A0
		private string CurrentTag(); // 0x0000000181ABACA0-0x0000000181ABAE60
		protected Exception CreateReadOnlyCollectionException(string name); // 0x0000000181ABA9A0-0x0000000181ABAA20
		protected Exception CreateUnknownConstantException(string value, Type enumType); // 0x0000000181ABAA20-0x0000000181ABAAA0
		protected Exception CreateUnknownNodeException(); // 0x0000000181ABAAA0-0x0000000181ABAB20
		protected Exception CreateUnknownTypeException(XmlQualifiedName type); // 0x0000000181ABAB20-0x0000000181ABACA0
		protected Array EnsureArrayIndex(Array a, int index, Type elementType); // 0x0000000181ABAE60-0x0000000181ABAEF0
		protected bool GetNullAttr(); // 0x0000000181ABB090-0x0000000181ABB170
		protected object GetTarget(string id); // 0x0000000181ABB170-0x0000000181ABB250
		private bool TargetReady(string id); // 0x0000000181ABEE30-0x0000000181ABEE60
		protected XmlQualifiedName GetXsiType(); // 0x0000000181ABB250-0x0000000181ABB470
		protected abstract void InitCallbacks();
		protected abstract void InitIDs();
		protected bool IsXmlnsAttribute(string name); // 0x0000000181ABB900-0x0000000181ABB980
		protected void ParseWsdlArrayType(XmlAttribute attr); // 0x0000000181ABBF60-0x0000000181ABC110
		protected XmlQualifiedName ReadElementQualifiedName(); // 0x0000000181ABC110-0x0000000181ABC210
		protected void ReadEndElement(); // 0x0000000181ABC210-0x0000000181ABC2E0
		protected bool ReadNull(); // 0x0000000181ABC7E0-0x0000000181ABC9D0
		protected XmlQualifiedName ReadNullableQualifiedName(); // 0x0000000181ABC9D0-0x0000000181ABCA00
		protected string ReadNullableString(); // 0x0000000181ABCA00-0x0000000181ABCA50
		protected object ReadReferencedElement(); // 0x0000000181ABCD50-0x0000000181ABCDC0
		private WriteCallbackInfo GetCallbackInfo(XmlQualifiedName qname); // 0x0000000181ABAF90-0x0000000181ABB090
		protected object ReadReferencedElement(string name, string ns); // 0x0000000181ABCA50-0x0000000181ABCD50
		private bool ReadList(out object resultList); // 0x0000000181ABC2E0-0x0000000181ABC7E0
		protected void ReadReferencedElements(); // 0x0000000181ABCDC0-0x0000000181ABDCA0
		protected object ReadReferencingElement(out string fixupReference); // 0x0000000181ABDCC0-0x0000000181ABDD50
		protected object ReadReferencingElement(string name, string ns, out string fixupReference); // 0x0000000181ABDCA0-0x0000000181ABDCC0
		protected object ReadReferencingElement(string name, string ns, bool elementCanBeType, out string fixupReference); // 0x0000000181ABDD50-0x0000000181ABE0E0
		protected IXmlSerializable ReadSerializable(IXmlSerializable serializable); // 0x0000000181ABE0E0-0x0000000181ABE2D0
		protected object ReadTypedPrimitive(XmlQualifiedName type); // 0x0000000181ABEBD0-0x0000000181ABEBE0
		private object ReadTypedPrimitive(XmlQualifiedName qname, bool reportUnknown); // 0x0000000181ABE2D0-0x0000000181ABEBD0
		protected XmlNode ReadXmlNode(bool wrapped); // 0x0000000181ABED20-0x0000000181ABED90
		protected XmlDocument ReadXmlDocument(bool wrapped); // 0x0000000181ABEBE0-0x0000000181ABED20
		protected Array ShrinkArray(Array a, int length, Type elementType, bool isNullable); // 0x0000000181ABED90-0x0000000181ABEE30
		protected XmlQualifiedName ToXmlQualifiedName(string value); // 0x0000000181ABEE60-0x0000000181ABF0B0
		protected void UnknownAttribute(object o, XmlAttribute attr, string qnames); // 0x0000000181ABF0B0-0x0000000181ABF260
		protected void UnknownElement(object o, XmlElement elem, string qnames); // 0x0000000181ABF260-0x0000000181ABF410
		protected void UnknownNode(object o); // 0x0000000181AB5340-0x0000000181AB53B0
		protected void UnknownNode(object o, string qnames); // 0x0000000181ABF410-0x0000000181ABF490
		private void OnUnknownNode(XmlNode node, object o, string qnames); // 0x0000000181ABB980-0x0000000181ABBF60
		protected void UnreferencedObject(string id, object o); // 0x0000000181ABF490-0x0000000181ABF530
	}
}
