namespace DG.Tweening.Plugins;

public class RectPlugin : ABSTweenPlugin<Rect, Rect, RectOptions>
{

	public RectPlugin() { }

	public virtual Rect ConvertToStartValue(TweenerCore<Rect, Rect, RectOptions> t, Rect value) { }

	public virtual void EvaluateAndApply(RectOptions options, Tween t, bool isRelative, DOGetter<Rect> getter, DOSetter<Rect> setter, float elapsed, Rect startValue, Rect changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(RectOptions options, float unitsXSecond, Rect changeValue) { }

	public virtual void Reset(TweenerCore<Rect, Rect, RectOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Rect, Rect, RectOptions> t) { }

	public virtual void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, Rect fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Rect, Rect, RectOptions> t) { }

}

