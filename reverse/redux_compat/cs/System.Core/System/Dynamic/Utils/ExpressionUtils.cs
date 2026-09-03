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

namespace System.Dynamic.Utils
{
	internal static class ExpressionUtils // TypeDefIndex: 12590
	{
		// Methods
		public static ReadOnlyCollection<T> ReturnReadOnly<T>(ref IReadOnlyList<T> collection);
		public static T ReturnObject<T>(object collectionOrT)
			where T : class;
		public static void ValidateArgumentTypes(MethodBase method, ExpressionType nodeKind, ref ReadOnlyCollection<Expression> arguments, string methodParamName); // 0x0000000181803AA0-0x0000000181803EF0
		public static void ValidateArgumentCount(MethodBase method, ExpressionType nodeKind, int count, ParameterInfo[] pis); // 0x00000001818039C0-0x0000000181803AA0
		public static Expression ValidateOneArgument(MethodBase method, ExpressionType nodeKind, Expression arguments, ParameterInfo pi, string methodParamName, string argumentParamName, int index = -1 /* Metadata: 0x006A25D1 */); // 0x0000000181803EF0-0x0000000181804460
		public static void RequiresCanRead(Expression expression, string paramName); // 0x0000000181803540-0x0000000181803550
		public static void RequiresCanRead(Expression expression, string paramName, int idx); // 0x0000000181803550-0x0000000181803790
		public static bool TryQuote(Type parameterType, ref Expression argument); // 0x0000000181803790-0x0000000181803940
		internal static ParameterInfo[] GetParametersForValidation(MethodBase method, ExpressionType nodeKind); // 0x00000001818034C0-0x0000000181803540
		internal static bool SameElements<T>(ref IEnumerable<T> replacement, IReadOnlyList<T> current)
			where T : class;
		private static bool SameElementsInCollection<T>(ICollection<T> replacement, IReadOnlyList<T> current)
			where T : class;
	
		// Extension methods
		public static void ValidateArgumentCount(this LambdaExpression lambda); // 0x0000000181803940-0x00000001818039C0
	}
}
