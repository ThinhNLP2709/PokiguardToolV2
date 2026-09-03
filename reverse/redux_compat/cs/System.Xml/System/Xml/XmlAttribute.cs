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
	public class XmlAttribute : XmlNode // TypeDefIndex: 6812
	{
		// Fields
		private XmlName name; // 0x18
		private XmlLinkedNode lastChild; // 0x20
	
		// Properties
		internal int LocalNameHash { get; } // 0x0000000181A5CD50-0x0000000181A5CD70 
		internal XmlName XmlName { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public override XmlNode ParentNode { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override string Name { get; } // 0x0000000181A5CD70-0x0000000181A5CD90 
		public override string LocalName { get; } // 0x0000000181777F00-0x0000000181777F20 
		public override string NamespaceURI { get; } // 0x0000000180E6D010-0x0000000180E6D030 
		public override string Prefix { get; set; } // 0x0000000181777F30-0x0000000181777F50 0x0000000181A5D030-0x0000000181A5D100
		public override XmlNodeType NodeType { get; } // 0x0000000180476390-0x00000001804763A0 
		public override XmlDocument OwnerDocument { get; } // 0x0000000181778090-0x00000001817780B0 
		public override string Value { get; set; } // 0x0000000181A5CE10-0x0000000181A5CE30 0x0000000181A5D100-0x0000000181A5D120
		public override IXmlSchemaInfo SchemaInfo { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override string InnerText { set; } // 0x0000000181A5CF20-0x0000000181A5CF90
		internal override bool IsContainer { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal override XmlLinkedNode LastNode { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public virtual bool Specified { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public virtual XmlElement OwnerElement { get; } // 0x0000000181A5CD90-0x0000000181A5CE10 
		public override string InnerXml { set; } // 0x0000000181A5CF90-0x0000000181A5D030
		public override string BaseURI { get; } // 0x0000000181A5CCD0-0x0000000181A5CD50 
		internal override XmlSpace XmlSpace { get; } // 0x0000000181A5CEB0-0x0000000181A5CF20 
		internal override string XmlLang { get; } // 0x0000000181A5CE30-0x0000000181A5CEB0 
	
		// Constructors
		internal XmlAttribute(XmlName name, XmlDocument doc); // 0x0000000181A5CBB0-0x0000000181A5CCD0
		protected internal XmlAttribute(string prefix, string localName, string namespaceURI, XmlDocument doc); // 0x0000000181A5CB60-0x0000000181A5CBB0
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A5C3F0-0x0000000181A5C4E0
		internal bool PrepareOwnerElementInElementIdAttrMap(); // 0x0000000181A5C630-0x0000000181A5C7D0
		internal void ResetOwnerElementInElementIdAttrMap(string oldInnerText); // 0x0000000181A5C8D0-0x0000000181A5CA00
		internal override XmlNode AppendChildForLoad(XmlNode newChild, XmlDocument doc); // 0x0000000181A5C1A0-0x0000000181A5C370
		internal override bool IsValidChildType(XmlNodeType type); // 0x0000000181A5C620-0x0000000181A5C630
		public override XmlNode InsertBefore(XmlNode newChild, XmlNode refChild); // 0x0000000181A5C580-0x0000000181A5C620
		public override XmlNode InsertAfter(XmlNode newChild, XmlNode refChild); // 0x0000000181A5C4E0-0x0000000181A5C580
		public override XmlNode RemoveChild(XmlNode oldChild); // 0x0000000181A5C850-0x0000000181A5C8D0
		public override XmlNode PrependChild(XmlNode newChild); // 0x0000000181A5C7D0-0x0000000181A5C850
		public override XmlNode AppendChild(XmlNode newChild); // 0x0000000181A5C370-0x0000000181A5C3F0
		public override void WriteTo(XmlWriter w); // 0x0000000181A5CA80-0x0000000181A5CB60
		public override void WriteContentTo(XmlWriter w); // 0x0000000181A5CA00-0x0000000181A5CA80
		internal override void SetParent(XmlNode node); // 0x00000001803780D0-0x00000001803780E0
	}
}
