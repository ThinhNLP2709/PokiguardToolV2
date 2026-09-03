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

namespace System.Runtime.CompilerServices
{
	public abstract class CallSiteBinder // TypeDefIndex: 12539
	{
		// Fields
		internal Dictionary<Type, object> Cache; // 0x10
		[CompilerGenerated]
		private static readonly LabelTarget _UpdateLabel_k__BackingField; // 0x00
	
		// Properties
		public static LabelTarget UpdateLabel { [CompilerGenerated] get; } // 0x00000001817E7FC0-0x00000001817E8010 
	
		// Nested types
		private sealed class LambdaSignature<T> // TypeDefIndex: 12540
			where T : class
		{
			// Fields
			private static LambdaSignature<T> s_instance;
			internal readonly ReadOnlyCollection<ParameterExpression> Parameters;
			internal readonly LabelTarget ReturnLabel;
	
			// Properties
			internal static LambdaSignature<T> Instance { get; }
	
			// Constructors
			private LambdaSignature();
		}
	
		// Constructors
		protected CallSiteBinder(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static CallSiteBinder(); // 0x00000001817E7F30-0x00000001817E7FC0
	
		// Methods
		public abstract Expression Bind(object[] args, ReadOnlyCollection<ParameterExpression> parameters, LabelTarget returnLabel);
		public virtual T BindDelegate<T>(CallSite<T> site, object[] args)
			where T : class;
		internal T BindCore<T>(CallSite<T> site, object[] args)
			where T : class;
		protected void CacheTarget<T>(T target)
			where T : class;
		private static Expression<T> Stitch<T>(Expression binding, LambdaSignature<T> signature)
			where T : class;
		internal RuleCache<T> GetRuleCache<T>()
			where T : class;
	}
}
