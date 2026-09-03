/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[IsReadOnly]
	internal struct PooledResourceEntry<Type> // TypeDefIndex: 5948
		where Type : class
	{
		// Fields
		public readonly Type resource;
		public readonly int frameIndex;
		public readonly int executionCount;
	
		// Constructors
		public PooledResourceEntry(Type resource, int frameIndex, int executionCount);
	}
}
