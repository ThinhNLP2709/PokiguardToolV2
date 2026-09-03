/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	[DefaultMember("Item")]
	internal class XmlAsyncCheckReader : XmlReader // TypeDefIndex: 6738
	{
		// Fields
		private readonly XmlReader coreReader; // 0x10
		private Task lastTask; // 0x18
	
		// Properties
		internal XmlReader CoreReader { get; } // 0x0000000180377550-0x0000000180377560 
		public override XmlReaderSettings Settings { get; } // 0x0000000181A38520-0x0000000181A38620 
		public override XmlNodeType NodeType { get; } // 0x0000000181A383E0-0x0000000181A38420 
		public override string Name { get; } // 0x0000000181A38320-0x0000000181A38360 
		public override string LocalName { get; } // 0x0000000181A382A0-0x0000000181A382E0 
		public override string NamespaceURI { get; } // 0x0000000181A383A0-0x0000000181A383E0 
		public override string Prefix { get; } // 0x0000000181A38420-0x0000000181A38460 
		public override string Value { get; } // 0x0000000181A38660-0x0000000181A386A0 
		public override int Depth { get; } // 0x0000000181A38120-0x0000000181A38160 
		public override string BaseURI { get; } // 0x0000000181A38060-0x0000000181A380A0 
		public override bool IsEmptyElement { get; } // 0x0000000181A38260-0x0000000181A382A0 
		public override bool IsDefault { get; } // 0x0000000181A38220-0x0000000181A38260 
		public override char QuoteChar { get; } // 0x0000000181A38460-0x0000000181A384A0 
		public override XmlSpace XmlSpace { get; } // 0x0000000181A386E0-0x0000000181A38720 
		public override string XmlLang { get; } // 0x0000000181A386A0-0x0000000181A386E0 
		public override IXmlSchemaInfo SchemaInfo { get; } // 0x0000000181A384E0-0x0000000181A38520 
		public override Type ValueType { get; } // 0x0000000181A38620-0x0000000181A38660 
		public override int AttributeCount { get; } // 0x0000000181A38020-0x0000000181A38060 
		public override bool EOF { get; } // 0x0000000181A381A0-0x0000000181A381E0 
		public override ReadState ReadState { get; } // 0x0000000181A384A0-0x0000000181A384E0 
		public override XmlNameTable NameTable { get; } // 0x0000000181A382E0-0x0000000181A38320 
		public override bool CanResolveEntity { get; } // 0x0000000181A380E0-0x0000000181A38120 
		public override bool CanReadValueChunk { get; } // 0x0000000181A380A0-0x0000000181A380E0 
		public override bool HasAttributes { get; } // 0x0000000181A381E0-0x0000000181A38220 
		internal override XmlNamespaceManager NamespaceManager { get; } // 0x0000000181A38360-0x0000000181A383A0 
		internal override IDtdInfo DtdInfo { get; } // 0x0000000181A38160-0x0000000181A381A0 
	
		// Constructors
		public XmlAsyncCheckReader(XmlReader reader); // 0x0000000181A37F70-0x0000000181A38020
	
		// Methods
		public static XmlAsyncCheckReader CreateAsyncCheckWrapper(XmlReader reader); // 0x0000000181A37680-0x0000000181A37930
		private void CheckAsync(); // 0x0000000181A375B0-0x0000000181A37640
		public override string GetAttribute(string name); // 0x0000000181A379C0-0x0000000181A37A10
		public override string GetAttribute(string name, string namespaceURI); // 0x0000000181A37A10-0x0000000181A37A70
		public override string GetAttribute(int i); // 0x0000000181A37970-0x0000000181A379C0
		public override bool MoveToAttribute(string name); // 0x0000000181A37B70-0x0000000181A37BC0
		public override void MoveToAttribute(int i); // 0x0000000181A37B20-0x0000000181A37B70
		public override bool MoveToFirstAttribute(); // 0x0000000181A37C40-0x0000000181A37C80
		public override bool MoveToNextAttribute(); // 0x0000000181A37C80-0x0000000181A37CC0
		public override bool MoveToElement(); // 0x0000000181A37C00-0x0000000181A37C40
		public override bool ReadAttributeValue(); // 0x0000000181A37CC0-0x0000000181A37D00
		public override bool Read(); // 0x0000000181A37EB0-0x0000000181A37EF0
		public override void Close(); // 0x0000000181A37640-0x0000000181A37680
		public override void Skip(); // 0x0000000181A37F30-0x0000000181A37F70
		public override string LookupNamespace(string prefix); // 0x0000000181A37AD0-0x0000000181A37B20
		public override void ResolveEntity(); // 0x0000000181A37EF0-0x0000000181A37F30
		public override int ReadValueChunk(char[] buffer, int index, int count); // 0x0000000181A37E40-0x0000000181A37EB0
		public override string ReadString(); // 0x0000000181A37E00-0x0000000181A37E40
		public override XmlNodeType MoveToContent(); // 0x0000000181A37BC0-0x0000000181A37C00
		public override void ReadStartElement(); // 0x0000000181A37DC0-0x0000000181A37E00
		public override string ReadElementString(); // 0x0000000181A37D00-0x0000000181A37D40
		public override void ReadEndElement(); // 0x0000000181A37D40-0x0000000181A37D80
		public override bool IsStartElement(string localname, string ns); // 0x0000000181A37A70-0x0000000181A37AD0
		public override string ReadInnerXml(); // 0x0000000181A37D80-0x0000000181A37DC0
		protected override void Dispose(bool disposing); // 0x0000000181A37930-0x0000000181A37970
	}
}
