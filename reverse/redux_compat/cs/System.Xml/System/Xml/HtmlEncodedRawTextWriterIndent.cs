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
	internal class HtmlEncodedRawTextWriterIndent : HtmlEncodedRawTextWriter // TypeDefIndex: 6705
	{
		// Fields
		private int indentLevel; // 0xF0
		private int endBlockPos; // 0xF4
		private string indentChars; // 0xF8
		private bool newLineOnAttributes; // 0x100
	
		// Constructors
		public HtmlEncodedRawTextWriterIndent(TextWriter writer, XmlWriterSettings settings); // 0x0000000181943890-0x0000000181943900
		public HtmlEncodedRawTextWriterIndent(Stream stream, XmlWriterSettings settings); // 0x0000000181943820-0x0000000181943890
	
		// Methods
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181943300-0x0000000181943330
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181943630-0x0000000181943820
		internal override void StartElementContent(); // 0x0000000181943230-0x0000000181943300
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181943330-0x0000000181943510
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181943570-0x0000000181943630
		protected override void FlushBuffer(); // 0x00000001819431B0-0x00000001819431D0
		private new void Init(XmlWriterSettings settings); // 0x00000001819431D0-0x0000000181943230
		private void WriteIndent(); // 0x0000000181943510-0x0000000181943570
	}
}
