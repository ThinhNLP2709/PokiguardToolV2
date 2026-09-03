/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	[DebuggerDisplay("PassRandomWriteData: Res({resource.index}):{index}:{preserveCounterValue}")]
	[IsReadOnly]
	internal struct PassRandomWriteData // TypeDefIndex: 5997
	{
		// Fields
		public readonly ResourceHandle resource; // 0x00
		public readonly int index; // 0x0C
		public readonly bool preserveCounterValue; // 0x10
	
		// Constructors
		public PassRandomWriteData([IsReadOnly] in ResourceHandle resource, int index, bool preserveCounterValue); // 0x0000000181F01EC0-0x0000000181F01EE0
	
		// Methods
		public override int GetHashCode(); // 0x0000000181F01E50-0x0000000181F01EC0
	}
}
