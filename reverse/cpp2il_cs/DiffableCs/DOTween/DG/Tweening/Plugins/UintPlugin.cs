namespace DG.Tweening.Plugins;

public class UintPlugin : ABSTweenPlugin<UInt32, UInt32, UintOptions>
{

	public UintPlugin() { }

	public virtual uint ConvertToStartValue(TweenerCore<UInt32, UInt32, UintOptions> t, uint value) { }

	public virtual void EvaluateAndApply(UintOptions options, Tween t, bool isRelative, DOGetter<UInt32> getter, DOSetter<UInt32> setter, float elapsed, uint startValue, uint changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(UintOptions options, float unitsXSecond, uint changeValue) { }

	public virtual void Reset(TweenerCore<UInt32, UInt32, UintOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<UInt32, UInt32, UintOptions> t) { }

	public virtual void SetFrom(TweenerCore<UInt32, UInt32, UintOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<UInt32, UInt32, UintOptions> t, uint fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<UInt32, UInt32, UintOptions> t) { }

}

