namespace DG.Tweening.Core;

[Extension]
public static class Extensions
{

	[Extension]
	public static TweenerCore<T1, T2, TPlugOptions> Blendable(TweenerCore<T1, T2, TPlugOptions> t) { }

	[Extension]
	public static TweenerCore<T1, T2, TPlugOptions> NoFrom(TweenerCore<T1, T2, TPlugOptions> t) { }

	[Extension]
	public static T SetSpecialStartupMode(T t, SpecialStartupMode mode) { }

}

