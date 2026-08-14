namespace DG.Tweening;

public abstract class Tweener : Tween
{
	internal bool hasManuallySetStartValue; //Field offset: 0x120
	internal bool isFromAllowed; //Field offset: 0x121

	internal Tweener() { }

	public abstract Tweener ChangeEndValue(object newEndValue, float newDuration = -1, bool snapStartValue = false) { }

	public abstract Tweener ChangeEndValue(object newEndValue, bool snapStartValue) { }

	public abstract Tweener ChangeStartValue(object newStartValue, float newDuration = -1) { }

	public abstract Tweener ChangeValues(object newStartValue, object newEndValue, float newDuration = -1) { }

	internal static TweenerCore<T1, T2, TPlugOptions> DoChangeEndValue(TweenerCore<T1, T2, TPlugOptions> t, T2 newEndValue, float newDuration, bool snapStartValue) { }

	internal static TweenerCore<T1, T2, TPlugOptions> DoChangeStartValue(TweenerCore<T1, T2, TPlugOptions> t, T2 newStartValue, float newDuration) { }

	internal static TweenerCore<T1, T2, TPlugOptions> DoChangeValues(TweenerCore<T1, T2, TPlugOptions> t, T2 newStartValue, T2 newEndValue, float newDuration) { }

	internal static bool DoStartup(TweenerCore<T1, T2, TPlugOptions> t) { }

	private static void DOStartupDurationBased(TweenerCore<T1, T2, TPlugOptions> t) { }

	private static bool DOStartupSpecials(TweenerCore<T1, T2, TPlugOptions> t) { }

	internal static float DoUpdateDelay(TweenerCore<T1, T2, TPlugOptions> t, float elapsed) { }

	internal abstract Tweener SetFrom(bool relative) { }

	internal static bool Setup(TweenerCore<T1, T2, TPlugOptions> t, DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration, ABSTweenPlugin<T1, T2, TPlugOptions> plugin = null) { }

}

