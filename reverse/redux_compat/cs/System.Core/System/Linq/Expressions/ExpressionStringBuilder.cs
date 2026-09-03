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
using System.Text;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	internal sealed class ExpressionStringBuilder : ExpressionVisitor // TypeDefIndex: 12076
	{
		// Fields
		private readonly StringBuilder _out; // 0x10
		private Dictionary<object, int> _ids; // 0x18
	
		// Constructors
		private ExpressionStringBuilder(); // 0x00000001817B97D0-0x00000001817B9820
	
		// Methods
		public override string ToString(); // 0x00000001817B7610-0x00000001817B7640
		private int GetLabelId(LabelTarget label); // 0x00000001817B7410-0x00000001817B7420
		private int GetParamId(ParameterExpression p); // 0x00000001817B7410-0x00000001817B7420
		private int GetId(object o); // 0x00000001817B7310-0x00000001817B7410
		private void Out(string s); // 0x00000001817B75D0-0x00000001817B75F0
		private void Out(char c); // 0x00000001817B75F0-0x00000001817B7610
		internal static string ExpressionToString(Expression node); // 0x00000001817B7250-0x00000001817B7310
		internal static string CatchBlockToString(CatchBlock node); // 0x00000001817AC8F0-0x00000001817AC9B0
		private void VisitExpressions<T>(char open, ReadOnlyCollection<T> expressions, char close)
			where T : Expression;
		private void VisitExpressions<T>(char open, ReadOnlyCollection<T> expressions, char close, string seperator)
			where T : Expression;
		protected internal override Expression VisitBinary(BinaryExpression node); // 0x00000001817B7640-0x00000001817B7C70
		protected internal override Expression VisitParameter(ParameterExpression node); // 0x00000001817B9030-0x00000001817B9130
		protected internal override Expression VisitLambda<T>(Expression<T> node);
		protected internal override Expression VisitConditional(ConditionalExpression node); // 0x00000001817B8070-0x00000001817B8190
		protected internal override Expression VisitConstant(ConstantExpression node); // 0x00000001817B8190-0x00000001817B8350
		private void OutMember(Expression instance, MemberInfo member); // 0x00000001817B74F0-0x00000001817B75D0
		protected internal override Expression VisitMember(MemberExpression node); // 0x00000001817B8BE0-0x00000001817B8D00
		protected internal override Expression VisitInvocation(InvocationExpression node); // 0x00000001817B89B0-0x00000001817B8AF0
		protected internal override Expression VisitMethodCall(MethodCallExpression node); // 0x00000001817B8D00-0x00000001817B8EF0
		protected internal override Expression VisitNewArray(NewArrayExpression node); // 0x00000001817B8EF0-0x00000001817B9030
		protected internal override Expression VisitTypeBinary(TypeBinaryExpression node); // 0x00000001817B9190-0x00000001817B92B0
		protected internal override Expression VisitUnary(UnaryExpression node); // 0x00000001817B92B0-0x00000001817B97D0
		protected internal override Expression VisitBlock(BlockExpression node); // 0x00000001817B7C70-0x00000001817B7F60
		protected internal override Expression VisitDefault(DefaultExpression node); // 0x00000001817B8350-0x00000001817B8410
		protected internal override Expression VisitLabel(LabelExpression node); // 0x00000001817B8AF0-0x00000001817B8B80
		protected internal override Expression VisitGoto(GotoExpression node); // 0x00000001817B8620-0x00000001817B87B0
		protected internal override Expression VisitLoop(LoopExpression node); // 0x00000001817B8B80-0x00000001817B8BE0
		protected override CatchBlock VisitCatchBlock(CatchBlock node); // 0x00000001817B7F60-0x00000001817B8070
		protected internal override Expression VisitTry(TryExpression node); // 0x00000001817B9130-0x00000001817B9190
		protected internal override Expression VisitIndex(IndexExpression node); // 0x00000001817B87B0-0x00000001817B89B0
		protected internal override Expression VisitExtension(Expression node); // 0x00000001817B8410-0x00000001817B8620
		private void DumpLabel(LabelTarget target); // 0x00000001817B7190-0x00000001817B7250
		private static bool IsBool(Expression node); // 0x00000001817B7420-0x00000001817B74F0
	}
}
