/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class Interpreter // TypeDefIndex: 12306
	{
		// Fields
		internal static readonly object NoValue; // 0x00
		private readonly InstructionArray _instructions; // 0x10
		internal readonly object[] _objects; // 0x38
		internal readonly RuntimeLabel[] _labels; // 0x40
		internal readonly DebugInfo[] _debugInfos; // 0x48
		[CompilerGenerated]
		private readonly string _Name_k__BackingField; // 0x50
		[CompilerGenerated]
		private readonly int _LocalCount_k__BackingField; // 0x58
		[CompilerGenerated]
		private readonly Dictionary<ParameterExpression, LocalVariable> _ClosureVariables_k__BackingField; // 0x60
	
		// Properties
		internal string Name { [CompilerGenerated] get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal int LocalCount { [CompilerGenerated] get; } // 0x000000018033D260-0x000000018033D270 
		internal int ClosureSize { get; } // 0x00000001817D0D90-0x00000001817D0DB0 
		internal InstructionArray Instructions { get; } // 0x0000000181102840-0x0000000181102860 
		internal Dictionary<ParameterExpression, LocalVariable> ClosureVariables { [CompilerGenerated] get; } // 0x0000000180333260-0x0000000180333490 
	
		// Constructors
		internal Interpreter(string name, LocalVariables locals, InstructionArray instructions, DebugInfo[] debugInfos); // 0x00000001817D0CC0-0x00000001817D0D90
		static Interpreter(); // 0x00000001817D0C50-0x00000001817D0CC0
	
		// Methods
		public void Run(InterpretedFrame frame); // 0x00000001817D0BE0-0x00000001817D0C50
	}
}
