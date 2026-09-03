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
	internal sealed class BranchLabel // TypeDefIndex: 12181
	{
		// Fields
		private int _targetIndex; // 0x10
		private int _stackDepth; // 0x14
		private int _continuationStackDepth; // 0x18
		private List<int> _forwardBranchFixups; // 0x20
		[CompilerGenerated]
		private int _LabelIndex_k__BackingField; // 0x28
	
		// Properties
		internal int LabelIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		internal bool HasRuntimeLabel { get; } // 0x00000001817AB820-0x00000001817AB830 
		internal int TargetIndex { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public BranchLabel(); // 0x00000001817AB7F0-0x00000001817AB820
	
		// Methods
		internal RuntimeLabel ToRuntimeLabel(); // 0x00000001817AB7D0-0x00000001817AB7F0
		internal void Mark(InstructionList instructions); // 0x00000001817AB6B0-0x00000001817AB7D0
		internal void AddBranch(InstructionList instructions, int branchIndex); // 0x00000001817AB550-0x00000001817AB680
		internal void FixupBranch(InstructionList instructions, int branchIndex); // 0x00000001817AB680-0x00000001817AB6B0
	}
}
