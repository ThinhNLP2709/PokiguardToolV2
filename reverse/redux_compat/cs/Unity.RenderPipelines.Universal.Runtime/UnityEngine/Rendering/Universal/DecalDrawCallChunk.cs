/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalDrawCallChunk : DecalChunk // TypeDefIndex: 9421
	{
		// Fields
		public NativeArray<float4x4> decalToWorlds; // 0x28
		public NativeArray<float4x4> normalToDecals; // 0x38
		public NativeArray<float> renderingLayerMasks; // 0x48
		public NativeArray<DecalSubDrawCall> subCalls; // 0x58
		public NativeArray<int> subCallCounts; // 0x68
	
		// Properties
		public int subCallCount { get; set; } // 0x0000000181F73CB0-0x0000000181F73CC0 0x0000000181F73CC0-0x0000000181F73CD0
	
		// Constructors
		public DecalDrawCallChunk(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override void RemoveAtSwapBack(int entityIndex); // 0x0000000181F73B80-0x0000000181F73C10
		public override void SetCapacity(int newCapacity); // 0x0000000181F73C10-0x0000000181F73CB0
		public override void Dispose(); // 0x0000000181F73AD0-0x0000000181F73B80
	}
}
