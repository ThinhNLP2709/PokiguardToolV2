namespace DG.Tweening;

[Extension]
public static class DOTweenModuleAudio
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public AudioSource target; //Field offset: 0x10

		public <>c__DisplayClass0_0() { }

		internal float <DOFade>b__0() { }

		internal void <DOFade>b__1(float x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public AudioSource target; //Field offset: 0x10

		public <>c__DisplayClass1_0() { }

		internal float <DOPitch>b__0() { }

		internal void <DOPitch>b__1(float x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public AudioMixer target; //Field offset: 0x10
		public string floatName; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal float <DOSetFloat>b__0() { }

		internal void <DOSetFloat>b__1(float x) { }

	}


	[Extension]
	public static int DOComplete(AudioMixer target, bool withCallbacks = false) { }

	[Extension]
	public static TweenerCore<Single, Single, FloatOptions> DOFade(AudioSource target, float endValue, float duration) { }

	[Extension]
	public static int DOFlip(AudioMixer target) { }

	[Extension]
	public static int DOGoto(AudioMixer target, float to, bool andPlay = false) { }

	[Extension]
	public static int DOKill(AudioMixer target, bool complete = false) { }

	[Extension]
	public static int DOPause(AudioMixer target) { }

	[Extension]
	public static TweenerCore<Single, Single, FloatOptions> DOPitch(AudioSource target, float endValue, float duration) { }

	[Extension]
	public static int DOPlay(AudioMixer target) { }

	[Extension]
	public static int DOPlayBackwards(AudioMixer target) { }

	[Extension]
	public static int DOPlayForward(AudioMixer target) { }

	[Extension]
	public static int DORestart(AudioMixer target) { }

	[Extension]
	public static int DORewind(AudioMixer target) { }

	[Extension]
	public static TweenerCore<Single, Single, FloatOptions> DOSetFloat(AudioMixer target, string floatName, float endValue, float duration) { }

	[Extension]
	public static int DOSmoothRewind(AudioMixer target) { }

	[Extension]
	public static int DOTogglePause(AudioMixer target) { }

}

