/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	internal struct ElementWriter // TypeDefIndex: 15396
	{
		// Fields
		private XmlWriter _writer; // 0x00
		private NamespaceResolver _resolver; // 0x08
	
		// Constructors
		public ElementWriter(XmlWriter writer); // 0x0000000181955FA0-0x0000000181955FD0
	
		// Methods
		public void WriteElement(XElement e); // 0x0000000181955A10-0x0000000181955C10
		private string GetPrefixOfNamespace(XNamespace ns, bool allowDefaultNamespace); // 0x0000000181955300-0x00000001819554B0
		private void PushAncestors(XElement e); // 0x00000001819554B0-0x00000001819557B0
		private void PushElement(XElement e); // 0x00000001819557B0-0x0000000181955A10
		private void WriteEndElement(); // 0x0000000181955C10-0x0000000181955C50
		private void WriteFullEndElement(); // 0x0000000181955C50-0x0000000181955C90
		private void WriteStartElement(XElement e); // 0x0000000181955C90-0x0000000181955FA0
	}
}
