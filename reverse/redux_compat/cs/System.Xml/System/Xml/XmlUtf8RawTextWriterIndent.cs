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
	internal class XmlUtf8RawTextWriterIndent : XmlUtf8RawTextWriter // TypeDefIndex: 6781
	{
		// Fields
		protected int indentLevel; // 0x90
		protected bool newLineOnAttributes; // 0x94
		protected string indentChars; // 0x98
		protected bool mixedContent; // 0xA0
		private BitStack mixedContentStack; // 0xA8
		protected ConformanceLevel conformanceLevel; // 0xB0
	
		// Constructors
		public XmlUtf8RawTextWriterIndent(Stream stream, XmlWriterSettings settings); // 0x0000000181A4D650-0x0000000181A4D780
	
		// Methods
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A4CCC0-0x0000000181A4CD30
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A4D380-0x0000000181A4D490
		internal override void StartElementContent(); // 0x0000000181A4CB80-0x0000000181A4CBF0
		internal override void OnRootElement(ConformanceLevel currentConformanceLevel); // 0x0000000181727410-0x0000000181727420
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181A4CD30-0x0000000181A4CDC0
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181A4CE80-0x0000000181A4CFD0
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A4D260-0x0000000181A4D380
		public override void WriteCData(string text); // 0x0000000181A4CC10-0x0000000181A4CC20
		public override void WriteComment(string text); // 0x0000000181A4CC80-0x0000000181A4CCC0
		public override void WriteProcessingInstruction(string target, string text); // 0x0000000181A4D070-0x0000000181A4D1B0
		public override void WriteEntityRef(string name); // 0x0000000181A4CDC0-0x0000000181A4CE80
		public override void WriteCharEntity(char ch); // 0x0000000181A4CC20-0x0000000181A4CC30
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A4D500-0x0000000181A4D650
		public override void WriteWhitespace(string ws); // 0x0000000181A4D490-0x0000000181A4D500
		public override void WriteString(string text); // 0x0000000181A4D490-0x0000000181A4D500
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A4CC30-0x0000000181A4CC80
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A4D210-0x0000000181A4D260
		public override void WriteRaw(string data); // 0x0000000181A4D1B0-0x0000000181A4D210
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x0000000181A4CBF0-0x0000000181A4CC10
		private void Init(XmlWriterSettings settings); // 0x0000000181A4CA60-0x0000000181A4CB80
		private void WriteIndent(); // 0x0000000181A4CFD0-0x0000000181A4D070
	}
}
