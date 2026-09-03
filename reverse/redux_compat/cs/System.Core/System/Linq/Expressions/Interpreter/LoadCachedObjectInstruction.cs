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
	internal sealed class LoadCachedObjectInstruction : Instruction // TypeDefIndex: 12489
	{
		// Fields
		private readonly uint _index; // 0x10
	
		// Properties
		public override int ProducedStack { get; } // 0x0000000180472790-0x00000001804727A0 
		public override string InstructionName { get; } // 0x00000001817F35A0-0x00000001817F35D0 
	
		// Constructors
		internal LoadCachedObjectInstruction(uint index); // 0x0000000181380310-0x0000000181380340
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817F3360-0x00000001817F3410
		public override string ToDebugString(int instructionIndex, object cookie, Func<int, int> labelIndexer, IReadOnlyList<object> objects); // 0x00000001817F3410-0x00000001817F3540
		public override string ToString(); // 0x00000001817F3540-0x00000001817F35A0
	}
}
