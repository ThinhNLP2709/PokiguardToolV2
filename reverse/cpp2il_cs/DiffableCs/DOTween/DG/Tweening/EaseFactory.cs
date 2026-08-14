namespace DG.Tweening;

public class EaseFactory
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public float motionDelay; //Field offset: 0x10
		public EaseFunction customEase; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal float <StopMotion>b__0(float time, float duration, float overshootOrAmplitude, float period) { }

	}


	public EaseFactory() { }

	public static EaseFunction StopMotion(int motionFps, Nullable<Ease> ease = null) { }

	public static EaseFunction StopMotion(int motionFps, AnimationCurve animCurve) { }

	public static EaseFunction StopMotion(int motionFps, EaseFunction customEase) { }

}

