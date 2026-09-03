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
	internal class XmlUtf8RawTextWriter : XmlRawWriter // TypeDefIndex: 6780
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
		protected NewLineHandling newLineHandling; // 0x6C
		protected bool closeOutput; // 0x70
		protected bool omitXmlDeclaration; // 0x71
		protected string newLineChars; // 0x78
		protected bool checkCharacters; // 0x80
		protected XmlStandalone standalone; // 0x84
		protected XmlOutputMethod outputMethod; // 0x88
		protected bool autoXmlDeclaration; // 0x8C
		protected bool mergeCDataSections; // 0x8D
	
		// Properties
		internal override bool SupportsNamespaceDeclarationInChunks { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		protected XmlUtf8RawTextWriter(XmlWriterSettings settings); // 0x0000000181A50D30-0x0000000181A50E30
		public XmlUtf8RawTextWriter(Stream stream, XmlWriterSettings settings); // 0x0000000181A50AE0-0x0000000181A50D30
	
		// Methods
		internal override void WriteXmlDeclaration(XmlStandalone standalone); // 0x0000000181A50850-0x0000000181A50A70
		internal override void WriteXmlDeclaration(string xmldecl); // 0x0000000181A50A70-0x0000000181A50AE0
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A4F550-0x0000000181A4F800
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A504A0-0x0000000181A50570
		internal override void StartElementContent(); // 0x0000000181A4E270-0x0000000181A4E2B0
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181A4FB40-0x0000000181A4FCA0
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181A4FD90-0x0000000181A4FEA0
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A50390-0x0000000181A504A0
		public override void WriteEndAttribute(); // 0x0000000181A4FB00-0x0000000181A4FB40
		internal override void WriteNamespaceDeclaration(string prefix, string namespaceName); // 0x0000000181A3DEB0-0x0000000181A3DF10
		internal override void WriteStartNamespaceDeclaration(string prefix); // 0x0000000181A50570-0x0000000181A506A0
		internal override void WriteEndNamespaceDeclaration(); // 0x0000000181A4FCA0-0x0000000181A4FCE0
		public override void WriteCData(string text); // 0x0000000181A4ED20-0x0000000181A4EF10
		public override void WriteComment(string text); // 0x0000000181A4F430-0x0000000181A4F550
		public override void WriteProcessingInstruction(string name, string text); // 0x0000000181A4FF20-0x0000000181A50050
		public override void WriteEntityRef(string name); // 0x0000000181A4FCE0-0x0000000181A4FD90
		public override void WriteCharEntity(char ch); // 0x0000000181A4EF10-0x0000000181A4F0D0
		public override void WriteWhitespace(string ws); // 0x0000000181A506A0-0x0000000181A50700
		public override void WriteString(string text); // 0x0000000181A506A0-0x0000000181A50700
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A50700-0x0000000181A50850
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181945690-0x00000001819456E0
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A502F0-0x0000000181A50340
		public override void WriteRaw(string data); // 0x0000000181A50340-0x0000000181A50390
		public override void Close(); // 0x0000000181A4D8F0-0x0000000181A4D970
		public override void Flush(); // 0x0000000181A4DE10-0x0000000181A4DE60
		protected virtual void FlushBuffer(); // 0x0000000181A4DC70-0x0000000181A4DE10
		private void FlushEncoder(); // 0x00000001802E76C0-0x00000001802E76D0
		protected unsafe void WriteAttributeTextBlock(char* pSrc, char* pSrcEnd); // 0x0000000181A4E660-0x0000000181A4E930
		protected unsafe void WriteElementTextBlock(char* pSrc, char* pSrcEnd); // 0x0000000181A4F800-0x0000000181A4FB00
		protected void RawText(string s); // 0x0000000181A4E080-0x0000000181A4E0D0
		protected unsafe void RawText(char* pSrcBegin, char* pSrcEnd); // 0x0000000181A4E0D0-0x0000000181A4E270
		protected unsafe void WriteRawWithCharChecking(char* pSrcBegin, char* pSrcEnd); // 0x0000000181A50050-0x0000000181A502F0
		protected void WriteCommentOrPi(string text, int stopChar); // 0x0000000181A4F0D0-0x0000000181A4F430
		protected void WriteCDataSection(string text); // 0x0000000181A4E930-0x0000000181A4ED20
		private static bool IsSurrogateByte(byte b); // 0x0000000181A4E000-0x0000000181A4E010
		private static unsafe byte* EncodeSurrogate(char* pSrc, char* pSrcEnd, byte* pDst); // 0x0000000181A4DAA0-0x0000000181A4DC70
		private unsafe byte* InvalidXmlChar(int ch, byte* pDst, bool entitize); // 0x0000000181A4DE70-0x0000000181A4E000
		internal unsafe void EncodeChar(ref char* pSrc, char* pSrcEnd, ref byte* pDst); // 0x0000000181A4D970-0x0000000181A4DA50
		internal static unsafe byte* EncodeMultibyteUTF8(int ch, byte* pDst); // 0x0000000181A4DA50-0x0000000181A4DAA0
		internal static unsafe void CharToUTF8(ref char* pSrc, char* pSrcEnd, ref byte* pDst); // 0x0000000181A4D840-0x0000000181A4D8F0
		protected unsafe byte* WriteNewLine(byte* pDst); // 0x0000000181A4FEA0-0x0000000181A4FF20
		protected static unsafe byte* LtEntity(byte* pDst); // 0x0000000181A4E020-0x0000000181A4E030
		protected static unsafe byte* GtEntity(byte* pDst); // 0x0000000181A4DE60-0x0000000181A4DE70
		protected static unsafe byte* AmpEntity(byte* pDst); // 0x0000000181A4D780-0x0000000181A4D790
		protected static unsafe byte* QuoteEntity(byte* pDst); // 0x0000000181A4E030-0x0000000181A4E050
		protected static unsafe byte* TabEntity(byte* pDst); // 0x0000000181A4E2B0-0x0000000181A4E2C0
		protected static unsafe byte* LineFeedEntity(byte* pDst); // 0x0000000181A4E010-0x0000000181A4E020
		protected static unsafe byte* CarriageReturnEntity(byte* pDst); // 0x0000000181A4D790-0x0000000181A4D7A0
		private static unsafe byte* CharEntity(byte* pDst, char ch); // 0x0000000181A4D7A0-0x0000000181A4D840
		protected static unsafe byte* RawStartCData(byte* pDst); // 0x0000000181A4E060-0x0000000181A4E080
		protected static unsafe byte* RawEndCData(byte* pDst); // 0x0000000181A4E050-0x0000000181A4E060
		protected void ValidateContentChars(string chars, string propertyName, bool allowOnlyWhitespace); // 0x0000000181A4E2C0-0x0000000181A4E660
	}
}
