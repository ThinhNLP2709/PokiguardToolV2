namespace DG.Tweening.Plugins;

public class Vector2Plugin : ABSTweenPlugin<Vector2, Vector2, VectorOptions>
{

	public Vector2Plugin() { }

	public virtual Vector2 ConvertToStartValue(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 value) { }

	public virtual void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector2> getter, DOSetter<Vector2> setter, float elapsed, Vector2 startValue, Vector2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector2 changeValue) { }

	public virtual void Reset(TweenerCore<Vector2, Vector2, VectorOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Vector2, Vector2, VectorOptions> t) { }

	public virtual void SetFrom(TweenerCore<Vector2, Vector2, VectorOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Vector2, Vector2, VectorOptions> t) { }

}

