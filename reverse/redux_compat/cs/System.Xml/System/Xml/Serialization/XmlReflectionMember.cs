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
	public class XmlReflectionMember // TypeDefIndex: 6955
	{
		// Fields
		private bool isReturnValue; // 0x10
		private string memberName; // 0x18
		private Type memberType; // 0x20
		private XmlAttributes xmlAttributes; // 0x28
		private Type declaringType; // 0x30
	
		// Properties
		public bool IsReturnValue { get; } // 0x00000001805625D0-0x00000001805625E0 
		public string MemberName { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public Type MemberType { get; } // 0x00000001802F8630-0x00000001802F8640 
		public XmlAttributes XmlAttributes { get; } // 0x0000000181AB3F20-0x0000000181AB3F90 
		internal Type DeclaringType { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
	
		// Constructors
		internal XmlReflectionMember(string name, Type type, XmlAttributes attributes); // 0x0000000181AB3EB0-0x0000000181AB3F20
	}
}
