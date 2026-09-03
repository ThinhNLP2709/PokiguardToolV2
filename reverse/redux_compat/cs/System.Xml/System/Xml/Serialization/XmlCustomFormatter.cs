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
	internal class XmlCustomFormatter // TypeDefIndex: 6941
	{
		// Fields
		private static string[] allTimeFormats; // 0x00
	
		// Constructors
		static XmlCustomFormatter(); // 0x0000000181AAB820-0x0000000181AABCE0
	
		// Methods
		internal static string FromEnum(long value, string[] values, long[] ids, string typeName); // 0x0000000181AA9E80-0x0000000181AAA1A0
		internal static string FromXmlName(string name); // 0x0000000181AAA1F0-0x0000000181AAA240
		internal static string FromXmlNCName(string ncName); // 0x0000000181AAA1A0-0x0000000181AAA1F0
		internal static string ToXmlString(TypeData type, object value); // 0x0000000181AAABB0-0x0000000181AAB820
		internal static object FromXmlString(TypeData type, string value); // 0x0000000181AAA240-0x0000000181AAABB0
	}
}
