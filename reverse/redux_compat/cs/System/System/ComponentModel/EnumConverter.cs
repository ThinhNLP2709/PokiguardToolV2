/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public class EnumConverter : TypeConverter // TypeDefIndex: 8905
	{
		// Fields
		private StandardValuesCollection values; // 0x10
		private Type type; // 0x18
	
		// Properties
		protected Type EnumType { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		protected StandardValuesCollection Values { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		protected virtual IComparer Comparer { get; } // 0x0000000181BA8EE0-0x0000000181BA8F30 
	
		// Constructors
		public EnumConverter(Type type); // 0x00000001818C1CC0-0x00000001818C1D00
	
		// Methods
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x0000000181BA77B0-0x0000000181BA7850
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x0000000181BA7850-0x0000000181BA78F0
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181BA78F0-0x0000000181BA7D90
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181BA7D90-0x0000000181BA8A10
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context); // 0x0000000181BA8A80-0x0000000181BA8EA0
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context); // 0x0000000181BA8A10-0x0000000181BA8A80
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
		public override bool IsValid(ITypeDescriptorContext context, object value); // 0x0000000181BA8EA0-0x0000000181BA8EE0
	}
}
