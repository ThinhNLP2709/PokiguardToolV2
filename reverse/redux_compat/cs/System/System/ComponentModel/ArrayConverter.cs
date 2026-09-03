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
	public class ArrayConverter : CollectionConverter // TypeDefIndex: 8822
	{
		// Nested types
		private class ArrayPropertyDescriptor : TypeConverter.SimplePropertyDescriptor // TypeDefIndex: 8823
		{
			// Fields
			private readonly int _index; // 0x98
	
			// Constructors
			public ArrayPropertyDescriptor(Type arrayType, Type elementType, int index); // 0x0000000181B88BD0-0x0000000181B88C80
	
			// Methods
			public override object GetValue(object instance); // 0x0000000181B88A30-0x0000000181B88AB0
			public override void SetValue(object instance, object value); // 0x0000000181B88AB0-0x0000000181B88BD0
		}
	
		// Constructors
		public ArrayConverter(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181B88630-0x0000000181B887C0
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes); // 0x0000000181B887C0-0x0000000181B88A30
		public override bool GetPropertiesSupported(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
	}
}
