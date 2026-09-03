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
using System.Xml;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class DataTextWriter : XmlWriter // TypeDefIndex: 11343
	{
		// Fields
		private XmlWriter _xmltextWriter; // 0x18
	
		// Properties
		internal Stream BaseStream { get; } // 0x00000001818C1D00-0x00000001818C1D70 
		public override WriteState WriteState { get; } // 0x000000018153EE80-0x000000018153EEB0 
	
		// Constructors
		private DataTextWriter(XmlWriter w); // 0x00000001818C1CC0-0x00000001818C1D00
	
		// Methods
		internal static XmlWriter CreateWriter(XmlWriter xw); // 0x00000001818C18D0-0x00000001818C1930
		public override void WriteStartDocument(); // 0x0000000181789720-0x0000000181789750
		public override void WriteStartDocument(bool standalone); // 0x00000001818C1BD0-0x00000001818C1C00
		public override void WriteEndDocument(); // 0x00000001815D1210-0x00000001815D1240
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x00000001818C1A80-0x00000001818C1AB0
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x00000001818C1C00-0x00000001818C1C30
		public override void WriteEndElement(); // 0x00000001815D1500-0x00000001815D1530
		public override void WriteFullEndElement(); // 0x00000001818C1AE0-0x00000001818C1B10
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x00000001818C1BA0-0x00000001818C1BD0
		public override void WriteEndAttribute(); // 0x00000001815D14A0-0x00000001815D14D0
		public override void WriteCData(string text); // 0x00000001818C19C0-0x00000001818C19F0
		public override void WriteComment(string text); // 0x00000001818C1A50-0x00000001818C1A80
		public override void WriteProcessingInstruction(string name, string text); // 0x00000001818C1B10-0x00000001818C1B40
		public override void WriteEntityRef(string name); // 0x00000001818C1AB0-0x00000001818C1AE0
		public override void WriteCharEntity(char ch); // 0x00000001818C19F0-0x00000001818C1A20
		public override void WriteWhitespace(string ws); // 0x00000001818C1C90-0x00000001818C1CC0
		public override void WriteString(string text); // 0x00000001818C1C30-0x00000001818C1C60
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x00000001818C1C60-0x00000001818C1C90
		public override void WriteChars(char[] buffer, int index, int count); // 0x00000001818C1A20-0x00000001818C1A50
		public override void WriteRaw(char[] buffer, int index, int count); // 0x00000001818C1B40-0x00000001818C1B70
		public override void WriteRaw(string data); // 0x00000001818C1B70-0x00000001818C1BA0
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x00000001818C1960-0x00000001818C1990
		public override void WriteBinHex(byte[] buffer, int index, int count); // 0x00000001818C1990-0x00000001818C19C0
		public override void Close(); // 0x000000018153EE20-0x000000018153EE50
		public override void Flush(); // 0x000000018153EFE0-0x000000018153F010
		public override string LookupPrefix(string ns); // 0x00000001818C1930-0x00000001818C1960
	}
}
