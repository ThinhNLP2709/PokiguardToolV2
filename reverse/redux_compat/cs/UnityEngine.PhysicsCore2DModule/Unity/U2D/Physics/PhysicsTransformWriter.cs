/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Scripting;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	internal struct PhysicsTransformWriter // TypeDefIndex: 14702
	{
		// Fields
		private static readonly ProfilerMarker s_WriteTransformsMarker; // 0x00
		private static readonly ProfilerMarker s_WriteTransformsCalculateWorldTransformsMarker; // 0x08
		private static readonly ProfilerMarker s_WriteTransformsWriteTransformsParallelJobMarker; // 0x10
		private static readonly ProfilerMarker s_WriteTransformsWriteTransformsSequentialJobMarker; // 0x18
		private static readonly ProfilerMarker s_WriteTransformsCustomMarker; // 0x20
	
		// Nested types
		private struct WriteTransformsParallelJob : IJobParallelForTransform // TypeDefIndex: 14703
		{
			// Fields
			[ReadOnly]
			public NativeArray<PhysicsBody.TransformWriteTween> transformWriteTweens; // 0x00
			[ReadOnly]
			public PhysicsWorld.TransformPlane transformPlane; // 0x10
			[ReadOnly]
			public PhysicsWorld.TransformPlaneCustom transformPlaneCustom; // 0x14
			[ReadOnly]
			public bool transformTweening; // 0xC0
			[ReadOnly]
			public bool fastWrite2D; // 0xC1
	
			// Methods
			public void Execute(int index, TransformAccess transformAccess); // 0x00000001822D3CF0-0x00000001822D40F0
		}
	
		// Constructors
		static PhysicsTransformWriter(); // 0x00000001822CD080-0x00000001822CD1D0
	
		// Methods
		[RequiredByNativeCode]
		private static void WriteWorldTransforms(PhysicsWorld world, PhysicsWorld.SimulationType simulationType, PhysicsWorld.TransformWriteMode transformWriteMode, PhysicsWorld.TransformPlane transformPlane, PhysicsWorld.TransformPlaneCustom transfomPlaneCustom, PhysicsWorld.TransformTweenMode transformTweenMode); // 0x00000001822CC920-0x00000001822CD080
		[RequiredByNativeCode]
		private static void WriteWorldTransformsCustom(object transformWriteCallbackTarget, PhysicsWorld world, PhysicsWorld.SimulationType simulationType, PhysicsWorld.TransformWriteMode transformWriteMode, PhysicsWorld.TransformPlane transformPlane, PhysicsWorld.TransformPlaneCustom transfomPlaneCustom, PhysicsWorld.TransformTweenMode transformTweenMode); // 0x00000001822CC2D0-0x00000001822CC8F0
		[RequiredByNativeCode]
		private static void WriteWorldTransformsGetPhysicsTransformPose3D(PhysicsBody.TransformWriteTween transformWriteTween, PhysicsWorld.TransformPlane transformPlane, PhysicsWorld.TransformPlaneCustom transfomPlaneCustom, bool fast2D, out Vector3 position, out Quaternion rotation); // 0x00000001822CC8F0-0x00000001822CC920
		private static void WriteTransformsSequentialTask(ref NativeArray<PhysicsBody.TransformWriteTween> transformWriteTweens, PhysicsWorld.TransformPlane transformPlane, ref PhysicsWorld.TransformPlaneCustom transformPlaneCustom, bool transformTweening, bool fastWrite2D); // 0x00000001822CBEE0-0x00000001822CC2D0
	}
}
