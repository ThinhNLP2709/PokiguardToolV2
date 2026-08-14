namespace DG.Tweening.Plugins;

public class LongPlugin : ABSTweenPlugin<Int64, Int64, NoOptions>
{

	public LongPlugin() { }

	public virtual long ConvertToStartValue(TweenerCore<Int64, Int64, NoOptions> t, long value) { }

	public virtual void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<Int64> getter, DOSetter<Int64> setter, float elapsed, long startValue, long changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, long changeValue) { }

	public virtual void Reset(TweenerCore<Int64, Int64, NoOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Int64, Int64, NoOptions> t) { }

	public virtual void SetFrom(TweenerCore<Int64, Int64, NoOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Int64, Int64, NoOptions> t, long fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Int64, Int64, NoOptions> t) { }

}

