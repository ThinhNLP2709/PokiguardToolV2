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
	public struct GPUResidentDrawerSettings // TypeDefIndex: 12935
	{
		// Fields
		public GPUResidentDrawerMode mode; // 0x00
		public bool supportDitheringCrossFade; // 0x01
		public bool enableOcclusionCulling; // 0x02
		public bool allowInEditMode; // 0x03
		public float smallMeshScreenPercentage; // 0x04
		public float4 shadowSmallMeshScreenPercentages; // 0x08
		public Shader errorShader; // 0x18
		public Shader loadingShader; // 0x20
	}
}
