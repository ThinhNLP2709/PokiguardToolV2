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
	internal sealed class LabelInfo // TypeDefIndex: 12307
	{
		// Fields
		private readonly LabelTarget _node; // 0x10
		private BranchLabel _label; // 0x18
		private object _definitions; // 0x20
		private readonly List<LabelScopeInfo> _references; // 0x28
		private bool _acrossBlockJump; // 0x30
	
		// Properties
		private bool HasDefinitions { get; } // 0x00000001817D1AF0-0x00000001817D1B00 
		private bool HasMultipleDefinitions { get; } // 0x00000001817D1B00-0x00000001817D1B80 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12308
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<LabelScopeInfo, LabelScopeInfo> __9__9_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001817E6D70-0x00000001817E7000
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal LabelScopeInfo _ValidateJump_b__9_0(LabelScopeInfo b); // 0x0000000180A67270-0x0000000180A67290
		}
	
		// Constructors
		internal LabelInfo(LabelTarget node); // 0x00000001817D1A50-0x00000001817D1AF0
	
		// Methods
		internal BranchLabel GetLabel(LightCompiler compiler); // 0x00000001817D1540-0x00000001817D1590
		internal void Reference(LabelScopeInfo block); // 0x00000001817D1590-0x00000001817D1650
		internal void Define(LabelScopeInfo block); // 0x00000001817D0EF0-0x00000001817D1290
		private void ValidateJump(LabelScopeInfo reference); // 0x00000001817D16C0-0x00000001817D1A50
		internal void ValidateFinish(); // 0x00000001817D1650-0x00000001817D16C0
		private void EnsureLabel(LightCompiler compiler); // 0x00000001817D1340-0x00000001817D1390
		private bool DefinedIn(LabelScopeInfo scope); // 0x00000001817D1290-0x00000001817D1340
		private LabelScopeInfo FirstDefinition(); // 0x00000001817D1390-0x00000001817D1540
		private void AddDefinition(LabelScopeInfo scope); // 0x00000001817D0DB0-0x00000001817D0EF0
		internal static T CommonNode<T>(T first, T second, Func<T, T> parent)
			where T : class;
	}
}
