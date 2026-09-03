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
	internal abstract class Instruction // TypeDefIndex: 12298
	{
		// Properties
		public virtual int ConsumedStack { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual int ProducedStack { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual int ConsumedContinuations { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual int ProducedContinuations { get; } // 0x00000001802E7860-0x00000001802E7870 
		public int StackBalance { get; } // 0x00000001817CF8C0-0x00000001817CF910 
		public int ContinuationsBalance { get; } // 0x00000001817CF870-0x00000001817CF8C0 
		public abstract string InstructionName { get; }
	
		// Constructors
		protected Instruction(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract int Run(InterpretedFrame frame);
		public override string ToString(); // 0x00000001817CF810-0x00000001817CF870
		public virtual string ToDebugString(int instructionIndex, object cookie, Func<int, int> labelIndexer, IReadOnlyList<object> objects); // 0x00000001815A1B20-0x00000001815A1B40
		protected static void NullCheck(object o); // 0x00000001806CDF70-0x00000001806CDF90
	}
}
