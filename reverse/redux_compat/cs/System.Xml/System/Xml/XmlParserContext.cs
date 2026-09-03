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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public class XmlParserContext // TypeDefIndex: 6750
	{
		// Fields
		private XmlNameTable _nt; // 0x10
		private XmlNamespaceManager _nsMgr; // 0x18
		private string _docTypeName; // 0x20
		private string _pubId; // 0x28
		private string _sysId; // 0x30
		private string _internalSubset; // 0x38
		private string _xmlLang; // 0x40
		private XmlSpace _xmlSpace; // 0x48
		private string _baseURI; // 0x50
		private Encoding _encoding; // 0x58
	
		// Properties
		public XmlNameTable NameTable { get; } // 0x0000000180377550-0x0000000180377560 
		public XmlNamespaceManager NamespaceManager { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string DocTypeName { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string PublicId { get; } // 0x000000018033D240-0x000000018033D250 
		public string SystemId { get; } // 0x000000018031E110-0x000000018031E120 
		public string BaseURI { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public string InternalSubset { get; } // 0x00000001803272A0-0x00000001803272B0 
		public string XmlLang { get; } // 0x0000000180377940-0x0000000180377950 
		public XmlSpace XmlSpace { get; } // 0x000000018033D1C0-0x000000018033D1D0 
		public Encoding Encoding { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal bool HasDtdInfo { get; } // 0x0000000181A410F0-0x0000000181A41170 
	
		// Constructors
		public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string xmlLang, XmlSpace xmlSpace); // 0x0000000181A40D70-0x0000000181A40DD0
		public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, XmlSpace xmlSpace); // 0x0000000181A40DD0-0x0000000181A40E40
		public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, XmlSpace xmlSpace, Encoding enc); // 0x0000000181A40E40-0x0000000181A410F0
	}
}
