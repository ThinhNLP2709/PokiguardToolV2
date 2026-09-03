/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class XmlTextWriter : XmlWriter // TypeDefIndex: 6773
	{
		// Fields
		private TextWriter textWriter; // 0x18
		private XmlTextEncoder xmlEncoder; // 0x20
		private Encoding encoding; // 0x28
		private Formatting formatting; // 0x30
		private bool indented; // 0x34
		private int indentation; // 0x38
		private char indentChar; // 0x3C
		private TagInfo[] stack; // 0x40
		private int top; // 0x48
		private State[] stateTable; // 0x50
		private State currentState; // 0x58
		private Token lastToken; // 0x5C
		private XmlTextWriterBase64Encoder base64Encoder; // 0x60
		private char quoteChar; // 0x68
		private char curQuoteChar; // 0x6A
		private bool namespaces; // 0x6C
		private SpecialAttr specialAttr; // 0x70
		private string prefixForXmlNs; // 0x78
		private bool flush; // 0x80
		private Namespace[] nsStack; // 0x88
		private int nsTop; // 0x90
		private Dictionary<string, int> nsHashtable; // 0x98
		private bool useNsHashtable; // 0xA0
		private XmlCharType xmlCharType; // 0xA8
		private static string[] stateName; // 0x00
		private static string[] tokenName; // 0x08
		private static readonly State[] stateTableDefault; // 0x10
		private static readonly State[] stateTableDocument; // 0x18
	
		// Properties
		public Stream BaseStream { get; } // 0x0000000181A4C840-0x0000000181A4C8C0 
		public bool Namespaces { set; } // 0x0000000181A4C940-0x0000000181A4C9C0
		public Formatting Formatting { set; } // 0x0000000181A4C930-0x0000000181A4C940
		public char QuoteChar { set; } // 0x0000000181A4C9C0-0x0000000181A4CA60
		public override WriteState WriteState { get; } // 0x0000000181A4C8C0-0x0000000181A4C930 
	
		// Nested types
		private enum NamespaceState // TypeDefIndex: 6774
		{
			Uninitialized = 0,
			NotDeclaredButInScope = 1,
			DeclaredButNotWrittenOut = 2,
			DeclaredAndWrittenOut = 3
		}
	
		private struct TagInfo // TypeDefIndex: 6775
		{
			// Fields
			internal string name; // 0x00
			internal string prefix; // 0x08
			internal string defaultNs; // 0x10
			internal NamespaceState defaultNsState; // 0x18
			internal XmlSpace xmlSpace; // 0x1C
			internal string xmlLang; // 0x20
			internal int prevNsTop; // 0x28
			internal int prefixCount; // 0x2C
			internal bool mixed; // 0x30
	
			// Methods
			internal void Init(int nsTop); // 0x0000000181A47490-0x0000000181A47500
		}
	
		private struct Namespace // TypeDefIndex: 6776
		{
			// Fields
			internal string prefix; // 0x00
			internal string ns; // 0x08
			internal bool declared; // 0x10
			internal int prevNsIndex; // 0x14
	
			// Methods
			internal void Set(string prefix, string ns, bool declared); // 0x0000000181A47310-0x0000000181A47360
		}
	
		private enum SpecialAttr // TypeDefIndex: 6777
		{
			None = 0,
			XmlSpace = 1,
			XmlLang = 2,
			XmlNs = 3
		}
	
		private enum State // TypeDefIndex: 6778
		{
			Start = 0,
			Prolog = 1,
			PostDTD = 2,
			Element = 3,
			Attribute = 4,
			Content = 5,
			AttrOnly = 6,
			Epilog = 7,
			Error = 8,
			Closed = 9
		}
	
		private enum Token // TypeDefIndex: 6779
		{
			PI = 0,
			Doctype = 1,
			Comment = 2,
			CData = 3,
			StartElement = 4,
			EndElement = 5,
			LongEndElement = 6,
			StartAttribute = 7,
			EndAttribute = 8,
			Content = 9,
			Base64 = 10,
			RawData = 11,
			Whitespace = 12,
			Empty = 13
		}
	
		// Constructors
		internal XmlTextWriter(); // 0x0000000181A4C380-0x0000000181A4C520
		public XmlTextWriter(Stream w, Encoding encoding); // 0x0000000181A4C740-0x0000000181A4C840
		public XmlTextWriter(string filename, Encoding encoding); // 0x0000000181A4C5F0-0x0000000181A4C740
		public XmlTextWriter(TextWriter w); // 0x0000000181A4C520-0x0000000181A4C5F0
		static XmlTextWriter(); // 0x0000000181A4BD20-0x0000000181A4C380
	
		// Methods
		public override void WriteStartDocument(); // 0x0000000181A4B530-0x0000000181A4B540
		public override void WriteStartDocument(bool standalone); // 0x0000000181A4B510-0x0000000181A4B530
		public override void WriteEndDocument(); // 0x0000000181A4A3F0-0x0000000181A4A590
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A49F60-0x0000000181A4A340
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A4B540-0x0000000181A4BB10
		public override void WriteEndElement(); // 0x0000000181A4A590-0x0000000181A4A5A0
		public override void WriteFullEndElement(); // 0x0000000181A4AA10-0x0000000181A4AA20
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A4AD10-0x0000000181A4B510
		public override void WriteEndAttribute(); // 0x0000000181A4A3A0-0x0000000181A4A3F0
		public override void WriteCData(string text); // 0x0000000181A49B40-0x0000000181A49CB0
		public override void WriteComment(string text); // 0x0000000181A49DC0-0x0000000181A49F60
		public override void WriteProcessingInstruction(string name, string text); // 0x0000000181A4AA20-0x0000000181A4AC00
		public override void WriteEntityRef(string name); // 0x0000000181A4A990-0x0000000181A4AA10
		public override void WriteCharEntity(char ch); // 0x0000000181A49CB0-0x0000000181A49D20
		public override void WriteWhitespace(string ws); // 0x0000000181A4BC20-0x0000000181A4BD20
		public override void WriteString(string text); // 0x0000000181A4BB10-0x0000000181A4BB90
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A4BB90-0x0000000181A4BC20
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A49D20-0x0000000181A49DC0
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A4AC00-0x0000000181A4ACA0
		public override void WriteRaw(string data); // 0x0000000181A4ACA0-0x0000000181A4AD10
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x0000000181A499A0-0x0000000181A49AB0
		public override void WriteBinHex(byte[] buffer, int index, int count); // 0x0000000181A49AB0-0x0000000181A49B40
		public override void Close(); // 0x0000000181A47FF0-0x0000000181A480D0
		public override void Flush(); // 0x00000001815D1500-0x00000001815D1530
		public override string LookupPrefix(string ns); // 0x0000000181A48D70-0x0000000181A48E60
		private void StartDocument(int standalone); // 0x0000000181A49380-0x0000000181A49660
		private void AutoComplete(Token token); // 0x0000000181A479E0-0x0000000181A47FF0
		private void AutoCompleteAll(); // 0x0000000181A47980-0x0000000181A479E0
		private void InternalWriteEndElement(bool longFormat); // 0x0000000181A48630-0x0000000181A48A30
		private void WriteEndStartTag(bool empty); // 0x0000000181A4A5A0-0x0000000181A4A990
		private void WriteEndAttributeQuote(); // 0x0000000181A4A340-0x0000000181A4A3A0
		private void Indent(bool beforeEndElement); // 0x0000000181A48540-0x0000000181A48630
		private void PushNamespace(string prefix, string ns, bool declared); // 0x0000000181A48F60-0x0000000181A49250
		private void AddNamespace(string prefix, string ns, bool declared); // 0x0000000181A476C0-0x0000000181A47890
		private void AddToNamespaceHashtable(int namespaceIndex); // 0x0000000181A47890-0x0000000181A47980
		private void PopNamespaces(int indexFrom, int indexTo); // 0x0000000181A48E60-0x0000000181A48F60
		private string GeneratePrefix(); // 0x0000000181A48200-0x0000000181A48300
		private void InternalWriteProcessingInstruction(string name, string text); // 0x0000000181A48A30-0x0000000181A48B40
		private int LookupNamespace(string prefix); // 0x0000000181A48C80-0x0000000181A48D70
		private int LookupNamespaceInCurrentScope(string prefix); // 0x0000000181A48B40-0x0000000181A48C80
		private string FindPrefix(string ns); // 0x0000000181A480D0-0x0000000181A481C0
		private void ValidateName(string name, bool isNCName); // 0x0000000181A49660-0x0000000181A49860
		private void HandleSpecialAttribute(); // 0x0000000181A48300-0x0000000181A48540
		private void VerifyPrefixXml(string prefix, string ns); // 0x0000000181A49860-0x0000000181A499A0
		private void PushStack(); // 0x0000000181A49250-0x0000000181A49380
		private void FlushEncoders(); // 0x0000000181A481C0-0x0000000181A48200
	}
}
