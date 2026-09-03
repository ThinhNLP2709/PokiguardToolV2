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
	internal sealed class LoadFieldInstruction : FieldInstruction // TypeDefIndex: 12262
	{
		// Properties
		public override string InstructionName { get; } // 0x00000001817E62A0-0x00000001817E62D0 
		public override int ConsumedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public LoadFieldInstruction(FieldInfo field); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817E61B0-0x00000001817E62A0
	}
}
