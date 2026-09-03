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
	internal sealed class DupInstruction : Instruction // TypeDefIndex: 12491
	{
		// Fields
		internal static readonly DupInstruction Instance; // 0x00
	
		// Properties
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817EB8E0-0x00000001817EB910 
	
		// Constructors
		private DupInstruction(); // 0x00000001802F4070-0x00000001802F4080
		static DupInstruction(); // 0x00000001817EB870-0x00000001817EB8E0
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817EB840-0x00000001817EB870
	}
}
