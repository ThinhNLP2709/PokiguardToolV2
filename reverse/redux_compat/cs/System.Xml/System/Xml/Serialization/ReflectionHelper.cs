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
	internal class ReflectionHelper // TypeDefIndex: 6923
	{
		// Fields
		private Hashtable _clrTypes; // 0x10
		private Hashtable _schemaTypes; // 0x18
		private static readonly ParameterModifier[] empty_modifiers; // 0x00
	
		// Constructors
		public ReflectionHelper(); // 0x0000000181A8CCC0-0x0000000181A8CD50
		static ReflectionHelper(); // 0x0000000181A8CC50-0x0000000181A8CCC0
	
		// Methods
		public void RegisterSchemaType(XmlTypeMapping map, string xmlType, string ns); // 0x0000000181A8CB90-0x0000000181A8CC50
		public XmlTypeMapping GetRegisteredSchemaType(string xmlType, string ns); // 0x0000000181A8C980-0x0000000181A8CA60
		public void RegisterClrType(XmlTypeMapping map, Type type, string ns); // 0x0000000181A8CA60-0x0000000181A8CB90
		public XmlTypeMapping GetRegisteredClrType(Type type, string ns); // 0x0000000181A8C830-0x0000000181A8C980
		public static void CheckSerializableType(Type type, bool allowPrivateConstructors); // 0x0000000181A8C460-0x0000000181A8C830
	}
}
