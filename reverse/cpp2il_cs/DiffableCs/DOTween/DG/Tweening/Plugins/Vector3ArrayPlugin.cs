namespace DG.Tweening.Plugins;

public class Vector3ArrayPlugin : ABSTweenPlugin<Vector3, Vector3[], Vector3ArrayOptions>
{

	public Vector3ArrayPlugin() { }

	public virtual Vector3[] ConvertToStartValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, Vector3 value) { }

	public virtual void EvaluateAndApply(Vector3ArrayOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3[] startValue, Vector3[] changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(Vector3ArrayOptions options, float unitsXSecond, Vector3[] changeValue) { }

	public virtual void Reset(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t) { }

	public virtual void SetFrom(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, Vector3[] fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t) { }

}

