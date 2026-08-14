namespace DG.Tweening.Plugins;

public class FloatPlugin : ABSTweenPlugin<Single, Single, FloatOptions>
{

	public FloatPlugin() { }

	public virtual float ConvertToStartValue(TweenerCore<Single, Single, FloatOptions> t, float value) { }

	public virtual void EvaluateAndApply(FloatOptions options, Tween t, bool isRelative, DOGetter<Single> getter, DOSetter<Single> setter, float elapsed, float startValue, float changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(FloatOptions options, float unitsXSecond, float changeValue) { }

	public virtual void Reset(TweenerCore<Single, Single, FloatOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Single, Single, FloatOptions> t) { }

	public virtual void SetFrom(TweenerCore<Single, Single, FloatOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Single, Single, FloatOptions> t, float fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Single, Single, FloatOptions> t) { }

}

