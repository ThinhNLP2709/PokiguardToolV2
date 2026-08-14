namespace DG.Tweening.Plugins;

public class CirclePlugin : ABSTweenPlugin<Vector2, Vector2, CircleOptions>
{

	public CirclePlugin() { }

	public virtual Vector2 ConvertToStartValue(TweenerCore<Vector2, Vector2, CircleOptions> t, Vector2 value) { }

	public virtual void EvaluateAndApply(CircleOptions options, Tween t, bool isRelative, DOGetter<Vector2> getter, DOSetter<Vector2> setter, float elapsed, Vector2 startValue, Vector2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public static ABSTweenPlugin<Vector2, Vector2, CircleOptions> Get() { }

	public Vector2 GetPositionOnCircle(CircleOptions options, float degrees) { }

	public virtual float GetSpeedBasedDuration(CircleOptions options, float unitsXSecond, Vector2 changeValue) { }

	public virtual void Reset(TweenerCore<Vector2, Vector2, CircleOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Vector2, Vector2, CircleOptions> t) { }

	public virtual void SetFrom(TweenerCore<Vector2, Vector2, CircleOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Vector2, Vector2, CircleOptions> t, Vector2 fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Vector2, Vector2, CircleOptions> t) { }

}

