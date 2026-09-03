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
	[Obsolete("UnityEngine.Rendering.DictionaryPool has been deprecated. Use UnityEngine.Pool.DictionaryPool instead.", false)]
	public static class DictionaryPool<TKey, TValue> // TypeDefIndex: 5389
	{
		// Fields
		private static readonly ObjectPool<Dictionary<TKey, TValue>> s_Pool;
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5390
		{
			// Fields
			public static readonly __c<TKey, TValue> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal void _.cctor_b__4_0(Dictionary<TKey, TValue> l);
		}
	
		// Constructors
		static DictionaryPool();
	
		// Methods
		public static Dictionary<TKey, TValue> Get();
		public static ObjectPool<Dictionary<TKey, TValue>> Get(out Dictionary<TKey, TValue> value);
		public static void Release(Dictionary<TKey, TValue> toRelease);
	}
}
