namespace DG.Tweening.Plugins;

public class Vector3Plugin : ABSTweenPlugin<Vector3, Vector3, VectorOptions>
{

	public Vector3Plugin() { }

	public virtual Vector3 ConvertToStartValue(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 value) { }

	public virtual void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector3 changeValue) { }

	public virtual void Reset(TweenerCore<Vector3, Vector3, VectorOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Vector3, Vector3, VectorOptions> t) { }

	public virtual void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Vector3, Vector3, VectorOptions> t) { }

}

