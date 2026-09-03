/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct RayTracingAABBsInstanceConfig // TypeDefIndex: 8319
	{
		// Fields
		[CompilerGenerated]
		private GraphicsBuffer _aabbBuffer_k__BackingField; // 0x00
		[CompilerGenerated]
		private int _aabbCount_k__BackingField; // 0x08
		[CompilerGenerated]
		private uint _aabbOffset_k__BackingField; // 0x0C
		[CompilerGenerated]
		private bool _dynamicGeometry_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _opaqueMaterial_k__BackingField; // 0x11
		[CompilerGenerated]
		private Material _material_k__BackingField; // 0x18
		[CompilerGenerated]
		private MaterialPropertyBlock _materialProperties_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _layer_k__BackingField; // 0x28
		[CompilerGenerated]
		private uint _mask_k__BackingField; // 0x2C
		[CompilerGenerated]
		private RayTracingAccelerationStructureBuildFlags _accelerationStructureBuildFlags_k__BackingField; // 0x30
		[CompilerGenerated]
		private bool _accelerationStructureBuildFlagsOverride_k__BackingField; // 0x34
	
		// Properties
		public GraphicsBuffer aabbBuffer { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public int aabbCount { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public uint aabbOffset { [CompilerGenerated] set; } // 0x0000000180732D70-0x0000000180732D80
		public bool dynamicGeometry { [CompilerGenerated] set; } // 0x00000001804C2E20-0x00000001804C2E30
		public bool opaqueMaterial { [CompilerGenerated] set; } // 0x00000001815C0340-0x00000001815C0350
		public Material material { [CompilerGenerated] set; } // 0x00000001802FAF70-0x00000001802FAF80
		public MaterialPropertyBlock materialProperties { [CompilerGenerated] set; } // 0x000000018033E830-0x000000018033E840
		public int layer { [CompilerGenerated] set; } // 0x0000000180378100-0x0000000180378110
		public uint mask { [CompilerGenerated] set; } // 0x00000001803FE010-0x00000001803FE020
		public RayTracingAccelerationStructureBuildFlags accelerationStructureBuildFlags { [CompilerGenerated] set; } // 0x000000018033E780-0x000000018033E790
		public bool accelerationStructureBuildFlagsOverride { [CompilerGenerated] set; } // 0x0000000181C10650-0x0000000181C10660
	
		// Constructors
		public RayTracingAABBsInstanceConfig(); // 0x000000018224E280-0x000000018224E2F0
		public RayTracingAABBsInstanceConfig(GraphicsBuffer aabbBuffer, int aabbCount, bool dynamicGeometry, Material material); // 0x000000018224E2F0-0x000000018224E370
	}
}
