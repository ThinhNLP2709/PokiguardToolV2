/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class EnterExceptionFilterInstruction : Instruction // TypeDefIndex: 12198
	{
		// Fields
		internal static readonly EnterExceptionFilterInstruction Instance; // 0x00
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817AEFA0-0x00000001817AEFD0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		private EnterExceptionFilterInstruction(); // 0x00000001802F4070-0x00000001802F4080
		static EnterExceptionFilterInstruction(); // 0x00000001817AEF30-0x00000001817AEFA0
	
		// Methods
		[ExcludeFromCodeCoverage]
		public override int Run(InterpretedFrame frame); // 0x0000000180472790-0x00000001804727A0
	}
}
