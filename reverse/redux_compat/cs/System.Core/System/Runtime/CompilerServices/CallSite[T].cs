/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Runtime.CompilerServices
{
	public class CallSite<T> : CallSite // TypeDefIndex: 12537
		where T : class
	{
		// Fields
		public T Target;
		internal T[] Rules;
		private static T s_cachedUpdate;
		private static T s_cachedNoMatch;
	
		// Properties
		public T Update { get; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12538
		{
			// Fields
			public static readonly __c<T> __9;
			public static Converter<ParameterInfo, ParameterExpression> __9__20_0;
			public static Converter<ParameterExpression, Expression> __9__20_1;
			public static Converter<ParameterInfo, ParameterExpression> __9__21_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal ParameterExpression _CreateCustomUpdateDelegate_b__20_0(ParameterInfo p);
			internal Expression _CreateCustomUpdateDelegate_b__20_1(ParameterExpression p);
			internal ParameterExpression _CreateCustomNoMatchDelegate_b__21_0(ParameterInfo p);
		}
	
		// Constructors
		private CallSite(CallSiteBinder binder);
		private CallSite();
	
		// Methods
		internal CallSite<T> CreateMatchMaker();
		public static CallSite<T> Create(CallSiteBinder binder);
		private T GetUpdateDelegate();
		private T GetUpdateDelegate(ref ref T addr);
		internal void AddRule(T newRule);
		internal void MoveRule(int i);
		internal T MakeUpdateDelegate();
		private T CreateCustomUpdateDelegate(MethodInfo invoke);
		private T CreateCustomNoMatchDelegate(MethodInfo invoke);
		private static Expression Convert(Expression arg, Type type);
	}
}
