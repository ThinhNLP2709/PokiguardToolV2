/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic.Utils;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions
{
	public abstract class Expression // TypeDefIndex: 12023
	{
		// Fields
		private static readonly CacheDict<Type, MethodInfo> s_lambdaDelegateCache; // 0x00
		private static CacheDict<Type, Func<Expression, string, bool, ReadOnlyCollection<ParameterExpression>, LambdaExpression>> s_lambdaFactories; // 0x08
		private static ConditionalWeakTable<Expression, ExtensionInfo> s_legacyCtorSupportTable; // 0x10
	
		// Properties
		public virtual ExpressionType NodeType { get; } // 0x00000001817A6680-0x00000001817A6750 
		public virtual Type Type { get; } // 0x00000001817A6750-0x00000001817A6820 
		public virtual bool CanReduce { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		internal class BinaryExpressionProxy // TypeDefIndex: 12024
		{
		}
	
		internal class BlockExpressionProxy // TypeDefIndex: 12025
		{
		}
	
		internal class CatchBlockProxy // TypeDefIndex: 12026
		{
		}
	
		internal class ConditionalExpressionProxy // TypeDefIndex: 12027
		{
		}
	
		internal class ConstantExpressionProxy // TypeDefIndex: 12028
		{
		}
	
		internal class DebugInfoExpressionProxy // TypeDefIndex: 12029
		{
		}
	
		internal class DefaultExpressionProxy // TypeDefIndex: 12030
		{
		}
	
		internal class GotoExpressionProxy // TypeDefIndex: 12031
		{
		}
	
		internal class IndexExpressionProxy // TypeDefIndex: 12032
		{
		}
	
		internal class InvocationExpressionProxy // TypeDefIndex: 12033
		{
		}
	
		internal class LabelExpressionProxy // TypeDefIndex: 12034
		{
		}
	
		internal class LambdaExpressionProxy // TypeDefIndex: 12035
		{
		}
	
		internal class ListInitExpressionProxy // TypeDefIndex: 12036
		{
		}
	
		internal class LoopExpressionProxy // TypeDefIndex: 12037
		{
		}
	
		internal class MemberExpressionProxy // TypeDefIndex: 12038
		{
		}
	
		internal class MemberInitExpressionProxy // TypeDefIndex: 12039
		{
		}
	
		internal class MethodCallExpressionProxy // TypeDefIndex: 12040
		{
		}
	
		internal class NewArrayExpressionProxy // TypeDefIndex: 12041
		{
		}
	
		internal class NewExpressionProxy // TypeDefIndex: 12042
		{
		}
	
		internal class ParameterExpressionProxy // TypeDefIndex: 12043
		{
		}
	
		internal class RuntimeVariablesExpressionProxy // TypeDefIndex: 12044
		{
		}
	
		internal class SwitchCaseProxy // TypeDefIndex: 12045
		{
		}
	
		internal class SwitchExpressionProxy // TypeDefIndex: 12046
		{
		}
	
		internal class TryExpressionProxy // TypeDefIndex: 12047
		{
		}
	
		internal class TypeBinaryExpressionProxy // TypeDefIndex: 12048
		{
		}
	
		internal class UnaryExpressionProxy // TypeDefIndex: 12049
		{
		}
	
		private class ExtensionInfo // TypeDefIndex: 12050
		{
			// Fields
			internal readonly ExpressionType NodeType; // 0x10
			internal readonly Type Type; // 0x18
		}
	
		// Constructors
		protected Expression(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static Expression(); // 0x00000001817A65F0-0x00000001817A6680
	
		// Methods
		public static BinaryExpression Assign(Expression left, Expression right); // 0x000000018178EA20-0x000000018178EC20
		private static BinaryExpression GetUserDefinedBinaryOperator(ExpressionType binaryType, string name, Expression left, Expression right, bool liftToNull); // 0x00000001817968D0-0x0000000181796C50
		private static BinaryExpression GetMethodBasedBinaryOperator(ExpressionType binaryType, Expression left, Expression right, MethodInfo method, bool liftToNull); // 0x0000000181795130-0x00000001817956A0
		private static BinaryExpression GetMethodBasedAssignOperator(ExpressionType binaryType, Expression left, Expression right, MethodInfo method, LambdaExpression conversion, bool liftToNull); // 0x0000000181794E80-0x0000000181795130
		private static BinaryExpression GetUserDefinedBinaryOperatorOrThrow(ExpressionType binaryType, string name, Expression left, Expression right, bool liftToNull); // 0x0000000181796680-0x00000001817968D0
		private static BinaryExpression GetUserDefinedAssignOperatorOrThrow(ExpressionType binaryType, string name, Expression left, Expression right, LambdaExpression conversion, bool liftToNull); // 0x00000001817963D0-0x0000000181796680
		private static MethodInfo GetUserDefinedBinaryOperator(ExpressionType binaryType, Type leftType, Type rightType, string name); // 0x0000000181796C50-0x0000000181796EC0
		private static bool IsLiftingConditionalLogicalOperator(Type left, Type right, MethodInfo method, ExpressionType binaryType); // 0x00000001817992A0-0x0000000181799350
		internal static bool ParameterIsAssignable(ParameterInfo pi, Type argType); // 0x000000018179FD20-0x000000018179FDD0
		private static void ValidateParamswithOperandsOrThrow(Type paramType, Type operandType, ExpressionType exprType, string name); // 0x00000001817A4F70-0x00000001817A5040
		private static void ValidateOperator(MethodInfo method); // 0x00000001817A4DC0-0x00000001817A4F70
		private static void ValidateMethodInfo(MethodInfo method, string paramName); // 0x00000001817A4A60-0x00000001817A4AF0
		private static bool IsNullComparison(Expression left, Expression right); // 0x0000000181799350-0x0000000181799510
		private static bool IsNullConstant(Expression e); // 0x0000000181799510-0x0000000181799580
		private static void ValidateUserDefinedConditionalLogicOperator(ExpressionType nodeType, Type left, Type right, MethodInfo method); // 0x00000001817A57E0-0x00000001817A5F60
		private static void VerifyOpTrueFalse(ExpressionType nodeType, Type left, MethodInfo opTrue, string paramName); // 0x00000001817A6280-0x00000001817A6430
		private static bool IsValidLiftedConditionalLogicalOperator(Type left, Type right, ParameterInfo[] pms); // 0x00000001817997D0-0x00000001817998B0
		public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right, bool liftToNull, MethodInfo method); // 0x000000018179B400-0x000000018179B490
		public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right, bool liftToNull, MethodInfo method, LambdaExpression conversion); // 0x000000018179A640-0x000000018179B400
		public static BinaryExpression Equal(Expression left, Expression right); // 0x0000000181793990-0x0000000181793A00
		public static BinaryExpression Equal(Expression left, Expression right, bool liftToNull, MethodInfo method); // 0x0000000181793A00-0x0000000181793B20
		public static BinaryExpression ReferenceEqual(Expression left, Expression right); // 0x00000001817A0F80-0x00000001817A1110
		public static BinaryExpression NotEqual(Expression left, Expression right); // 0x000000018179ED80-0x000000018179EDF0
		public static BinaryExpression NotEqual(Expression left, Expression right, bool liftToNull, MethodInfo method); // 0x000000018179EDF0-0x000000018179EF10
		public static BinaryExpression ReferenceNotEqual(Expression left, Expression right); // 0x00000001817A1110-0x00000001817A12A0
		private static BinaryExpression GetEqualityComparisonOperator(ExpressionType binaryType, string opName, Expression left, Expression right, bool liftToNull); // 0x00000001817948C0-0x0000000181794CA0
		public static BinaryExpression GreaterThan(Expression left, Expression right, bool liftToNull, MethodInfo method); // 0x00000001817977D0-0x00000001817978F0
		public static BinaryExpression LessThan(Expression left, Expression right, bool liftToNull, MethodInfo method); // 0x000000018179A400-0x000000018179A520
		public static BinaryExpression GreaterThanOrEqual(Expression left, Expression right, bool liftToNull, MethodInfo method); // 0x00000001817976B0-0x00000001817977D0
		public static BinaryExpression LessThanOrEqual(Expression left, Expression right, bool liftToNull, MethodInfo method); // 0x000000018179A2E0-0x000000018179A400
		private static BinaryExpression GetComparisonOperator(ExpressionType binaryType, string opName, Expression left, Expression right, bool liftToNull); // 0x00000001817946C0-0x00000001817948C0
		public static BinaryExpression AndAlso(Expression left, Expression right); // 0x000000018178DBA0-0x000000018178DC00
		public static BinaryExpression AndAlso(Expression left, Expression right, MethodInfo method); // 0x000000018178D690-0x000000018178DBA0
		public static BinaryExpression OrElse(Expression left, Expression right, MethodInfo method); // 0x000000018179F540-0x000000018179FAD0
		public static BinaryExpression Coalesce(Expression left, Expression right, LambdaExpression conversion); // 0x0000000181791B80-0x00000001817921C0
		private static Type ValidateCoalesceArgTypes(Type left, Type right); // 0x00000001817A3670-0x00000001817A37C0
		public static BinaryExpression Add(Expression left, Expression right, MethodInfo method); // 0x000000018178D440-0x000000018178D690
		public static BinaryExpression AddAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x000000018178CF70-0x000000018178D1F0
		private static void ValidateOpAssignConversionLambda(LambdaExpression conversion, Expression left, MethodInfo method, ExpressionType nodeType); // 0x00000001817A4B30-0x00000001817A4DC0
		public static BinaryExpression AddAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x000000018178CCF0-0x000000018178CF70
		public static BinaryExpression AddChecked(Expression left, Expression right, MethodInfo method); // 0x000000018178D1F0-0x000000018178D440
		public static BinaryExpression Subtract(Expression left, Expression right, MethodInfo method); // 0x00000001817A2330-0x00000001817A2580
		public static BinaryExpression SubtractAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x00000001817A1E60-0x00000001817A20E0
		public static BinaryExpression SubtractAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x00000001817A1BE0-0x00000001817A1E60
		public static BinaryExpression SubtractChecked(Expression left, Expression right, MethodInfo method); // 0x00000001817A20E0-0x00000001817A2330
		public static BinaryExpression Divide(Expression left, Expression right, MethodInfo method); // 0x00000001817936C0-0x0000000181793910
		public static BinaryExpression DivideAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x0000000181793440-0x00000001817936C0
		public static BinaryExpression Modulo(Expression left, Expression right, MethodInfo method); // 0x000000018179D6A0-0x000000018179D8F0
		public static BinaryExpression ModuloAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x000000018179D420-0x000000018179D6A0
		public static BinaryExpression Multiply(Expression left, Expression right, MethodInfo method); // 0x000000018179E040-0x000000018179E290
		public static BinaryExpression MultiplyAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x000000018179DB70-0x000000018179DDF0
		public static BinaryExpression MultiplyAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x000000018179D8F0-0x000000018179DB70
		public static BinaryExpression MultiplyChecked(Expression left, Expression right, MethodInfo method); // 0x000000018179DDF0-0x000000018179E040
		private static bool IsSimpleShift(Type left, Type right); // 0x0000000181799580-0x0000000181799630
		private static Type GetResultTypeOfShift(Type left, Type right); // 0x0000000181796280-0x00000001817963D0
		public static BinaryExpression LeftShift(Expression left, Expression right, MethodInfo method); // 0x000000018179A0C0-0x000000018179A2E0
		public static BinaryExpression LeftShiftAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x0000000181799E80-0x000000018179A0C0
		public static BinaryExpression RightShift(Expression left, Expression right, MethodInfo method); // 0x00000001817A19C0-0x00000001817A1BE0
		public static BinaryExpression RightShiftAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x00000001817A1780-0x00000001817A19C0
		public static BinaryExpression And(Expression left, Expression right, MethodInfo method); // 0x000000018178DE80-0x000000018178E0D0
		public static BinaryExpression AndAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x000000018178DC00-0x000000018178DE80
		public static BinaryExpression Or(Expression left, Expression right, MethodInfo method); // 0x000000018179FAD0-0x000000018179FD20
		public static BinaryExpression OrAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x000000018179F2C0-0x000000018179F540
		public static BinaryExpression ExclusiveOr(Expression left, Expression right, MethodInfo method); // 0x0000000181793DA0-0x0000000181793FF0
		public static BinaryExpression ExclusiveOrAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x0000000181793B20-0x0000000181793DA0
		public static BinaryExpression Power(Expression left, Expression right, MethodInfo method); // 0x00000001817A01B0-0x00000001817A0580
		public static BinaryExpression PowerAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion); // 0x00000001817A0020-0x00000001817A01B0
		public static BinaryExpression ArrayIndex(Expression array, Expression index); // 0x000000018178E600-0x000000018178E820
		public static BlockExpression Block(Expression arg0, Expression arg1); // 0x000000018178F5A0-0x000000018178F640
		public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2); // 0x000000018178F7E0-0x000000018178F8C0
		public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2, Expression arg3); // 0x000000018178F490-0x000000018178F5A0
		public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4); // 0x000000018178F6B0-0x000000018178F7E0
		public static BlockExpression Block(IEnumerable<Expression> expressions); // 0x000000018178FA30-0x000000018178FAC0
		public static BlockExpression Block(Type type, params Expression[] expressions); // 0x000000018178F390-0x000000018178F490
		public static BlockExpression Block(Type type, IEnumerable<Expression> expressions); // 0x000000018178F2F0-0x000000018178F390
		public static BlockExpression Block(IEnumerable<ParameterExpression> variables, params Expression[] expressions); // 0x000000018178FAC0-0x000000018178FB20
		public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, params Expression[] expressions); // 0x000000018178F640-0x000000018178F6B0
		public static BlockExpression Block(IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions); // 0x000000018178F8C0-0x000000018178FA30
		public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions); // 0x000000018178F100-0x000000018178F2F0
		private static BlockExpression BlockCore(Type type, ReadOnlyCollection<ParameterExpression> variables, ReadOnlyCollection<Expression> expressions); // 0x000000018178EC20-0x000000018178F100
		internal static void ValidateVariables(ReadOnlyCollection<ParameterExpression> varList, string collectionName); // 0x00000001817A5F60-0x00000001817A6110
		private static BlockExpression GetOptimizedBlockExpression(IReadOnlyList<Expression> expressions); // 0x0000000181795E10-0x0000000181796270
		public static CatchBlock MakeCatchBlock(Type type, ParameterExpression variable, Expression body, Expression filter); // 0x000000018179B490-0x000000018179B710
		public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse); // 0x0000000181792400-0x0000000181792610
		public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse, Type type); // 0x00000001817921C0-0x0000000181792400
		public static ConditionalExpression IfThen(Expression test, Expression ifTrue); // 0x00000001817978F0-0x0000000181797A00
		public static ConstantExpression Constant(object value); // 0x0000000181792830-0x0000000181792890
		public static ConstantExpression Constant(object value, Type type); // 0x0000000181792610-0x0000000181792830
		public static DefaultExpression Empty(); // 0x0000000181793910-0x0000000181793990
		public static DefaultExpression Default(Type type); // 0x0000000181793390-0x0000000181793440
		public virtual Expression Reduce(); // 0x00000001817A0F30-0x00000001817A0F80
		protected internal virtual Expression VisitChildren(ExpressionVisitor visitor); // 0x00000001817A6430-0x00000001817A65F0
		protected internal virtual Expression Accept(ExpressionVisitor visitor); // 0x000000018178CCC0-0x000000018178CCF0
		public Expression ReduceAndCheck(); // 0x00000001817A0DE0-0x00000001817A0F30
		public override string ToString(); // 0x00000001817A26D0-0x00000001817A26E0
		private static void RequiresCanRead(IReadOnlyList<Expression> items, string paramName); // 0x00000001817A12A0-0x00000001817A13C0
		private static void RequiresCanWrite(Expression expression, string paramName); // 0x00000001817A13C0-0x00000001817A1650
		public static GotoExpression Break(LabelTarget target); // 0x000000018178FB20-0x000000018178FBB0
		public static GotoExpression Return(LabelTarget target); // 0x00000001817A1650-0x00000001817A16E0
		public static GotoExpression Return(LabelTarget target, Expression value); // 0x00000001817A16E0-0x00000001817A1780
		public static GotoExpression Goto(LabelTarget target, Type type); // 0x0000000181797640-0x00000001817976B0
		public static GotoExpression Goto(LabelTarget target, Expression value); // 0x00000001817975A0-0x0000000181797640
		public static GotoExpression MakeGoto(GotoExpressionKind kind, LabelTarget target, Expression value, Type type); // 0x000000018179B710-0x000000018179B800
		private static void ValidateGoto(LabelTarget target, ref Expression value, string targetParameter, string valueParameter, Type type); // 0x00000001817A3920-0x00000001817A3BB0
		private static void ValidateGotoType(Type expectedType, ref Expression value, string paramName); // 0x00000001817A37C0-0x00000001817A3920
		public static IndexExpression MakeIndex(Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments); // 0x000000018179B8D0-0x000000018179BA70
		public static IndexExpression ArrayAccess(Expression array, params Expression[] indexes); // 0x000000018178E1A0-0x000000018178E200
		public static IndexExpression ArrayAccess(Expression array, IEnumerable<Expression> indexes); // 0x000000018178E200-0x000000018178E600
		public static IndexExpression Property(Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments); // 0x00000001817A0B90-0x00000001817A0CC0
		private static IndexExpression MakeIndexProperty(Expression instance, PropertyInfo indexer, string paramName, ReadOnlyCollection<Expression> argList); // 0x000000018179B800-0x000000018179B8D0
		private static void ValidateIndexedProperty(Expression instance, PropertyInfo indexer, string paramName, ref ReadOnlyCollection<Expression> argList); // 0x00000001817A3BB0-0x00000001817A41E0
		private static void ValidateAccessor(Expression instance, MethodInfo method, ParameterInfo[] indexes, ref ReadOnlyCollection<Expression> arguments, string paramName); // 0x00000001817A3370-0x00000001817A35B0
		private static void ValidateAccessorArgumentTypes(MethodInfo method, ParameterInfo[] indexes, ref ReadOnlyCollection<Expression> arguments, string paramName); // 0x00000001817A2E40-0x00000001817A3370
		internal static InvocationExpression Invoke(Expression expression); // 0x0000000181798250-0x0000000181798350
		internal static InvocationExpression Invoke(Expression expression, Expression arg0); // 0x0000000181798A80-0x0000000181798C00
		internal static InvocationExpression Invoke(Expression expression, Expression arg0, Expression arg1); // 0x0000000181798350-0x0000000181798540
		internal static InvocationExpression Invoke(Expression expression, Expression arg0, Expression arg1, Expression arg2); // 0x0000000181798540-0x0000000181798780
		internal static InvocationExpression Invoke(Expression expression, Expression arg0, Expression arg1, Expression arg2, Expression arg3); // 0x0000000181798C00-0x0000000181798EA0
		internal static InvocationExpression Invoke(Expression expression, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4); // 0x0000000181798780-0x0000000181798A80
		public static InvocationExpression Invoke(Expression expression, IEnumerable<Expression> arguments); // 0x0000000181797BA0-0x0000000181798250
		internal static MethodInfo GetInvokeMethod(Expression expression); // 0x0000000181794CA0-0x0000000181794E80
		public static LabelExpression Label(LabelTarget target); // 0x0000000181799A00-0x0000000181799B10
		public static LabelExpression Label(LabelTarget target, Expression defaultValue); // 0x0000000181799930-0x0000000181799A00
		public static LabelTarget Label(); // 0x0000000181799B10-0x0000000181799B90
		public static LabelTarget Label(string name); // 0x00000001817998B0-0x0000000181799930
		public static LabelTarget Label(Type type); // 0x0000000181799C50-0x0000000181799CA0
		public static LabelTarget Label(Type type, string name); // 0x0000000181799B90-0x0000000181799C50
		internal static LambdaExpression CreateLambda(Type delegateType, Expression body, string name, bool tailCall, ReadOnlyCollection<ParameterExpression> parameters); // 0x0000000181792CE0-0x00000001817931F0
		public static Expression<TDelegate> Lambda<TDelegate>(Expression body, params ParameterExpression[] parameters);
		public static Expression<TDelegate> Lambda<TDelegate>(Expression body, IEnumerable<ParameterExpression> parameters);
		public static Expression<TDelegate> Lambda<TDelegate>(Expression body, bool tailCall, IEnumerable<ParameterExpression> parameters);
		public static Expression<TDelegate> Lambda<TDelegate>(Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters);
		public static LambdaExpression Lambda(Type delegateType, Expression body, params ParameterExpression[] parameters); // 0x0000000181799CA0-0x0000000181799DA0
		public static LambdaExpression Lambda(Type delegateType, Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters); // 0x0000000181799DA0-0x0000000181799E80
		private static void ValidateLambdaArgs(Type delegateType, ref Expression body, ReadOnlyCollection<ParameterExpression> parameters, string paramName); // 0x00000001817A41E0-0x00000001817A4890
		public static LoopExpression Loop(Expression body, LabelTarget @break, LabelTarget @continue); // 0x000000018179A520-0x000000018179A640
		public static MemberExpression Field(Expression expression, FieldInfo field); // 0x0000000181794180-0x0000000181794380
		public static MemberExpression Field(Expression expression, string fieldName); // 0x0000000181793FF0-0x0000000181794180
		public static MemberExpression Property(Expression expression, string propertyName); // 0x00000001817A0A10-0x00000001817A0B90
		public static MemberExpression Property(Expression expression, PropertyInfo property); // 0x00000001817A06A0-0x00000001817A0A10
		public static MemberExpression MakeMemberAccess(Expression expression, MemberInfo member); // 0x000000018179BA70-0x000000018179BC10
		internal static MethodCallExpression Call(MethodInfo method); // 0x0000000181791040-0x0000000181791100
		public static MethodCallExpression Call(MethodInfo method, Expression arg0); // 0x00000001817913C0-0x0000000181791510
		public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1); // 0x0000000181791510-0x00000001817916E0
		public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2); // 0x0000000181790510-0x0000000181790750
		public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3); // 0x0000000181791100-0x00000001817913C0
		public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4); // 0x0000000181790970-0x0000000181790CA0
		public static MethodCallExpression Call(MethodInfo method, params Expression[] arguments); // 0x00000001817916E0-0x0000000181791780
		public static MethodCallExpression Call(MethodInfo method, IEnumerable<Expression> arguments); // 0x0000000181791B20-0x0000000181791B80
		public static MethodCallExpression Call(Expression instance, MethodInfo method); // 0x0000000181790F30-0x0000000181791040
		public static MethodCallExpression Call(Expression instance, MethodInfo method, params Expression[] arguments); // 0x0000000181791780-0x00000001817917F0
		internal static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0); // 0x00000001817917F0-0x0000000181791990
		public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1); // 0x0000000181790750-0x0000000181790970
		public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2); // 0x0000000181790CA0-0x0000000181790F30
		public static MethodCallExpression Call(Expression instance, string methodName, Type[] typeArguments, params Expression[] arguments); // 0x0000000181791990-0x0000000181791B20
		public static MethodCallExpression Call(Expression instance, MethodInfo method, IEnumerable<Expression> arguments); // 0x000000018178FBB0-0x0000000181790510
		private static ParameterInfo[] ValidateMethodAndGetParameters(Expression instance, MethodInfo method); // 0x00000001817A4890-0x00000001817A4A60
		private static void ValidateStaticOrInstanceMethod(Expression instance, MethodInfo method); // 0x00000001817A5040-0x00000001817A5140
		private static void ValidateCallInstanceType(Type instanceType, MethodInfo method); // 0x00000001817A35D0-0x00000001817A3670
		private static void ValidateArgumentTypes(MethodBase method, ExpressionType nodeKind, ref ReadOnlyCollection<Expression> arguments, string methodParamName); // 0x00000001817A35C0-0x00000001817A35D0
		private static ParameterInfo[] GetParametersForValidation(MethodBase method, ExpressionType nodeKind); // 0x0000000181796270-0x0000000181796280
		private static void ValidateArgumentCount(MethodBase method, ExpressionType nodeKind, int count, ParameterInfo[] pis); // 0x00000001817A35B0-0x00000001817A35C0
		private static Expression ValidateOneArgument(MethodBase method, ExpressionType nodeKind, Expression arg, ParameterInfo pi, string methodParamName, string argumentParamName); // 0x00000001817A4AF0-0x00000001817A4B30
		private static bool TryQuote(Type parameterType, ref Expression argument); // 0x00000001817A2750-0x00000001817A2760
		private static MethodInfo FindMethod(Type type, string methodName, Type[] typeArgs, Expression[] args, BindingFlags flags); // 0x0000000181794380-0x00000001817946C0
		private static bool IsCompatible(MethodBase m, Expression[] arguments); // 0x0000000181798EA0-0x0000000181799100
		private static MethodInfo ApplyTypeArgs(MethodInfo m, Type[] typeArgs); // 0x000000018178E0D0-0x000000018178E1A0
		public static NewArrayExpression NewArrayInit(Type type, params Expression[] initializers); // 0x000000018179ED20-0x000000018179ED80
		public static NewArrayExpression NewArrayInit(Type type, IEnumerable<Expression> initializers); // 0x000000018179E8C0-0x000000018179ED20
		public static NewArrayExpression NewArrayBounds(Type type, IEnumerable<Expression> bounds); // 0x000000018179E610-0x000000018179E8C0
		public static ParameterExpression Parameter(Type type); // 0x000000018179FDD0-0x000000018179FEB0
		public static ParameterExpression Parameter(Type type, string name); // 0x000000018179FEB0-0x000000018179FF60
		public static ParameterExpression Variable(Type type, string name); // 0x00000001817A6210-0x00000001817A6280
		private static void Validate(Type type, bool allowByRef); // 0x00000001817A6110-0x00000001817A6210
		public static TryExpression TryFinally(Expression body, Expression @finally); // 0x00000001817A26E0-0x00000001817A2750
		public static TryExpression MakeTry(Type type, Expression body, Expression @finally, Expression fault, IEnumerable<CatchBlock> handlers); // 0x000000018179BEA0-0x000000018179C0F0
		private static void ValidateTryAndCatchHaveSameType(Type type, Expression tryBody, ReadOnlyCollection<CatchBlock> handlers); // 0x00000001817A5140-0x00000001817A57E0
		public static TypeBinaryExpression TypeIs(Expression expression, Type type); // 0x00000001817A29A0-0x00000001817A2AA0
		public static TypeBinaryExpression TypeEqual(Expression expression, Type type); // 0x00000001817A28A0-0x00000001817A29A0
		public static UnaryExpression MakeUnary(ExpressionType unaryType, Expression operand, Type type, MethodInfo method); // 0x000000018179C0F0-0x000000018179D420
		private static UnaryExpression GetUserDefinedUnaryOperatorOrThrow(ExpressionType unaryType, string name, Expression operand); // 0x0000000181797130-0x00000001817972B0
		private static UnaryExpression GetUserDefinedUnaryOperator(ExpressionType unaryType, string name, Expression operand); // 0x00000001817972B0-0x00000001817975A0
		private static UnaryExpression GetMethodBasedUnaryOperator(ExpressionType unaryType, Expression operand, MethodInfo method); // 0x0000000181795A90-0x0000000181795E10
		private static UnaryExpression GetUserDefinedCoercionOrThrow(ExpressionType coercionType, Expression expression, Type convertToType); // 0x0000000181796EC0-0x0000000181797030
		private static UnaryExpression GetUserDefinedCoercion(ExpressionType coercionType, Expression expression, Type convertToType); // 0x0000000181797030-0x0000000181797130
		private static UnaryExpression GetMethodBasedCoercionOperator(ExpressionType unaryType, Expression operand, Type convertToType, MethodInfo method); // 0x00000001817956A0-0x0000000181795A90
		public static UnaryExpression Negate(Expression expression, MethodInfo method); // 0x000000018179E450-0x000000018179E610
		public static UnaryExpression UnaryPlus(Expression expression, MethodInfo method); // 0x00000001817A2AA0-0x00000001817A2C40
		public static UnaryExpression NegateChecked(Expression expression, MethodInfo method); // 0x000000018179E290-0x000000018179E450
		public static UnaryExpression Not(Expression expression); // 0x000000018179EF10-0x000000018179EF60
		public static UnaryExpression Not(Expression expression, MethodInfo method); // 0x000000018179EF60-0x000000018179F120
		public static UnaryExpression IsFalse(Expression expression, MethodInfo method); // 0x0000000181799100-0x00000001817992A0
		public static UnaryExpression IsTrue(Expression expression, MethodInfo method); // 0x0000000181799630-0x00000001817997D0
		public static UnaryExpression OnesComplement(Expression expression, MethodInfo method); // 0x000000018179F120-0x000000018179F2C0
		public static UnaryExpression TypeAs(Expression expression, Type type); // 0x00000001817A2760-0x00000001817A28A0
		public static UnaryExpression Unbox(Expression expression, Type type); // 0x00000001817A2C40-0x00000001817A2E40
		public static UnaryExpression Convert(Expression expression, Type type); // 0x0000000181792C80-0x0000000181792CE0
		public static UnaryExpression Convert(Expression expression, Type type, MethodInfo method); // 0x0000000181792AA0-0x0000000181792C80
		public static UnaryExpression ConvertChecked(Expression expression, Type type, MethodInfo method); // 0x0000000181792890-0x0000000181792AA0
		public static UnaryExpression ArrayLength(Expression array); // 0x000000018178E820-0x000000018178EA20
		public static UnaryExpression Quote(Expression expression); // 0x00000001817A0CC0-0x00000001817A0DE0
		public static UnaryExpression Throw(Expression value, Type type); // 0x00000001817A2580-0x00000001817A26D0
		public static UnaryExpression Increment(Expression expression, MethodInfo method); // 0x0000000181797A00-0x0000000181797BA0
		public static UnaryExpression Decrement(Expression expression, MethodInfo method); // 0x00000001817931F0-0x0000000181793390
		public static UnaryExpression PreIncrementAssign(Expression expression); // 0x00000001817A0640-0x00000001817A06A0
		public static UnaryExpression PreIncrementAssign(Expression expression, MethodInfo method); // 0x00000001817A05E0-0x00000001817A0640
		public static UnaryExpression PreDecrementAssign(Expression expression, MethodInfo method); // 0x00000001817A0580-0x00000001817A05E0
		public static UnaryExpression PostIncrementAssign(Expression expression, MethodInfo method); // 0x000000018179FFC0-0x00000001817A0020
		public static UnaryExpression PostDecrementAssign(Expression expression, MethodInfo method); // 0x000000018179FF60-0x000000018179FFC0
		private static UnaryExpression MakeOpAssignUnary(ExpressionType kind, Expression expression, MethodInfo method); // 0x000000018179BC10-0x000000018179BEA0
	}
}
