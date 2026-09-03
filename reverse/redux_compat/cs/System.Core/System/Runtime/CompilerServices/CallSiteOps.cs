/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Runtime.CompilerServices
{
	[DebuggerStepThrough]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class CallSiteOps // TypeDefIndex: 12541
	{
		// Methods
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static CallSite<T> CreateMatchmaker<T>(CallSite<T> site)
			where T : class;
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static bool SetNotMatched(CallSite site); // 0x00000001817E8030-0x00000001817E8050
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static bool GetMatch(CallSite site); // 0x0000000180F9E760-0x0000000180F9E780
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static void ClearMatch(CallSite site); // 0x00000001817E8010-0x00000001817E8030
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static void AddRule<T>(CallSite<T> site, T rule)
			where T : class;
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static void UpdateRules<T>(CallSite<T> @this, int matched)
			where T : class;
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static T[] GetRules<T>(CallSite<T> site)
			where T : class;
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static RuleCache<T> GetRuleCache<T>(CallSite<T> site)
			where T : class;
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static void MoveRule<T>(RuleCache<T> cache, T rule, int i)
			where T : class;
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static T[] GetCachedRules<T>(RuleCache<T> cache)
			where T : class;
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("do not use this method", true)]
		public static T Bind<T>(CallSiteBinder binder, CallSite<T> site, object[] args)
			where T : class;
	}
}
