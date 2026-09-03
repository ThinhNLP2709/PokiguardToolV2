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
	internal sealed class LeaveExceptionFilterInstruction : Instruction // TypeDefIndex: 12199
	{
		// Fields
		internal static readonly LeaveExceptionFilterInstruction Instance; // 0x00
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817BD4F0-0x00000001817BD520 
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
	
		// Constructors
		private LeaveExceptionFilterInstruction(); // 0x00000001802F4070-0x00000001802F4080
		static LeaveExceptionFilterInstruction(); // 0x00000001817BD480-0x00000001817BD4F0
	
		// Methods
		[ExcludeFromCodeCoverage]
		public override int Run(InterpretedFrame frame); // 0x0000000180472790-0x00000001804727A0
	}
}
