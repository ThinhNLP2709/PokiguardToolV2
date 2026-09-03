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
	internal sealed class ArrayByRefUpdater : ByRefUpdater // TypeDefIndex: 12357
	{
		// Fields
		private readonly LocalDefinition _array; // 0x18
		private readonly LocalDefinition _index; // 0x28
	
		// Constructors
		public ArrayByRefUpdater(LocalDefinition array, LocalDefinition index, int argumentIndex); // 0x00000001817E7150-0x00000001817E71C0
	
		// Methods
		public override void Update(InterpretedFrame frame, object value); // 0x00000001817E7090-0x00000001817E7150
		public override void UndefineTemps(InstructionList instructions, LocalVariables locals); // 0x00000001817E7000-0x00000001817E7090
	}
}
