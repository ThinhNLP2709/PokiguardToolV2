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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public sealed class XmlAttributeCollection : XmlNamedNodeMap, ICollection // TypeDefIndex: 6813
	{
		// Properties
		public XmlAttribute this[int i] { get => default; } // 0x0000000181A5BF80-0x0000000181A5C070 
		public XmlAttribute this[string name] { get => default; } // 0x0000000181A5C070-0x0000000181A5C1A0 
		public XmlAttribute this[string localName, string namespaceURI] { get => default; } // 0x0000000181A5BE30-0x0000000181A5BF80 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		object ICollection.SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		int ICollection.Count { get; } // 0x0000000181A5BE20-0x0000000181A5BE30 
	
		// Constructors
		internal XmlAttributeCollection(XmlNode parent); // 0x0000000180E027D0-0x0000000180E027E0
	
		// Methods
		internal int FindNodeOffsetNS(XmlAttribute node); // 0x0000000181A5AED0-0x0000000181A5B070
		public override XmlNode SetNamedItem(XmlNode node); // 0x0000000181A5BBF0-0x0000000181A5BD90
		public XmlAttribute Append(XmlAttribute node); // 0x0000000181A5AC00-0x0000000181A5ADF0
		public XmlAttribute Remove(XmlAttribute node); // 0x0000000181A5BA70-0x0000000181A5BB10
		public XmlAttribute RemoveAt(int i); // 0x0000000181A5B550-0x0000000181A5B600
		public void RemoveAll(); // 0x0000000181A5B470-0x0000000181A5B550
		void ICollection.CopyTo(Array array, int index); // 0x0000000181A5BD90-0x0000000181A5BE20
		internal override XmlNode AddNode(XmlNode node); // 0x0000000181A5AA10-0x0000000181A5AC00
		internal override XmlNode InsertNodeAt(int i, XmlNode node); // 0x0000000181A5B070-0x0000000181A5B110
		internal override XmlNode RemoveNodeAt(int i); // 0x0000000181A5B700-0x0000000181A5B8E0
		internal void Detach(XmlAttribute attr); // 0x0000000181A5ADF0-0x0000000181A5AED0
		internal void InsertParentIntoElementIdAttrMap(XmlAttribute attr); // 0x0000000181A5B110-0x0000000181A5B2A0
		internal void RemoveParentFromElementIdAttrMap(XmlAttribute attr); // 0x0000000181A5B8E0-0x0000000181A5BA70
		internal int RemoveDuplicateAttribute(XmlAttribute attr); // 0x0000000181A5B600-0x0000000181A5B700
		internal bool PrepareParentInElementIdAttrMap(string attrPrefix, string attrLocalName); // 0x0000000181A5B360-0x0000000181A5B470
		internal void ResetParentInElementIdAttrMap(string oldVal, string newVal); // 0x0000000181A5BB10-0x0000000181A5BBF0
		internal XmlAttribute InternalAppendAttribute(XmlAttribute node); // 0x0000000181A5B2A0-0x0000000181A5B360
	}
}
