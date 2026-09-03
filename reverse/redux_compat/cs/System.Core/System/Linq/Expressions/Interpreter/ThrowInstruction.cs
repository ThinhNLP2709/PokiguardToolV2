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
	internal sealed class ThrowInstruction : Instruction // TypeDefIndex: 12202
	{
		// Fields
		internal static readonly ThrowInstruction Throw; // 0x00
		internal static readonly ThrowInstruction VoidThrow; // 0x08
		internal static readonly ThrowInstruction Rethrow; // 0x10
		internal static readonly ThrowInstruction VoidRethrow; // 0x18
		private readonly bool _hasResult; // 0x10
		private readonly bool _rethrow; // 0x11
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817C2B80-0x00000001817C2BB0 
		public override int ProducedStack { get; } // 0x00000001817AF090-0x00000001817AF0A0 
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		private ThrowInstruction(bool hasResult, bool isRethrow); // 0x00000001817C2B40-0x00000001817C2B80
		static ThrowInstruction(); // 0x00000001817C29F0-0x00000001817C2B40
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817C2830-0x00000001817C2950
		private static Exception WrapThrownObject(object thrown); // 0x00000001817C2950-0x00000001817C29F0
	}
}
