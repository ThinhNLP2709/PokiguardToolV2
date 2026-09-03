/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaSequence : XmlSchemaGroupBase // TypeDefIndex: 7244
	{
		// Fields
		private XmlSchemaObjectCollection items; // 0x78
	
		// Properties
		[XmlElement("element", typeof(XmlSchemaElement))]
		[XmlElement("choice", typeof(XmlSchemaChoice))]
		[XmlElement("sequence", typeof(XmlSchemaSequence))]
		[XmlElement("any", typeof(XmlSchemaAny))]
		[XmlElement("group", typeof(XmlSchemaGroupRef))]
		public override XmlSchemaObjectCollection Items { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		internal override bool IsEmpty { get; } // 0x00000001819E8FA0-0x00000001819E9050 
	
		// Constructors
		public XmlSchemaSequence(); // 0x00000001819E8F30-0x00000001819E8FA0
	
		// Methods
		internal override void SetItems(XmlSchemaObjectCollection newItems); // 0x000000018033EA70-0x000000018033EA80
	}
}
