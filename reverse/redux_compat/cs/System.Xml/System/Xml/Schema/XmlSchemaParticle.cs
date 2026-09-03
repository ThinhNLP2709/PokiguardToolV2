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
	public abstract class XmlSchemaParticle : XmlSchemaAnnotated // TypeDefIndex: 7240
	{
		// Fields
		private decimal minOccurs; // 0x50
		private decimal maxOccurs; // 0x60
		private Occurs flags; // 0x70
		internal static readonly XmlSchemaParticle Empty; // 0x00
	
		// Properties
		[XmlAttribute("minOccurs")]
		public string MinOccursString { get; set; } // 0x00000001819E8760-0x00000001819E87D0 0x00000001819E8B70-0x00000001819E8CE0
		[XmlAttribute("maxOccurs")]
		public string MaxOccursString { get; set; } // 0x00000001819E8640-0x00000001819E8760 0x00000001819E87D0-0x00000001819E8A00
		[XmlIgnore]
		public decimal MinOccurs { get; set; } // 0x0000000180E14960-0x0000000180E14970 0x00000001819E8CE0-0x00000001819E8E10
		[XmlIgnore]
		public decimal MaxOccurs { get; set; } // 0x00000001816A56A0-0x00000001816A56B0 0x00000001819E8A00-0x00000001819E8B70
		internal virtual bool IsEmpty { get; } // 0x00000001819E85C0-0x00000001819E8640 
		internal virtual string NameString { get; } // 0x00000001815B1550-0x00000001815B1570 
	
		// Nested types
		[Flags]
		private enum Occurs // TypeDefIndex: 7241
		{
			None = 0,
			Min = 1,
			Max = 2
		}
	
		private class EmptyParticle : XmlSchemaParticle // TypeDefIndex: 7242
		{
			// Properties
			internal override bool IsEmpty { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public EmptyParticle(); // 0x00000001819E09C0-0x00000001819E0A70
		}
	
		// Constructors
		protected XmlSchemaParticle(); // 0x00000001819E8540-0x00000001819E85C0
		static XmlSchemaParticle(); // 0x00000001819E8430-0x00000001819E8540
	
		// Methods
		internal XmlQualifiedName GetQualifiedName(); // 0x00000001819E82B0-0x00000001819E8430
	}
}
