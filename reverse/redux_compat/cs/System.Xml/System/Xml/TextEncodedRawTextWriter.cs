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
	internal class TextEncodedRawTextWriter : XmlEncodedRawTextWriter // TypeDefIndex: 6733
	{
		// Properties
		internal override bool SupportsNamespaceDeclarationInChunks { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		public TextEncodedRawTextWriter(TextWriter writer, XmlWriterSettings settings); // 0x0000000181A36810-0x0000000181A36820
		public TextEncodedRawTextWriter(Stream stream, XmlWriterSettings settings); // 0x0000000181A36820-0x0000000181A36830
	
		// Methods
		internal override void WriteXmlDeclaration(XmlStandalone standalone); // 0x00000001802E76C0-0x00000001802E76D0
		internal override void WriteXmlDeclaration(string xmldecl); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x00000001802E76C0-0x00000001802E76D0
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x00000001802E76C0-0x00000001802E76D0
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x00000001802E76C0-0x00000001802E76D0
		internal override void StartElementContent(); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A36800-0x0000000181A36810
		public override void WriteEndAttribute(); // 0x0000000181A36780-0x0000000181A36790
		internal override void WriteNamespaceDeclaration(string prefix, string ns); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteCData(string text); // 0x0000000181A36680-0x0000000181A366F0
		public override void WriteComment(string text); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteProcessingInstruction(string name, string text); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteEntityRef(string name); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteCharEntity(char ch); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteWhitespace(string ws); // 0x0000000181A36790-0x0000000181A36800
		public override void WriteString(string textBlock); // 0x0000000181A36790-0x0000000181A36800
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A366F0-0x0000000181A36780
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A366F0-0x0000000181A36780
		public override void WriteRaw(string data); // 0x0000000181A36790-0x0000000181A36800
	}
}
