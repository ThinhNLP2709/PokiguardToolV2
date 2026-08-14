namespace DG.Tweening.Plugins;

public class IntPlugin : ABSTweenPlugin<Int32, Int32, NoOptions>
{

	public IntPlugin() { }

	public virtual int ConvertToStartValue(TweenerCore<Int32, Int32, NoOptions> t, int value) { }

	public virtual void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<Int32> getter, DOSetter<Int32> setter, float elapsed, int startValue, int changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, int changeValue) { }

	public virtual void Reset(TweenerCore<Int32, Int32, NoOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Int32, Int32, NoOptions> t) { }

	public virtual void SetFrom(TweenerCore<Int32, Int32, NoOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Int32, Int32, NoOptions> t, int fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Int32, Int32, NoOptions> t) { }

}

