/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[MovedFrom("UnityEngine.Experimental.Rendering")]
	public struct RayTracingMeshInstanceConfig // TypeDefIndex: 8318
	{
		// Fields
		public Mesh mesh; // 0x00
		public uint subMeshIndex; // 0x08
		public RayTracingSubMeshFlags subMeshFlags; // 0x0C
		[CompilerGenerated]
		private RayTracingMode _rayTracingMode_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _dynamicGeometry_k__BackingField; // 0x14
		public Material material; // 0x18
		public MaterialPropertyBlock materialProperties; // 0x20
		public bool enableTriangleCulling; // 0x28
		public bool frontTriangleCounterClockwise; // 0x29
		public int layer; // 0x2C
		public uint renderingLayerMask; // 0x30
		public uint mask; // 0x34
		public MotionVectorGenerationMode motionVectorMode; // 0x38
		public LightProbeUsage lightProbeUsage; // 0x3C
		[Obsolete("This field is obsolete. #from(6000.5)", false)]
		public LightProbeProxyVolume lightProbeProxyVolume; // 0x40
		[CompilerGenerated]
		private RayTracingAccelerationStructureBuildFlags _accelerationStructureBuildFlags_k__BackingField; // 0x48
		[CompilerGenerated]
		private bool _accelerationStructureBuildFlagsOverride_k__BackingField; // 0x4C
		public int meshLod; // 0x50
	
		// Properties
		public RayTracingMode rayTracingMode { [CompilerGenerated] set; } // 0x00000001805D5560-0x00000001805D5570
		[Obsolete("dynamicGeometry has been deprecated and will be removed in the future. Use rayTracingMode instead.", false)]
		public bool dynamicGeometry { [CompilerGenerated] set; } // 0x0000000181541B70-0x0000000181541B80
		public RayTracingAccelerationStructureBuildFlags accelerationStructureBuildFlags { [CompilerGenerated] set; } // 0x000000018033E7A0-0x000000018033E7B0
		public bool accelerationStructureBuildFlagsOverride { [CompilerGenerated] set; } // 0x0000000181DB90D0-0x0000000181DB90E0
	
		// Constructors
		public RayTracingMeshInstanceConfig(); // 0x000000018224F3A0-0x000000018224F4B0
		public RayTracingMeshInstanceConfig(Mesh mesh, uint subMeshIndex, Material material); // 0x000000018224F270-0x000000018224F3A0
	}
}
