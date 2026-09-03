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
	[DebuggerDisplay("PassFragmentData: Res({resource.index}):{accessFlags}")]
	[IsReadOnly]
	internal struct PassFragmentData // TypeDefIndex: 5996
	{
		// Fields
		public readonly ResourceHandle resource; // 0x00
		public readonly AccessFlags accessFlags; // 0x0C
		public readonly int mipLevel; // 0x10
		public readonly int depthSlice; // 0x14
	
		// Constructors
		public PassFragmentData([IsReadOnly] in ResourceHandle handle, AccessFlags flags, int mipLevel, int depthSlice); // 0x0000000181F01DD0-0x0000000181F01DF0
	
		// Methods
		public override int GetHashCode(); // 0x0000000181F01CA0-0x0000000181F01D50
		public static bool SameSubResource([IsReadOnly] in PassFragmentData x, [IsReadOnly] in PassFragmentData y); // 0x0000000181F01D50-0x0000000181F01DD0
	}
}
