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
	public class XDocumentType : XNode // TypeDefIndex: 15388
	{
		// Fields
		private string _name; // 0x28
		private string _publicId; // 0x30
		private string _systemId; // 0x38
		private string _internalSubset; // 0x40
	
		// Properties
		public string InternalSubset { get; } // 0x0000000180377940-0x0000000180377950 
		public string Name { get; } // 0x000000018033D240-0x000000018033D250 
		public override XmlNodeType NodeType { get; } // 0x0000000181626E00-0x0000000181626E10 
		public string PublicId { get; } // 0x000000018031E110-0x000000018031E120 
		public string SystemId { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		public XDocumentType(string name, string publicId, string systemId, string internalSubset); // 0x000000018195A650-0x000000018195A710
		public XDocumentType(XDocumentType other); // 0x000000018195A590-0x000000018195A650
	
		// Methods
		public override void WriteTo(XmlWriter writer); // 0x000000018195A4F0-0x000000018195A590
		internal override XNode CloneNode(); // 0x000000018195A400-0x000000018195A4F0
	}
}
