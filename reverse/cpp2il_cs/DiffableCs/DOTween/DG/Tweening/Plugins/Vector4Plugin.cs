namespace DG.Tweening.Plugins;

public class Vector4Plugin : ABSTweenPlugin<Vector4, Vector4, VectorOptions>
{

	public Vector4Plugin() { }

	public virtual Vector4 ConvertToStartValue(TweenerCore<Vector4, Vector4, VectorOptions> t, Vector4 value) { }

	public virtual void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector4> getter, DOSetter<Vector4> setter, float elapsed, Vector4 startValue, Vector4 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector4 changeValue) { }

	public virtual void Reset(TweenerCore<Vector4, Vector4, VectorOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Vector4, Vector4, VectorOptions> t) { }

	public virtual void SetFrom(TweenerCore<Vector4, Vector4, VectorOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Vector4, Vector4, VectorOptions> t, Vector4 fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Vector4, Vector4, VectorOptions> t) { }

}

