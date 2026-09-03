/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlAsyncCheckWriter : XmlWriter // TypeDefIndex: 6743
	{
		// Fields
		private readonly XmlWriter coreWriter; // 0x18
		private Task lastTask; // 0x20
	
		// Properties
		public override WriteState WriteState { get; } // 0x0000000181A391E0-0x0000000181A39220 
	
		// Constructors
		public XmlAsyncCheckWriter(XmlWriter writer); // 0x0000000181A39150-0x0000000181A391E0
	
		// Methods
		private void CheckAsync(); // 0x0000000181A38720-0x0000000181A387B0
		public override void WriteStartDocument(); // 0x0000000181A38F50-0x0000000181A38F90
		public override void WriteStartDocument(bool standalone); // 0x0000000181A38F00-0x0000000181A38F50
		public override void WriteEndDocument(); // 0x0000000181A38C00-0x0000000181A38C40
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A38B50-0x0000000181A38BC0
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A38F90-0x0000000181A39000
		public override void WriteEndElement(); // 0x0000000181A38C40-0x0000000181A38C80
		public override void WriteFullEndElement(); // 0x0000000181A38CD0-0x0000000181A38D10
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A38E90-0x0000000181A38F00
		public override void WriteEndAttribute(); // 0x0000000181A38BC0-0x0000000181A38C00
		public override void WriteCData(string text); // 0x0000000181A389F0-0x0000000181A38A40
		public override void WriteComment(string text); // 0x0000000181A38B00-0x0000000181A38B50
		public override void WriteProcessingInstruction(string name, string text); // 0x0000000181A38D70-0x0000000181A38DD0
		public override void WriteEntityRef(string name); // 0x0000000181A38C80-0x0000000181A38CD0
		public override void WriteCharEntity(char ch); // 0x0000000181A38A40-0x0000000181A38A90
		public override void WriteWhitespace(string ws); // 0x0000000181A39100-0x0000000181A39150
		public override void WriteString(string text); // 0x0000000181A39000-0x0000000181A39050
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A39050-0x0000000181A390B0
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A38A90-0x0000000181A38B00
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A38DD0-0x0000000181A38E40
		public override void WriteRaw(string data); // 0x0000000181A38E40-0x0000000181A38E90
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x0000000181A38910-0x0000000181A38980
		public override void WriteBinHex(byte[] buffer, int index, int count); // 0x0000000181A38980-0x0000000181A389F0
		public override void Close(); // 0x0000000181A387B0-0x0000000181A387F0
		public override void Flush(); // 0x0000000181A38820-0x0000000181A38860
		public override string LookupPrefix(string ns); // 0x0000000181A38860-0x0000000181A388B0
		public override void WriteValue(string value); // 0x0000000181A390B0-0x0000000181A39100
		public override void WriteAttributes(XmlReader reader, bool defattr); // 0x0000000181A388B0-0x0000000181A38910
		public override void WriteNode(XmlReader reader, bool defattr); // 0x0000000181A38D10-0x0000000181A38D70
		protected override void Dispose(bool disposing); // 0x0000000181A387F0-0x0000000181A38820
	}
}
