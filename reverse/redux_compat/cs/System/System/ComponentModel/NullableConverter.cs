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
	public class NullableConverter : TypeConverter // TypeDefIndex: 8870
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _NullableType_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Type _UnderlyingType_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly TypeConverter _UnderlyingTypeConverter_k__BackingField; // 0x20
	
		// Properties
		public Type NullableType { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public Type UnderlyingType { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public TypeConverter UnderlyingTypeConverter { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		public NullableConverter(Type type); // 0x0000000181BAE080-0x0000000181BAE1B0
	
		// Methods
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x0000000181BAD7C0-0x0000000181BAD870
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181BAD920-0x0000000181BADA50
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x0000000181BAD870-0x0000000181BAD920
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181BADA50-0x0000000181BADBF0
		public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues); // 0x0000000181BADBF0-0x0000000181BADC30
		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context); // 0x0000000181BADC30-0x0000000181BADC70
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes); // 0x0000000181BADCB0-0x0000000181BADD00
		public override bool GetPropertiesSupported(ITypeDescriptorContext context); // 0x0000000181BADC70-0x0000000181BADCB0
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context); // 0x0000000181BADD80-0x0000000181BAE030
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context); // 0x0000000181BADD00-0x0000000181BADD40
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context); // 0x0000000181BADD40-0x0000000181BADD80
		public override bool IsValid(ITypeDescriptorContext context, object value); // 0x0000000181BAE030-0x0000000181BAE080
	}
}
