/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	internal sealed class SerializationFieldInfo : FieldInfo // TypeDefIndex: 3050
	{
		// Fields
		private RuntimeFieldInfo m_field; // 0x10
		private string m_serializationName; // 0x18
	
		// Properties
		public override Module Module { get; } // 0x0000000181501AA0-0x0000000181501AD0 
		public override int MetadataToken { get; } // 0x0000000181501A70-0x0000000181501AA0 
		public override string Name { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override Type DeclaringType { get; } // 0x00000001815019E0-0x0000000181501A10 
		public override Type ReflectedType { get; } // 0x0000000181501AD0-0x0000000181501B00 
		public override Type FieldType { get; } // 0x0000000181501A40-0x0000000181501A70 
		internal RuntimeFieldInfo FieldInfo { get; } // 0x0000000180377550-0x0000000180377560 
		public override RuntimeFieldHandle FieldHandle { get; } // 0x0000000181501A10-0x0000000181501A40 
		public override FieldAttributes Attributes { get; } // 0x00000001815019B0-0x00000001815019E0 
	
		// Constructors
		internal SerializationFieldInfo(RuntimeFieldInfo field, string namePrefix); // 0x0000000181501900-0x00000001815019B0
	
		// Methods
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181501680-0x00000001815016B0
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x00000001815016B0-0x00000001815016E0
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181501890-0x00000001815018C0
		public override object GetValue(object obj); // 0x0000000180A6BAA0-0x0000000180A6BAD0
		internal object InternalGetValue(object obj); // 0x00000001815016E0-0x0000000181501790
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture); // 0x00000001815018C0-0x0000000181501900
		internal void InternalSetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture); // 0x0000000181501790-0x0000000181501890
	}
}
