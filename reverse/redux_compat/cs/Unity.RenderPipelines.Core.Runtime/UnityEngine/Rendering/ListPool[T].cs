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
	[Obsolete("UnityEngine.Rendering.ListPool has been deprecated. Use UnityEngine.Pool.ListPool instead.", false)]
	public static class ListPool<T> // TypeDefIndex: 5385
	{
		// Fields
		private static readonly ObjectPool<List<T>> s_Pool;
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5386
		{
			// Fields
			public static readonly __c<T> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal void _.cctor_b__4_0(List<T> l);
		}
	
		// Constructors
		static ListPool();
	
		// Methods
		public static List<T> Get();
		public static ObjectPool<List<T>> Get(out List<T> value);
		public static void Release(List<T> toRelease);
	}
}
