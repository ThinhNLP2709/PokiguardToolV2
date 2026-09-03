/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalEntityChunk : DecalChunk // TypeDefIndex: 9428
	{
		// Fields
		public Material material; // 0x28
		public NativeArray<DecalEntity> decalEntities; // 0x30
		public DecalProjector[] decalProjectors; // 0x40
		public TransformAccessArray transformAccessArray; // 0x48
	
		// Constructors
		public DecalEntityChunk(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override void Push(); // 0x0000000181F73190-0x0000000181F731A0
		public override void RemoveAtSwapBack(int entityIndex); // 0x0000000181F757A0-0x0000000181F75800
		public override void SetCapacity(int newCapacity); // 0x0000000181F75800-0x0000000181F75940
		public override void Dispose(); // 0x0000000181F75730-0x0000000181F757A0
	}
}
