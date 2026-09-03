/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal class TransformAccessJob // TypeDefIndex: 14352
	{
		// Fields
		private Transform[] m_Transform; // 0x10
		private TransformAccessArray m_TransformAccessArray; // 0x18
		private NativeHashMap<EntityId, TransformData> m_TransformData; // 0x20
		private NativeArray<float4x4> m_TransformMatrix; // 0x28
		private NativeArray<bool> m_TransformChanged; // 0x38
		private bool m_Dirty; // 0x48
		private JobHandle m_JobHandle; // 0x50
	
		// Properties
		public NativeHashMap<EntityId, TransformData> transformData { get; } // 0x00000001802F8630-0x00000001802F8640 
		public NativeArray<float4x4> transformMatrix { get; } // 0x0000000180C46B90-0x0000000180C46BA0 
		public NativeArray<bool> transformChanged { get; } // 0x00000001817273D0-0x00000001817273E0 
	
		// Nested types
		public struct TransformData // TypeDefIndex: 14353
		{
			// Fields
			public int transformIndex; // 0x00
			public int refCount; // 0x04
	
			// Constructors
			public TransformData(int index); // 0x0000000181C2E570-0x0000000181C2E580
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass29_0 // TypeDefIndex: 14354
		{
			// Fields
			public EntityId transformId; // 0x10
	
			// Constructors
			public __c__DisplayClass29_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveTransformById_b__0(Transform t); // 0x0000000181C2E960-0x0000000181C2E9A0
		}
	
		// Constructors
		public TransformAccessJob(); // 0x0000000181C2E540-0x0000000181C2E570
	
		// Methods
		public void Destroy(); // 0x0000000181C2D7E0-0x0000000181C2D7F0
		private void InitializeDataStructures(); // 0x0000000181C2DAE0-0x0000000181C2DBC0
		private void ClearDataStructures(); // 0x0000000181C2D720-0x0000000181C2D7E0
		public void ResetCache(); // 0x0000000181C2E120-0x0000000181C2E140
		public void AddTransform(Transform t); // 0x0000000181C2D5C0-0x0000000181C2D720
		private static void ArrayAdd<T>(ref ref T[] array, T item);
		private static void ArrayRemoveAt<T>(ref ref T[] array, int index);
		private static bool CompactArray<T>(ref ref T[] array);
		private void UpdateTransformIndex(); // 0x0000000181C2E320-0x0000000181C2E540
		public JobHandle StartLocalToWorldAndChangeDetectionJob(); // 0x0000000181C2E140-0x0000000181C2E250
		public JobHandle StartWorldToLocalJob(); // 0x0000000181C2E250-0x0000000181C2E320
		internal string GetDebugLog(); // 0x0000000181C2D7F0-0x0000000181C2DAE0
		internal int RemoveTransformsIfNull(); // 0x0000000181C2DFA0-0x0000000181C2E120
		internal void RemoveTransformsByIds(List<EntityId> idsToRemove); // 0x0000000181C2DD50-0x0000000181C2DFA0
		internal void RemoveTransformById(EntityId transformId); // 0x0000000181C2DBC0-0x0000000181C2DD50
	}
}
