/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	public class XmlSerializer // TypeDefIndex: 6975
	{
		// Fields
		private static int generationThreshold; // 0x00
		private static bool backgroundGeneration; // 0x04
		private static bool deleteTempFiles; // 0x05
		private static bool generatorFallback; // 0x06
		private bool customSerializer; // 0x10
		private XmlMapping typeMapping; // 0x18
		private SerializerData serializerData; // 0x20
		private static Hashtable serializerTypes; // 0x08
		private UnreferencedObjectEventHandler onUnreferencedObject; // 0x28
		private XmlAttributeEventHandler onUnknownAttribute; // 0x30
		private XmlElementEventHandler onUnknownElement; // 0x38
		private XmlNodeEventHandler onUnknownNode; // 0x40
	
		// Properties
		internal XmlMapping Mapping { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		internal class SerializerData // TypeDefIndex: 6976
		{
			// Fields
			public MethodInfo ReaderMethod; // 0x10
			public Type WriterType; // 0x18
			public MethodInfo WriterMethod; // 0x20
			public XmlSerializerImplementation Implementation; // 0x28
	
			// Methods
			public XmlSerializationWriter CreateWriter(); // 0x0000000181AD2FB0-0x0000000181AD3090
		}
	
		// Constructors
		static XmlSerializer(); // 0x0000000181ADAF10-0x0000000181ADB010
		public XmlSerializer(Type type, XmlAttributeOverrides overrides, Type[] extraTypes, XmlRootAttribute root, string defaultNamespace); // 0x0000000181ADB010-0x0000000181ADB190
	
		// Methods
		internal virtual void OnUnknownAttribute(XmlAttributeEventArgs e); // 0x0000000181ADA900-0x0000000181ADA930
		internal virtual void OnUnknownElement(XmlElementEventArgs e); // 0x0000000181ADA930-0x0000000181ADA960
		internal virtual void OnUnknownNode(XmlNodeEventArgs e); // 0x0000000181ADA960-0x0000000181ADA990
		internal virtual void OnUnreferencedObject(UnreferencedObjectEventArgs e); // 0x0000000181ADA990-0x0000000181ADA9C0
		protected virtual XmlSerializationReader CreateReader(); // 0x0000000181ADA150-0x0000000181ADA190
		protected virtual XmlSerializationWriter CreateWriter(); // 0x0000000181ADA460-0x0000000181ADA4A0
		public object Deserialize(TextReader textReader); // 0x0000000181ADA560-0x0000000181ADA690
		public object Deserialize(XmlReader xmlReader); // 0x0000000181ADA4A0-0x0000000181ADA560
		protected virtual object Deserialize(XmlSerializationReader reader); // 0x0000000181ADA690-0x0000000181ADA900
		protected virtual void Serialize(object o, XmlSerializationWriter writer); // 0x0000000181ADAA60-0x0000000181ADAC50
		public void Serialize(TextWriter textWriter, object o); // 0x0000000181ADA9C0-0x0000000181ADAA60
		public void Serialize(XmlWriter xmlWriter, object o); // 0x0000000181ADAEF0-0x0000000181ADAF10
		public void Serialize(XmlWriter xmlWriter, object o, XmlSerializerNamespaces namespaces); // 0x0000000181ADAC50-0x0000000181ADAEF0
		private XmlSerializationWriter CreateWriter(XmlMapping typeMapping); // 0x0000000181ADA190-0x0000000181ADA460
		private XmlSerializationReader CreateReader(XmlMapping typeMapping); // 0x0000000181ADA0F0-0x0000000181ADA150
	}
}
