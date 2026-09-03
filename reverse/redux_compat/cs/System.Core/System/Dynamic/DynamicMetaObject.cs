/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic
{
	public class DynamicMetaObject // TypeDefIndex: 12562
	{
		// Fields
		public static readonly DynamicMetaObject[] EmptyMetaObjects; // 0x00
		private static readonly object s_noValueSentinel; // 0x08
		private readonly object _value; // 0x10
		[CompilerGenerated]
		private readonly Expression _Expression_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly BindingRestrictions _Restrictions_k__BackingField; // 0x20
	
		// Properties
		public Expression Expression { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public BindingRestrictions Restrictions { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public object Value { get; } // 0x00000001817ED280-0x00000001817ED300 
		public bool HasValue { get; } // 0x00000001817ED070-0x00000001817ED0D0 
		public Type RuntimeType { get; } // 0x00000001817ED1B0-0x00000001817ED280 
		public Type LimitType { get; } // 0x00000001817ED0D0-0x00000001817ED1B0 
	
		// Constructors
		public DynamicMetaObject(Expression expression, BindingRestrictions restrictions); // 0x00000001817ECF90-0x00000001817ED070
		public DynamicMetaObject(Expression expression, BindingRestrictions restrictions, object value); // 0x00000001817ECE90-0x00000001817ECF90
		static DynamicMetaObject(); // 0x00000001817ECDB0-0x00000001817ECE90
	
		// Methods
		public virtual DynamicMetaObject BindConvert(ConvertBinder binder); // 0x00000001817EC560-0x00000001817EC5D0
		public virtual DynamicMetaObject BindGetMember(GetMemberBinder binder); // 0x00000001817EC7E0-0x00000001817EC850
		public virtual DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value); // 0x00000001817EC9E0-0x00000001817ECA60
		public virtual DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder); // 0x00000001817EC6F0-0x00000001817EC760
		public virtual DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes); // 0x00000001817EC760-0x00000001817EC7E0
		public virtual DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value); // 0x00000001817EC950-0x00000001817EC9E0
		public virtual DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes); // 0x00000001817EC660-0x00000001817EC6F0
		public virtual DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args); // 0x00000001817EC850-0x00000001817EC8D0
		public virtual DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args); // 0x00000001817EC8D0-0x00000001817EC950
		public virtual DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args); // 0x00000001817EC5D0-0x00000001817EC660
		public virtual DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder); // 0x00000001817ECA60-0x00000001817ECAD0
		public virtual DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg); // 0x00000001817EC4D0-0x00000001817EC560
		public virtual IEnumerable<string> GetDynamicMemberNames(); // 0x00000001817ECD40-0x00000001817ECDB0
		public static DynamicMetaObject Create(object value, Expression expression); // 0x00000001817ECAD0-0x00000001817ECD40
	}
}
