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
	internal class HtmlUtf8RawTextWriter : XmlUtf8RawTextWriter // TypeDefIndex: 6707
	{
		// Fields
		protected ByteStack elementScope; // 0x90
		protected ElementProperties currentElementProperties; // 0x98
		private AttributeProperties currentAttributeProperties; // 0x9C
		private bool endsWithAmpersand; // 0xA0
		private byte[] uriEscapingBuffer; // 0xA8
		private string mediaType; // 0xB0
		private bool doNotEscapeUriAttributes; // 0xB8
		protected static TernaryTreeReadOnly elementPropertySearch; // 0x00
		protected static TernaryTreeReadOnly attributePropertySearch; // 0x08
	
		// Constructors
		public HtmlUtf8RawTextWriter(Stream stream, XmlWriterSettings settings); // 0x0000000181946840-0x0000000181946A80
	
		// Methods
		internal override void WriteXmlDeclaration(XmlStandalone standalone); // 0x00000001802E76C0-0x00000001802E76D0
		internal override void WriteXmlDeclaration(string xmldecl); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x00000001819456E0-0x00000001819458D0
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181946250-0x0000000181946360
		internal override void StartElementContent(); // 0x00000001819454D0-0x0000000181945630
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181945940-0x0000000181945A50
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181945AB0-0x0000000181945BC0
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x00000001819460F0-0x0000000181946250
		public override void WriteEndAttribute(); // 0x00000001819458D0-0x0000000181945940
		public override void WriteProcessingInstruction(string target, string text); // 0x0000000181945FF0-0x00000001819460F0
		public override void WriteString(string text); // 0x0000000181946360-0x0000000181946440
		public override void WriteEntityRef(string name); // 0x0000000181945A50-0x0000000181945AB0
		public override void WriteCharEntity(char ch); // 0x0000000181945630-0x0000000181945690
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181946440-0x00000001819464A0
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181945690-0x00000001819456E0
		private void Init(XmlWriterSettings settings); // 0x00000001819451F0-0x0000000181945430
		protected void WriteMetaElement(); // 0x0000000181945EE0-0x0000000181945FF0
		protected unsafe void WriteHtmlElementTextBlock(char* pSrc, char* pSrcEnd); // 0x0000000181945EC0-0x0000000181945EE0
		protected unsafe void WriteHtmlAttributeTextBlock(char* pSrc, char* pSrcEnd); // 0x0000000181945BC0-0x0000000181945C10
		private unsafe void WriteHtmlAttributeText(char* pSrc, char* pSrcEnd); // 0x0000000181945C10-0x0000000181945EC0
		private unsafe void WriteUriAttributeText(char* pSrc, char* pSrcEnd); // 0x00000001819464A0-0x0000000181946840
		private void OutputRestAmps(); // 0x0000000181945430-0x00000001819454D0
	}
}
