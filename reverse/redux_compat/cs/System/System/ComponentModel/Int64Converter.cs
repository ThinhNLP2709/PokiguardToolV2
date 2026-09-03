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
	public class Int64Converter : BaseNumberConverter // TypeDefIndex: 8862
	{
		// Properties
		internal override Type TargetType { get; } // 0x0000000181842780-0x00000001818427C0 
	
		// Constructors
		public Int64Converter(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		internal override object FromString(string value, int radix); // 0x0000000181BAB670-0x0000000181BAB6E0
		internal override object FromString(string value, NumberFormatInfo formatInfo); // 0x0000000181BAB640-0x0000000181BAB670
		internal override string ToString(object value, NumberFormatInfo formatInfo); // 0x0000000181BAB6E0-0x0000000181BAB770
	}
}
