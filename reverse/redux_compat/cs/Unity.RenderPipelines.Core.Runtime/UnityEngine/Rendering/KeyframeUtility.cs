/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class KeyframeUtility // TypeDefIndex: 5796
	{
		// Constructors
		public KeyframeUtility(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static void ResetAnimationCurve(AnimationCurve curve); // 0x0000000181EC0570-0x0000000181EC0590
		private static Keyframe LerpSingleKeyframe(Keyframe lhs, Keyframe rhs, float t); // 0x0000000181EC0460-0x0000000181EC0570
		private static Keyframe GetKeyframeAndClampEdge([DisallowNull] NativeArray<Keyframe> keys, int index); // 0x0000000181EBFC40-0x0000000181EBFD40
		private static Keyframe FetchKeyFromIndexClampEdge([DisallowNull] NativeArray<Keyframe> keys, int index, float segmentStartTime, float segmentEndTime); // 0x0000000181EBFAC0-0x0000000181EBFC40
		private static void EvalCurveSegmentAndDeriv(out float dstValue, out float dstDeriv, Keyframe lhsKey, Keyframe rhsKey, float desiredTime); // 0x0000000181EBF780-0x0000000181EBF8A0
		private static Keyframe EvalKeyAtTime([DisallowNull] NativeArray<Keyframe> keys, int lhsIndex, int rhsIndex, float startTime, float endTime, float currTime); // 0x0000000181EBF8A0-0x0000000181EBFAC0
		public static void InterpAnimationCurve(ref AnimationCurve lhsAndResultCurve, [DisallowNull] AnimationCurve rhsCurve, float t); // 0x0000000181EBFD40-0x0000000181EC0460
	}
}
