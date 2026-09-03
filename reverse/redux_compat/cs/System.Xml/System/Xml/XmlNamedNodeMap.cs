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
	public class XmlNamedNodeMap : IEnumerable // TypeDefIndex: 6832
	{
		// Fields
		internal XmlNode parent; // 0x10
		internal SmallXmlNodeList nodes; // 0x18
	
		// Properties
		public virtual int Count { get; } // 0x0000000181A821D0-0x0000000181A82260 
	
		// Nested types
		internal struct SmallXmlNodeList // TypeDefIndex: 6833
		{
			// Fields
			private object field; // 0x00
	
			// Properties
			public int Count { get; } // 0x0000000181A808F0-0x0000000181A80980 
			public object this[int index] { get => default; } // 0x0000000181A80980-0x0000000181A80AB0 
	
			// Nested types
			private class SingleObjectEnumerator : IEnumerator // TypeDefIndex: 6834
			{
				// Fields
				private object loneValue; // 0x10
				private int position; // 0x18
	
				// Properties
				public object Current { get; } // 0x0000000181A80300-0x0000000181A80360 
	
				// Constructors
				public SingleObjectEnumerator(object value); // 0x0000000181A802C0-0x0000000181A80300
	
				// Methods
				public bool MoveNext(); // 0x0000000181A802A0-0x0000000181A802C0
				public void Reset(); // 0x00000001810FCE00-0x00000001810FCE10
			}
	
			// Methods
			public void Add(object value); // 0x0000000181A80360-0x0000000181A804B0
			public void RemoveAt(int index); // 0x0000000181A807C0-0x0000000181A808F0
			public void Insert(int index, object value); // 0x0000000181A805C0-0x0000000181A807C0
			public IEnumerator GetEnumerator(); // 0x0000000181A804B0-0x0000000181A805C0
		}
	
		// Constructors
		internal XmlNamedNodeMap(XmlNode parent); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public virtual XmlNode GetNamedItem(string name); // 0x0000000181A819B0-0x0000000181A81B30
		public virtual XmlNode SetNamedItem(XmlNode node); // 0x0000000181A81FE0-0x0000000181A821D0
		public virtual IEnumerator GetEnumerator(); // 0x0000000181A818A0-0x0000000181A819B0
		internal int FindNodeOffset(string name); // 0x0000000181A81660-0x0000000181A81760
		internal int FindNodeOffset(string localName, string namespaceURI); // 0x0000000181A81760-0x0000000181A818A0
		internal virtual XmlNode AddNode(XmlNode node); // 0x0000000181A814C0-0x0000000181A81660
		internal virtual XmlNode AddNodeForLoad(XmlNode node, XmlDocument doc); // 0x0000000181A813F0-0x0000000181A814C0
		internal virtual XmlNode RemoveNodeAt(int i); // 0x0000000181A81CE0-0x0000000181A81F70
		internal XmlNode ReplaceNodeAt(int i, XmlNode node); // 0x0000000181A81F70-0x0000000181A81FE0
		internal virtual XmlNode InsertNodeAt(int i, XmlNode node); // 0x0000000181A81B30-0x0000000181A81CE0
	}
}
