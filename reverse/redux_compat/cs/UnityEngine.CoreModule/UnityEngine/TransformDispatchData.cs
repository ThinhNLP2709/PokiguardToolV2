/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal struct TransformDispatchData : IDisposable // TypeDefIndex: 7673
	{
		// Fields
		public NativeArray<EntityId> transformedID; // 0x00
		public NativeArray<EntityId> parentID; // 0x10
		public NativeArray<Matrix4x4> localToWorldMatrices; // 0x20
		public NativeArray<Vector3> positions; // 0x30
		public NativeArray<Quaternion> rotations; // 0x40
		public NativeArray<Vector3> scales; // 0x50
	
		// Methods
		public void Dispose(); // 0x00000001821FAC10-0x00000001821FACC0
	}
}
