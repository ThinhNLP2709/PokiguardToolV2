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
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaGroupRef : XmlSchemaParticle // TypeDefIndex: 7221
	{
		// Fields
		private XmlQualifiedName refName; // 0x78
		private XmlSchemaGroupBase particle; // 0x80
		private XmlSchemaGroup refined; // 0x88
	
		// Properties
		[XmlAttribute("ref")]
		public XmlQualifiedName RefName { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x00000001819DE4B0-0x00000001819DE540
		[XmlIgnore]
		public XmlSchemaGroupBase Particle { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		[XmlIgnore]
		internal XmlSchemaGroup Redefined { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
	
		// Constructors
		public XmlSchemaGroupRef(); // 0x00000001819DE420-0x00000001819DE4B0
	
		// Methods
		internal void SetParticle(XmlSchemaGroupBase value); // 0x000000018033EA30-0x000000018033EA40
	}
}
