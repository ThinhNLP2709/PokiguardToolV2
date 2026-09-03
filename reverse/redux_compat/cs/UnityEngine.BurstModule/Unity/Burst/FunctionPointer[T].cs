/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst
{
	[IsReadOnly]
	public struct FunctionPointer<T> // TypeDefIndex: 15022
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		private readonly IntPtr _ptr;
	
		// Properties
		public IntPtr Value { get; }
		public T Invoke { get; }
	
		// Constructors
		public FunctionPointer(IntPtr ptr);
	}
}
