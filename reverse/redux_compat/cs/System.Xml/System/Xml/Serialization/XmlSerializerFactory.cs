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
	public class XmlSerializerFactory // TypeDefIndex: 6977
	{
		// Fields
		private static Hashtable serializersBySource; // 0x00
	
		// Constructors
		public XmlSerializerFactory(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static XmlSerializerFactory(); // 0x0000000181ADA030-0x0000000181ADA0B0
	
		// Methods
		public XmlSerializer CreateSerializer(Type type); // 0x0000000181AD9FD0-0x0000000181ADA000
		public XmlSerializer CreateSerializer(Type type, XmlRootAttribute root); // 0x0000000181ADA000-0x0000000181ADA030
		public XmlSerializer CreateSerializer(Type type, XmlAttributeOverrides overrides, Type[] extraTypes, XmlRootAttribute root, string defaultNamespace); // 0x0000000181AD9C20-0x0000000181AD9FD0
	}
}
