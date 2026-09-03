/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Obsolete("UnityEngine.Rendering.GenericPool has been deprecated. Use UnityEngine.Pool.GenericPool instead.", false)]
	public static class GenericPool<T> // TypeDefIndex: 5383
		where T : new()
	{
		// Fields
		private static readonly ObjectPool<T> s_Pool;
	
		// Constructors
		static GenericPool();
	
		// Methods
		public static T Get();
		public static ObjectPool<T> Get(out ref T value);
		public static void Release(T toRelease);
	}
}
