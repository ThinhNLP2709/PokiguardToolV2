/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	public abstract class ExpressionVisitor // TypeDefIndex: 12078
	{
		// Constructors
		protected ExpressionVisitor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual Expression Visit(Expression node); // 0x00000001817BAC00-0x00000001817BAC30
		public ReadOnlyCollection<Expression> Visit(ReadOnlyCollection<Expression> nodes); // 0x00000001817BAC30-0x00000001817BAF20
		private Expression[] VisitArguments(IArgumentProvider nodes); // 0x00000001817B9BB0-0x00000001817B9BC0
		private ParameterExpression[] VisitParameters(IParameterProvider nodes, string callerName); // 0x00000001817BA740-0x00000001817BA750
		public static ReadOnlyCollection<T> Visit<T>(ReadOnlyCollection<T> nodes, Func<T, T> elementVisitor);
		public T VisitAndConvert<T>(T node, string callerName)
			where T : Expression;
		public ReadOnlyCollection<T> VisitAndConvert<T>(ReadOnlyCollection<T> nodes, string callerName)
			where T : Expression;
		protected internal virtual Expression VisitBinary(BinaryExpression node); // 0x00000001817B9BC0-0x00000001817B9CB0
		protected internal virtual Expression VisitBlock(BlockExpression node); // 0x00000001817B9CB0-0x00000001817B9DA0
		protected internal virtual Expression VisitConditional(ConditionalExpression node); // 0x00000001817B9EE0-0x00000001817BA030
		protected internal virtual Expression VisitConstant(ConstantExpression node); // 0x0000000180A68C50-0x0000000180A68C60
		protected internal virtual Expression VisitDefault(DefaultExpression node); // 0x0000000180A68C50-0x0000000180A68C60
		protected internal virtual Expression VisitExtension(Expression node); // 0x00000001817AD360-0x00000001817AD390
		protected internal virtual Expression VisitGoto(GotoExpression node); // 0x00000001817BA030-0x00000001817BA120
		protected internal virtual Expression VisitInvocation(InvocationExpression node); // 0x00000001817BA1F0-0x00000001817BA290
		protected virtual LabelTarget VisitLabelTarget(LabelTarget node); // 0x0000000180A68C50-0x0000000180A68C60
		protected internal virtual Expression VisitLabel(LabelExpression node); // 0x00000001817BA290-0x00000001817BA350
		protected internal virtual Expression VisitLambda<T>(Expression<T> node);
		protected internal virtual Expression VisitLoop(LoopExpression node); // 0x00000001817BA350-0x00000001817BA440
		protected internal virtual Expression VisitMember(MemberExpression node); // 0x00000001817BA440-0x00000001817BA4F0
		protected internal virtual Expression VisitIndex(IndexExpression node); // 0x00000001817BA120-0x00000001817BA1F0
		protected internal virtual Expression VisitMethodCall(MethodCallExpression node); // 0x00000001817BA4F0-0x00000001817BA5C0
		protected internal virtual Expression VisitNewArray(NewArrayExpression node); // 0x00000001817BA5C0-0x00000001817BA740
		protected internal virtual Expression VisitParameter(ParameterExpression node); // 0x0000000180A68C50-0x0000000180A68C60
		protected virtual CatchBlock VisitCatchBlock(CatchBlock node); // 0x00000001817B9DA0-0x00000001817B9EE0
		protected internal virtual Expression VisitTry(TryExpression node); // 0x00000001817BA750-0x00000001817BA930
		protected internal virtual Expression VisitTypeBinary(TypeBinaryExpression node); // 0x00000001817BA930-0x00000001817BAA10
		protected internal virtual Expression VisitUnary(UnaryExpression node); // 0x00000001817BAA10-0x00000001817BAC00
		private static UnaryExpression ValidateUnary(UnaryExpression before, UnaryExpression after); // 0x00000001817B9A90-0x00000001817B9BB0
		private static BinaryExpression ValidateBinary(BinaryExpression before, BinaryExpression after); // 0x00000001817B9820-0x00000001817B99C0
		private static void ValidateChildType(Type before, Type after, string methodName); // 0x00000001817B99C0-0x00000001817B9A90
	}
}
