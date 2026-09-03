/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal struct SpriteSkinData // TypeDefIndex: 14338
	{
		// Fields
		public NativeCustomSlice<Vector3> vertices; // 0x00
		public NativeCustomSlice<BoneWeight> boneWeights; // 0x10
		public NativeCustomSlice<Matrix4x4> bindPoses; // 0x20
		public NativeCustomSlice<Vector4> tangents; // 0x30
		public bool hasTangents; // 0x40
		public int spriteVertexStreamSize; // 0x44
		public int spriteVertexCount; // 0x48
		public int tangentVertexOffset; // 0x4C
		public int deformVerticesStartPos; // 0x50
		public int previousDeformVerticesStartPos; // 0x54
		public EntityId transformId; // 0x58
		public NativeCustomSlice<EntityId> boneTransformId; // 0x60
		public NativeCustomSlice<Bounds> boneBounds; // 0x70
	}
}
