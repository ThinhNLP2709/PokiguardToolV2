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

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	public abstract class SpriteShapeGeometryCreator : ScriptableObject // TypeDefIndex: 14016
	{
		// Constructors
		protected SpriteShapeGeometryCreator(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public abstract int GetVertexArrayCount(SpriteShapeController spriteShapeController);
		public abstract JobHandle MakeCreatorJob(SpriteShapeController spriteShapeController, NativeArray<ushort> indices, NativeSlice<Vector3> positions, NativeSlice<Vector2> texCoords, NativeSlice<Vector4> tangents, NativeArray<SpriteShapeSegment> segments, NativeArray<float2> colliderData);
		public virtual int GetVersion(); // 0x0000000181C60C50-0x0000000181C60C80
	}
}
