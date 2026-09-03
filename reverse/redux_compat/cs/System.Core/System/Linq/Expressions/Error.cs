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
	internal static class Error // TypeDefIndex: 12075
	{
		// Methods
		internal static Exception ReducibleMustOverrideReduce(); // 0x00000001817B5B40-0x00000001817B5BC0
		internal static Exception InvalidMetaObjectCreated(object p0); // 0x00000001817B4420-0x00000001817B44B0
		internal static Exception AmbiguousMatchInExpandoObject(object p0); // 0x00000001817B1EF0-0x00000001817B1F80
		internal static Exception SameKeyExistsInExpando(object key); // 0x00000001817B5CD0-0x00000001817B5D70
		internal static Exception KeyDoesNotExistInExpando(object p0); // 0x00000001817B4700-0x00000001817B4790
		internal static Exception CollectionModifiedWhileEnumerating(); // 0x00000001817B2A00-0x00000001817B2A80
		internal static Exception CollectionReadOnly(); // 0x00000001817B2A80-0x00000001817B2B00
		internal static Exception MustReduceToDifferent(); // 0x00000001817B4E70-0x00000001817B4EF0
		internal static Exception BinderNotCompatibleWithCallSite(object p0, object p1, object p2); // 0x00000001817B2590-0x00000001817B2640
		internal static Exception DynamicBindingNeedsRestrictions(object p0, object p1); // 0x00000001817B2F80-0x00000001817B3010
		internal static Exception DynamicObjectResultNotAssignable(object p0, object p1, object p2, object p3); // 0x00000001817B3010-0x00000001817B30A0
		internal static Exception DynamicBinderResultNotAssignable(object p0, object p1, object p2); // 0x00000001817B2ED0-0x00000001817B2F80
		internal static Exception BindingCannotBeNull(); // 0x00000001817B2640-0x00000001817B26C0
		internal static Exception ReducedNotCompatible(); // 0x00000001817B5AC0-0x00000001817B5B40
		internal static Exception SetterHasNoParams(string paramName); // 0x00000001817B5D70-0x00000001817B5E00
		internal static Exception PropertyCannotHaveRefType(string paramName); // 0x00000001817B56B0-0x00000001817B5740
		internal static Exception IndexesOfSetGetMustMatch(string paramName); // 0x00000001817B4070-0x00000001817B4100
		internal static Exception TypeParameterIsNotDelegate(object p0); // 0x00000001817B6350-0x00000001817B63E0
		internal static Exception FirstArgumentMustBeCallSite(); // 0x00000001817B3BA0-0x00000001817B3C20
		internal static Exception AccessorsCannotHaveVarArgs(string paramName); // 0x00000001817B1DD0-0x00000001817B1E60
		private static Exception AccessorsCannotHaveByRefArgs(string paramName); // 0x00000001817B1D40-0x00000001817B1DD0
		internal static Exception AccessorsCannotHaveByRefArgs(string paramName, int index); // 0x00000001817B1CB0-0x00000001817B1D40
		internal static Exception TypeMustBeDerivedFromSystemDelegate(); // 0x00000001817B61B0-0x00000001817B6230
		internal static Exception NoOrInvalidRuleProduced(); // 0x00000001817B50E0-0x00000001817B5160
		internal static Exception BoundsCannotBeLessThanOne(string paramName); // 0x00000001817B27D0-0x00000001817B2860
		internal static Exception TypeMustNotBeByRef(string paramName); // 0x00000001817B6230-0x00000001817B62C0
		internal static Exception TypeMustNotBePointer(string paramName); // 0x00000001817B62C0-0x00000001817B6350
		internal static Exception SetterMustBeVoid(string paramName); // 0x00000001817B5E00-0x00000001817B5E90
		internal static Exception PropertyTypeMustMatchGetter(string paramName); // 0x00000001817B5910-0x00000001817B59A0
		internal static Exception PropertyTypeMustMatchSetter(string paramName); // 0x00000001817B59A0-0x00000001817B5A30
		internal static Exception BothAccessorsMustBeStatic(string paramName); // 0x00000001817B2740-0x00000001817B27D0
		internal static Exception OnlyStaticFieldsHaveNullInstance(string paramName); // 0x00000001817B52C0-0x00000001817B5350
		internal static Exception OnlyStaticPropertiesHaveNullInstance(string paramName); // 0x00000001817B53D0-0x00000001817B5460
		internal static Exception OnlyStaticMethodsHaveNullInstance(); // 0x00000001817B5350-0x00000001817B53D0
		internal static Exception PropertyTypeCannotBeVoid(string paramName); // 0x00000001817B5880-0x00000001817B5910
		internal static Exception InvalidUnboxType(string paramName); // 0x00000001817B4670-0x00000001817B4700
		internal static Exception ExpressionMustBeWriteable(string paramName); // 0x00000001817B3240-0x00000001817B32D0
		internal static Exception ArgumentMustNotHaveValueType(string paramName); // 0x00000001817B2370-0x00000001817B2400
		internal static Exception MustBeReducible(); // 0x00000001817B4DF0-0x00000001817B4E70
		internal static Exception LabelMustBeVoidOrHaveExpression(string paramName); // 0x00000001817B4790-0x00000001817B4820
		internal static Exception LabelTypeMustBeVoid(string paramName); // 0x00000001817B4940-0x00000001817B49D0
		internal static Exception QuotedExpressionMustBeLambda(string paramName); // 0x00000001817B5A30-0x00000001817B5AC0
		internal static Exception VariableMustNotBeByRef(object p0, object p1, string paramName); // 0x00000001817B68C0-0x00000001817B6960
		internal static Exception VariableMustNotBeByRef(object p0, object p1, string paramName, int index); // 0x00000001817B6810-0x00000001817B68C0
		private static Exception DuplicateVariable(object p0, string paramName); // 0x00000001817B2D80-0x00000001817B2E20
		internal static Exception DuplicateVariable(object p0, string paramName, int index); // 0x00000001817B2E20-0x00000001817B2ED0
		internal static Exception FaultCannotHaveCatchOrFinally(string paramName); // 0x00000001817B3A60-0x00000001817B3AF0
		internal static Exception TryMustHaveCatchFinallyOrFault(); // 0x00000001817B5E90-0x00000001817B5F10
		internal static Exception BodyOfCatchMustHaveSameTypeAsBodyOfTry(); // 0x00000001817B26C0-0x00000001817B2740
		internal static Exception ExtensionNodeMustOverrideProperty(object p0); // 0x00000001817B39D0-0x00000001817B3A60
		internal static Exception UserDefinedOperatorMustBeStatic(object p0, string paramName); // 0x00000001817B66D0-0x00000001817B6770
		internal static Exception UserDefinedOperatorMustNotBeVoid(object p0, string paramName); // 0x00000001817B6770-0x00000001817B6810
		internal static Exception CoercionOperatorNotDefined(object p0, object p1); // 0x00000001817B2970-0x00000001817B2A00
		internal static Exception UnaryOperatorNotDefined(object p0, object p1); // 0x00000001817B63E0-0x00000001817B6470
		internal static Exception BinaryOperatorNotDefined(object p0, object p1, object p2); // 0x00000001817B24E0-0x00000001817B2590
		internal static Exception ReferenceEqualityNotDefined(object p0, object p1); // 0x00000001817B5BC0-0x00000001817B5C50
		internal static Exception OperandTypesDoNotMatchParameters(object p0, object p1); // 0x00000001817B5460-0x00000001817B54F0
		internal static Exception OverloadOperatorTypeDoesNotMatchConversionType(object p0, object p1); // 0x00000001817B5590-0x00000001817B5620
		internal static Exception ConversionIsNotSupportedForArithmeticTypes(); // 0x00000001817B2D00-0x00000001817B2D80
		internal static Exception ArgumentMustBeArray(string paramName); // 0x00000001817B20A0-0x00000001817B2130
		internal static Exception ArgumentMustBeBoolean(string paramName); // 0x00000001817B2130-0x00000001817B21C0
		private static Exception ArgumentMustBeInteger(string paramName); // 0x00000001817B21C0-0x00000001817B2250
		internal static Exception ArgumentMustBeInteger(string paramName, int index); // 0x00000001817B2250-0x00000001817B22E0
		internal static Exception ArgumentMustBeArrayIndexType(string paramName); // 0x00000001817B2010-0x00000001817B20A0
		internal static Exception ArgumentMustBeSingleDimensionalArrayType(string paramName); // 0x00000001817B22E0-0x00000001817B2370
		internal static Exception ArgumentTypesMustMatch(); // 0x00000001817B2460-0x00000001817B24E0
		internal static Exception CannotAutoInitializeValueTypeMemberThroughProperty(object p0); // 0x00000001817B2860-0x00000001817B28F0
		internal static Exception IncorrectTypeForTypeAs(object p0, string paramName); // 0x00000001817B3FD0-0x00000001817B4070
		internal static Exception CoalesceUsedOnNonNullType(); // 0x00000001817B28F0-0x00000001817B2970
		internal static Exception ExpressionTypeCannotInitializeArrayType(object p0, object p1); // 0x00000001817B32D0-0x00000001817B3360
		internal static Exception ExpressionTypeDoesNotMatchReturn(object p0, object p1); // 0x00000001817B38A0-0x00000001817B3930
		internal static Exception ExpressionTypeDoesNotMatchAssignment(object p0, object p1); // 0x00000001817B3360-0x00000001817B33F0
		internal static Exception ExpressionTypeDoesNotMatchLabel(object p0, object p1); // 0x00000001817B3540-0x00000001817B35D0
		internal static Exception ExpressionTypeNotInvocable(object p0, string paramName); // 0x00000001817B3930-0x00000001817B39D0
		internal static Exception InstanceFieldNotDefinedForType(object p0, object p1); // 0x00000001817B41B0-0x00000001817B4240
		internal static Exception FieldInfoNotDefinedForType(object p0, object p1, object p2); // 0x00000001817B3AF0-0x00000001817B3BA0
		internal static Exception IncorrectNumberOfIndexes(); // 0x00000001817B3DB0-0x00000001817B3E30
		internal static Exception IncorrectNumberOfLambdaDeclarationParameters(); // 0x00000001817B3EB0-0x00000001817B3F30
		internal static Exception LambdaTypeMustBeDerivedFromSystemDelegate(string paramName); // 0x00000001817B49D0-0x00000001817B4A60
		internal static Exception MemberNotFieldOrProperty(object p0, string paramName); // 0x00000001817B4AF0-0x00000001817B4B90
		internal static Exception MethodContainsGenericParameters(object p0, string paramName); // 0x00000001817B4B90-0x00000001817B4C30
		internal static Exception MethodIsGeneric(object p0, string paramName); // 0x00000001817B4C30-0x00000001817B4CD0
		internal static Exception PropertyDoesNotHaveAccessor(object p0, string paramName); // 0x00000001817B5740-0x00000001817B57E0
		internal static Exception ParameterExpressionNotValidAsDelegate(object p0, object p1); // 0x00000001817B5620-0x00000001817B56B0
		internal static Exception PropertyNotDefinedForType(object p0, object p1, string paramName); // 0x00000001817B57E0-0x00000001817B5880
		internal static Exception InstancePropertyNotDefinedForType(object p0, object p1, string paramName); // 0x00000001817B4240-0x00000001817B42E0
		internal static Exception InstanceAndMethodTypeMismatch(object p0, object p1, object p2); // 0x00000001817B4100-0x00000001817B41B0
		internal static Exception UnhandledBinary(object p0, string paramName); // 0x00000001817B6470-0x00000001817B6510
		internal static Exception UnhandledUnary(object p0, string paramName); // 0x00000001817B6510-0x00000001817B65B0
		internal static Exception UserDefinedOpMustHaveConsistentTypes(object p0, object p1); // 0x00000001817B65B0-0x00000001817B6640
		internal static Exception UserDefinedOpMustHaveValidReturnType(object p0, object p1); // 0x00000001817B6640-0x00000001817B66D0
		internal static Exception LogicalOperatorMustHaveBooleanOperators(object p0, object p1); // 0x00000001817B4A60-0x00000001817B4AF0
		internal static Exception MethodWithArgsDoesNotExistOnType(object p0, object p1); // 0x00000001817B4CD0-0x00000001817B4D60
		internal static Exception GenericMethodWithArgsDoesNotExistOnType(object p0, object p1); // 0x00000001817B3C20-0x00000001817B3CB0
		internal static Exception MethodWithMoreThanOneMatch(object p0, object p1); // 0x00000001817B4D60-0x00000001817B4DF0
		internal static Exception ArgumentCannotBeOfTypeVoid(string paramName); // 0x00000001817B1F80-0x00000001817B2010
		internal static Exception OutOfRange(string paramName, object p1); // 0x00000001817B54F0-0x00000001817B5590
		internal static Exception LabelTargetAlreadyDefined(object p0); // 0x00000001817B4820-0x00000001817B48B0
		internal static Exception LabelTargetUndefined(object p0); // 0x00000001817B48B0-0x00000001817B4940
		internal static Exception ControlCannotLeaveFinally(); // 0x00000001817B2C80-0x00000001817B2D00
		internal static Exception ControlCannotLeaveFilterTest(); // 0x00000001817B2C00-0x00000001817B2C80
		internal static Exception AmbiguousJump(object p0); // 0x00000001817B1E60-0x00000001817B1EF0
		internal static Exception ControlCannotEnterTry(); // 0x00000001817B2B80-0x00000001817B2C00
		internal static Exception ControlCannotEnterExpression(); // 0x00000001817B2B00-0x00000001817B2B80
		internal static Exception NonLocalJumpWithValue(object p0); // 0x00000001817B51E0-0x00000001817B5270
		internal static Exception InvalidLvalue(ExpressionType p0); // 0x00000001817B4370-0x00000001817B4420
		internal static Exception RethrowRequiresCatch(); // 0x00000001817B5C50-0x00000001817B5CD0
		internal static Exception MustRewriteToSameNode(object p0, object p1, object p2); // 0x00000001817B4FA0-0x00000001817B5050
		internal static Exception MustRewriteChildToSameType(object p0, object p1, object p2); // 0x00000001817B4EF0-0x00000001817B4FA0
		internal static Exception MustRewriteWithoutMethod(object p0, object p1); // 0x00000001817B5050-0x00000001817B50E0
		internal static Exception ArgumentOutOfRange(string paramName); // 0x00000001817B2400-0x00000001817B2460
		internal static Exception NotSupported(); // 0x00000001817B5270-0x00000001817B52C0
		internal static Exception NonAbstractConstructorRequired(); // 0x00000001817B5160-0x00000001817B51E0
		internal static Exception InvalidProgram(); // 0x00000001817B4550-0x00000001817B45A0
		internal static Exception EnumerationIsDone(); // 0x00000001817B30A0-0x00000001817B3120
		private static Exception TypeContainsGenericParameters(object p0, string paramName); // 0x00000001817B5FC0-0x00000001817B6060
		internal static Exception TypeContainsGenericParameters(object p0, string paramName, int index); // 0x00000001817B5F10-0x00000001817B5FC0
		internal static Exception TypeIsGeneric(object p0, string paramName); // 0x00000001817B6060-0x00000001817B6100
		internal static Exception TypeIsGeneric(object p0, string paramName, int index); // 0x00000001817B6100-0x00000001817B61B0
		internal static Exception IncorrectNumberOfConstructorArguments(); // 0x00000001817B3D30-0x00000001817B3DB0
		internal static Exception ExpressionTypeDoesNotMatchMethodParameter(object p0, object p1, object p2, string paramName); // 0x00000001817B35D0-0x00000001817B3690
		internal static Exception ExpressionTypeDoesNotMatchMethodParameter(object p0, object p1, object p2, string paramName, int index); // 0x00000001817B3690-0x00000001817B3750
		internal static Exception ExpressionTypeDoesNotMatchParameter(object p0, object p1, string paramName); // 0x00000001817B3800-0x00000001817B38A0
		internal static Exception ExpressionTypeDoesNotMatchParameter(object p0, object p1, string paramName, int index); // 0x00000001817B3750-0x00000001817B3800
		internal static Exception IncorrectNumberOfLambdaArguments(); // 0x00000001817B3E30-0x00000001817B3EB0
		internal static Exception IncorrectNumberOfMethodCallArguments(object p0, string paramName); // 0x00000001817B3F30-0x00000001817B3FD0
		internal static Exception ExpressionTypeDoesNotMatchConstructorParameter(object p0, object p1, string paramName); // 0x00000001817B33F0-0x00000001817B3490
		internal static Exception ExpressionTypeDoesNotMatchConstructorParameter(object p0, object p1, string paramName, int index); // 0x00000001817B3490-0x00000001817B3540
		internal static Exception ExpressionMustBeReadable(string paramName); // 0x00000001817B3120-0x00000001817B31B0
		internal static Exception ExpressionMustBeReadable(string paramName, int index); // 0x00000001817B31B0-0x00000001817B3240
		internal static Exception InvalidArgumentValue(string paramName); // 0x00000001817B42E0-0x00000001817B4370
		internal static Exception InvalidNullValue(Type type, string paramName); // 0x00000001817B44B0-0x00000001817B4550
		internal static Exception InvalidTypeException(object value, Type type, string paramName); // 0x00000001817B45A0-0x00000001817B4670
		private static string GetParamName(string paramName, int index); // 0x00000001817B3CB0-0x00000001817B3D30
	}
}
