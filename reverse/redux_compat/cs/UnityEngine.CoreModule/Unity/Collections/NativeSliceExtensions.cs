/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Collections
{
	public static class NativeSliceExtensions // TypeDefIndex: 7431
	{
		// Extension methods
		public static NativeSlice<T> Slice<T>(this NativeArray<T> thisArray)
			where T : struct;
		public static NativeSlice<T> Slice<T>(this NativeArray<T> thisArray, int start)
			where T : struct;
		public static NativeSlice<T> Slice<T>(this NativeArray<T> thisArray, int start, int length)
			where T : struct;
		public static NativeSlice<T> Slice<T>(this NativeSlice<T> thisSlice, int start, int length)
			where T : struct;
	}
}
