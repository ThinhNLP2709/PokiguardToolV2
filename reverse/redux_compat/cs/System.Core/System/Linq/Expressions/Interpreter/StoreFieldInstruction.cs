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
	internal sealed class StoreFieldInstruction : FieldInstruction // TypeDefIndex: 12263
	{
		// Properties
		public override string InstructionName { get; } // 0x00000001817E6440-0x00000001817E6470 
		public override int ConsumedStack { get; } // 0x0000000180476390-0x00000001804763A0 
	
		// Constructors
		public StoreFieldInstruction(FieldInfo field); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817E63C0-0x00000001817E6440
	}
}
