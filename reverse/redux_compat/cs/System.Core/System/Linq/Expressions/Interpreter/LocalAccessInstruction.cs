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
	internal abstract class LocalAccessInstruction : Instruction // TypeDefIndex: 12366
	{
		// Fields
		internal readonly int _index; // 0x10
	
		// Constructors
		protected LocalAccessInstruction(int index); // 0x0000000181380310-0x0000000181380340
	
		// Methods
		public override string ToDebugString(int instructionIndex, object cookie, Func<int, int> labelIndexer, IReadOnlyList<object> objects); // 0x00000001817F3BC0-0x00000001817F3D90
	}
}
