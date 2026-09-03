/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	public static class Observable // TypeDefIndex: 6619
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0<TValue> // TypeDefIndex: 6620
		{
			// Fields
			public IDisposable subscription;
	
			// Constructors
			public __c__DisplayClass6_0();
	
			// Methods
			internal void _CallOnce_b__0();
		}
	
		// Extension methods
		public static IObservable<TValue> Where<TValue>(this IObservable<TValue> source, Func<TValue, bool> predicate);
		public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> filter);
		public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> filter);
		public static IObservable<TValue> Take<TValue>(this IObservable<TValue> source, int count);
		public static IObservable<InputEventPtr> ForDevice(this IObservable<InputEventPtr> source, InputDevice device); // 0x0000000181CFB660-0x0000000181CFB740
		public static IObservable<InputEventPtr> ForDevice<TDevice>(this IObservable<InputEventPtr> source)
			where TDevice : InputDevice;
		public static IDisposable CallOnce<TValue>(this IObservable<TValue> source, Action<TValue> action);
		public static IDisposable Call<TValue>(this IObservable<TValue> source, Action<TValue> action);
	}
}
