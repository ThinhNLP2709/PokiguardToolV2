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
	internal class SpriteShapeDefaultCreator : SpriteShapeGeometryCreator // TypeDefIndex: 14000
	{
		// Fields
		private static SpriteShapeDefaultCreator creator; // 0x00
	
		// Properties
		internal static SpriteShapeDefaultCreator defaultInstance { get; } // 0x0000000181C4CD90-0x0000000181C4CEF0 
	
		// Constructors
		public SpriteShapeDefaultCreator(); // 0x00000001805E1340-0x00000001805E1350
	
		// Methods
		public override int GetVertexArrayCount(SpriteShapeController sc); // 0x0000000181C4C4B0-0x0000000181C4C6E0
		public override JobHandle MakeCreatorJob(SpriteShapeController sc, NativeArray<ushort> indices, NativeSlice<Vector3> positions, NativeSlice<Vector2> texCoords, NativeSlice<Vector4> tangents, NativeArray<SpriteShapeSegment> segments, NativeArray<float2> colliderData); // 0x0000000181C4C7D0-0x0000000181C4CD90
		[RuntimeInitializeOnLoadMethod]
		private static void InitializeCreator(); // 0x0000000181C4C6E0-0x0000000181C4C7D0
		public override int GetVersion(); // 0x0000000181C4C470-0x0000000181C4C4B0
	}
}
