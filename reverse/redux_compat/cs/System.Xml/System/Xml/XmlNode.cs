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
using System.Text;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	[DebuggerDisplay("{debuggerDisplayProxy}")]
	[DefaultMember("Item")]
	public abstract class XmlNode : ICloneable, IEnumerable // TypeDefIndex: 6835
	{
		// Fields
		internal XmlNode parentNode; // 0x10
	
		// Properties
		public abstract string Name { get; }
		public virtual string Value { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x0000000181A8ACB0-0x0000000181A8ADA0
		public abstract XmlNodeType NodeType { get; }
		public virtual XmlNode ParentNode { get; } // 0x0000000181A8A770-0x0000000181A8A870 
		public virtual XmlNodeList ChildNodes { get; } // 0x0000000181A8A350-0x0000000181A8A3B0 
		public virtual XmlNode PreviousSibling { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual XmlNode NextSibling { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual XmlAttributeCollection Attributes { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual XmlDocument OwnerDocument { get; } // 0x0000000181A8A6B0-0x0000000181A8A770 
		public virtual XmlNode FirstChild { get; } // 0x0000000181A8A450-0x0000000181A8A480 
		public virtual XmlNode LastChild { get; } // 0x0000000181A8A690-0x0000000181A8A6B0 
		internal virtual bool IsContainer { get; } // 0x00000001802E7840-0x00000001802E7850 
		internal virtual XmlLinkedNode LastNode { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x00000001802E76C0-0x00000001802E76D0
		public virtual bool HasChildNodes { get; } // 0x0000000181A8A480-0x0000000181A8A4B0 
		public virtual string NamespaceURI { get; } // 0x00000001815B1550-0x00000001815B1570 
		public virtual string Prefix { get; set; } // 0x00000001815B1550-0x00000001815B1570 0x00000001802E76C0-0x00000001802E76D0
		public abstract string LocalName { get; }
		public virtual bool IsReadOnly { get; } // 0x0000000181A8A5B0-0x0000000181A8A690 
		public virtual string InnerText { get; set; } // 0x0000000181A8A4B0-0x0000000181A8A5B0 0x0000000181A8AB40-0x0000000181A8AC50
		public virtual string InnerXml { set; } // 0x0000000181A8AC50-0x0000000181A8ACB0
		public virtual IXmlSchemaInfo SchemaInfo { get; } // 0x0000000181A8A870-0x0000000181A8A8C0 
		public virtual string BaseURI { get; } // 0x0000000181A8A240-0x0000000181A8A350 
		internal XmlDocument Document { get; } // 0x0000000181A8A3B0-0x0000000181A8A450 
		internal virtual XmlSpace XmlSpace { get; } // 0x0000000181A8A9B0-0x0000000181A8AB40 
		internal virtual string XmlLang { get; } // 0x0000000181A8A8C0-0x0000000181A8A9B0 
		internal virtual bool IsText { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		internal XmlNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
		internal XmlNode(XmlDocument doc); // 0x0000000181A8A1B0-0x0000000181A8A240
	
		// Methods
		internal bool AncestorNode(XmlNode node); // 0x0000000181A877F0-0x0000000181A87870
		public virtual XmlNode InsertBefore(XmlNode newChild, XmlNode refChild); // 0x0000000181A89240-0x0000000181A89A20
		public virtual XmlNode InsertAfter(XmlNode newChild, XmlNode refChild); // 0x0000000181A88A80-0x0000000181A89240
		public virtual XmlNode RemoveChild(XmlNode oldChild); // 0x0000000181A89B20-0x0000000181A89FD0
		public virtual XmlNode PrependChild(XmlNode newChild); // 0x0000000181A89A50-0x0000000181A89AA0
		public virtual XmlNode AppendChild(XmlNode newChild); // 0x0000000181A87BA0-0x0000000181A88200
		internal virtual XmlNode AppendChildForLoad(XmlNode newChild, XmlDocument doc); // 0x0000000181A87870-0x0000000181A87A70
		internal virtual bool IsValidChildType(XmlNodeType type); // 0x00000001802E7840-0x00000001802E7850
		internal virtual bool CanInsertBefore(XmlNode newChild, XmlNode refChild); // 0x00000001802E7990-0x00000001802E79A0
		internal virtual bool CanInsertAfter(XmlNode newChild, XmlNode refChild); // 0x00000001802E7990-0x00000001802E79A0
		public abstract XmlNode CloneNode(bool deep);
		internal virtual void CopyChildren(XmlDocument doc, XmlNode container, bool deep); // 0x0000000181A88250-0x0000000181A88310
		internal static bool HasReadOnlyParent(XmlNode n); // 0x0000000181A889B0-0x0000000181A88A80
		object ICloneable.Clone(); // 0x0000000181A8A140-0x0000000181A8A160
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181A8A0E0-0x0000000181A8A140
		public IEnumerator GetEnumerator(); // 0x0000000181A883A0-0x0000000181A88400
		private void AppendChildText(StringBuilder builder); // 0x0000000181A87A70-0x0000000181A87BA0
		public abstract void WriteTo(XmlWriter w);
		public abstract void WriteContentTo(XmlWriter w);
		public virtual void RemoveAll(); // 0x0000000181A89AA0-0x0000000181A89B20
		public virtual string GetPrefixOfNamespace(string namespaceURI); // 0x0000000181A88980-0x0000000181A889B0
		internal string GetPrefixOfNamespaceStrict(string namespaceURI); // 0x0000000181A88540-0x0000000181A88980
		internal virtual void SetParent(XmlNode node); // 0x0000000181A89FD0-0x0000000181A8A010
		internal virtual void SetParentForLoad(XmlNode node); // 0x00000001803780D0-0x00000001803780E0
		internal static void SplitName(string name, out string prefix, out string localName); // 0x0000000181A8A010-0x0000000181A8A0E0
		internal virtual XmlNode FindChild(XmlNodeType type); // 0x0000000181A88310-0x0000000181A883A0
		internal virtual XmlNodeChangedEventArgs GetEventArgs(XmlNode node, XmlNode oldParent, XmlNode newParent, string oldValue, string newValue, XmlNodeChangedAction action); // 0x0000000181A88400-0x0000000181A88540
		internal virtual void BeforeEvent(XmlNodeChangedEventArgs args); // 0x0000000181A88200-0x0000000181A88250
		internal virtual void AfterEvent(XmlNodeChangedEventArgs args); // 0x0000000181A877A0-0x0000000181A877F0
		internal static void NestTextNodes(XmlNode prevNode, XmlNode nextNode); // 0x0000000181A89A20-0x0000000181A89A50
		internal static void UnnestTextNodes(XmlNode prevNode, XmlNode nextNode); // 0x0000000181A8A160-0x0000000181A8A1B0
	}
}
