/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	public abstract class XNode : XObject // TypeDefIndex: 15404
	{
		// Fields
		internal XNode next; // 0x20
	
		// Constructors
		internal XNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Remove(); // 0x000000018195DED0-0x000000018195DF40
		public override string ToString(); // 0x000000018195DF40-0x000000018195DF70
		public abstract void WriteTo(XmlWriter writer);
		internal virtual void AppendText(StringBuilder sb); // 0x00000001802E76C0-0x00000001802E76D0
		internal abstract XNode CloneNode();
		private string GetXmlString(SaveOptions o); // 0x000000018195DBC0-0x000000018195DED0
	}
}
