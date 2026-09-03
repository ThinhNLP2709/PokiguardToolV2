/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[MovedFrom("UnityEngine.Experimental.Rendering")]
	public sealed class RayTracingAccelerationStructure : IDisposable // TypeDefIndex: 8320
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
	
		// Nested types
		[Flags]
		public enum RayTracingModeMask // TypeDefIndex: 8321
		{
			Nothing = 0,
			Static = 2,
			DynamicTransform = 4,
			DynamicGeometry = 8,
			DynamicGeometryManualUpdate = 16,
			Everything = 30
		}
	
		public enum ManagementMode // TypeDefIndex: 8322
		{
			Manual = 0,
			Automatic = 1
		}
	
		public struct BuildSettings // TypeDefIndex: 8323
		{
			// Fields
			[CompilerGenerated]
			private RayTracingAccelerationStructureBuildFlags _buildFlags_k__BackingField; // 0x00
			[CompilerGenerated]
			private Vector3 _relativeOrigin_k__BackingField; // 0x04
	
			// Properties
			public RayTracingAccelerationStructureBuildFlags buildFlags { [CompilerGenerated] set; } // 0x0000000180732D50-0x0000000180732D60
			public Vector3 relativeOrigin { [CompilerGenerated] set; } // 0x0000000181D8A7E0-0x0000000181D8A7F0
	
			// Constructors
			public BuildSettings(); // 0x000000018222B050-0x000000018222B080
		}
	
		public struct Settings // TypeDefIndex: 8324
		{
			// Fields
			public ManagementMode managementMode; // 0x00
			public RayTracingModeMask rayTracingModeMask; // 0x04
			public int layerMask; // 0x08
			[CompilerGenerated]
			private RayTracingAccelerationStructureBuildFlags _buildFlagsStaticGeometries_k__BackingField; // 0x0C
			[CompilerGenerated]
			private RayTracingAccelerationStructureBuildFlags _buildFlagsDynamicGeometries_k__BackingField; // 0x10
			[CompilerGenerated]
			private bool _enableCompaction_k__BackingField; // 0x14
	
			// Properties
			public RayTracingAccelerationStructureBuildFlags buildFlagsStaticGeometries { [CompilerGenerated] set; } // 0x0000000180732D70-0x0000000180732D80
			public RayTracingAccelerationStructureBuildFlags buildFlagsDynamicGeometries { [CompilerGenerated] set; } // 0x00000001805D5560-0x00000001805D5570
			public bool enableCompaction { [CompilerGenerated] set; } // 0x0000000181541B70-0x0000000181541B80
	
			// Constructors
			public Settings(); // 0x0000000182253400-0x0000000182253430
		}
	
		internal static class BindingsMarshaller // TypeDefIndex: 8325
		{
			// Methods
			public static IntPtr ConvertToNative(RayTracingAccelerationStructure rayTracingAccelerationStructure); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public RayTracingAccelerationStructure(Settings settings); // 0x000000018224F210-0x000000018224F270
	
		// Methods
		~RayTracingAccelerationStructure(); // 0x000000018224EE50-0x000000018224EEA0
		public void Dispose(); // 0x000000018224EDC0-0x000000018224EE50
		private void Dispose(bool disposing); // 0x000000018224ED50-0x000000018224EDC0
		public int AddInstance(RayTracingAABBsInstanceConfig config, Matrix4x4 matrix, uint id = 4294967295 /* Metadata: 0x0069DB3F */); // 0x000000018224E460-0x000000018224E6B0
		public int AddInstance([IsReadOnly] in RayTracingMeshInstanceConfig config, Matrix4x4 matrix, [DefaultValue("null")] Matrix4x4? prevMatrix = default, uint id = 4294967295 /* Metadata: 0x0069DB40 */); // 0x000000018224E6B0-0x000000018224EAB0
		public void RemoveInstance(int handle); // 0x000000018224EEE0-0x000000018224EF40
		public void UpdateInstanceTransform(int handle, Matrix4x4 matrix); // 0x000000018224F180-0x000000018224F210
		public void UpdateInstanceID(int handle, uint instanceID); // 0x000000018224EF90-0x000000018224F000
		public void UpdateInstanceMask(int handle, uint mask); // 0x000000018224F050-0x000000018224F0C0
		[FreeFunction(Name = "RayTracingAccelerationStructure_Bindings::ClearInstances", HasExplicitThis = true)]
		public void ClearInstances(); // 0x000000018224EBF0-0x000000018224EC50
		[FreeFunction("RayTracingAccelerationStructure_Bindings::Create")]
		private static IntPtr Create(Settings desc); // 0x000000018224EC90-0x000000018224ECD0
		[FreeFunction("RayTracingAccelerationStructure_Bindings::Destroy")]
		private static void Destroy(RayTracingAccelerationStructure accelStruct); // 0x000000018224ED10-0x000000018224ED50
		[FreeFunction(Name = "RayTracingAccelerationStructure_Bindings::RemoveInstance", HasExplicitThis = true)]
		private void RemoveInstance_InstanceID(int instanceID); // 0x000000018224EEE0-0x000000018224EF40
		[FreeFunction(Name = "RayTracingAccelerationStructure_Bindings::UpdateInstanceTransform", HasExplicitThis = true)]
		private void UpdateInstanceTransform_Handle(int handle, Matrix4x4 matrix); // 0x000000018224F110-0x000000018224F180
		[FreeFunction(Name = "RayTracingAccelerationStructure_Bindings::UpdateInstanceMask", HasExplicitThis = true)]
		private void UpdateInstanceMask_Handle(int handle, uint mask); // 0x000000018224F050-0x000000018224F0C0
		[FreeFunction(Name = "RayTracingAccelerationStructure_Bindings::UpdateInstanceID", HasExplicitThis = true)]
		private void UpdateInstanceID_Handle(int handle, uint id); // 0x000000018224EF90-0x000000018224F000
		[FreeFunction("RayTracingAccelerationStructure_Bindings::AddMeshInstance", HasExplicitThis = true)]
		private unsafe int AddMeshInstance(RayTracingMeshInstanceConfig config, Matrix4x4 matrix, Matrix4x4* prevMatrix, uint id = 4294967295 /* Metadata: 0x0069DB41 */); // 0x000000018224EB20-0x000000018224EBB0
		[FreeFunction("RayTracingAccelerationStructure_Bindings::AddAABBsInstance", HasExplicitThis = true)]
		private int AddAABBsInstance(RayTracingAABBsInstanceConfig config, Matrix4x4 matrix, uint id = 4294967295 /* Metadata: 0x0069DB42 */); // 0x000000018224E3E0-0x000000018224E460
		private static void ClearInstances_Injected(IntPtr _unity_self); // 0x000000018224EBB0-0x000000018224EBF0
		private static IntPtr Create_Injected(in Settings desc); // 0x000000018224EC50-0x000000018224EC90
		private static void Destroy_Injected(IntPtr accelStruct); // 0x000000018224ECD0-0x000000018224ED10
		private static void RemoveInstance_InstanceID_Injected(IntPtr _unity_self, int instanceID); // 0x000000018224EEA0-0x000000018224EEE0
		private static void UpdateInstanceTransform_Handle_Injected(IntPtr _unity_self, int handle, in Matrix4x4 matrix); // 0x000000018224F0C0-0x000000018224F110
		private static void UpdateInstanceMask_Handle_Injected(IntPtr _unity_self, int handle, uint mask); // 0x000000018224F000-0x000000018224F050
		private static void UpdateInstanceID_Handle_Injected(IntPtr _unity_self, int handle, uint id); // 0x000000018224EF40-0x000000018224EF90
		private static unsafe int AddMeshInstance_Injected(IntPtr _unity_self, in RayTracingMeshInstanceConfig config, in Matrix4x4 matrix, Matrix4x4* prevMatrix, uint id); // 0x000000018224EAB0-0x000000018224EB20
		private static int AddAABBsInstance_Injected(IntPtr _unity_self, in RayTracingAABBsInstanceConfig config, in Matrix4x4 matrix, uint id); // 0x000000018224E370-0x000000018224E3E0
	}
}
