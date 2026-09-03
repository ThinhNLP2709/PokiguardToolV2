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
	public class DoubleConverter : BaseNumberConverter // TypeDefIndex: 8845
	{
		// Properties
		internal override bool AllowHex { get; } // 0x00000001802E7840-0x00000001802E7850 
		internal override Type TargetType { get; } // 0x0000000181BA7590-0x0000000181BA75D0 
	
		// Constructors
		public DoubleConverter(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		internal override object FromString(string value, int radix); // 0x0000000181BA7440-0x0000000181BA74D0
		internal override object FromString(string value, NumberFormatInfo formatInfo); // 0x0000000181BA74D0-0x0000000181BA7500
		internal override string ToString(object value, NumberFormatInfo formatInfo); // 0x0000000181BA7500-0x0000000181BA7590
	}
}
