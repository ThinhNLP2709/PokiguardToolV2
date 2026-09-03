/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal abstract class XmlRawWriter : XmlWriter // TypeDefIndex: 6751
	{
		// Fields
		protected XmlRawWriterBase64Encoder base64Encoder; // 0x18
		protected IXmlNamespaceResolver resolver; // 0x20
	
		// Properties
		public override WriteState WriteState { get; } // 0x0000000181A41750-0x0000000181A417B0 
		internal virtual IXmlNamespaceResolver NamespaceResolver { set; } // 0x000000018033E830-0x000000018033E840
		internal virtual bool SupportsNamespaceDeclarationInChunks { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		protected XmlRawWriter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void WriteStartDocument(); // 0x0000000181A415A0-0x0000000181A41600
		public override void WriteStartDocument(bool standalone); // 0x0000000181A41600-0x0000000181A41660
		public override void WriteEndDocument(); // 0x0000000181A413C0-0x0000000181A41420
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteEndElement(); // 0x0000000181A41420-0x0000000181A41480
		public override void WriteFullEndElement(); // 0x0000000181A414C0-0x0000000181A41520
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x0000000181A41250-0x0000000181A41310
		public override string LookupPrefix(string ns); // 0x0000000181A41190-0x0000000181A411F0
		public override void WriteCData(string text); // 0x000000018184CE60-0x000000018184CE80
		public override void WriteCharEntity(char ch); // 0x0000000181A41310-0x0000000181A413A0
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A416A0-0x0000000181A41750
		public override void WriteWhitespace(string ws); // 0x000000018184CE60-0x000000018184CE80
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A397E0-0x0000000181A39820
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A397E0-0x0000000181A39820
		public override void WriteRaw(string data); // 0x000000018184CE60-0x000000018184CE80
		public override void WriteValue(string value); // 0x000000018184CE60-0x000000018184CE80
		public override void WriteAttributes(XmlReader reader, bool defattr); // 0x0000000181A411F0-0x0000000181A41250
		public override void WriteNode(XmlReader reader, bool defattr); // 0x0000000181A41540-0x0000000181A415A0
		internal virtual void WriteXmlDeclaration(XmlStandalone standalone); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void WriteXmlDeclaration(string xmldecl); // 0x00000001802E76C0-0x00000001802E76D0
		internal abstract void StartElementContent();
		internal virtual void OnRootElement(ConformanceLevel conformanceLevel); // 0x00000001802E76C0-0x00000001802E76D0
		internal abstract void WriteEndElement(string prefix, string localName, string ns);
		internal virtual void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181A41520-0x0000000181A41540
		internal abstract void WriteNamespaceDeclaration(string prefix, string ns);
		internal virtual void WriteStartNamespaceDeclaration(string prefix); // 0x0000000181A41660-0x0000000181A416A0
		internal virtual void WriteEndNamespaceDeclaration(); // 0x0000000181A41480-0x0000000181A414C0
		internal virtual void WriteEndBase64(); // 0x0000000181A413A0-0x0000000181A413C0
		internal virtual void Close(WriteState currentState); // 0x0000000181A41170-0x0000000181A41190
	}
}
