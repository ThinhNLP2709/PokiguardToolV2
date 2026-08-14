namespace DG.Tweening.Plugins;

public class RectOffsetPlugin : ABSTweenPlugin<RectOffset, RectOffset, NoOptions>
{
	private static RectOffset _r; //Field offset: 0x0

	private static RectOffsetPlugin() { }

	public RectOffsetPlugin() { }

	public virtual RectOffset ConvertToStartValue(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset value) { }

	public virtual void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, float elapsed, RectOffset startValue, RectOffset changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, RectOffset changeValue) { }

	public virtual void Reset(TweenerCore<RectOffset, RectOffset, NoOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<RectOffset, RectOffset, NoOptions> t) { }

	public virtual void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<RectOffset, RectOffset, NoOptions> t) { }

}

