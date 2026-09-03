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
	[IsReadOnly]
	internal struct LocalDefinition // TypeDefIndex: 12388
	{
		// Fields
		[CompilerGenerated]
		private readonly int _Index_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly ParameterExpression _Parameter_k__BackingField; // 0x08
	
		// Properties
		public int Index { [CompilerGenerated] get; } // 0x0000000180732D10-0x0000000180732D20 
		public ParameterExpression Parameter { [CompilerGenerated] get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
	
		// Constructors
		internal LocalDefinition(int localIndex, ParameterExpression parameter); // 0x0000000180F37790-0x0000000180F377B0
	
		// Methods
		public override bool Equals(object obj); // 0x00000001817F3D90-0x00000001817F3E30
		public override int GetHashCode(); // 0x00000001817F3E30-0x00000001817F3E90
	}
}
