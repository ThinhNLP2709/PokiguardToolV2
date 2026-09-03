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
	internal class ValidatingReaderNodeData // TypeDefIndex: 6735
	{
		// Fields
		private string localName; // 0x10
		private string namespaceUri; // 0x18
		private string prefix; // 0x20
		private string nameWPrefix; // 0x28
		private string rawValue; // 0x30
		private string originalStringValue; // 0x38
		private int depth; // 0x40
		private AttributePSVIInfo attributePSVIInfo; // 0x48
		private XmlNodeType nodeType; // 0x50
		private int lineNo; // 0x54
		private int linePos; // 0x58
	
		// Properties
		public string LocalName { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string Namespace { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string Prefix { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public int Depth { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
		public string RawValue { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public string OriginalStringValue { get; } // 0x00000001803272A0-0x00000001803272B0 
		public XmlNodeType NodeType { get; set; } // 0x000000018033D660-0x000000018033D670 0x000000018033EC40-0x000000018033EC50
		public AttributePSVIInfo AttInfo { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public int LineNumber { get; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 
		public int LinePosition { get; } // 0x000000018033D260-0x000000018033D270 
	
		// Constructors
		public ValidatingReaderNodeData(); // 0x0000000181A36BA0-0x0000000181A36BD0
		public ValidatingReaderNodeData(XmlNodeType nodeType); // 0x0000000181A36B70-0x0000000181A36BA0
	
		// Methods
		public string GetAtomizedNameWPrefix(XmlNameTable nameTable); // 0x0000000181A36940-0x0000000181A369F0
		internal void Clear(XmlNodeType nodeType); // 0x0000000181A36880-0x0000000181A36940
		internal void SetLineInfo(int lineNo, int linePos); // 0x0000000181A36B60-0x0000000181A36B70
		internal void SetLineInfo(IXmlLineInfo lineInfo); // 0x0000000181A36AF0-0x0000000181A36B60
		internal void SetItemData(string localName, string prefix, string ns, int depth); // 0x0000000181A369F0-0x0000000181A36A70
		internal void SetItemData(string value); // 0x0000000181A36AB0-0x0000000181A36AF0
		internal void SetItemData(string value, string originalStringValue); // 0x0000000181A36A70-0x0000000181A36AB0
	}
}
