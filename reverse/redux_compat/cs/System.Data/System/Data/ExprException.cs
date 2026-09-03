/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class ExprException // TypeDefIndex: 11285
	{
		// Methods
		private static OverflowException _Overflow(string error); // 0x000000018188C900-0x000000018188C960
		private static InvalidExpressionException _Expr(string error); // 0x000000018188C8A0-0x000000018188C900
		private static SyntaxErrorException _Syntax(string error); // 0x000000018188C960-0x000000018188C9C0
		private static EvaluateException _Eval(string error); // 0x000000018188C840-0x000000018188C8A0
		private static EvaluateException _Eval(string error, Exception innerException); // 0x000000018188C7E0-0x000000018188C840
		public static Exception InvokeArgument(); // 0x000000018188BAC0-0x000000018188BB00
		public static Exception NYI(string moreinfo); // 0x000000018188BE70-0x000000018188BF00
		public static Exception MissingOperand(OperatorInfo before); // 0x000000018188BC90-0x000000018188BD60
		public static Exception MissingOperator(string token); // 0x000000018188BD60-0x000000018188BDF0
		public static Exception TypeMismatch(string expr); // 0x000000018188C260-0x000000018188C2F0
		public static Exception FunctionArgumentOutOfRange(string arg, string func); // 0x000000018188B400-0x000000018188B460
		public static Exception ExpressionTooComplex(); // 0x000000018188B1D0-0x000000018188B250
		public static Exception UnboundName(string name); // 0x000000018188C2F0-0x000000018188C380
		public static Exception InvalidString(string str); // 0x000000018188B920-0x000000018188B9B0
		public static Exception UndefinedFunction(string name); // 0x000000018188C380-0x000000018188C410
		public static Exception SyntaxError(); // 0x000000018188C040-0x000000018188C0C0
		public static Exception FunctionArgumentCount(string name); // 0x000000018188B370-0x000000018188B400
		public static Exception MissingRightParen(); // 0x000000018188BDF0-0x000000018188BE70
		public static Exception UnknownToken(string token, int position); // 0x000000018188C540-0x000000018188C610
		public static Exception UnknownToken(Tokens tokExpected, Tokens tokCurr, int position); // 0x000000018188C410-0x000000018188C540
		public static Exception DatatypeConvertion(Type type1, Type type2); // 0x000000018188AF90-0x000000018188B070
		public static Exception DatavalueConvertion(object value, Type type, Exception innerException); // 0x000000018188B070-0x000000018188B150
		public static Exception InvalidName(string name); // 0x000000018188B800-0x000000018188B890
		public static Exception InvalidDate(string date); // 0x000000018188B560-0x000000018188B5F0
		public static Exception NonConstantArgument(); // 0x000000018188BF00-0x000000018188BF80
		public static Exception InvalidPattern(string pat); // 0x000000018188B890-0x000000018188B920
		public static Exception InWithoutParentheses(); // 0x000000018188B4E0-0x000000018188B560
		public static Exception InWithoutList(); // 0x000000018188B460-0x000000018188B4E0
		public static Exception InvalidIsSyntax(); // 0x000000018188B670-0x000000018188B6F0
		public static Exception Overflow(Type type); // 0x000000018188BF80-0x000000018188C040
		public static Exception ArgumentType(string function, int arg, Type type); // 0x000000018188AD60-0x000000018188AE70
		public static Exception ArgumentTypeInteger(string function, int arg); // 0x000000018188AC90-0x000000018188AD60
		public static Exception TypeMismatchInBinop(int op, Type type1, Type type2); // 0x000000018188C140-0x000000018188C260
		public static Exception AmbiguousBinop(int op, Type type1, Type type2); // 0x000000018188AB70-0x000000018188AC90
		public static Exception UnsupportedOperator(int op); // 0x000000018188C720-0x000000018188C7E0
		public static Exception InvalidNameBracketing(string name); // 0x000000018188B770-0x000000018188B800
		public static Exception MissingOperandBefore(string op); // 0x000000018188BC00-0x000000018188BC90
		public static Exception TooManyRightParentheses(); // 0x000000018188C0C0-0x000000018188C140
		public static Exception UnresolvedRelation(string name, string expr); // 0x000000018188C610-0x000000018188C6B0
		internal static EvaluateException BindFailure(string relationName); // 0x000000018188AE70-0x000000018188AF00
		public static Exception AggregateArgument(); // 0x000000018188AA60-0x000000018188AAE0
		public static Exception AggregateUnbound(string expr); // 0x000000018188AAE0-0x000000018188AB70
		public static Exception EvalNoContext(); // 0x000000018188B150-0x000000018188B1D0
		public static Exception ExpressionUnbound(string expr); // 0x000000018188B250-0x000000018188B2E0
		public static Exception ComputeNotAggregate(string expr); // 0x000000018188AF00-0x000000018188AF90
		public static Exception FilterConvertion(string expr); // 0x000000018188B2E0-0x000000018188B370
		public static Exception LookupArgument(); // 0x000000018188BB00-0x000000018188BB80
		public static Exception InvalidType(string typeName); // 0x000000018188BA30-0x000000018188BAC0
		public static Exception InvalidHoursArgument(); // 0x000000018188B5F0-0x000000018188B670
		public static Exception InvalidMinutesArgument(); // 0x000000018188B6F0-0x000000018188B770
		public static Exception InvalidTimeZoneRange(); // 0x000000018188B9B0-0x000000018188BA30
		public static Exception MismatchKindandTimeSpan(); // 0x000000018188BB80-0x000000018188BC00
		public static Exception UnsupportedDataType(Type type); // 0x000000018188C6B0-0x000000018188C720
	}
}
