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
using System.Xml.Xsl.Runtime;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal sealed class XmlEventCache : XmlRawWriter // TypeDefIndex: 6747
	{
		// Fields
		private List<XmlEvent[]> pages; // 0x28
		private XmlEvent[] pageCurr; // 0x30
		private int pageSize; // 0x38
		private bool hasRootNode; // 0x3C
		private StringConcat singleText; // 0x40
		private string baseUri; // 0x78
	
		// Nested types
		private enum XmlEventType // TypeDefIndex: 6748
		{
			Unknown = 0,
			DocType = 1,
			StartElem = 2,
			StartAttr = 3,
			EndAttr = 4,
			CData = 5,
			Comment = 6,
			PI = 7,
			Whitespace = 8,
			String = 9,
			Raw = 10,
			EntRef = 11,
			CharEnt = 12,
			SurrCharEnt = 13,
			Base64 = 14,
			BinHex = 15,
			XmlDecl1 = 16,
			XmlDecl2 = 17,
			StartContent = 18,
			EndElem = 19,
			FullEndElem = 20,
			Nmsp = 21,
			EndBase64 = 22,
			Close = 23,
			Flush = 24,
			Dispose = 25
		}
	
		private struct XmlEvent // TypeDefIndex: 6749
		{
			// Fields
			private XmlEventType eventType; // 0x00
			private string s1; // 0x08
			private string s2; // 0x10
			private string s3; // 0x18
			private object o; // 0x20
	
			// Properties
			public XmlEventType EventType { get; } // 0x0000000180732D10-0x0000000180732D20 
			public string String1 { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
			public string String2 { get; } // 0x0000000180377550-0x0000000180377560 
			public string String3 { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public object Object { get; } // 0x00000001802F8630-0x00000001802F8640 
	
			// Methods
			public void InitEvent(XmlEventType eventType); // 0x0000000180732D50-0x0000000180732D60
			public void InitEvent(XmlEventType eventType, string s1); // 0x0000000180F37790-0x0000000180F377B0
			public void InitEvent(XmlEventType eventType, string s1, string s2); // 0x0000000181A40C60-0x0000000181A40CA0
			public void InitEvent(XmlEventType eventType, string s1, string s2, string s3); // 0x0000000181A40D20-0x0000000181A40D70
			public void InitEvent(XmlEventType eventType, string s1, string s2, string s3, object o); // 0x0000000181A40CC0-0x0000000181A40D20
			public void InitEvent(XmlEventType eventType, object o); // 0x0000000181A40CA0-0x0000000181A40CC0
		}
	
		// Constructors
		public XmlEventCache(string baseUri, bool hasRootNode); // 0x0000000181A40C10-0x0000000181A40C60
	
		// Methods
		public void EndEvents(); // 0x0000000181A3F6D0-0x0000000181A3F720
		public void EventsToWriter(XmlWriter writer); // 0x0000000181A3F720-0x0000000181A40100
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A40650-0x0000000181A40700
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A40930-0x0000000181A40960
		public override void WriteStartAttribute(string prefix, string localName, string ns); // 0x0000000181A40900-0x0000000181A40930
		public override void WriteEndAttribute(); // 0x0000000181A40700-0x0000000181A40740
		public override void WriteCData(string text); // 0x0000000181A40510-0x0000000181A40570
		public override void WriteComment(string text); // 0x0000000181A405F0-0x0000000181A40650
		public override void WriteProcessingInstruction(string name, string text); // 0x0000000181A40870-0x0000000181A408A0
		public override void WriteWhitespace(string ws); // 0x0000000181A40AB0-0x0000000181A40B10
		public override void WriteString(string text); // 0x0000000181A40960-0x0000000181A409E0
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A397E0-0x0000000181A39820
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A39A80-0x0000000181A39AC0
		public override void WriteRaw(string data); // 0x0000000181A408A0-0x0000000181A40900
		public override void WriteEntityRef(string name); // 0x0000000181A407B0-0x0000000181A40810
		public override void WriteCharEntity(char ch); // 0x0000000181A40570-0x0000000181A405F0
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A409E0-0x0000000181A40AB0
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x0000000181A40410-0x0000000181A40490
		public override void WriteBinHex(byte[] buffer, int index, int count); // 0x0000000181A40490-0x0000000181A40510
		public override void Close(); // 0x0000000181A3F5D0-0x0000000181A3F610
		public override void Flush(); // 0x0000000181A40100-0x0000000181A40140
		public override void WriteValue(string value); // 0x000000018184CE60-0x000000018184CE80
		protected override void Dispose(bool disposing); // 0x0000000181A3F610-0x0000000181A3F6D0
		internal override void WriteXmlDeclaration(XmlStandalone standalone); // 0x0000000181A40B10-0x0000000181A40BB0
		internal override void WriteXmlDeclaration(string xmldecl); // 0x0000000181A40BB0-0x0000000181A40C10
		internal override void StartElementContent(); // 0x0000000181A40310-0x0000000181A40350
		internal override void WriteEndElement(string prefix, string localName, string ns); // 0x0000000181A40780-0x0000000181A407B0
		internal override void WriteFullEndElement(string prefix, string localName, string ns); // 0x0000000181A40810-0x0000000181A40840
		internal override void WriteNamespaceDeclaration(string prefix, string ns); // 0x0000000181A40840-0x0000000181A40870
		internal override void WriteEndBase64(); // 0x0000000181A40740-0x0000000181A40780
		private void AddEvent(XmlEventType eventType); // 0x0000000181A3F360-0x0000000181A3F3B0
		private void AddEvent(XmlEventType eventType, string s1); // 0x0000000181A3F4D0-0x0000000181A3F540
		private void AddEvent(XmlEventType eventType, string s1, string s2); // 0x0000000181A3F540-0x0000000181A3F5D0
		private void AddEvent(XmlEventType eventType, string s1, string s2, string s3); // 0x0000000181A3F2C0-0x0000000181A3F360
		private void AddEvent(XmlEventType eventType, string s1, string s2, string s3, object o); // 0x0000000181A3F420-0x0000000181A3F4D0
		private void AddEvent(XmlEventType eventType, object o); // 0x0000000181A3F3B0-0x0000000181A3F420
		private int NewEvent(); // 0x0000000181A40140-0x0000000181A40310
		private static byte[] ToBytes(byte[] buffer, int index, int count); // 0x0000000181A40350-0x0000000181A40410
	}
}
