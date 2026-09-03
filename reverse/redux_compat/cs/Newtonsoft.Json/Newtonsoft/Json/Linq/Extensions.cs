/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(0)]
	[NullableContext(1)]
	public static class Extensions // TypeDefIndex: 10287
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10288
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Func<JObject, IEnumerable<JProperty>> __9__4_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181738990-0x0000000181738A00
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal IEnumerable<JProperty> _Properties_b__4_0(JObject d); // 0x00000001817381E0-0x0000000181738200
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__0<T> // TypeDefIndex: 10289
			where T : JToken
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__0<T> __9;
			[Nullable(0)]
			public static Func<T, IEnumerable<JToken>> __9__0_0;
	
			// Constructors
			static __c__0();
			public __c__0();
	
			// Methods
			[NullableContext(0)]
			internal IEnumerable<JToken> _Ancestors_b__0_0(T j);
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__1<T> // TypeDefIndex: 10290
			where T : JToken
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__1<T> __9;
			[Nullable(0)]
			public static Func<T, IEnumerable<JToken>> __9__1_0;
	
			// Constructors
			static __c__1();
			public __c__1();
	
			// Methods
			[NullableContext(0)]
			internal IEnumerable<JToken> _AncestorsAndSelf_b__1_0(T j);
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__13<T, U> // TypeDefIndex: 10291
			where T : JToken
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__13<T, U> __9;
			[Nullable(0)]
			public static Func<T, IEnumerable<JToken>> __9__13_0;
	
			// Constructors
			static __c__13();
			public __c__13();
	
			// Methods
			[NullableContext(0)]
			internal IEnumerable<JToken> _Children_b__13_0(T c);
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__2<T> // TypeDefIndex: 10292
			where T : JContainer
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__2<T> __9;
			[Nullable(0)]
			public static Func<T, IEnumerable<JToken>> __9__2_0;
	
			// Constructors
			static __c__2();
			public __c__2();
	
			// Methods
			[NullableContext(0)]
			internal IEnumerable<JToken> _Descendants_b__2_0(T j);
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__3<T> // TypeDefIndex: 10293
			where T : JContainer
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__3<T> __9;
			[Nullable(0)]
			public static Func<T, IEnumerable<JToken>> __9__3_0;
	
			// Constructors
			static __c__3();
			public __c__3();
	
			// Methods
			[NullableContext(0)]
			internal IEnumerable<JToken> _DescendantsAndSelf_b__3_0(T j);
		}
	
		[CompilerGenerated]
		private sealed class _Convert_d__14<T, U> : IEnumerable<U>, IEnumerator<U> // TypeDefIndex: 10294
			where T : JToken
		{
			// Fields
			private int __1__state;
			[Nullable(2)]
			private U __2__current;
			private int __l__initialThreadId;
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerable<T> source;
			[Nullable(new byte[2] {0, 1 })]
			public IEnumerable<T> __3__source;
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<T> __7__wrap1;
	
			// Properties
			U IEnumerator<U>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _Convert_d__14(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<U> IEnumerable<U>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _Values_d__11<T, U> : IEnumerable<U>, IEnumerator<U> // TypeDefIndex: 10295
			where T : JToken
		{
			// Fields
			private int __1__state;
			[Nullable(2)]
			private U __2__current;
			private int __l__initialThreadId;
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerable<T> source;
			[Nullable(new byte[2] {0, 1 })]
			public IEnumerable<T> __3__source;
			[Nullable(0)]
			private object key;
			[Nullable(0)]
			public object __3__key;
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<T> __7__wrap1;
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap2;
	
			// Properties
			U IEnumerator<U>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _Values_d__11(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			private void __m__Finally2();
			private void __m__Finally3();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<U> IEnumerable<U>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Extension methods
		public static IJEnumerable<JToken> Ancestors<T>(this IEnumerable<T> source)
			where T : JToken;
		public static IJEnumerable<JToken> AncestorsAndSelf<T>(this IEnumerable<T> source)
			where T : JToken;
		public static IJEnumerable<JToken> Descendants<T>(this IEnumerable<T> source)
			where T : JContainer;
		public static IJEnumerable<JToken> DescendantsAndSelf<T>(this IEnumerable<T> source)
			where T : JContainer;
		public static IJEnumerable<JProperty> Properties(this IEnumerable<JObject> source); // 0x000000018171E340-0x000000018171E470
		public static IJEnumerable<JToken> Values(this IEnumerable<JToken> source, [Nullable(2)] object key); // 0x000000018171E640-0x000000018171E6C0
		public static IJEnumerable<JToken> Values(this IEnumerable<JToken> source); // 0x000000018171E6C0-0x000000018171E730
		public static IEnumerable<U> Values<U>(this IEnumerable<JToken> source, object key);
		public static IEnumerable<U> Values<U>(this IEnumerable<JToken> source);
		[NullableContext(2)]
		public static U Value<U>([Nullable(1)] this IEnumerable<JToken> value);
		public static U Value<T, U>(this IEnumerable<T> value)
			where T : JToken;
		[IteratorStateMachine(typeof(_Values_d__11<T, U>))]
		internal static IEnumerable<U> Values<T, U>(this IEnumerable<T> source, [Nullable(2)] object key)
			where T : JToken;
		public static IJEnumerable<JToken> Children<T>(this IEnumerable<T> source)
			where T : JToken;
		public static IEnumerable<U> Children<T, U>(this IEnumerable<T> source)
			where T : JToken;
		[IteratorStateMachine(typeof(_Convert_d__14<T, U>))]
		internal static IEnumerable<U> Convert<T, U>(this IEnumerable<T> source)
			where T : JToken;
		[NullableContext(2)]
		internal static U Convert<T, U>([Nullable(1)] this T token)
			where T : JToken;
		public static IJEnumerable<JToken> AsJEnumerable(this IEnumerable<JToken> source); // 0x000000018171E0E0-0x000000018171E120
		public static IJEnumerable<T> AsJEnumerable<T>(this IEnumerable<T> source)
			where T : JToken;
	}
}
