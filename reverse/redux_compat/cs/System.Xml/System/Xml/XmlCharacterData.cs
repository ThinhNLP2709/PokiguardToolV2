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
	public abstract class XmlCharacterData : XmlLinkedNode // TypeDefIndex: 6815
	{
		// Fields
		private string data; // 0x20
	
		// Properties
		public override string Value { get; set; } // 0x00000001816251D0-0x00000001816251F0 0x0000000181A5D440-0x0000000181A5D460
		public override string InnerText { get; set; } // 0x0000000181542050-0x0000000181542070 0x000000018195C640-0x000000018195C660
		public virtual string Data { get; set; } // 0x0000000181A5D340-0x0000000181A5D360 0x0000000181A5D360-0x0000000181A5D440
	
		// Constructors
		protected internal XmlCharacterData(string data, XmlDocument doc); // 0x0000000181A5D1E0-0x0000000181A5D230
	
		// Methods
		internal bool CheckOnData(string data); // 0x0000000181A5D300-0x0000000181A5D340
	}
}
