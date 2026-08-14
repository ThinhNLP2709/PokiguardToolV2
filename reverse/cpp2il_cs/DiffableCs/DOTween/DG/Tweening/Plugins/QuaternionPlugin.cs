namespace DG.Tweening.Plugins;

public class QuaternionPlugin : ABSTweenPlugin<Quaternion, Vector3, QuaternionOptions>
{

	public QuaternionPlugin() { }

	public virtual Vector3 ConvertToStartValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, Quaternion value) { }

	public virtual void EvaluateAndApply(QuaternionOptions options, Tween t, bool isRelative, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	private Vector3 FlipEulerAngles(Vector3 euler) { }

	private Vector3 GetEulerValForCalculations(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, Vector3 val, Vector3 counterVal) { }

	public virtual float GetSpeedBasedDuration(QuaternionOptions options, float unitsXSecond, Vector3 changeValue) { }

	public virtual void Reset(TweenerCore<Quaternion, Vector3, QuaternionOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t) { }

	public virtual void SetFrom(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, Vector3 fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Quaternion, Vector3, QuaternionOptions> t) { }

}

