/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Xml
{
	internal class SmallXmlParser // TypeDefIndex: 2097
	{
		// Fields
		private IContentHandler handler; // 0x10
		private TextReader reader; // 0x18
		private Stack elementNames; // 0x20
		private Stack xmlSpaces; // 0x28
		private string xmlSpace; // 0x30
		private StringBuilder buffer; // 0x38
		private char[] nameBuffer; // 0x40
		private bool isWhitespace; // 0x48
		private AttrListImpl attributes; // 0x50
		private int line; // 0x58
		private int column; // 0x5C
		private bool resetColumn; // 0x60
	
		// Nested types
		public interface IContentHandler // TypeDefIndex: 2098
		{
			// Methods
			void OnStartParsing(SmallXmlParser parser);
			void OnEndParsing(SmallXmlParser parser);
			void OnStartElement(string name, IAttrList attrs);
			void OnEndElement(string name);
			void OnProcessingInstruction(string name, string text);
			void OnChars(string text);
			void OnIgnorableWhitespace(string text);
		}
	
		public interface IAttrList // TypeDefIndex: 2099
		{
			// Properties
			int Length { get; }
			string[] Names { get; }
			string[] Values { get; }
	
			// Methods
			string GetName(int i);
			string GetValue(int i);
			string GetValue(string name);
		}
	
		private class AttrListImpl : IAttrList // TypeDefIndex: 2100
		{
			// Fields
			private List<string> attrNames; // 0x10
			private List<string> attrValues; // 0x18
	
			// Properties
			public int Length { get; } // 0x0000000180B5F570-0x0000000180B5F590 
			public string[] Names { get; } // 0x000000018142D9B0-0x000000018142DA00 
			public string[] Values { get; } // 0x000000018142DA00-0x000000018142DA50 
	
			// Constructors
			public AttrListImpl(); // 0x000000018142D900-0x000000018142D9B0
	
			// Methods
			public string GetName(int i); // 0x0000000180CAFA00-0x0000000180CAFA20
			public string GetValue(int i); // 0x000000018142D840-0x000000018142D860
			public string GetValue(string name); // 0x000000018142D860-0x000000018142D900
			internal void Clear(); // 0x000000018142D7D0-0x000000018142D840
			internal void Add(string name, string value); // 0x000000018142D6B0-0x000000018142D7D0
		}
	
		// Constructors
		public SmallXmlParser(); // 0x000000018143C770-0x000000018143C930
	
		// Methods
		private Exception Error(string msg); // 0x000000018143A150-0x000000018143A230
		private Exception UnexpectedEndError(); // 0x000000018143C690-0x000000018143C770
		private bool IsNameChar(char c, bool start); // 0x000000018143A540-0x000000018143A630
		private bool IsWhitespace(int c); // 0x000000018143A630-0x000000018143A650
		public void SkipWhitespaces(); // 0x000000018143C5A0-0x000000018143C5B0
		private void HandleWhitespaces(); // 0x000000018143A430-0x000000018143A540
		public void SkipWhitespaces(bool expected); // 0x000000018143C5B0-0x000000018143C690
		private int Peek(); // 0x000000018143A8B0-0x000000018143A8E0
		private int Read(); // 0x000000018143C540-0x000000018143C5A0
		public void Expect(int c); // 0x000000018143A230-0x000000018143A360
		private string ReadUntil(char until, bool handleReferences); // 0x000000018143C400-0x000000018143C540
		public string ReadName(); // 0x000000018143BF60-0x000000018143C190
		public void Parse(TextReader input, IContentHandler handler); // 0x000000018143A650-0x000000018143A8B0
		private void Cleanup(); // 0x000000018143A040-0x000000018143A150
		public void ReadContent(); // 0x000000018143B0F0-0x000000018143BF60
		private void HandleBufferedContent(); // 0x000000018143A360-0x000000018143A430
		private void ReadCharacters(); // 0x000000018143AE80-0x000000018143AFA0
		private void ReadReference(); // 0x000000018143C190-0x000000018143C400
		private int ReadCharacterReference(); // 0x000000018143AC90-0x000000018143AE80
		private void ReadAttribute(AttrListImpl a); // 0x000000018143A8E0-0x000000018143AB40
		private void ReadCDATASection(); // 0x000000018143AB40-0x000000018143AC90
		private void ReadComment(); // 0x000000018143AFA0-0x000000018143B0F0
	}
}
