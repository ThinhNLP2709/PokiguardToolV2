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
	internal class ReaderPositionInfo : PositionInfo // TypeDefIndex: 6852
	{
		// Fields
		private IXmlLineInfo lineInfo; // 0x10
	
		// Properties
		public override int LineNumber { get; } // 0x0000000181A80200-0x0000000181A80250 
		public override int LinePosition { get; } // 0x0000000181A80250-0x0000000181A802A0 
	
		// Constructors
		public ReaderPositionInfo(IXmlLineInfo lineInfo); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public override bool HasLineInfo(); // 0x0000000181A801B0-0x0000000181A80200
	}
}
