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
	internal struct ResourceVersionedData // TypeDefIndex: 6010
	{
		// Fields
		public bool written; // 0x00
		public int writePassId; // 0x04
		public int numReaders; // 0x08
	
		// Methods
		public void SetWritingPass(CompilerContextData ctx, [IsReadOnly] in ResourceHandle h, int passId); // 0x0000000181F023E0-0x0000000181F023F0
		public void RegisterReadingPass(CompilerContextData ctx, [IsReadOnly] in ResourceHandle h, int passId, int index); // 0x0000000181F02030-0x0000000181F02150
		public void RemoveReadingPass(CompilerContextData ctx, [IsReadOnly] in ResourceHandle h, int passId); // 0x0000000181F02150-0x0000000181F023E0
	}
}
