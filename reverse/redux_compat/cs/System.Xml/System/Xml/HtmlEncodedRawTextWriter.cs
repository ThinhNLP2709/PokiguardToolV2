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
	internal class HtmlEncodedRawTextWriter : XmlEncodedRawTextWriter // TypeDefIndex: 6704
	{
		// Fields
		protected ByteStack elementScope; // 0xC0
		protected ElementProperties currentElementProperties; // 0xC8
		private AttributeProperties currentAttributeProperties; // 0xCC
		private bool endsWithAmpersand; // 0xD0
		private byte[] uriEscapingBuffer; // 0xD8
		private string mediaType; // 0xE0
		private bool doNotEscapeUriAttributes; // 0xE8
		protected static TernaryTreeReadOnly elementPropertySearch; // 0x00
		protected static TernaryTreeReadOnly attributePropertySearch; // 0x08
	
		// Constructors
		public HtmlEncodedRawTextWriter(TextWriter writer, XmlWriterSettings settings); // 0x0000000181944FC0-0x0000000181944FF0
		public HtmlEncodedRawTextWriter(Stream stream, XmlWriterSettings settings); // 0x0000000181944FF0-0x0000000181945020
	
		// Methods
		internal override void WriteXmlDeclaration(XmlStandalone standalone); // 0x00000001802E76C0-0x00000001802E76D0
		internal override void WriteXmlDeclaration(string xmldecl); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181943D30-0x0000000181943F50
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x00000001819449A0-0x0000000181944AD0
		internal override void StartElementContent(); // 0x0000000181943BE0-0x0000000181943C40
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181943FE0-0x0000000181944110
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181944170-0x00000001819442A0
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181944820-0x00000001819449A0
		public override void WriteEndAttribute(); // 0x0000000181943F50-0x0000000181943FE0
		public override void WriteProcessingInstruction(string target, string text); // 0x00000001819446F0-0x0000000181944820
		public override void WriteString(string text); // 0x0000000181944AD0-0x0000000181944BC0
		public override void WriteEntityRef(string name); // 0x0000000181944110-0x0000000181944170
		public override void WriteCharEntity(char ch); // 0x0000000181943C40-0x0000000181943CA0
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181944BC0-0x0000000181944C20
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181943CA0-0x0000000181943D30
		private void Init(XmlWriterSettings settings); // 0x0000000181943900-0x0000000181943B40
		protected void WriteMetaElement(); // 0x00000001819445E0-0x00000001819446F0
		protected unsafe void WriteHtmlElementTextBlock(char* pSrc, char* pSrcEnd); // 0x00000001819445C0-0x00000001819445E0
		protected unsafe void WriteHtmlAttributeTextBlock(char* pSrc, char* pSrcEnd); // 0x00000001819442A0-0x00000001819442F0
		private unsafe void WriteHtmlAttributeText(char* pSrc, char* pSrcEnd); // 0x00000001819442F0-0x00000001819445C0
		private unsafe void WriteUriAttributeText(char* pSrc, char* pSrcEnd); // 0x0000000181944C20-0x0000000181944FC0
		private void OutputRestAmps(); // 0x0000000181943B40-0x0000000181943BE0
	}
}
