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

namespace System.Xml
{
	public class XmlElement : XmlLinkedNode // TypeDefIndex: 6823
	{
		// Fields
		private XmlName name; // 0x20
		private XmlAttributeCollection attributes; // 0x28
		private XmlLinkedNode lastChild; // 0x30
	
		// Properties
		internal XmlName XmlName { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public override string Name { get; } // 0x0000000181A65570-0x0000000181A65590 
		public override string LocalName { get; } // 0x0000000181A65550-0x0000000181A65570 
		public override string NamespaceURI { get; } // 0x0000000181A65590-0x0000000181A655B0 
		public override string Prefix { get; set; } // 0x0000000181A65610-0x0000000181A65630 0x0000000181A65970-0x0000000181A65A50
		public override XmlNodeType NodeType { get; } // 0x0000000180472790-0x00000001804727A0 
		public override XmlNode ParentNode { get; } // 0x0000000180377550-0x0000000180377560 
		public override XmlDocument OwnerDocument { get; } // 0x0000000181A655F0-0x0000000181A65610 
		internal override bool IsContainer { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool IsEmpty { get; set; } // 0x0000000181A65530-0x0000000181A65540 0x0000000181A65910-0x0000000181A65970
		internal override XmlLinkedNode LastNode { get; set; } // 0x0000000181A65540-0x0000000181A65550 0x0000000180378110-0x0000000180378120
		public override XmlAttributeCollection Attributes { get; } // 0x0000000181A653A0-0x0000000181A654E0 
		public virtual bool HasAttributes { get; } // 0x0000000181A654E0-0x0000000181A65520 
		public override IXmlSchemaInfo SchemaInfo { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override string InnerXml { set; } // 0x0000000181A65720-0x0000000181A65910
		public override string InnerText { get; set; } // 0x0000000181A65520-0x0000000181A65530 0x0000000181A65630-0x0000000181A65720
		public override XmlNode NextSibling { get; } // 0x0000000181A655B0-0x0000000181A655F0 
	
		// Constructors
		internal XmlElement(XmlName name, bool empty, XmlDocument doc); // 0x0000000181A65240-0x0000000181A653A0
		protected internal XmlElement(string prefix, string localName, string namespaceURI, XmlDocument doc); // 0x0000000181A651D0-0x0000000181A65240
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A63CD0-0x0000000181A641D0
		internal override XmlNode AppendChildForLoad(XmlNode newChild, XmlDocument doc); // 0x0000000181A63AF0-0x0000000181A63CD0
		internal override bool IsValidChildType(XmlNodeType type); // 0x0000000181A645B0-0x0000000181A64610
		public virtual string GetAttribute(string name); // 0x0000000181A644E0-0x0000000181A64530
		public virtual void SetAttribute(string name, string value); // 0x0000000181A64960-0x0000000181A64B40
		public virtual XmlAttribute GetAttributeNode(string name); // 0x0000000181A641D0-0x0000000181A64340
		public virtual XmlAttribute SetAttributeNode(XmlAttribute newAttr); // 0x0000000181A64830-0x0000000181A64960
		public virtual string GetAttribute(string localName, string namespaceURI); // 0x0000000181A64530-0x0000000181A64580
		public virtual string SetAttribute(string localName, string namespaceURI, string value); // 0x0000000181A64B40-0x0000000181A64C60
		public virtual XmlAttribute GetAttributeNode(string localName, string namespaceURI); // 0x0000000181A64340-0x0000000181A644E0
		public virtual XmlAttribute SetAttributeNode(string localName, string namespaceURI); // 0x0000000181A64760-0x0000000181A64830
		public virtual bool HasAttribute(string name); // 0x0000000181A64580-0x0000000181A645B0
		public override void WriteTo(XmlWriter w); // 0x0000000181A64F50-0x0000000181A651D0
		private static void WriteElementTo(XmlWriter writer, XmlElement e); // 0x0000000181A64C60-0x0000000181A64E10
		private void WriteStartElement(XmlWriter w); // 0x0000000181A64E10-0x0000000181A64F50
		public override void WriteContentTo(XmlWriter w); // 0x0000000181A5CA00-0x0000000181A5CA80
		public virtual void RemoveAllAttributes(); // 0x0000000181A64610-0x0000000181A64720
		public override void RemoveAll(); // 0x0000000181A64730-0x0000000181A64760
		internal void RemoveAllChildren(); // 0x0000000181A64720-0x0000000181A64730
		internal override void SetParent(XmlNode node); // 0x00000001803780D0-0x00000001803780E0
	}
}
