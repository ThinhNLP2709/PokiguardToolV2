/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.CompilerServices
{
	internal static class AsyncTaskCache // TypeDefIndex: 3228
	{
		// Fields
		internal static readonly Task<bool> TrueTask; // 0x00
		internal static readonly Task<bool> FalseTask; // 0x08
		internal static readonly Task<int>[] Int32Tasks; // 0x10
	
		// Constructors
		static AsyncTaskCache(); // 0x000000018150A3F0-0x000000018150A5E0
	
		// Methods
		private static Task<int>[] CreateInt32Tasks(); // 0x000000018150A2D0-0x000000018150A3F0
		internal static Task<TResult> CreateCacheableTask<TResult>(TResult result);
	}
}
