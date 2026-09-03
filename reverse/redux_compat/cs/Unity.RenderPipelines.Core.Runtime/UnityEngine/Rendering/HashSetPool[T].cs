/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Obsolete("UnityEngine.Rendering.HashSetPool has been deprecated. Use UnityEngine.Pool.HashSetPool instead.", false)]
	public static class HashSetPool<T> // TypeDefIndex: 5387
	{
		// Fields
		private static readonly ObjectPool<HashSet<T>> s_Pool;
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5388
		{
			// Fields
			public static readonly __c<T> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal void _.cctor_b__4_0(HashSet<T> l);
		}
	
		// Constructors
		static HashSetPool();
	
		// Methods
		public static HashSet<T> Get();
		public static ObjectPool<HashSet<T>> Get(out HashSet<T> value);
		public static void Release(HashSet<T> toRelease);
	}
}
