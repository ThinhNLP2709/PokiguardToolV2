/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	public sealed class RenderGraphObjectPool // TypeDefIndex: 5926
	{
		// Fields
		private static readonly DynamicArray<SharedObjectPoolBase> s_AllocatedPools; // 0x00
		private Dictionary<ValueTuple<Type, int>, Stack<object>> m_ArrayPool; // 0x10
		private List<ValueTuple<object, ValueTuple<Type, int>>> m_AllocatedArrays; // 0x18
		private List<MaterialPropertyBlock> m_AllocatedMaterialPropertyBlocks; // 0x20
	
		// Nested types
		private class SharedObjectPoolBase // TypeDefIndex: 5927
		{
			// Constructors
			public SharedObjectPoolBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public virtual void Clear(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		private class SharedObjectPool<T> : SharedObjectPoolBase // TypeDefIndex: 5928
			where T : class, new()
		{
			// Fields
			private static readonly UnityEngine.Pool.ObjectPool<T> s_Pool;
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 5929
			{
				// Fields
				public static readonly __c<T> __9;
				public static Func<T> __9__1_0;
	
				// Constructors
				static __c();
				public __c();
	
				// Methods
				internal T _AllocatePool_b__1_0();
			}
	
			// Constructors
			public SharedObjectPool();
			static SharedObjectPool();
	
			// Methods
			private static UnityEngine.Pool.ObjectPool<T> AllocatePool();
			public override void Clear();
			public static T Get();
			public static void Release(T toRelease);
		}
	
		// Constructors
		internal RenderGraphObjectPool(); // 0x0000000181EE0ED0-0x0000000181EE0FE0
		static RenderGraphObjectPool(); // 0x0000000181EE0E40-0x0000000181EE0ED0
	
		// Methods
		public T[] GetTempArray<T>(int size);
		public MaterialPropertyBlock GetTempMaterialPropertyBlock(); // 0x0000000181EE09F0-0x0000000181EE0AF0
		internal void ReleaseAllTempAlloc(); // 0x0000000181EE0B30-0x0000000181EE0E40
		internal bool IsEmpty(); // 0x0000000181EE0AF0-0x0000000181EE0B30
		internal T Get<T>()
			where T : class, new();
		internal void Release<T>(T value)
			where T : class, new();
		internal void Cleanup(); // 0x0000000181EE08B0-0x0000000181EE09F0
	}
}
