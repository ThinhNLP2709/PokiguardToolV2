namespace DG.Tweening.Plugins;

public class PathPlugin : ABSTweenPlugin<Vector3, Path, PathOptions>
{
	public const float MinLookAhead = 0.0001; //Field offset: 0x0

	public PathPlugin() { }

	public virtual Path ConvertToStartValue(TweenerCore<Vector3, Path, PathOptions> t, Vector3 value) { }

	private Vector3 DivideVectorByVector(Vector3 vector, Vector3 byVector) { }

	public virtual void EvaluateAndApply(PathOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Path startValue, Path changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public static ABSTweenPlugin<Vector3, Path, PathOptions> Get() { }

	public virtual float GetSpeedBasedDuration(PathOptions options, float unitsXSecond, Path changeValue) { }

	private Vector3 MultiplyVectorByVector(Vector3 vector, Vector3 byVector) { }

	public virtual void Reset(TweenerCore<Vector3, Path, PathOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Vector3, Path, PathOptions> t) { }

	public virtual void SetFrom(TweenerCore<Vector3, Path, PathOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Vector3, Path, PathOptions> t, Path fromValue, bool setImmediately, bool isRelative) { }

	public void SetOrientation(PathOptions options, Tween t, Path path, float pathPerc, Vector3 tPos, UpdateNotice updateNotice) { }

	public virtual void SetRelativeEndValue(TweenerCore<Vector3, Path, PathOptions> t) { }

}

