/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Xml
{
	internal class SecurityParser : SmallXmlParser, IContentHandler // TypeDefIndex: 2096
	{
		// Fields
		private SecurityElement root; // 0x68
		private SecurityElement current; // 0x70
		private Stack stack; // 0x78
	
		// Constructors
		public SecurityParser(); // 0x0000000181433F80-0x0000000181434180
	
		// Methods
		public void LoadXml(string xml); // 0x0000000181433A60-0x0000000181433B10
		public SecurityElement ToXml(); // 0x0000000180316960-0x0000000180316970
		public void OnStartParsing(SmallXmlParser parser); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnProcessingInstruction(string name, string text); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnIgnorableWhitespace(string s); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnStartElement(string name, IAttrList attrs); // 0x0000000181433C50-0x0000000181433F80
		public void OnEndElement(string name); // 0x0000000181433B90-0x0000000181433C50
		public void OnChars(string ch); // 0x0000000181433B10-0x0000000181433B90
		public void OnEndParsing(SmallXmlParser parser); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
