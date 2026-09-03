/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct BatchCullingContext // TypeDefIndex: 8358
	{
		// Fields
		public readonly NativeArray<Plane> cullingPlanes; // 0x00
		public readonly NativeArray<CullingSplit> cullingSplits; // 0x10
		public readonly LODParameters lodParameters; // 0x20
		public readonly Matrix4x4 localToWorldMatrix; // 0x3C
		public readonly BatchCullingViewType viewType; // 0x7C
		public readonly BatchCullingProjectionType projectionType; // 0x80
		public readonly BatchCullingFlags cullingFlags; // 0x84
		public readonly BatchPackedCullingViewID viewID; // 0x88
		public readonly uint cullingLayerMask; // 0x90
		public readonly ulong sceneCullingMask; // 0x98
		public readonly ushort splitExclusionMask; // 0xA0
		[Obsolete("BatchCullingContext.isOrthographic is deprecated. Use BatchCullingContext.projectionType instead.")]
		public readonly byte isOrthographic; // 0xA2
		public readonly int receiverPlaneOffset; // 0xA4
		public readonly int receiverPlaneCount; // 0xA8
		internal readonly IntPtr occlusionBuffer; // 0xB0
	
		// Constructors
		internal BatchCullingContext(NativeArray<Plane> inCullingPlanes, NativeArray<CullingSplit> inCullingSplits, LODParameters inLodParameters, Matrix4x4 inLocalToWorldMatrix, BatchCullingViewType inViewType, BatchCullingProjectionType inProjectionType, BatchCullingFlags inBatchCullingFlags, ulong inViewID, uint inCullingLayerMask, ulong inSceneCullingMask, byte inExclusionSplitMask, int inReceiverPlaneOffset, int inReceiverPlaneCount, IntPtr inOcclusionBuffer); // 0x0000000182255270-0x0000000182255330
	}
}
