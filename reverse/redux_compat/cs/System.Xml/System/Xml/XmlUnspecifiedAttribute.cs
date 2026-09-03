/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlUnspecifiedAttribute : XmlAttribute // TypeDefIndex: 6846
	{
		// Fields
		private bool fSpecified; // 0x28
	
		// Properties
		public override bool Specified { get; } // 0x0000000180327270-0x0000000180327280 
		public override string InnerText { set; } // 0x0000000181A8B7C0-0x0000000181A8B7E0
	
		// Constructors
		protected internal XmlUnspecifiedAttribute(string prefix, string localName, string namespaceURI, XmlDocument doc); // 0x0000000181A8B7B0-0x0000000181A8B7C0
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A8B5F0-0x0000000181A8B740
		public override XmlNode InsertBefore(XmlNode newChild, XmlNode refChild); // 0x0000000181A8B760-0x0000000181A8B780
		public override XmlNode InsertAfter(XmlNode newChild, XmlNode refChild); // 0x0000000181A8B740-0x0000000181A8B760
		public override XmlNode RemoveChild(XmlNode oldChild); // 0x0000000181A8B780-0x0000000181A8B7A0
		public override XmlNode AppendChild(XmlNode newChild); // 0x0000000181A8B5D0-0x0000000181A8B5F0
		public override void WriteTo(XmlWriter w); // 0x0000000181A8B7A0-0x0000000181A8B7B0
		internal void SetSpecified(bool f); // 0x00000001804AE490-0x00000001804AE4A0
	}
}
