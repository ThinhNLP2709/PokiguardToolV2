/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class StringSwitchInstruction : Instruction // TypeDefIndex: 12204
	{
		// Fields
		private readonly Dictionary<string, int> _cases; // 0x10
		private readonly StrongBox<int> _nullCase; // 0x18
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817C0860-0x00000001817C0890 
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		internal StringSwitchInstruction(Dictionary<string, int> cases, StrongBox<int> nullCase); // 0x000000018150AEB0-0x000000018150AF00
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817C0790-0x00000001817C0860
	}
}
