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
	public class ReferenceConverter : TypeConverter // TypeDefIndex: 8875
	{
		// Fields
		private static readonly string s_none; // 0x00
		private Type _type; // 0x10
	
		// Nested types
		private class ReferenceComparer : IComparer // TypeDefIndex: 8876
		{
			// Fields
			private ReferenceConverter _converter; // 0x10
	
			// Constructors
			public ReferenceComparer(ReferenceConverter converter); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public int Compare(object item1, object item2); // 0x0000000181BB1410-0x0000000181BB14A0
		}
	
		// Constructors
		public ReferenceConverter(Type type); // 0x00000001802E7420-0x00000001802E7460
		static ReferenceConverter(); // 0x0000000181BB2030-0x0000000181BB20A0
	
		// Methods
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType); // 0x0000000181BB14A0-0x0000000181BB1530
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value); // 0x0000000181BB1530-0x0000000181BB17A0
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181BB17A0-0x0000000181BB1AC0
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context); // 0x0000000181BB1AC0-0x0000000181BB2030
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context); // 0x00000001802E7990-0x00000001802E79A0
		protected virtual bool IsValueAllowed(ITypeDescriptorContext context, object value); // 0x00000001802E7990-0x00000001802E79A0
	}
}
