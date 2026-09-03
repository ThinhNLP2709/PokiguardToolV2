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

namespace System.Runtime.CompilerServices
{
	public static class FormattableStringFactory // TypeDefIndex: 3195
	{
		// Nested types
		private sealed class ConcreteFormattableString : FormattableString // TypeDefIndex: 3196
		{
			// Fields
			private readonly string _format; // 0x10
			private readonly object[] _arguments; // 0x18
	
			// Properties
			public override string Format { get; } // 0x0000000180377550-0x0000000180377560 
			public override int ArgumentCount { get; } // 0x00000001814EA450-0x00000001814EA470 
	
			// Constructors
			internal ConcreteFormattableString(string format, object[] arguments); // 0x000000018150AEB0-0x000000018150AF00
	
			// Methods
			public override object[] GetArguments(); // 0x00000001802F8EC0-0x00000001802F8ED0
			public override object GetArgument(int index); // 0x00000001814EA230-0x00000001814EA260
			public override string ToString(IFormatProvider formatProvider); // 0x000000018150AE90-0x000000018150AEB0
		}
	
		// Methods
		public static FormattableString Create(string format, params object[] arguments); // 0x000000018150C730-0x000000018150C850
	}
}
