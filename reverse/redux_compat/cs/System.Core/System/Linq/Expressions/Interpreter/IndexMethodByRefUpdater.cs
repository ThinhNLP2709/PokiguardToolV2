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
	internal sealed class IndexMethodByRefUpdater : ByRefUpdater // TypeDefIndex: 12360
	{
		// Fields
		private readonly MethodInfo _indexer; // 0x18
		private readonly LocalDefinition? _obj; // 0x20
		private readonly LocalDefinition[] _args; // 0x38
	
		// Constructors
		public IndexMethodByRefUpdater(LocalDefinition? obj, LocalDefinition[] args, MethodInfo indexer, int argumentIndex); // 0x00000001817F08C0-0x00000001817F0940
	
		// Methods
		public override void Update(InterpretedFrame frame, object value); // 0x00000001817F0680-0x00000001817F08C0
		public override void UndefineTemps(InstructionList instructions, LocalVariables locals); // 0x00000001817F04D0-0x00000001817F0680
	}
}
