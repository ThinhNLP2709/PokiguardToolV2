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

namespace System.Xml.Serialization
{
	internal class ListMap : ObjectMap // TypeDefIndex: 6995
	{
		// Fields
		private XmlTypeMapElementInfoList _itemInfo; // 0x10
		private string _choiceMember; // 0x18
	
		// Properties
		public string ChoiceMember { set; } // 0x00000001802FAF70-0x00000001802FAF80
		public XmlTypeMapElementInfoList ItemInfo { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
		// Constructors
		public ListMap(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public XmlTypeMapElementInfo FindElement(object ob, int index, object memberValue); // 0x0000000181ACD650-0x0000000181ACDC70
		public XmlTypeMapElementInfo FindElement(string elementName, string ns); // 0x0000000181ACDC70-0x0000000181ACDE70
		public XmlTypeMapElementInfo FindTextElement(); // 0x0000000181ACDE70-0x0000000181ACE070
		public void GetArrayType(int itemCount, out string localName, out string ns); // 0x0000000181ACE070-0x0000000181ACE290
		public override bool Equals(object other); // 0x0000000181ACD4B0-0x0000000181ACD650
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
	}
}
