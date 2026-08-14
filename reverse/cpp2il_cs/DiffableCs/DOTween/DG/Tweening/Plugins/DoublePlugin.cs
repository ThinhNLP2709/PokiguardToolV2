namespace DG.Tweening.Plugins;

public class DoublePlugin : ABSTweenPlugin<Double, Double, NoOptions>
{

	public DoublePlugin() { }

	public virtual double ConvertToStartValue(TweenerCore<Double, Double, NoOptions> t, double value) { }

	public virtual void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<Double> getter, DOSetter<Double> setter, float elapsed, double startValue, double changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, double changeValue) { }

	public virtual void Reset(TweenerCore<Double, Double, NoOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Double, Double, NoOptions> t) { }

	public virtual void SetFrom(TweenerCore<Double, Double, NoOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Double, Double, NoOptions> t, double fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Double, Double, NoOptions> t) { }

}

