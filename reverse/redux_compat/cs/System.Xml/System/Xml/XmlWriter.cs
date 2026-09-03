/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public abstract class XmlWriter : IDisposable // TypeDefIndex: 6800
	{
		// Fields
		private char[] writeNodeBuffer; // 0x10
	
		// Properties
		public abstract WriteState WriteState { get; }
	
		// Constructors
		protected XmlWriter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract void WriteStartDocument();
		public abstract void WriteStartDocument(bool standalone);
		public abstract void WriteEndDocument();
		public abstract void WriteDocType(string name, string pubid, string sysid, string subset);
		public void WriteStartElement(string localName, string ns); // 0x0000000181A6D0F0-0x0000000181A6D120
		public abstract void WriteStartElement(string prefix, string localName, string ns);
		public abstract void WriteEndElement();
		public abstract void WriteFullEndElement();
		public void WriteAttributeString(string localName, string ns, string value); // 0x0000000181A6C660-0x0000000181A6C6D0
		public void WriteAttributeString(string localName, string value); // 0x0000000181A6C6D0-0x0000000181A6C740
		public void WriteAttributeString(string prefix, string localName, string ns, string value); // 0x0000000181A6C740-0x0000000181A6C7A0
		public abstract void WriteStartAttribute(string prefix, string localName, string ns);
		public abstract void WriteEndAttribute();
		public abstract void WriteCData(string text);
		public abstract void WriteComment(string text);
		public abstract void WriteProcessingInstruction(string name, string text);
		public abstract void WriteEntityRef(string name);
		public abstract void WriteCharEntity(char ch);
		public abstract void WriteWhitespace(string ws);
		public abstract void WriteString(string text);
		public abstract void WriteSurrogateCharEntity(char lowChar, char highChar);
		public abstract void WriteChars(char[] buffer, int index, int count);
		public abstract void WriteRaw(char[] buffer, int index, int count);
		public abstract void WriteRaw(string data);
		public abstract void WriteBase64(byte[] buffer, int index, int count);
		public virtual void WriteBinHex(byte[] buffer, int index, int count); // 0x0000000181A6CAB0-0x0000000181A6CAE0
		public virtual void Close(); // 0x00000001802E76C0-0x00000001802E76D0
		public abstract void Flush();
		public abstract string LookupPrefix(string ns);
		public virtual void WriteValue(string value); // 0x0000000181A6D120-0x0000000181A6D140
		public virtual void WriteAttributes(XmlReader reader, bool defattr); // 0x0000000181A6C7A0-0x0000000181A6CAB0
		public virtual void WriteNode(XmlReader reader, bool defattr); // 0x0000000181A6CB60-0x0000000181A6D0F0
		public void WriteElementString(string localName, string ns, string value); // 0x0000000181A6CAE0-0x0000000181A6CB60
		public void Dispose(); // 0x0000000181A6C640-0x0000000181A6C660
		protected virtual void Dispose(bool disposing); // 0x0000000181A6C600-0x0000000181A6C640
		public static XmlWriter Create(Stream output, XmlWriterSettings settings); // 0x0000000181A6C520-0x0000000181A6C590
		public static XmlWriter Create(TextWriter output, XmlWriterSettings settings); // 0x0000000181A6C590-0x0000000181A6C600
	}
}
