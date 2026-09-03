/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class LabelScopeInfo // TypeDefIndex: 12310
	{
		// Fields
		private HybridReferenceDictionary<LabelTarget, LabelInfo> _labels; // 0x10
		internal readonly LabelScopeKind Kind; // 0x18
		internal readonly LabelScopeInfo Parent; // 0x20
	
		// Properties
		internal bool CanJumpInto { get; } // 0x00000001817D1D70-0x00000001817D1D80 
	
		// Constructors
		internal LabelScopeInfo(LabelScopeInfo parent, LabelScopeKind kind); // 0x00000001817D1D20-0x00000001817D1D70
	
		// Methods
		internal bool ContainsTarget(LabelTarget target); // 0x00000001817D1C30-0x00000001817D1C90
		internal bool TryGetLabelInfo(LabelTarget target, out LabelInfo info); // 0x00000001817D1C90-0x00000001817D1D20
		internal void AddLabelInfo(LabelTarget target, LabelInfo info); // 0x00000001817D1B80-0x00000001817D1C30
	}
}
