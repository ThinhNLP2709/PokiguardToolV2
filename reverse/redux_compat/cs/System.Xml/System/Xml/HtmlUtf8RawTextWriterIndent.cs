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
	internal class HtmlUtf8RawTextWriterIndent : HtmlUtf8RawTextWriter // TypeDefIndex: 6708
	{
		// Fields
		private int indentLevel; // 0xC0
		private int endBlockPos; // 0xC4
		private string indentChars; // 0xC8
		private bool newLineOnAttributes; // 0xD0
	
		// Constructors
		public HtmlUtf8RawTextWriterIndent(Stream stream, XmlWriterSettings settings); // 0x0000000181A34550-0x0000000181A345B0
	
		// Methods
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A34010-0x0000000181A34040
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A34230-0x0000000181A34550
		internal override void StartElementContent(); // 0x0000000181A33F50-0x0000000181A34010
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181A34040-0x0000000181A34120
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A34170-0x0000000181A34230
		protected override void FlushBuffer(); // 0x0000000181A33ED0-0x0000000181A33EF0
		private new void Init(XmlWriterSettings settings); // 0x0000000181A33EF0-0x0000000181A33F50
		private void WriteIndent(); // 0x0000000181A34120-0x0000000181A34170
	}
}
