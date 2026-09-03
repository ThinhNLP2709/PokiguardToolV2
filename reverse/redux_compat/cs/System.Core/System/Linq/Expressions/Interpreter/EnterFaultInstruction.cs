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
	internal sealed class EnterFaultInstruction : IndexedBranchInstruction // TypeDefIndex: 12196
	{
		// Fields
		private static readonly EnterFaultInstruction[] s_cache; // 0x00
	
		// Properties
		public override string InstructionName { get; } // 0x00000001817AF2B0-0x00000001817AF2E0 
		public override int ProducedStack { get; } // 0x0000000180476390-0x00000001804763A0 
	
		// Constructors
		private EnterFaultInstruction(int labelIndex); // 0x0000000181380310-0x0000000181380340
		static EnterFaultInstruction(); // 0x00000001817AF240-0x00000001817AF2B0
	
		// Methods
		internal static EnterFaultInstruction Create(int labelIndex); // 0x00000001817AF0D0-0x00000001817AF1C0
		public override int Run(InterpretedFrame frame); // 0x00000001817AF1C0-0x00000001817AF240
	}
}
