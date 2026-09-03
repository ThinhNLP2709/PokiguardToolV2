/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
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
	internal class DynamicProxy<T> // TypeDefIndex: 10115
	{
		// Constructors
		public DynamicProxy();
	
		// Methods
		public virtual IEnumerable<string> GetDynamicMemberNames(T instance);
		public virtual bool TryBinaryOperation(T instance, BinaryOperationBinder binder, object arg, [Nullable(2)] out object result);
		public virtual bool TryConvert(T instance, ConvertBinder binder, [Nullable(2)] out object result);
		public virtual bool TryCreateInstance(T instance, CreateInstanceBinder binder, object[] args, [Nullable(2)] out object result);
		public virtual bool TryDeleteIndex(T instance, DeleteIndexBinder binder, object[] indexes);
		public virtual bool TryDeleteMember(T instance, DeleteMemberBinder binder);
		public virtual bool TryGetIndex(T instance, GetIndexBinder binder, object[] indexes, [Nullable(2)] out object result);
		public virtual bool TryGetMember(T instance, GetMemberBinder binder, [Nullable(2)] out object result);
		public virtual bool TryInvoke(T instance, InvokeBinder binder, object[] args, [Nullable(2)] out object result);
		public virtual bool TryInvokeMember(T instance, InvokeMemberBinder binder, object[] args, [Nullable(2)] out object result);
		public virtual bool TrySetIndex(T instance, SetIndexBinder binder, object[] indexes, object value);
		public virtual bool TrySetMember(T instance, SetMemberBinder binder, object value);
		public virtual bool TryUnaryOperation(T instance, UnaryOperationBinder binder, [Nullable(2)] out object result);
	}
}
