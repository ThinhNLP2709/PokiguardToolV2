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
using Mono.Xml;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	internal class ConfigHandler : SmallXmlParser.IContentHandler // TypeDefIndex: 2882
	{
		// Fields
		private ArrayList typeEntries; // 0x10
		private ArrayList channelInstances; // 0x18
		private ChannelData currentChannel; // 0x20
		private Stack currentProviderData; // 0x28
		private string currentClientUrl; // 0x30
		private string appName; // 0x38
		private string currentXmlPath; // 0x40
		private bool onlyDelayedChannels; // 0x48
	
		// Constructors
		public ConfigHandler(bool onlyDelayedChannels); // 0x00000001814B6DA0-0x00000001814B6E70
	
		// Methods
		private void ValidatePath(string element, params string[] paths); // 0x00000001814B6CB0-0x00000001814B6DA0
		private bool CheckPath(string path); // 0x00000001814B36D0-0x00000001814B37E0
		public void OnStartParsing(SmallXmlParser parser); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnProcessingInstruction(string name, string text); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnIgnorableWhitespace(string s); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnStartElement(string name, SmallXmlParser.IAttrList attrs); // 0x00000001814B3B40-0x00000001814B3CA0
		public void ParseElement(string name, SmallXmlParser.IAttrList attrs); // 0x00000001814B3CA0-0x00000001814B4A50
		public void OnEndElement(string name); // 0x00000001814B39A0-0x00000001814B3A50
		private void ReadCustomProviderData(string name, SmallXmlParser.IAttrList attrs); // 0x00000001814B57B0-0x00000001814B5B90
		private void ReadLifetine(SmallXmlParser.IAttrList attrs); // 0x00000001814B5D20-0x00000001814B6080
		private TimeSpan ParseTime(string s); // 0x00000001814B4A50-0x00000001814B4DC0
		private void ReadChannel(SmallXmlParser.IAttrList attrs, bool isTemplate); // 0x00000001814B4DC0-0x00000001814B5350
		private ProviderData ReadProvider(string name, SmallXmlParser.IAttrList attrs, bool isTemplate); // 0x00000001814B6310-0x00000001814B67E0
		private void ReadClientActivated(SmallXmlParser.IAttrList attrs); // 0x00000001814B5350-0x00000001814B55B0
		private void ReadServiceActivated(SmallXmlParser.IAttrList attrs); // 0x00000001814B67E0-0x00000001814B69B0
		private void ReadClientWellKnown(SmallXmlParser.IAttrList attrs); // 0x00000001814B55B0-0x00000001814B57B0
		private void ReadServiceWellKnown(SmallXmlParser.IAttrList attrs); // 0x00000001814B69B0-0x00000001814B6CB0
		private void ReadInteropXml(SmallXmlParser.IAttrList attrs, bool isElement); // 0x00000001814B5B90-0x00000001814B5D20
		private void ReadPreload(SmallXmlParser.IAttrList attrs); // 0x00000001814B6080-0x00000001814B6310
		private string GetNotNull(SmallXmlParser.IAttrList attrs, string name); // 0x00000001814B38C0-0x00000001814B39A0
		private string ExtractAssembly(ref string type); // 0x00000001814B37E0-0x00000001814B38C0
		public void OnChars(string ch); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnEndParsing(SmallXmlParser parser); // 0x00000001814B3A50-0x00000001814B3B40
	}
}
