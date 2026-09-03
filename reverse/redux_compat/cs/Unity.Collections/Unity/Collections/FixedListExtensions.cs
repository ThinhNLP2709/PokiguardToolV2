/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	public static class FixedListExtensions // TypeDefIndex: 11516
	{
		// Extension methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this ref FixedList32Bytes<T> list)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(NativeSortExtension.DefaultComparer<int>) })]
		public static void Sort<T, U>(this ref FixedList32Bytes<T> list, U comp)
			where T : struct, IComparable<T>
			where U : struct, IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this ref FixedList64Bytes<T> list)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(NativeSortExtension.DefaultComparer<int>) })]
		public static void Sort<T, U>(this ref FixedList64Bytes<T> list, U comp)
			where T : struct, IComparable<T>
			where U : struct, IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this ref FixedList128Bytes<T> list)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(NativeSortExtension.DefaultComparer<int>) })]
		public static void Sort<T, U>(this ref FixedList128Bytes<T> list, U comp)
			where T : struct, IComparable<T>
			where U : struct, IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this ref FixedList512Bytes<T> list)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(NativeSortExtension.DefaultComparer<int>) })]
		public static void Sort<T, U>(this ref FixedList512Bytes<T> list, U comp)
			where T : struct, IComparable<T>
			where U : struct, IComparer<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Sort<T>(this ref FixedList4096Bytes<T> list)
			where T : struct, IComparable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(NativeSortExtension.DefaultComparer<int>) })]
		public static void Sort<T, U>(this ref FixedList4096Bytes<T> list, U comp)
			where T : struct, IComparable<T>
			where U : struct, IComparer<T>;
	}
}
