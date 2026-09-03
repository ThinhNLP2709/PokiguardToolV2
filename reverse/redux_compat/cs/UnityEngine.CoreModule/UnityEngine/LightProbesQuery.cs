/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeContainer]
	[NativeHeader("Runtime/Camera/RenderLoops/LightProbeContext.h")]
	[StaticAccessor("LightProbeContextWrapper", StaticAccessorType.DoubleColon)]
	public struct LightProbesQuery : IDisposable // TypeDefIndex: 7540
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal IntPtr m_LightProbeContextWrapper; // 0x00
		internal Allocator m_AllocatorLabel; // 0x08
	
		// Nested types
		[NativeContainer]
		internal struct LightProbesQueryDispose // TypeDefIndex: 7541
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal IntPtr m_LightProbeContextWrapper; // 0x00
	
			// Methods
			public void Dispose(); // 0x00000001821A3E90-0x00000001821A3EE0
		}
	
		internal struct LightProbesQueryDisposeJob : IJob // TypeDefIndex: 7542
		{
			// Fields
			internal LightProbesQueryDispose Data; // 0x00
	
			// Methods
			public void Execute(); // 0x00000001821A3E90-0x00000001821A3EE0
		}
	
		// Constructors
		public LightProbesQuery(Allocator allocator); // 0x00000001821A43F0-0x00000001821A4450
	
		// Methods
		public void Dispose(); // 0x00000001821A41A0-0x00000001821A42B0
		public JobHandle Dispose(JobHandle inputDeps); // 0x00000001821A42B0-0x00000001821A43F0
		private static IntPtr Create(); // 0x00000001821A4130-0x00000001821A4160
		[NativeMethod(IsThreadSafe = true)]
		private static void Destroy(IntPtr lightProbeContextWrapper); // 0x00000001821A4160-0x00000001821A41A0
		public void CalculateInterpolatedLightAndOcclusionProbes(NativeArray<Vector3> positions, NativeArray<int> tetrahedronIndices, NativeArray<SphericalHarmonicsL2> lightProbes, NativeArray<Vector4> occlusionProbes); // 0x00000001821A3F50-0x00000001821A4130
		[NativeMethod(IsThreadSafe = true)]
		private static void CalculateInterpolatedLightAndOcclusionProbes(IntPtr lightProbeContextWrapper, IntPtr positions, IntPtr tetrahedronIndices, IntPtr lightProbes, IntPtr occlusionProbes, int count); // 0x00000001821A3EE0-0x00000001821A3F50
	}
}
