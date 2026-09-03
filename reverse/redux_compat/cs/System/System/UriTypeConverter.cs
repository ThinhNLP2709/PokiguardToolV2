/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System
{
	public class UriTypeConverter : TypeConverter // TypeDefIndex: 8686
	{
		// Constructors
		public UriTypeConverter(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		private bool CanConvert(Type type); // 0x0000000181B72FA0-0x0000000181B73020
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x0000000181B72EA0-0x0000000181B72F40
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x0000000181B72F40-0x0000000181B72FA0
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181B73020-0x0000000181B73200
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181B73200-0x0000000181B73470
	}
}
