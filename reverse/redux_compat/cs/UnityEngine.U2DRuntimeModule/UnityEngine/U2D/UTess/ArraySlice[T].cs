/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

// Image 38: UnityEngine.U2DRuntimeModule.dll - Assembly: UnityEngine.U2DRuntimeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15050-15086

namespace UnityEngine.U2D.UTess
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(ArraySliceDebugView<T>))]
	internal struct ArraySlice<T> : IEquatable<UnityEngine.U2D.UTess.ArraySlice<T>> // TypeDefIndex: 15055
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe byte* m_Buffer;
		internal int m_Stride;
		internal int m_Length;
	
		// Properties
		public T this[int index] { get => default; [WriteAccessRequired] set {} }
		public int Length { get; }
	
		// Constructors
		public unsafe ArraySlice(NativeArray<T> array, int start, int length);
	
		// Methods
		public bool Equals(ArraySlice<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
	}
}
