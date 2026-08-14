namespace DG.Tweening.CustomPlugins;

public class PureQuaternionPlugin : ABSTweenPlugin<Quaternion, Quaternion, NoOptions>
{
	private static PureQuaternionPlugin _plug; //Field offset: 0x0

	public PureQuaternionPlugin() { }

	public virtual Quaternion ConvertToStartValue(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion value) { }

	public virtual void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, float elapsed, Quaternion startValue, Quaternion changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, Quaternion changeValue) { }

	public static PureQuaternionPlugin Plug() { }

	public virtual void Reset(TweenerCore<Quaternion, Quaternion, NoOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Quaternion, Quaternion, NoOptions> t) { }

	public virtual void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Quaternion, Quaternion, NoOptions> t) { }

}

