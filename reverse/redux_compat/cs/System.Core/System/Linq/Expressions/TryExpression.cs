/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	[DebuggerTypeProxy(typeof(TryExpressionProxy))]
	public sealed class TryExpression : Expression // TypeDefIndex: 12143
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _Type_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Expression _Body_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly ReadOnlyCollection<CatchBlock> _Handlers_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly Expression _Finally_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly Expression _Fault_k__BackingField; // 0x30
	
		// Properties
		public sealed override Type Type { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public sealed override ExpressionType NodeType { get; } // 0x00000001817C2DB0-0x00000001817C2DC0 
		public Expression Body { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public ReadOnlyCollection<CatchBlock> Handlers { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public Expression Finally { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		public Expression Fault { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
	
		// Constructors
		internal TryExpression(Type type, Expression body, Expression @finally, Expression fault, ReadOnlyCollection<CatchBlock> handlers); // 0x00000001817C2CE0-0x00000001817C2DB0
	
		// Methods
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x00000001817C2BB0-0x00000001817C2BE0
		public TryExpression Update(Expression body, IEnumerable<CatchBlock> handlers, Expression @finally, Expression fault); // 0x00000001817C2BE0-0x00000001817C2CE0
	}
}
