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
	internal abstract class OffsetInstruction : Instruction // TypeDefIndex: 12185
	{
		// Fields
		protected int _offset; // 0x10
	
		// Properties
		public abstract Instruction[] Cache { get; }
	
		// Constructors
		protected OffsetInstruction(); // 0x00000001817AB100-0x00000001817AB110
	
		// Methods
		public Instruction Fixup(int offset); // 0x00000001817BF7D0-0x00000001817BF870
		public override string ToDebugString(int instructionIndex, object cookie, Func<int, int> labelIndexer, IReadOnlyList<object> objects); // 0x00000001817BF870-0x00000001817BF930
		public override string ToString(); // 0x00000001817BF930-0x00000001817BF9E0
	}
}
