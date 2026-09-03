/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct URPLightShadowCullingInfos // TypeDefIndex: 9782
	{
		// Fields
		public NativeArray<ShadowSliceData> slices; // 0x00
		public uint slicesValidMask; // 0x10
	
		// Methods
		[IsReadOnly]
		public bool IsSliceValid(int i); // 0x0000000181FF44D0-0x0000000181FF44F0
	}
}
