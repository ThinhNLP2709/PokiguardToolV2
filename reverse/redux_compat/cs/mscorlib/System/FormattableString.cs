/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	public abstract class FormattableString : IFormattable // TypeDefIndex: 2246
	{
		// Properties
		public abstract string Format { get; }
		public abstract int ArgumentCount { get; }
	
		// Constructors
		protected FormattableString(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract object[] GetArguments();
		public abstract object GetArgument(int index);
		public abstract string ToString(IFormatProvider formatProvider);
		string IFormattable.ToString(string ignored, IFormatProvider formatProvider); // 0x00000001815F72F0-0x00000001815F7310
		public override string ToString(); // 0x00000001815F7310-0x00000001815F7360
	}
}
