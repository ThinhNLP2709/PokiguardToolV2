/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct PinnedArray<T> : IDisposable // TypeDefIndex: 9507
		where T : struct
	{
		// Fields
		public T[] managedArray;
		public GCHandle handle;
		public NativeArray<T> nativeArray;
	
		// Properties
		public int length { get; }
	
		// Constructors
		public PinnedArray(int length);
	
		// Methods
		public void Dispose();
	}
}
