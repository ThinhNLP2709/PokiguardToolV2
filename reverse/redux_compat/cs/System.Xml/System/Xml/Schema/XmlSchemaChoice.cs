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
	public class XmlSchemaChoice : XmlSchemaGroupBase // TypeDefIndex: 7184
	{
		// Fields
		private XmlSchemaObjectCollection items; // 0x78
	
		// Properties
		[XmlElement("any", typeof(XmlSchemaAny))]
		[XmlElement("group", typeof(XmlSchemaGroupRef))]
		[XmlElement("choice", typeof(XmlSchemaChoice))]
		[XmlElement("sequence", typeof(XmlSchemaSequence))]
		[XmlElement("element", typeof(XmlSchemaElement))]
		public override XmlSchemaObjectCollection Items { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		internal override bool IsEmpty { get; } // 0x00000001819D8820-0x00000001819D8830 
	
		// Constructors
		public XmlSchemaChoice(); // 0x00000001819D8780-0x00000001819D8820
	
		// Methods
		internal override void SetItems(XmlSchemaObjectCollection newItems); // 0x000000018033EA70-0x000000018033EA80
	}
}
