/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal sealed class DynamicProxyMetaObject<T> : DynamicMetaObject // TypeDefIndex: 10116
	{
		// Fields
		private readonly DynamicProxy<T> _proxy;
	
		// Properties
		private static Expression[] NoArgs { get; }
	
		// Nested types
		[NullableContext(0)]
		private delegate DynamicMetaObject Fallback([Nullable(2)] DynamicMetaObject errorSuggestion); // TypeDefIndex: 10117; 0x00000000-0x00000000
	
		[Nullable(0)]
		private sealed class GetBinderAdapter : GetMemberBinder // TypeDefIndex: 10118
		{
			// Constructors
			internal GetBinderAdapter(InvokeMemberBinder binder);
	
			// Methods
			public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, [Nullable(2)] DynamicMetaObject errorSuggestion);
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10119
		{
			// Fields
			[Nullable(0)]
			public static readonly __c<T> __9;
			[Nullable(0)]
			public static Func<DynamicMetaObject, Expression> __9__18_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			[NullableContext(0)]
			internal Expression _GetArgs_b__18_0(DynamicMetaObject arg);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 10120
		{
			// Fields
			[Nullable(0)]
			public BinaryOperationBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
			[Nullable(0)]
			public DynamicMetaObject arg;
	
			// Constructors
			public __c__DisplayClass10_0();
	
			// Methods
			internal DynamicMetaObject _BindBinaryOperation_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass11_0 // TypeDefIndex: 10121
		{
			// Fields
			[Nullable(0)]
			public UnaryOperationBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
	
			// Constructors
			public __c__DisplayClass11_0();
	
			// Methods
			internal DynamicMetaObject _BindUnaryOperation_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass12_0 // TypeDefIndex: 10122
		{
			// Fields
			[Nullable(0)]
			public GetIndexBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
			[Nullable(new byte[2] {0, 1 })]
			public DynamicMetaObject[] indexes;
	
			// Constructors
			public __c__DisplayClass12_0();
	
			// Methods
			internal DynamicMetaObject _BindGetIndex_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass13_0 // TypeDefIndex: 10123
		{
			// Fields
			[Nullable(0)]
			public SetIndexBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
			[Nullable(new byte[2] {0, 1 })]
			public DynamicMetaObject[] indexes;
			[Nullable(0)]
			public DynamicMetaObject value;
	
			// Constructors
			public __c__DisplayClass13_0();
	
			// Methods
			internal DynamicMetaObject _BindSetIndex_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0 // TypeDefIndex: 10124
		{
			// Fields
			[Nullable(0)]
			public DeleteIndexBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
			[Nullable(new byte[2] {0, 1 })]
			public DynamicMetaObject[] indexes;
	
			// Constructors
			public __c__DisplayClass14_0();
	
			// Methods
			internal DynamicMetaObject _BindDeleteIndex_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 10125
		{
			// Fields
			[Nullable(0)]
			public GetMemberBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
	
			// Constructors
			public __c__DisplayClass3_0();
	
			// Methods
			internal DynamicMetaObject _BindGetMember_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass4_0 // TypeDefIndex: 10126
		{
			// Fields
			[Nullable(0)]
			public SetMemberBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
			[Nullable(0)]
			public DynamicMetaObject value;
	
			// Constructors
			public __c__DisplayClass4_0();
	
			// Methods
			internal DynamicMetaObject _BindSetMember_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 10127
		{
			// Fields
			[Nullable(0)]
			public DeleteMemberBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
	
			// Constructors
			public __c__DisplayClass5_0();
	
			// Methods
			internal DynamicMetaObject _BindDeleteMember_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 10128
		{
			// Fields
			[Nullable(0)]
			public ConvertBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
	
			// Constructors
			public __c__DisplayClass6_0();
	
			// Methods
			internal DynamicMetaObject _BindConvert_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 10129
		{
			// Fields
			[Nullable(0)]
			public InvokeMemberBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
			[Nullable(new byte[2] {0, 1 })]
			public DynamicMetaObject[] args;
	
			// Constructors
			public __c__DisplayClass7_0();
	
			// Methods
			internal DynamicMetaObject _BindInvokeMember_b__0([Nullable(2)] DynamicMetaObject e);
			internal DynamicMetaObject _BindInvokeMember_b__1([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 10130
		{
			// Fields
			[Nullable(0)]
			public CreateInstanceBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
			[Nullable(new byte[2] {0, 1 })]
			public DynamicMetaObject[] args;
	
			// Constructors
			public __c__DisplayClass8_0();
	
			// Methods
			internal DynamicMetaObject _BindCreateInstance_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 10131
		{
			// Fields
			[Nullable(0)]
			public InvokeBinder binder;
			[Nullable(0)]
			public DynamicProxyMetaObject<T> __4__this;
			[Nullable(new byte[2] {0, 1 })]
			public DynamicMetaObject[] args;
	
			// Constructors
			public __c__DisplayClass9_0();
	
			// Methods
			internal DynamicMetaObject _BindInvoke_b__0([Nullable(2)] DynamicMetaObject e);
		}
	
		// Constructors
		internal DynamicProxyMetaObject(Expression expression, T value, DynamicProxy<T> proxy);
	
		// Methods
		private bool IsOverridden(string method);
		public override DynamicMetaObject BindGetMember(GetMemberBinder binder);
		public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value);
		public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder);
		public override DynamicMetaObject BindConvert(ConvertBinder binder);
		public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args);
		public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args);
		public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args);
		public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg);
		public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder);
		public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes);
		public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value);
		public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes);
		private static IEnumerable<Expression> GetArgs(params DynamicMetaObject[] args);
		private static Expression[] GetArgArray(DynamicMetaObject[] args);
		private static Expression[] GetArgArray(DynamicMetaObject[] args, DynamicMetaObject value);
		private static ConstantExpression Constant(DynamicMetaObjectBinder binder);
		private DynamicMetaObject CallMethodWithResult(string methodName, DynamicMetaObjectBinder binder, IEnumerable<Expression> args, [Nullable(new byte[2] {1, 0 })] Fallback fallback, [Nullable(new byte[2] {2, 0 })] Fallback fallbackInvoke = null);
		private DynamicMetaObject BuildCallMethodWithResult(string methodName, DynamicMetaObjectBinder binder, IEnumerable<Expression> args, DynamicMetaObject fallbackResult, [Nullable(new byte[2] {2, 0 })] Fallback fallbackInvoke);
		private DynamicMetaObject CallMethodReturnLast(string methodName, DynamicMetaObjectBinder binder, IEnumerable<Expression> args, [Nullable(new byte[2] {1, 0 })] Fallback fallback);
		private DynamicMetaObject CallMethodNoResult(string methodName, DynamicMetaObjectBinder binder, Expression[] args, [Nullable(new byte[2] {1, 0 })] Fallback fallback);
		private BindingRestrictions GetRestrictions();
		public override IEnumerable<string> GetDynamicMemberNames();
	}
}
