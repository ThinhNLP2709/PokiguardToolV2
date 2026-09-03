/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class SetArrayItemInstruction : Instruction // TypeDefIndex: 12177
	{
		// Fields
		internal static readonly SetArrayItemInstruction Instance; // 0x00
	
		// Properties
		public override int ConsumedStack { get; } // 0x000000018071E4A0-0x000000018071E4B0 
		public override string InstructionName { get; } // 0x00000001817C06F0-0x00000001817C0720 
	
		// Constructors
		private SetArrayItemInstruction(); // 0x00000001802F4070-0x00000001802F4080
		static SetArrayItemInstruction(); // 0x00000001817C0680-0x00000001817C06F0
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817C05D0-0x00000001817C0680
	}
}
