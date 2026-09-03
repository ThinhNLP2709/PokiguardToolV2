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
	public class Int32Converter : BaseNumberConverter // TypeDefIndex: 8861
	{
		// Properties
		internal override Type TargetType { get; } // 0x0000000181BAB600-0x0000000181BAB640 
	
		// Constructors
		public Int32Converter(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		internal override object FromString(string value, int radix); // 0x0000000181BAB4D0-0x0000000181BAB540
		internal override object FromString(string value, NumberFormatInfo formatInfo); // 0x0000000181BAB540-0x0000000181BAB570
		internal override string ToString(object value, NumberFormatInfo formatInfo); // 0x0000000181BAB570-0x0000000181BAB600
	}
}
