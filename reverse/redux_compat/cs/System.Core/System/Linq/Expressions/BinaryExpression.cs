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

namespace System.Linq.Expressions
{
	[DebuggerTypeProxy(typeof(BinaryExpressionProxy))]
	public class BinaryExpression : Expression // TypeDefIndex: 12016
	{
		// Fields
		[CompilerGenerated]
		private readonly Expression _Right_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Expression _Left_k__BackingField; // 0x18
	
		// Properties
		public override bool CanReduce { get; } // 0x000000018178B570-0x000000018178B5A0 
		public Expression Right { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public Expression Left { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public MethodInfo Method { get; } // 0x000000018152D8E0-0x000000018152D900 
		public LambdaExpression Conversion { get; } // 0x000000018178B5A0-0x000000018178B5C0 
		public bool IsLifted { get; } // 0x000000018178B7A0-0x000000018178B940 
		public bool IsLiftedToNull { get; } // 0x000000018178B720-0x000000018178B7A0 
		internal bool IsLiftedLogical { get; } // 0x000000018178B5C0-0x000000018178B720 
		internal bool IsReferenceComparison { get; } // 0x000000018178B940-0x000000018178BA30 
	
		// Constructors
		internal BinaryExpression(Expression left, Expression right); // 0x000000018178B4E0-0x000000018178B570
	
		// Methods
		private static bool IsOpAssignment(ExpressionType op); // 0x00000001817898A0-0x00000001817898B0
		internal virtual MethodInfo GetMethod(); // 0x00000001802E7860-0x00000001802E7870
		public BinaryExpression Update(Expression left, LambdaExpression conversion, Expression right); // 0x000000018178AFA0-0x000000018178B4E0
		public override Expression Reduce(); // 0x000000018178AF20-0x000000018178AFA0
		private static ExpressionType GetBinaryOpFromAssignmentOp(ExpressionType op); // 0x0000000181789780-0x00000001817898A0
		private Expression ReduceVariable(); // 0x000000018178AE10-0x000000018178AF20
		private Expression ReduceMember(); // 0x0000000181789F60-0x000000018178A420
		private Expression ReduceIndex(); // 0x00000001817898B0-0x0000000181789F60
		internal virtual LambdaExpression GetConversion(); // 0x00000001802E7860-0x00000001802E7870
		protected internal override Expression Accept(ExpressionVisitor visitor); // 0x0000000181789750-0x0000000181789780
		internal Expression ReduceUserdefinedLifted(); // 0x000000018178A420-0x000000018178AE10
	}
}
