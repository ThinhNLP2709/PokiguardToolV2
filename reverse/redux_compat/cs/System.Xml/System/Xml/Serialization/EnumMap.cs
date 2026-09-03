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
	internal class EnumMap : ObjectMap // TypeDefIndex: 6996
	{
		// Fields
		private readonly EnumMapMember[] _members; // 0x10
		private readonly bool _isFlags; // 0x18
		private readonly string[] _enumNames; // 0x20
		private readonly string[] _xmlNames; // 0x28
		private readonly long[] _values; // 0x30
	
		// Properties
		public bool IsFlags { get; } // 0x0000000180F9E350-0x0000000180F9E360 
		public string[] EnumNames { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string[] XmlNames { get; } // 0x000000018033D240-0x000000018033D250 
		public long[] Values { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Nested types
		public class EnumMapMember // TypeDefIndex: 6997
		{
			// Fields
			private readonly string _xmlName; // 0x10
			private readonly string _enumName; // 0x18
			private readonly long _value; // 0x20
	
			// Properties
			public string XmlName { get; } // 0x0000000180377550-0x0000000180377560 
			public string EnumName { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public long Value { get; } // 0x00000001802F8630-0x00000001802F8640 
	
			// Constructors
			public EnumMapMember(string xmlName, string enumName, long value); // 0x0000000181ACBD60-0x0000000181ACBDC0
		}
	
		// Constructors
		public EnumMap(EnumMapMember[] members, bool isFlags); // 0x0000000181ACC410-0x0000000181ACC5E0
	
		// Methods
		public string GetXmlName(string typeName, object enumValue); // 0x0000000181ACC0A0-0x0000000181ACC410
		public string GetEnumName(string typeName, string xmlName); // 0x0000000181ACBDC0-0x0000000181ACC0A0
	}
}
