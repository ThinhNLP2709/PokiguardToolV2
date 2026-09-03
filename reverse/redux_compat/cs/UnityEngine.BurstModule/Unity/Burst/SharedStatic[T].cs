/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst
{
	[IsReadOnly]
	[VisibleToOtherModules]
	public struct SharedStatic<T> // TypeDefIndex: 15024
		where T : struct
	{
		// Fields
		private readonly unsafe void* _buffer;
	
		// Properties
		public ref T Data { get; }
		private static uint SizeOfT { get; }
	
		// Constructors
		private unsafe SharedStatic(void* buffer);
	
		// Methods
		public static SharedStatic<T> GetOrCreate<TContext>(uint alignment = 0 /* Metadata: 0x006A9C25 */);
		public static SharedStatic<T> GetOrCreateUnsafe(uint alignment, long hashCode, long subHashCode);
	}
}
