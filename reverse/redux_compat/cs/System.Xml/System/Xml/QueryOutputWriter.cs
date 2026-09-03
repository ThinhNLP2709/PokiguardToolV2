/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class QueryOutputWriter : XmlRawWriter // TypeDefIndex: 6724
	{
		// Fields
		private XmlRawWriter wrapped; // 0x28
		private bool inCDataSection; // 0x30
		private Dictionary<XmlQualifiedName, int> lookupCDataElems; // 0x38
		private BitStack bitsCData; // 0x40
		private XmlQualifiedName qnameCData; // 0x48
		private bool outputDocType; // 0x50
		private bool checkWellFormedDoc; // 0x51
		private bool hasDocElem; // 0x52
		private bool inAttr; // 0x53
		private string systemId; // 0x58
		private string publicId; // 0x60
		private int depth; // 0x68
	
		// Properties
		internal override IXmlNamespaceResolver NamespaceResolver { set; } // 0x0000000181A35E10-0x0000000181A35E60
		internal override bool SupportsNamespaceDeclarationInChunks { get; } // 0x0000000181A35DE0-0x0000000181A35E10 
	
		// Constructors
		public QueryOutputWriter(XmlRawWriter writer, XmlWriterSettings settings); // 0x0000000181A35B50-0x0000000181A35DE0
	
		// Methods
		internal override void WriteXmlDeclaration(XmlStandalone standalone); // 0x0000000181A35AF0-0x0000000181A35B20
		internal override void WriteXmlDeclaration(string xmldecl); // 0x0000000181A35B20-0x0000000181A35B50
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A353B0-0x0000000181A35400
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A35770-0x0000000181A35950
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181A35430-0x0000000181A35490
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181A354F0-0x0000000181A35550
		internal override void StartElementContent(); // 0x0000000181A35210-0x0000000181A35240
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A35730-0x0000000181A35770
		public override void WriteEndAttribute(); // 0x0000000181A35400-0x0000000181A35430
		internal override void WriteNamespaceDeclaration(string prefix, string ns); // 0x0000000181A35550-0x0000000181A35580
		internal override void WriteStartNamespaceDeclaration(string prefix); // 0x0000000181A35950-0x0000000181A35980
		internal override void WriteEndNamespaceDeclaration(); // 0x0000000181A35490-0x0000000181A354C0
		public override void WriteCData(string text); // 0x0000000181A35240-0x0000000181A35270
		public override void WriteComment(string text); // 0x0000000181A35380-0x0000000181A353B0
		public override void WriteProcessingInstruction(string name, string text); // 0x0000000181A35580-0x0000000181A355B0
		public override void WriteWhitespace(string ws); // 0x0000000181A35A50-0x0000000181A35AF0
		public override void WriteString(string text); // 0x0000000181A35980-0x0000000181A35A20
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A352A0-0x0000000181A35380
		public override void WriteEntityRef(string name); // 0x0000000181A354C0-0x0000000181A354F0
		public override void WriteCharEntity(char ch); // 0x0000000181A35270-0x0000000181A352A0
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A35A20-0x0000000181A35A50
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A355B0-0x0000000181A35690
		public override void WriteRaw(string data); // 0x0000000181A35690-0x0000000181A35730
		public override void Close(); // 0x0000000181A350F0-0x0000000181A351A0
		public override void Flush(); // 0x0000000181A351A0-0x0000000181A351D0
		private bool StartCDataSection(); // 0x0000000181A351D0-0x0000000181A35210
		private void EndCDataSection(); // 0x00000001803ED880-0x00000001803ED890
	}
}
