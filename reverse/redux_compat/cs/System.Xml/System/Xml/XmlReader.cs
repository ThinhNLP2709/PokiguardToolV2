/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	[DebuggerDisplay("{debuggerDisplayProxy}")]
	[DebuggerDisplay("{debuggerDisplayProxy}")]
	[DefaultMember("Item")]
	public abstract class XmlReader : IDisposable // TypeDefIndex: 6752
	{
		// Fields
		private static uint IsTextualNodeBitmap; // 0x00
		private static uint CanReadContentAsBitmap; // 0x04
		private static uint HasValueBitmap; // 0x08
	
		// Properties
		public virtual XmlReaderSettings Settings { get; } // 0x00000001802E7860-0x00000001802E7870 
		public abstract XmlNodeType NodeType { get; }
		public virtual string Name { get; } // 0x0000000181A44BA0-0x0000000181A44CB0 
		public abstract string LocalName { get; }
		public abstract string NamespaceURI { get; }
		public abstract string Prefix { get; }
		public abstract string Value { get; }
		public abstract int Depth { get; }
		public abstract string BaseURI { get; }
		public abstract bool IsEmptyElement { get; }
		public virtual bool IsDefault { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual char QuoteChar { get; } // 0x0000000181A44CB0-0x0000000181A44CC0 
		public virtual XmlSpace XmlSpace { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual string XmlLang { get; } // 0x00000001815B1550-0x00000001815B1570 
		public virtual IXmlSchemaInfo SchemaInfo { get; } // 0x0000000181A44CC0-0x0000000181A44D00 
		public virtual Type ValueType { get; } // 0x0000000181A44D00-0x0000000181A44D40 
		public abstract int AttributeCount { get; }
		public abstract bool EOF { get; }
		public abstract ReadState ReadState { get; }
		public abstract XmlNameTable NameTable { get; }
		public virtual bool CanResolveEntity { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool CanReadValueChunk { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool HasAttributes { get; } // 0x0000000181A44AE0-0x0000000181A44B10 
		internal virtual XmlNamespaceManager NamespaceManager { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal bool IsDefaultInternal { get; } // 0x0000000181A44B10-0x0000000181A44BA0 
		internal virtual IDtdInfo DtdInfo { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		protected XmlReader(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static XmlReader(); // 0x0000000181A44A70-0x0000000181A44AE0
	
		// Methods
		public abstract string GetAttribute(string name);
		public abstract string GetAttribute(string name, string namespaceURI);
		public abstract string GetAttribute(int i);
		public abstract bool MoveToAttribute(string name);
		public virtual void MoveToAttribute(int i); // 0x0000000181A433C0-0x0000000181A43490
		public abstract bool MoveToFirstAttribute();
		public abstract bool MoveToNextAttribute();
		public abstract bool MoveToElement();
		public abstract bool ReadAttributeValue();
		public abstract bool Read();
		public virtual void Close(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void Skip(); // 0x0000000181A442F0-0x0000000181A44400
		public abstract string LookupNamespace(string prefix);
		public abstract void ResolveEntity();
		public virtual int ReadValueChunk(char[] buffer, int index, int count); // 0x0000000181A440B0-0x0000000181A44110
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual string ReadString(); // 0x0000000181A43E50-0x0000000181A440B0
		public virtual XmlNodeType MoveToContent(); // 0x0000000181A43490-0x0000000181A43530
		public virtual void ReadStartElement(); // 0x0000000181A43D50-0x0000000181A43E50
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual string ReadElementString(); // 0x0000000181A43530-0x0000000181A437D0
		public virtual void ReadEndElement(); // 0x0000000181A437D0-0x0000000181A438D0
		public virtual bool IsStartElement(string localname, string ns); // 0x0000000181A432B0-0x0000000181A43350
		public virtual string ReadInnerXml(); // 0x0000000181A438D0-0x0000000181A43D50
		private void WriteNode(XmlWriter xtw, bool defattr); // 0x0000000181A44520-0x0000000181A44A70
		private void WriteAttributeValue(XmlWriter xtw); // 0x0000000181A44400-0x0000000181A44520
		private XmlWriter CreateWriterForInnerOuterXml(StringWriter sw); // 0x0000000181A42DA0-0x0000000181A42EC0
		private void SetNamespacesFlag(XmlTextWriter xtw); // 0x0000000181A44110-0x0000000181A44200
		public void Dispose(); // 0x0000000181A431E0-0x0000000181A43200
		protected virtual void Dispose(bool disposing); // 0x0000000181A43200-0x0000000181A43240
		internal static bool IsTextualNode(XmlNodeType nodeType); // 0x0000000181A43350-0x0000000181A433C0
		internal static bool HasValueInternal(XmlNodeType nodeType); // 0x0000000181A43240-0x0000000181A432B0
		private bool SkipSubtree(); // 0x0000000181A44200-0x0000000181A442F0
		public static XmlReader Create(Stream input, XmlReaderSettings settings, string baseUri); // 0x0000000181A42EC0-0x0000000181A43080
		public static XmlReader Create(TextReader input, XmlReaderSettings settings, string baseUri); // 0x0000000181A43080-0x0000000181A431E0
		internal static XmlReader CreateSqlReader(Stream input, XmlReaderSettings settings, XmlParserContext inputContext); // 0x0000000181A42A10-0x0000000181A42DA0
		internal static int CalcBufferSize(Stream input); // 0x0000000181A42960-0x0000000181A42A10
	}
}
