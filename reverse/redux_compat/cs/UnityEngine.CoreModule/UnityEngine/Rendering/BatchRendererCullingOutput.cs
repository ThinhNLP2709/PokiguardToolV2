/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[UsedByNativeCode]
	internal struct BatchRendererCullingOutput // TypeDefIndex: 8360
	{
		// Fields
		public JobHandle cullingJobsFence; // 0x00
		public Matrix4x4 localToWorldMatrix; // 0x10
		public unsafe Plane* cullingPlanes; // 0x50
		public int cullingPlaneCount; // 0x58
		public int receiverPlaneOffset; // 0x5C
		public int receiverPlaneCount; // 0x60
		public unsafe CullingSplit* cullingSplits; // 0x68
		public int cullingSplitCount; // 0x70
		public BatchCullingViewType viewType; // 0x74
		public BatchCullingProjectionType projectionType; // 0x78
		public BatchCullingFlags cullingFlags; // 0x7C
		public ulong viewID; // 0x80
		public uint cullingLayerMask; // 0x88
		public byte splitExclusionMask; // 0x8C
		public ulong sceneCullingMask; // 0x90
		public unsafe BatchCullingOutputDrawCommands* drawCommands; // 0x98
		public uint brgId; // 0xA0
		public IntPtr occlusionBuffer; // 0xA8
		public IntPtr customCullingResult; // 0xB0
	}
}
