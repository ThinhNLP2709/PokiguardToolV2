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

namespace System.Reflection.Emit
{
	public sealed class FieldBuilder : FieldInfo // TypeDefIndex: 3369
	{
		// Properties
		public override FieldAttributes Attributes { get; } // 0x0000000181529160-0x0000000181529170 
		public override Type DeclaringType { get; } // 0x0000000181529160-0x0000000181529170 
		public override RuntimeFieldHandle FieldHandle { get; } // 0x0000000181529160-0x0000000181529170 
		public override Type FieldType { get; } // 0x0000000181529160-0x0000000181529170 
		public override string Name { get; } // 0x0000000181529160-0x0000000181529170 
		public override Type ReflectedType { get; } // 0x0000000181529160-0x0000000181529170 
	
		// Methods
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181529160-0x0000000181529170
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181529160-0x0000000181529170
		public override object GetValue(object obj); // 0x0000000181529160-0x0000000181529170
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181529160-0x0000000181529170
		public override void SetValue(object obj, object val, BindingFlags invokeAttr, Binder binder, CultureInfo culture); // 0x0000000181529170-0x00000001815291B0
	}
}
