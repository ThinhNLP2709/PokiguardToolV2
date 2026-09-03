/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	public abstract class XmlMapping // TypeDefIndex: 6947
	{
		// Fields
		private ObjectMap map; // 0x10
		private ArrayList relatedMaps; // 0x18
		private SerializationFormat format; // 0x20
		private SerializationSource source; // 0x28
		internal string _elementName; // 0x30
		internal string _namespace; // 0x38
		private string key; // 0x40
	
		// Properties
		public string ElementName { get; } // 0x000000018031E110-0x000000018031E120 
		public string Namespace { get; } // 0x00000001803272A0-0x00000001803272B0 
		internal ObjectMap ObjectMap { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal ArrayList RelatedMaps { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		internal SerializationFormat Format { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		internal SerializationSource Source { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		internal XmlMapping(string elementName, string ns); // 0x0000000181AAC460-0x0000000181AAC4B0
	
		// Methods
		public void SetKey(string key); // 0x0000000180378120-0x0000000180378130
	}
}
