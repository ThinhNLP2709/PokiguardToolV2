/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal struct NativeCustomSlice<T> // TypeDefIndex: 14372
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		public IntPtr data;
		public int length;
		public int stride;
	
		// Properties
		public T this[int index] { get => default; }
		public int Length { get; }
	
		// Constructors
		public NativeCustomSlice(NativeSlice<T> nativeSlice);
		public NativeCustomSlice(NativeSlice<byte> slice, int length, int stride);
	
		// Methods
		public static NativeCustomSlice<T> Default();
	}
}
