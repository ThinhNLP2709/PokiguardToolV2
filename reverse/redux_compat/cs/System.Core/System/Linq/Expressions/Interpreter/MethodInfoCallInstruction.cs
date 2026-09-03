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
	internal class MethodInfoCallInstruction : CallInstruction // TypeDefIndex: 12183
	{
		// Fields
		protected readonly MethodInfo _target; // 0x10
		protected readonly int _argumentCount; // 0x18
	
		// Properties
		public override int ArgumentCount { get; } // 0x0000000180B23260-0x0000000180B23270 
		public override int ProducedStack { get; } // 0x00000001817ABEE0-0x00000001817ABF60 
	
		// Constructors
		internal MethodInfoCallInstruction(MethodInfo target, int argumentCount); // 0x00000001802E74A0-0x00000001802E74F0
	
		// Methods
		public override int Run(InterpretedFrame frame); // 0x00000001817BEE90-0x00000001817BF130
		protected object[] GetArgs(InterpretedFrame frame, int first, int skip); // 0x00000001817BED20-0x00000001817BEE90
		public override string ToString(); // 0x00000001817BF130-0x00000001817BF1B0
	}
}
