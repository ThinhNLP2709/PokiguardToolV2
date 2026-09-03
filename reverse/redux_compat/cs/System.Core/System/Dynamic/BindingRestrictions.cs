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

namespace System.Dynamic
{
	[DebuggerDisplay("{DebugView}")]
	[DebuggerTypeProxy(typeof(BindingRestrictionsProxy))]
	public abstract class BindingRestrictions // TypeDefIndex: 12550
	{
		// Fields
		public static readonly BindingRestrictions Empty; // 0x00
	
		// Nested types
		private sealed class TestBuilder // TypeDefIndex: 12551
		{
			// Fields
			private readonly HashSet<BindingRestrictions> _unique; // 0x10
			private readonly Stack<AndNode> _tests; // 0x18
	
			// Nested types
			private struct AndNode // TypeDefIndex: 12552
			{
				// Fields
				internal int Depth; // 0x00
				internal Expression Node; // 0x08
			}
	
			// Constructors
			public TestBuilder(); // 0x0000000181800D10-0x0000000181800DD0
	
			// Methods
			internal void Append(BindingRestrictions restrictions); // 0x00000001818008C0-0x0000000181800AA0
			internal Expression ToExpression(); // 0x0000000181800C20-0x0000000181800D10
			private void Push(Expression node, int depth); // 0x0000000181800AA0-0x0000000181800C20
		}
	
		private sealed class MergedRestriction : BindingRestrictions // TypeDefIndex: 12553
		{
			// Fields
			internal readonly BindingRestrictions Left; // 0x10
			internal readonly BindingRestrictions Right; // 0x18
	
			// Constructors
			internal MergedRestriction(BindingRestrictions left, BindingRestrictions right); // 0x00000001817F49A0-0x00000001817F4A30
	
			// Methods
			internal override Expression GetExpression(); // 0x00000001817F4720-0x00000001817F49A0
		}
	
		private sealed class CustomRestriction : BindingRestrictions // TypeDefIndex: 12554
		{
			// Fields
			private readonly Expression _expression; // 0x10
	
			// Constructors
			internal CustomRestriction(Expression expression); // 0x00000001817EA480-0x00000001817EA4F0
	
			// Methods
			public override bool Equals(object obj); // 0x00000001817EA3F0-0x00000001817EA450
			public override int GetHashCode(); // 0x00000001817EA450-0x00000001817EA480
			internal override Expression GetExpression(); // 0x0000000180377550-0x0000000180377560
		}
	
		private sealed class TypeRestriction : BindingRestrictions // TypeDefIndex: 12555
		{
			// Fields
			private readonly Expression _expression; // 0x10
			private readonly Type _type; // 0x18
	
			// Constructors
			internal TypeRestriction(Expression parameter, Type type); // 0x0000000181801640-0x00000001818016D0
	
			// Methods
			public override bool Equals(object obj); // 0x00000001818014D0-0x0000000181801580
			public override int GetHashCode(); // 0x00000001818015E0-0x0000000181801640
			internal override Expression GetExpression(); // 0x0000000181801580-0x00000001818015E0
		}
	
		private sealed class InstanceRestriction : BindingRestrictions // TypeDefIndex: 12556
		{
			// Fields
			private readonly Expression _expression; // 0x10
			private readonly object _instance; // 0x18
	
			// Constructors
			internal InstanceRestriction(Expression parameter, object instance); // 0x00000001817F0DB0-0x00000001817F0E40
	
			// Methods
			public override bool Equals(object obj); // 0x00000001817F0940-0x00000001817F09D0
			public override int GetHashCode(); // 0x00000001817F0D60-0x00000001817F0DB0
			internal override Expression GetExpression(); // 0x00000001817F09D0-0x00000001817F0D60
		}
	
		private sealed class BindingRestrictionsProxy // TypeDefIndex: 12557
		{
		}
	
		// Constructors
		private BindingRestrictions(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static BindingRestrictions(); // 0x00000001817E7BF0-0x00000001817E7CE0
	
		// Methods
		internal abstract Expression GetExpression();
		public BindingRestrictions Merge(BindingRestrictions restrictions); // 0x00000001817E7AC0-0x00000001817E7BF0
		public static BindingRestrictions GetTypeRestriction(Expression expression, Type type); // 0x00000001817E79D0-0x00000001817E7AC0
		internal static BindingRestrictions GetTypeRestriction(DynamicMetaObject obj); // 0x00000001817E76B0-0x00000001817E79D0
		public static BindingRestrictions GetInstanceRestriction(Expression expression, object instance); // 0x00000001817E75E0-0x00000001817E76B0
		public Expression ToExpression(); // 0x00000001816197C0-0x00000001816197E0
	}
}
