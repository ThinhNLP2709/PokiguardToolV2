/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal static class SpriteSkinBoneBoundsUtility // TypeDefIndex: 14413
	{
		// Methods
		[BurstCompile]
		private static void CalculateBoneBoundsBurst(ref NativeSlice<Vector3> vertices, ref NativeSlice<BoneWeight> boneWeights, ref NativeSlice<Matrix4x4> bindPoses, int boneCount, ref NativeArray<Bounds> boneBounds); // 0x0000000181C24F00-0x0000000181C25320
		public static NativeArray<Bounds> CalculateBoneBounds(Sprite sprite); // 0x0000000181C25320-0x0000000181C254A0
	}
}
