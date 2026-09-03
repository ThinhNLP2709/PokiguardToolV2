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
	public class DecimalConverter : BaseNumberConverter // TypeDefIndex: 8839
	{
		// Properties
		internal override bool AllowHex { get; } // 0x00000001802E7840-0x00000001802E7850 
		internal override Type TargetType { get; } // 0x0000000181BA6C40-0x0000000181BA6C80 
	
		// Constructors
		public DecimalConverter(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType); // 0x0000000181BA66E0-0x0000000181BA6760
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType); // 0x0000000181BA6760-0x0000000181BA6A60
		internal override object FromString(string value, int radix); // 0x0000000181BA6AF0-0x0000000181BA6B90
		internal override object FromString(string value, NumberFormatInfo formatInfo); // 0x0000000181BA6A60-0x0000000181BA6AF0
		internal override string ToString(object value, NumberFormatInfo formatInfo); // 0x0000000181BA6B90-0x0000000181BA6C40
	}
}
