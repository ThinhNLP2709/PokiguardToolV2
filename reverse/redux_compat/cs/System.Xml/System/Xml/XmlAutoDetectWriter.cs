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
	internal class XmlAutoDetectWriter : XmlRawWriter // TypeDefIndex: 6744
	{
		// Fields
		private XmlRawWriter wrapped; // 0x28
		private OnRemoveWriter onRemove; // 0x30
		private XmlWriterSettings writerSettings; // 0x38
		private XmlEventCache eventCache; // 0x40
		private TextWriter textWriter; // 0x48
		private Stream strm; // 0x50
	
		// Properties
		internal override IXmlNamespaceResolver NamespaceResolver { set; } // 0x0000000181A3A140-0x0000000181A3A1A0
		internal override bool SupportsNamespaceDeclarationInChunks { get; } // 0x0000000181A35DE0-0x0000000181A35E10 
	
		// Constructors
		private XmlAutoDetectWriter(XmlWriterSettings writerSettings); // 0x0000000181A3A060-0x0000000181A3A140
		public XmlAutoDetectWriter(TextWriter textWriter, XmlWriterSettings writerSettings); // 0x0000000181A3A020-0x0000000181A3A060
		public XmlAutoDetectWriter(Stream strm, XmlWriterSettings writerSettings); // 0x0000000181A39FE0-0x0000000181A3A020
	
		// Methods
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A39860-0x0000000181A398E0
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A39BD0-0x0000000181A39D30
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A39B50-0x0000000181A39BD0
		public override void WriteEndAttribute(); // 0x0000000181A398E0-0x0000000181A39910
		public override void WriteCData(string text); // 0x0000000181A396F0-0x0000000181A39780
		public override void WriteComment(string text); // 0x0000000181A39820-0x0000000181A39860
		public override void WriteProcessingInstruction(string name, string text); // 0x0000000181A39A40-0x0000000181A39A80
		public override void WriteWhitespace(string ws); // 0x0000000181A39EF0-0x0000000181A39F30
		public override void WriteString(string text); // 0x0000000181A39D90-0x0000000181A39E20
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A397E0-0x0000000181A39820
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A39A80-0x0000000181A39AC0
		public override void WriteRaw(string data); // 0x0000000181A39AC0-0x0000000181A39B50
		public override void WriteEntityRef(string name); // 0x0000000181A39940-0x0000000181A399A0
		public override void WriteCharEntity(char ch); // 0x0000000181A39780-0x0000000181A397E0
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A39E20-0x0000000181A39E90
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x0000000181A395F0-0x0000000181A39670
		public override void WriteBinHex(byte[] buffer, int index, int count); // 0x0000000181A39670-0x0000000181A396F0
		public override void Close(); // 0x0000000181A39220-0x0000000181A39270
		public override void Flush(); // 0x0000000181A39450-0x0000000181A394A0
		public override void WriteValue(string value); // 0x0000000181A39E90-0x0000000181A39EF0
		internal override void WriteXmlDeclaration(XmlStandalone standalone); // 0x0000000181A39F30-0x0000000181A39F80
		internal override void WriteXmlDeclaration(string xmldecl); // 0x0000000181A39F80-0x0000000181A39FE0
		internal override void StartElementContent(); // 0x0000000181A35210-0x0000000181A35240
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181A39910-0x0000000181A39940
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181A399A0-0x0000000181A399D0
		internal override void WriteNamespaceDeclaration(string prefix, string ns); // 0x0000000181A399D0-0x0000000181A39A40
		internal override void WriteStartNamespaceDeclaration(string prefix); // 0x0000000181A39D30-0x0000000181A39D90
		internal override void WriteEndNamespaceDeclaration(); // 0x0000000181A35490-0x0000000181A354C0
		private static bool IsHtmlTag(string tagName); // 0x0000000181A394A0-0x0000000181A39580
		private void EnsureWrappedWriter(XmlOutputMethod outMethod); // 0x0000000181A39440-0x0000000181A39450
		private bool TextBlockCreatesWriter(string textBlock); // 0x0000000181A39580-0x0000000181A395F0
		private void CreateWrappedWriter(XmlOutputMethod outMethod); // 0x0000000181A39270-0x0000000181A39440
	}
}
