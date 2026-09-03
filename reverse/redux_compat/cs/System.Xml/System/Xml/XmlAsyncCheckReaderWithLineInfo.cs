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
	internal class XmlAsyncCheckReaderWithLineInfo : XmlAsyncCheckReader, IXmlLineInfo // TypeDefIndex: 6740
	{
		// Fields
		private readonly IXmlLineInfo readerAsIXmlLineInfo; // 0x20
	
		// Properties
		public virtual int LineNumber { get; } // 0x0000000181A37340-0x0000000181A37390 
		public virtual int LinePosition { get; } // 0x0000000181A37390-0x0000000181A373E0 
	
		// Constructors
		public XmlAsyncCheckReaderWithLineInfo(XmlReader reader); // 0x0000000181A37290-0x0000000181A37340
	
		// Methods
		public virtual bool HasLineInfo(); // 0x0000000181A37240-0x0000000181A37290
	}
}
