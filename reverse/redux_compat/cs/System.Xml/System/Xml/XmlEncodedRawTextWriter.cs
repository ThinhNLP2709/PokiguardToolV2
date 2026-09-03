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
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlEncodedRawTextWriter : XmlRawWriter // TypeDefIndex: 6745
	{
		// Fields
		private readonly bool useAsync; // 0x28
		protected byte[] bufBytes; // 0x30
		protected Stream stream; // 0x38
		protected Encoding encoding; // 0x40
		protected XmlCharType xmlCharType; // 0x48
		protected int bufPos; // 0x50
		protected int textPos; // 0x54
		protected int contentPos; // 0x58
		protected int cdataPos; // 0x5C
		protected int attrEndPos; // 0x60
		protected int bufLen; // 0x64
		protected bool writeToNull; // 0x68
		protected bool hadDoubleBracket; // 0x69
		protected bool inAttributeValue; // 0x6A
		protected int bufBytesUsed; // 0x6C
		protected char[] bufChars; // 0x70
		protected Encoder encoder; // 0x78
		protected TextWriter writer; // 0x80
		protected bool trackTextContent; // 0x88
		protected bool inTextContent; // 0x89
		private int lastMarkPos; // 0x8C
		private int[] textContentMarks; // 0x90
		private CharEntityEncoderFallback charEntityFallback; // 0x98
		protected NewLineHandling newLineHandling; // 0xA0
		protected bool closeOutput; // 0xA4
		protected bool omitXmlDeclaration; // 0xA5
		protected string newLineChars; // 0xA8
		protected bool checkCharacters; // 0xB0
		protected XmlStandalone standalone; // 0xB4
		protected XmlOutputMethod outputMethod; // 0xB8
		protected bool autoXmlDeclaration; // 0xBC
		protected bool mergeCDataSections; // 0xBD
	
		// Properties
		internal override bool SupportsNamespaceDeclarationInChunks { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		protected XmlEncodedRawTextWriter(XmlWriterSettings settings); // 0x0000000181A3ED30-0x0000000181A3EE40
		public XmlEncodedRawTextWriter(TextWriter writer, XmlWriterSettings settings); // 0x0000000181A3F1C0-0x0000000181A3F2C0
		public XmlEncodedRawTextWriter(Stream stream, XmlWriterSettings settings); // 0x0000000181A3EE40-0x0000000181A3F1C0
	
		// Methods
		internal override void WriteXmlDeclaration(XmlStandalone standalone); // 0x0000000181A3EA70-0x0000000181A3ECC0
		internal override void WriteXmlDeclaration(string xmldecl); // 0x0000000181A3ECC0-0x0000000181A3ED30
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A3D440-0x0000000181A3D710
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A3E590-0x0000000181A3E680
		internal override void StartElementContent(); // 0x0000000181A3BFB0-0x0000000181A3BFF0
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181A3DAC0-0x0000000181A3DC40
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181A3DD80-0x0000000181A3DEB0
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A3E450-0x0000000181A3E590
		public override void WriteEndAttribute(); // 0x0000000181A3DA60-0x0000000181A3DAC0
		internal override void WriteNamespaceDeclaration(string prefix, string namespaceName); // 0x0000000181A3DEB0-0x0000000181A3DF10
		internal override void WriteStartNamespaceDeclaration(string prefix); // 0x0000000181A3E680-0x0000000181A3E800
		internal override void WriteEndNamespaceDeclaration(); // 0x0000000181A3DC40-0x0000000181A3DCA0
		public override void WriteCData(string text); // 0x0000000181A3CAC0-0x0000000181A3CD00
		public override void WriteComment(string text); // 0x0000000181A3D2E0-0x0000000181A3D440
		public override void WriteProcessingInstruction(string name, string text); // 0x0000000181A3DFA0-0x0000000181A3E0F0
		public override void WriteEntityRef(string name); // 0x0000000181A3DCA0-0x0000000181A3DD80
		public override void WriteCharEntity(char ch); // 0x0000000181A3CD00-0x0000000181A3CEF0
		public override void WriteWhitespace(string ws); // 0x0000000181A3E9F0-0x0000000181A3EA70
		public override void WriteString(string text); // 0x0000000181A3E800-0x0000000181A3E880
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A3E880-0x0000000181A3E9F0
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181943CA0-0x0000000181943D30
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A3E3C0-0x0000000181A3E450
		public override void WriteRaw(string data); // 0x0000000181A36680-0x0000000181A366F0
		public override void Close(); // 0x0000000181A3B100-0x0000000181A3B180
		public override void Flush(); // 0x0000000181A3BA80-0x0000000181A3BB10
		protected virtual void FlushBuffer(); // 0x0000000181A3B5B0-0x0000000181A3B9A0
		private void EncodeChars(int startOffset, int endOffset, bool writeAllToStream); // 0x0000000181A3B280-0x0000000181A3B400
		private void FlushEncoder(); // 0x0000000181A3B9A0-0x0000000181A3BA80
		protected unsafe void WriteAttributeTextBlock(char* pSrc, char* pSrcEnd); // 0x0000000181A3C3B0-0x0000000181A3C6D0
		protected unsafe void WriteElementTextBlock(char* pSrc, char* pSrcEnd); // 0x0000000181A3D710-0x0000000181A3DA60
		protected void RawText(string s); // 0x0000000181A3BF60-0x0000000181A3BFB0
		protected unsafe void RawText(char* pSrcBegin, char* pSrcEnd); // 0x0000000181A3BDA0-0x0000000181A3BF60
		protected unsafe void WriteRawWithCharChecking(char* pSrcBegin, char* pSrcEnd); // 0x0000000181A3E0F0-0x0000000181A3E3C0
		protected void WriteCommentOrPi(string text, int stopChar); // 0x0000000181A3CEF0-0x0000000181A3D2E0
		protected void WriteCDataSection(string text); // 0x0000000181A3C6D0-0x0000000181A3CAC0
		private static unsafe char* EncodeSurrogate(char* pSrc, char* pSrcEnd, char* pDst); // 0x0000000181A3B400-0x0000000181A3B5B0
		private unsafe char* InvalidXmlChar(int ch, char* pDst, bool entitize); // 0x0000000181A3BBD0-0x0000000181A3BCF0
		internal unsafe void EncodeChar(ref char* pSrc, char* pSrcEnd, ref char* pDst); // 0x0000000181A3B180-0x0000000181A3B280
		protected void ChangeTextContentMark(bool value); // 0x0000000181A3AF60-0x0000000181A3B050
		private void GrowTextContentMarks(); // 0x0000000181A3BB10-0x0000000181A3BBB0
		protected unsafe char* WriteNewLine(char* pDst); // 0x0000000181A3DF10-0x0000000181A3DFA0
		protected static unsafe char* LtEntity(char* pDst); // 0x0000000181A3BD10-0x0000000181A3BD30
		protected static unsafe char* GtEntity(char* pDst); // 0x0000000181A3BBB0-0x0000000181A3BBD0
		protected static unsafe char* AmpEntity(char* pDst); // 0x0000000181A3AF20-0x0000000181A3AF40
		protected static unsafe char* QuoteEntity(char* pDst); // 0x0000000181A3BD30-0x0000000181A3BD50
		protected static unsafe char* TabEntity(char* pDst); // 0x0000000181A3BFF0-0x0000000181A3C010
		protected static unsafe char* LineFeedEntity(char* pDst); // 0x0000000181A3BCF0-0x0000000181A3BD10
		protected static unsafe char* CarriageReturnEntity(char* pDst); // 0x0000000181A3AF40-0x0000000181A3AF60
		private static unsafe char* CharEntity(char* pDst, char ch); // 0x0000000181A3B050-0x0000000181A3B100
		protected static unsafe char* RawStartCData(char* pDst); // 0x0000000181A3BD70-0x0000000181A3BDA0
		protected static unsafe char* RawEndCData(char* pDst); // 0x0000000181A3BD50-0x0000000181A3BD70
		protected void ValidateContentChars(string chars, string propertyName, bool allowOnlyWhitespace); // 0x0000000181A3C010-0x0000000181A3C3B0
	}
}
