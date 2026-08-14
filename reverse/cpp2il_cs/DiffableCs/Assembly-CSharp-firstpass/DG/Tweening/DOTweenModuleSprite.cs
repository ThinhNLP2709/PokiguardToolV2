namespace DG.Tweening;

[Extension]
public static class DOTweenModuleSprite
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public SpriteRenderer target; //Field offset: 0x10

		public <>c__DisplayClass0_0() { }

		internal Color <DOColor>b__0() { }

		internal void <DOColor>b__1(Color x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public SpriteRenderer target; //Field offset: 0x10

		public <>c__DisplayClass1_0() { }

		internal Color <DOFade>b__0() { }

		internal void <DOFade>b__1(Color x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public Color to; //Field offset: 0x10
		public SpriteRenderer target; //Field offset: 0x20

		public <>c__DisplayClass3_0() { }

		internal Color <DOBlendableColor>b__0() { }

		internal void <DOBlendableColor>b__1(Color x) { }

	}


	[Extension]
	public static Tweener DOBlendableColor(SpriteRenderer target, Color endValue, float duration) { }

	[Extension]
	public static TweenerCore<Color, Color, ColorOptions> DOColor(SpriteRenderer target, Color endValue, float duration) { }

	[Extension]
	public static TweenerCore<Color, Color, ColorOptions> DOFade(SpriteRenderer target, float endValue, float duration) { }

	[Extension]
	public static Sequence DOGradientColor(SpriteRenderer target, Gradient gradient, float duration) { }

}

