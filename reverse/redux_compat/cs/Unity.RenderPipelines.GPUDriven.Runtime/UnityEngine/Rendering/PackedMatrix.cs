/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct PackedMatrix // TypeDefIndex: 12831
	{
		// Fields
		public float4 packed0; // 0x00
		public float4 packed1; // 0x10
		public float4 packed2; // 0x20
	
		// Methods
		public static PackedMatrix FromMatrix4x4([IsReadOnly] in Matrix4x4 m); // 0x0000000181F29740-0x0000000181F297F0
		public static PackedMatrix FromFloat4x4([IsReadOnly] in float4x4 m); // 0x0000000181F29740-0x0000000181F297F0
		public override string ToString(); // 0x0000000181F297F0-0x0000000181F298A0
	}
}
