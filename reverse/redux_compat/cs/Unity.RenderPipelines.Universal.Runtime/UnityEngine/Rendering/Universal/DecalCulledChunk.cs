/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalCulledChunk : DecalChunk // TypeDefIndex: 9437
	{
		// Fields
		public Vector3 cameraPosition; // 0x28
		public ulong sceneCullingMask; // 0x38
		public int cullingMask; // 0x40
		public CullingGroup cullingGroups; // 0x48
		public int[] visibleDecalIndexArray; // 0x50
		public NativeArray<int> visibleDecalIndices; // 0x58
		public int visibleDecalCount; // 0x68
	
		// Constructors
		public DecalCulledChunk(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override void RemoveAtSwapBack(int entityIndex); // 0x0000000181F739C0-0x0000000181F73A20
		public override void SetCapacity(int newCapacity); // 0x0000000181F73A20-0x0000000181F73AD0
		public override void Dispose(); // 0x0000000181F73930-0x0000000181F739C0
	}
}
