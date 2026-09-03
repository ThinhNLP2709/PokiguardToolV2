/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Profiling;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Scripting;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	internal struct PhysicsTransformTweener // TypeDefIndex: 14699
	{
		// Fields
		private static readonly ProfilerMarker s_WriteTransformTweensMarker; // 0x00
		private static readonly ProfilerMarker s_WriteTransformTweensParallelMarker; // 0x08
		private static readonly ProfilerMarker s_WriteTransformTweensSequentialMarker; // 0x10
		private static readonly ProfilerMarker s_WriteTransformTweensCustomMarker; // 0x18
		[NoAutoStaticsCleanup]
		private static TransformAccessArray[] s_WorldTransformAccessArrays; // 0x20
	
		// Nested types
		private struct WriteTransformTweensParallelJob : IJobParallelForTransform // TypeDefIndex: 14700
		{
			// Fields
			[ReadOnly]
			public float interpolationTime; // 0x00
			[ReadOnly]
			public float extrapolationTime; // 0x04
			[ReadOnly]
			public PhysicsWorld.TransformWriteMode transformWriteMode; // 0x08
			[ReadOnly]
			public PhysicsWorld.TransformPlane transformPlane; // 0x0C
			[ReadOnly]
			public PhysicsWorld.TransformPlaneCustom transformPlaneCustom; // 0x10
			[ReadOnly]
			public NativeArray<PhysicsBody.TransformWriteTween> transformWriteTweens; // 0xC0
			[ReadOnly]
			public bool syncInterpolation; // 0xD0
	
			// Methods
			public void Execute(int index, TransformAccess transformAccess); // 0x00000001822D36E0-0x00000001822D3CF0
		}
	
		// Constructors
		static PhysicsTransformTweener(); // 0x00000001822CB760-0x00000001822CB8A0
	
		// Methods
		[RequiredByNativeCode]
		private static void WriteTransformTweens(bool syncInterpolation, PhysicsWorld world, float interpolationTime, float extrapolationTime, PhysicsWorld.TransformWriteMode transformWriteMode, PhysicsWorld.TransformTweenMode transformTweenMode, PhysicsWorld.TransformPlane transformPlane, PhysicsWorld.TransformPlaneCustom transformPlaneCustom, Scripting2D.PhysicsBuffer transformWriteTweensBuffer); // 0x00000001822CB240-0x00000001822CB760
		[RequiredByNativeCode]
		private static void WriteTransformTweensCustom(object transformWriteCallbackTarget, PhysicsWorld world, float interpolationTime, float extrapolationTime, PhysicsWorld.TransformWriteMode transformWriteMode, PhysicsWorld.TransformPlane transformPlane, PhysicsWorld.TransformPlaneCustom transformPlaneCustom, Scripting2D.PhysicsBuffer transformWriteTweensBuffer); // 0x00000001822CA700-0x00000001822CAAF0
		private static void WriteTransformTweensTask(bool syncInterpolation, float interpolationTime, float extrapolationTime, PhysicsWorld.TransformWriteMode transformWriteMode, PhysicsWorld.TransformPlane transformPlane, ref PhysicsWorld.TransformPlaneCustom transformPlaneCustom, ref NativeArray<PhysicsBody.TransformWriteTween> transformWriteTweens); // 0x00000001822CAAF0-0x00000001822CB240
		private static void EnsureWorldTransformAccessArrayCapacity(int worldIndex); // 0x00000001822CA520-0x00000001822CA5D0
		[RequiredByNativeCode]
		private static void CreateWorldTransformAccessArray(PhysicsWorld world, int capacity, int desiredJobCount); // 0x00000001822CA2F0-0x00000001822CA3F0
		[RequiredByNativeCode]
		private static void DestroyWorldTransformAccessArray(PhysicsWorld world); // 0x00000001822CA3F0-0x00000001822CA520
		internal static TransformAccessArray GetWorldTransformAccessArray(PhysicsWorld world); // 0x00000001822CA5D0-0x00000001822CA700
	}
}
