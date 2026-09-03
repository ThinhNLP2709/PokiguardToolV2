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
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlTextEncoder // TypeDefIndex: 6755
	{
		// Fields
		private TextWriter textWriter; // 0x10
		private bool inAttribute; // 0x18
		private char quoteChar; // 0x1A
		private StringBuilder attrValue; // 0x20
		private bool cacheAttrValue; // 0x28
		private XmlCharType xmlCharType; // 0x30
	
		// Properties
		internal char QuoteChar { set; } // 0x0000000181A46460-0x0000000181A46470
		internal string AttributeValue { get; } // 0x0000000181A46410-0x0000000181A46460 
	
		// Constructors
		internal XmlTextEncoder(TextWriter textWriter); // 0x0000000181A463C0-0x0000000181A46410
	
		// Methods
		internal void StartAttribute(bool cacheAttrValue); // 0x0000000181A44D80-0x0000000181A44DF0
		internal void EndAttribute(); // 0x0000000181A44D40-0x0000000181A44D80
		internal void WriteSurrogateChar(char lowChar, char highChar); // 0x0000000181A45790-0x0000000181A45870
		internal void Write(char[] array, int offset, int count); // 0x0000000181A45DD0-0x0000000181A463C0
		internal void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A455F0-0x0000000181A45790
		internal void Write(string text); // 0x0000000181A45870-0x0000000181A45DD0
		internal void WriteRawWithSurrogateChecking(string text); // 0x0000000181A45150-0x0000000181A45380
		internal void WriteRaw(char[] array, int offset, int count); // 0x0000000181A45380-0x0000000181A45540
		internal void WriteCharEntity(char ch); // 0x0000000181A44F00-0x0000000181A45040
		internal void WriteEntityRef(string name); // 0x0000000181A450D0-0x0000000181A45150
		private void WriteStringFragment(string str, int offset, int count, char[] helperBuffer); // 0x0000000181A45540-0x0000000181A455F0
		private void WriteCharEntityImpl(char ch); // 0x0000000181A44DF0-0x0000000181A44E60
		private void WriteCharEntityImpl(string strVal); // 0x0000000181A44E60-0x0000000181A44F00
		private void WriteEntityRefImpl(string name); // 0x0000000181A45040-0x0000000181A450D0
	}
}
