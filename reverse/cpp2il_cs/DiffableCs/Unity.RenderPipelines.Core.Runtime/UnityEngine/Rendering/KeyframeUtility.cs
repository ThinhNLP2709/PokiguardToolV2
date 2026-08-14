namespace UnityEngine.Rendering;

public class KeyframeUtility
{

	public KeyframeUtility() { }

	private static void EvalCurveSegmentAndDeriv(out float dstValue, out float dstDeriv, Keyframe lhsKey, Keyframe rhsKey, float desiredTime) { }

	private static Keyframe EvalKeyAtTime(NativeArray<Keyframe> keys, int lhsIndex, int rhsIndex, float startTime, float endTime, float currTime) { }

	private static Keyframe FetchKeyFromIndexClampEdge(NativeArray<Keyframe> keys, int index, float segmentStartTime, float segmentEndTime) { }

	private static Keyframe GetKeyframeAndClampEdge(NativeArray<Keyframe> keys, int index) { }

	public static void InterpAnimationCurve(ref AnimationCurve lhsAndResultCurve, AnimationCurve rhsCurve, float t) { }

	private static Keyframe LerpSingleKeyframe(Keyframe lhs, Keyframe rhs, float t) { }

	public static void ResetAnimationCurve(AnimationCurve curve) { }

}

