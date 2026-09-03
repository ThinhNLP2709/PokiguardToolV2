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

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class ColumnTypeConverter : TypeConverter // TypeDefIndex: 11217
	{
		// Fields
		private static readonly Type[] s_types; // 0x00
		private StandardValuesCollection _values; // 0x10
	
		// Constructors
		public ColumnTypeConverter(); // 0x00000001802F4070-0x00000001802F4080
		static ColumnTypeConverter(); // 0x0000000181861FB0-0x0000000181862CF0
	
		// Methods
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x0000000181861750-0x00000001818617D0
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x00000001818619A0-0x0000000181861E90
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x00000001818616D0-0x0000000181861750
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x00000001818617D0-0x00000001818619A0
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context); // 0x0000000181861E90-0x0000000181861FB0
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
	}
}
