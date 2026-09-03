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
	internal class XmlEncodedRawTextWriterIndent : XmlEncodedRawTextWriter // TypeDefIndex: 6746
	{
		// Fields
		protected int indentLevel; // 0xC0
		protected bool newLineOnAttributes; // 0xC4
		protected string indentChars; // 0xC8
		protected bool mixedContent; // 0xD0
		private BitStack mixedContentStack; // 0xD8
		protected ConformanceLevel conformanceLevel; // 0xE0
	
		// Constructors
		public XmlEncodedRawTextWriterIndent(TextWriter writer, XmlWriterSettings settings); // 0x0000000181A3AEC0-0x0000000181A3AEF0
		public XmlEncodedRawTextWriterIndent(Stream stream, XmlWriterSettings settings); // 0x0000000181A3AEF0-0x0000000181A3AF20
	
		// Methods
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A3A5F0-0x0000000181A3A660
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A3AC80-0x0000000181A3ADB0
		internal override void StartElementContent(); // 0x0000000181A3A3C0-0x0000000181A3A430
		internal override void OnRootElement(ConformanceLevel currentConformanceLevel); // 0x0000000181A3A3B0-0x0000000181A3A3C0
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181A3A660-0x0000000181A3A6F0
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181A3A7D0-0x0000000181A3A940
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A3AB30-0x0000000181A3AC80
		public override void WriteCData(string text); // 0x0000000181A3A4F0-0x0000000181A3A500
		public override void WriteComment(string text); // 0x0000000181A3A5B0-0x0000000181A3A5F0
		public override void WriteProcessingInstruction(string target, string text); // 0x0000000181A3A9E0-0x0000000181A3AA30
		public override void WriteEntityRef(string name); // 0x0000000181A3A6F0-0x0000000181A3A7D0
		public override void WriteCharEntity(char ch); // 0x0000000181A3A500-0x0000000181A3A510
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A3AE30-0x0000000181A3AE40
		public override void WriteWhitespace(string ws); // 0x0000000181A3AE40-0x0000000181A3AEC0
		public override void WriteString(string text); // 0x0000000181A3ADB0-0x0000000181A3AE30
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A3A510-0x0000000181A3A5B0
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A3AA30-0x0000000181A3AAC0
		public override void WriteRaw(string data); // 0x0000000181A3AAC0-0x0000000181A3AB30
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x0000000181A3A430-0x0000000181A3A4F0
		private void Init(XmlWriterSettings settings); // 0x0000000181A3A280-0x0000000181A3A3B0
		private void WriteIndent(); // 0x0000000181A3A940-0x0000000181A3A9E0
	}
}
