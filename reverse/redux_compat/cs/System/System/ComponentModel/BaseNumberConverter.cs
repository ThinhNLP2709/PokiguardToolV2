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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public abstract class BaseNumberConverter : TypeConverter // TypeDefIndex: 8827
	{
		// Properties
		internal virtual bool AllowHex { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal abstract Type TargetType { get; }
	
		// Constructors
		internal BaseNumberConverter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal abstract object FromString(string value, int radix);
		internal abstract object FromString(string value, NumberFormatInfo formatInfo);
		internal abstract string ToString(object value, NumberFormatInfo formatInfo);
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x0000000181B89BA0-0x0000000181B89C20
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181B89C60-0x0000000181B89FB0
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181B89FB0-0x0000000181B8A200
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x0000000181B89C20-0x0000000181B89C60
	}
}
