/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	public static class LazyInitializer // TypeDefIndex: 2529
	{
		// Methods
		public static T EnsureInitialized<T>(ref ref T target)
			where T : class;
		private static T EnsureInitializedCore<T>(ref ref T target)
			where T : class;
		public static T EnsureInitialized<T>(ref ref T target, Func<T> valueFactory)
			where T : class;
		private static T EnsureInitializedCore<T>(ref ref T target, Func<T> valueFactory)
			where T : class;
		public static T EnsureInitialized<T>(ref ref T target, ref bool initialized, ref object syncLock, Func<T> valueFactory);
		private static T EnsureInitializedCore<T>(ref ref T target, ref bool initialized, ref object syncLock, Func<T> valueFactory);
		public static T EnsureInitialized<T>(ref ref T target, ref object syncLock, Func<T> valueFactory)
			where T : class;
		private static T EnsureInitializedCore<T>(ref ref T target, ref object syncLock, Func<T> valueFactory)
			where T : class;
		private static object EnsureLockInitialized(ref object syncLock); // 0x000000018166F6C0-0x000000018166F730
	}
}
