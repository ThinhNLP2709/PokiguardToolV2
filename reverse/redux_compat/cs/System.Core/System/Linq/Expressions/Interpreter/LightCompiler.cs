/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class LightCompiler // TypeDefIndex: 12352
	{
		// Fields
		private readonly InstructionList _instructions; // 0x10
		private readonly LocalVariables _locals; // 0x18
		private readonly List<DebugInfo> _debugInfos; // 0x20
		private readonly HybridReferenceDictionary<LabelTarget, LabelInfo> _treeLabels; // 0x28
		private LabelScopeInfo _labelBlock; // 0x30
		private readonly Stack<ParameterExpression> _exceptionForRethrowStack; // 0x38
		private readonly LightCompiler _parent; // 0x40
		private readonly StackGuard _guard; // 0x48
		private static readonly LocalDefinition[] s_emptyLocals; // 0x00
	
		// Properties
		public InstructionList Instructions { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		private sealed class QuoteVisitor : ExpressionVisitor // TypeDefIndex: 12353
		{
			// Fields
			private readonly Dictionary<ParameterExpression, int> _definedParameters; // 0x10
			public readonly HashSet<ParameterExpression> _hoistedParameters; // 0x18
	
			// Constructors
			public QuoteVisitor(); // 0x00000001817FD310-0x00000001817FD3D0
	
			// Methods
			protected internal override Expression VisitParameter(ParameterExpression node); // 0x00000001817FD290-0x00000001817FD310
			protected internal override Expression VisitBlock(BlockExpression node); // 0x00000001817FD090-0x00000001817FD100
			protected override CatchBlock VisitCatchBlock(CatchBlock node); // 0x00000001817FD100-0x00000001817FD290
			protected internal override Expression VisitLambda<T>(Expression<T> node);
			private void PushParameters(IEnumerable<ParameterExpression> parameters); // 0x00000001817FCE40-0x00000001817FD090
			private void PopParameters(IEnumerable<ParameterExpression> parameters); // 0x00000001817FCBE0-0x00000001817FCE40
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12354
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Expression, bool> __9__56_1; // 0x08
			public static Func<SwitchCase, bool> __9__56_0; // 0x10
			public static Action<LightCompiler, Expression> __9__101_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181801960-0x00000001818019D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _CompileSwitchExpression_b__56_0(SwitchCase c); // 0x0000000181801700-0x0000000181801810
			internal bool _CompileSwitchExpression_b__56_1(Expression t); // 0x0000000181801810-0x0000000181801890
			internal void _CompileNoLabelPush_b__101_0(LightCompiler @this, Expression e); // 0x00000001818016D0-0x0000000181801700
		}
	
		// Constructors
		public LightCompiler(); // 0x00000001817E5F70-0x00000001817E61B0
		private LightCompiler(LightCompiler parent); // 0x00000001817E5F30-0x00000001817E5F70
		static LightCompiler(); // 0x00000001817E5E90-0x00000001817E5F30
	
		// Methods
		public LightDelegateCreator CompileTop(LambdaExpression node); // 0x00000001817E2330-0x00000001817E2620
		private Interpreter MakeInterpreter(string lambdaName); // 0x00000001817E5230-0x00000001817E5690
		private void CompileConstantExpression(Expression expr); // 0x00000001817DA010-0x00000001817DA0C0
		private void CompileDefaultExpression(Expression expr); // 0x00000001817DB390-0x00000001817DB3D0
		private void CompileDefaultExpression(Type type); // 0x00000001817DB1A0-0x00000001817DB390
		private LocalVariable EnsureAvailableForClosure(ParameterExpression expr); // 0x00000001817E4DC0-0x00000001817E4F20
		private LocalVariable ResolveLocal(ParameterExpression variable); // 0x00000001817E5880-0x00000001817E58F0
		private void CompileGetVariable(ParameterExpression variable); // 0x00000001817DB520-0x00000001817DB600
		private void EmitCopyValueType(Type valueType); // 0x00000001817E4750-0x00000001817E4810
		private void LoadLocalNoValueTypeCopy(ParameterExpression variable); // 0x00000001817E5150-0x00000001817E5230
		private bool MaybeMutableValueType(Type type); // 0x00000001817E5690-0x00000001817E56F0
		private void CompileGetBoxedVariable(ParameterExpression variable); // 0x00000001817DB470-0x00000001817DB520
		private void CompileSetVariable(ParameterExpression variable, bool isVoid); // 0x00000001817E1060-0x00000001817E1230
		private void CompileParameterExpression(Expression expr); // 0x00000001817E0A30-0x00000001817E0AB0
		private void CompileBlockExpression(Expression expr, bool asVoid); // 0x00000001817D8C30-0x00000001817D8DE0
		private LocalDefinition[] CompileBlockStart(BlockExpression node); // 0x00000001817D8DE0-0x00000001817D92E0
		private void CompileBlockEnd(LocalDefinition[] locals); // 0x00000001817D8B90-0x00000001817D8C30
		private void CompileIndexExpression(Expression expr); // 0x00000001817DBC50-0x00000001817DBD30
		private void EmitIndexGet(IndexExpression index); // 0x00000001817E4810-0x00000001817E4910
		private void CompileIndexAssignment(BinaryExpression node, bool asVoid); // 0x00000001817DB8E0-0x00000001817DBC50
		private void CompileMemberAssignment(BinaryExpression node, bool asVoid); // 0x00000001817DDE90-0x00000001817DDF70
		private void CompileMemberAssignment(bool asVoid, MemberInfo refMember, Expression value, bool forBinding); // 0x00000001817DD9D0-0x00000001817DDE90
		private void CompileVariableAssignment(BinaryExpression node, bool asVoid); // 0x00000001817E4430-0x00000001817E44E0
		private void CompileAssignBinaryExpression(Expression expr, bool asVoid); // 0x00000001817D79E0-0x00000001817D7C50
		private void CompileBinaryExpression(Expression expr); // 0x00000001817D7C50-0x00000001817D8B90
		private void CompileEqual(Expression left, Expression right, bool liftedToNull); // 0x00000001817DB3D0-0x00000001817DB470
		private void CompileNotEqual(Expression left, Expression right, bool liftedToNull); // 0x00000001817E08A0-0x00000001817E0940
		private void CompileComparison(BinaryExpression node); // 0x00000001817D9AF0-0x00000001817D9CF0
		private void CompileArithmetic(ExpressionType nodeType, Expression left, Expression right); // 0x00000001817D7320-0x00000001817D75B0
		private void CompileConvertUnaryExpression(Expression expr); // 0x00000001817DA790-0x00000001817DAFE0
		private void CompileConvertToType(Type typeFrom, Type typeTo, bool isChecked, bool isLiftedToNull); // 0x00000001817DA0C0-0x00000001817DA790
		private void CompileNotExpression(UnaryExpression node); // 0x00000001817E0940-0x00000001817E09B0
		private void CompileUnaryExpression(Expression expr); // 0x00000001817E3C90-0x00000001817E40D0
		private void EmitUnaryMethodCall(UnaryExpression node); // 0x00000001817E4BE0-0x00000001817E4DC0
		private void EmitUnaryBoolCheck(UnaryExpression node); // 0x00000001817E4920-0x00000001817E4BE0
		private void CompileAndAlsoBinaryExpression(Expression expr); // 0x00000001817D72A0-0x00000001817D7320
		private void CompileOrElseBinaryExpression(Expression expr); // 0x00000001817E09B0-0x00000001817E0A30
		private void CompileLogicalBinaryExpression(BinaryExpression b, bool andAlso); // 0x00000001817DD570-0x00000001817DD6D0
		private void CompileMethodLogicalBinaryExpression(BinaryExpression expr, bool andAlso); // 0x00000001817DEE60-0x00000001817DF090
		private void CompileLiftedLogicalBinaryExpression(BinaryExpression node, bool andAlso); // 0x00000001817DC4D0-0x00000001817DD1E0
		private void CompileUnliftedLogicalBinaryExpression(BinaryExpression expr, bool andAlso); // 0x00000001817E4210-0x00000001817E4430
		private void CompileConditionalExpression(Expression expr, bool asVoid); // 0x00000001817D9CF0-0x00000001817DA010
		private void CompileLoopExpression(Expression expr); // 0x00000001817DD6D0-0x00000001817DD9D0
		private void CompileSwitchExpression(Expression expr); // 0x00000001817E1840-0x00000001817E2040
		private void CompileIntSwitchExpression<T>(SwitchExpression node);
		private void CompileStringSwitchExpression(SwitchExpression node); // 0x00000001817E1230-0x00000001817E1840
		private void CompileLabelExpression(Expression expr); // 0x00000001817DBFD0-0x00000001817DC290
		private void CompileGotoExpression(Expression expr); // 0x00000001817DB600-0x00000001817DB8E0
		private void PushLabelBlock(LabelScopeKind type); // 0x00000001817E5720-0x00000001817E57B0
		private void PopLabelBlock(LabelScopeKind kind); // 0x00000001817E56F0-0x00000001817E5720
		private LabelInfo EnsureLabel(LabelTarget node); // 0x00000001817E4F20-0x00000001817E4FF0
		private LabelInfo ReferenceLabel(LabelTarget node); // 0x00000001817E57B0-0x00000001817E5880
		private LabelInfo DefineLabel(LabelTarget node); // 0x00000001817E46B0-0x00000001817E4750
		private bool TryPushLabelBlock(Expression node); // 0x00000001817E5AB0-0x00000001817E5E90
		private void DefineBlockLabels(Expression node); // 0x00000001817E4570-0x00000001817E46B0
		private void CheckRethrow(); // 0x00000001817D6750-0x00000001817D67B0
		private void CompileThrowUnaryExpression(Expression expr, bool asVoid); // 0x00000001817E2040-0x00000001817E2330
		private void CompileTryExpression(Expression expr); // 0x00000001817E2620-0x00000001817E3270
		private void CompileTryFaultExpression(TryExpression expr); // 0x00000001817E3270-0x00000001817E3680
		private void CompileMethodCallExpression(Expression expr); // 0x00000001817DEDC0-0x00000001817DEE60
		private void CompileMethodCallExpression(Expression @object, MethodInfo method, IArgumentProvider arguments); // 0x00000001817DE8B0-0x00000001817DEDC0
		private ByRefUpdater CompileArrayIndexAddress(Expression array, Expression index, int argumentIndex); // 0x00000001817D75B0-0x00000001817D7870
		private void EmitThisForMethodCall(Expression node); // 0x00000001817E4910-0x00000001817E4920
		private static bool ShouldWritebackNode(Expression node); // 0x00000001817E58F0-0x00000001817E5AB0
		private ByRefUpdater CompileAddress(Expression node, int index); // 0x00000001817D67B0-0x00000001817D72A0
		private ByRefUpdater CompileMultiDimArrayAccess(Expression array, IArgumentProvider arguments, int index); // 0x00000001817DF090-0x00000001817DF5E0
		private void CompileNewExpression(Expression expr); // 0x00000001817DF9A0-0x00000001817DFE60
		private void CompileMemberExpression(Expression expr); // 0x00000001817DDF70-0x00000001817DE020
		private void CompileMember(Expression from, MemberInfo member, bool forBinding); // 0x00000001817DE510-0x00000001817DE8B0
		private void CompileNewArrayExpression(Expression expr); // 0x00000001817DF5E0-0x00000001817DF9A0
		private void CompileDebugInfoExpression(Expression expr); // 0x00000001817DAFE0-0x00000001817DB1A0
		private void CompileRuntimeVariablesExpression(Expression expr); // 0x00000001817E0DB0-0x00000001817E1060
		private void CompileLambdaExpression(Expression expr); // 0x00000001817DC290-0x00000001817DC4D0
		private void CompileCoalesceBinaryExpression(Expression expr); // 0x00000001817D92E0-0x00000001817D9AF0
		private void CompileInvocationExpression(Expression expr); // 0x00000001817DBD30-0x00000001817DBFD0
		private void CompileListInitExpression(Expression expr); // 0x00000001817DD1E0-0x00000001817DD270
		private void CompileListInit(ReadOnlyCollection<ElementInit> initializers); // 0x00000001817DD270-0x00000001817DD570
		private void CompileMemberInitExpression(Expression expr); // 0x00000001817DE020-0x00000001817DE0B0
		private void CompileMemberInit(ReadOnlyCollection<MemberBinding> bindings); // 0x00000001817DE0B0-0x00000001817DE510
		private static Type GetMemberType(MemberInfo member); // 0x00000001817E4FF0-0x00000001817E5150
		private void CompileQuoteUnaryExpression(Expression expr); // 0x00000001817E0AB0-0x00000001817E0DB0
		private void CompileUnboxUnaryExpression(Expression expr); // 0x00000001817E40D0-0x00000001817E4210
		private void CompileTypeEqualExpression(Expression expr); // 0x00000001817E3730-0x00000001817E3940
		private void CompileTypeAsExpression(UnaryExpression node); // 0x00000001817E3680-0x00000001817E3730
		private void CompileTypeIsExpression(Expression expr); // 0x00000001817E3940-0x00000001817E3C90
		private void Compile(Expression expr, bool asVoid); // 0x00000001817E4550-0x00000001817E4570
		private void CompileAsVoid(Expression expr); // 0x00000001817D7870-0x00000001817D79E0
		private void CompileNoLabelPush(Expression expr); // 0x00000001817DFE60-0x00000001817E08A0
		private void Compile(Expression expr); // 0x00000001817E44E0-0x00000001817E4550
	}
}
