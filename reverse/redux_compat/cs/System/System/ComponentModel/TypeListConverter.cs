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
	public abstract class TypeListConverter : TypeConverter // TypeDefIndex: 8888
	{
		// Fields
		private readonly Type[] _types; // 0x10
		private StandardValuesCollection _values; // 0x18
	
		// Constructors
		protected TypeListConverter(Type[] types); // 0x00000001802E7420-0x00000001802E7460
	
		// Methods
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x0000000181B8AF30-0x0000000181B8AFB0
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x000000018189D6C0-0x000000018189D740
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181BC0360-0x0000000181BC0460
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181BC0460-0x0000000181BC05D0
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context); // 0x0000000181BC05D0-0x0000000181BC06A0
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
	}
}
