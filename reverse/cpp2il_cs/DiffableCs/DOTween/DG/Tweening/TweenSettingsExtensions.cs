namespace DG.Tweening;

[Extension]
public static class TweenSettingsExtensions
{

	[Extension]
	public static Sequence Append(Sequence s, Tween t) { }

	[Extension]
	public static Sequence AppendCallback(Sequence s, TweenCallback callback) { }

	[Extension]
	public static Sequence AppendInterval(Sequence s, float interval) { }

	[Extension]
	public static TweenerCore<Vector2, Vector2, CircleOptions> From(TweenerCore<Vector2, Vector2, CircleOptions> t, float fromValueDegrees, bool setImmediately = true, bool isRelative = false) { }

	[Extension]
	public static TweenerCore<Vector3, Vector3, VectorOptions> From(TweenerCore<Vector3, Vector3, VectorOptions> t, float fromValue, bool setImmediately = true, bool isRelative = false) { }

	[Extension]
	public static TweenerCore<Color, Color, ColorOptions> From(TweenerCore<Color, Color, ColorOptions> t, float fromAlphaValue, bool setImmediately = true, bool isRelative = false) { }

	[Extension]
	public static TweenerCore<T1, T2, TPlugOptions> From(TweenerCore<T1, T2, TPlugOptions> t, T2 fromValue, bool setImmediately = true, bool isRelative = false) { }

	[Extension]
	public static T From(T t, bool setImmediately, bool isRelative) { }

	[Extension]
	public static T From(T t, bool isRelative) { }

	[Extension]
	public static T From(T t) { }

	[Extension]
	public static Sequence Insert(Sequence s, float atPosition, Tween t) { }

	[Extension]
	public static Sequence InsertCallback(Sequence s, float atPosition, TweenCallback callback) { }

	[Extension]
	public static Sequence Join(Sequence s, Tween t) { }

	[Extension]
	public static Sequence JoinCallback(Sequence s, TweenCallback callback) { }

	[Extension]
	public static T OnComplete(T t, TweenCallback action) { }

	[Extension]
	public static T OnKill(T t, TweenCallback action) { }

	[Extension]
	public static T OnPause(T t, TweenCallback action) { }

	[Extension]
	public static T OnPlay(T t, TweenCallback action) { }

	[Extension]
	public static T OnRewind(T t, TweenCallback action) { }

	[Extension]
	public static T OnStart(T t, TweenCallback action) { }

	[Extension]
	public static T OnStepComplete(T t, TweenCallback action) { }

	[Extension]
	public static T OnUpdate(T t, TweenCallback action) { }

	[Extension]
	public static T OnWaypointChange(T t, TweenCallback<Int32> action) { }

	[Extension]
	public static Sequence Prepend(Sequence s, Tween t) { }

	[Extension]
	public static Sequence PrependCallback(Sequence s, TweenCallback callback) { }

	[Extension]
	public static Sequence PrependInterval(Sequence s, float interval) { }

	[Extension]
	public static T SetAs(T t, Tween asTween) { }

	[Extension]
	public static T SetAs(T t, TweenParams tweenParams) { }

	[Extension]
	public static T SetAutoKill(T t) { }

	[Extension]
	public static T SetAutoKill(T t, bool autoKillOnCompletion) { }

	[Extension]
	public static T SetDelay(T t, float delay, bool asPrependedIntervalIfSequence) { }

	[Extension]
	public static T SetDelay(T t, float delay) { }

	[Extension]
	public static T SetEase(T t, EaseFunction customEase) { }

	[Extension]
	public static T SetEase(T t, AnimationCurve animCurve) { }

	[Extension]
	public static T SetEase(T t, Ease ease, float amplitude, float period) { }

	[Extension]
	public static T SetEase(T t, Ease ease, float overshoot) { }

	[Extension]
	public static T SetEase(T t, Ease ease) { }

	[Extension]
	public static T SetId(T t, string stringId) { }

	[Extension]
	public static T SetId(T t, object objectId) { }

	[Extension]
	public static T SetId(T t, int intId) { }

	[Extension]
	public static T SetInverted(T t, bool inverted) { }

	[Extension]
	public static T SetInverted(T t) { }

	[Extension]
	public static T SetLink(T t, GameObject gameObject, LinkBehaviour behaviour) { }

	[Extension]
	public static T SetLink(T t, GameObject gameObject) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, Nullable<Vector3> forwardDirection = null, Nullable<Vector3> up = null) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, Nullable<Vector3> forwardDirection = null, Nullable<Vector3> up = null) { }

	[Extension]
	private static TweenerCore<Vector3, Path, PathOptions> SetLookAt(TweenerCore<Vector3, Path, PathOptions> t, OrientType orientType, Vector3 lookAtPosition, Transform lookAtTransform, float lookAhead, Nullable<Vector3> forwardDirection = null, Nullable<Vector3> up = null, bool stableZRotation = false) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, bool stableZRotation) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, bool stableZRotation) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, Nullable<Vector3> forwardDirection = null, Nullable<Vector3> up = null) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, bool stableZRotation) { }

	[Extension]
	public static T SetLoops(T t, int loops, LoopType loopType) { }

	[Extension]
	public static T SetLoops(T t, int loops) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool useShortest360Route = true) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Color, Color, ColorOptions> t, bool alphaOnly) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Rect, Rect, RectOptions> t, bool snapping) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector4, Vector4, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector4, Vector4, VectorOptions> t, bool snapping) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector3, Vector3, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector3, Vector3, VectorOptions> t, bool snapping) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector2, Vector2, CircleOptions> t, float endValueDegrees, bool relativeCenter = true, bool snapping = false) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector2, Vector2, VectorOptions> t, bool snapping) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Single, Single, FloatOptions> t, bool snapping) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, AxisConstraint axisConstraint, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> SetOptions(TweenerCore<Vector3, Path, PathOptions> t, AxisConstraint lockPosition, AxisConstraint lockRotation = 0) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<String, String, StringOptions> t, bool richTextEnabled, ScrambleMode scrambleMode = 0, string scrambleChars = null) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> SetOptions(TweenerCore<Vector3, Path, PathOptions> t, bool closePath, AxisConstraint lockPosition = 0, AxisConstraint lockRotation = 0) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector2, Vector2, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false) { }

	[Extension]
	public static Tweener SetOptions(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool snapping) { }

	[Extension]
	private static void SetPathForwardDirection(TweenerCore<Vector3, Path, PathOptions> t, Nullable<Vector3> forwardDirection = null, Nullable<Vector3> up = null) { }

	[Extension]
	public static T SetRecyclable(T t) { }

	[Extension]
	public static T SetRecyclable(T t, bool recyclable) { }

	[Extension]
	public static T SetRelative(T t) { }

	[Extension]
	public static T SetRelative(T t, bool isRelative) { }

	[Extension]
	public static T SetSpeedBased(T t) { }

	[Extension]
	public static T SetSpeedBased(T t, bool isSpeedBased) { }

	[Extension]
	public static T SetTarget(T t, object target) { }

	[Extension]
	public static T SetUpdate(T t, bool isIndependentUpdate) { }

	[Extension]
	public static T SetUpdate(T t, UpdateType updateType) { }

	[Extension]
	public static T SetUpdate(T t, UpdateType updateType, bool isIndependentUpdate) { }

	private static bool ValidateAddToSequence(Sequence s, Tween t, bool ignoreTween = false) { }

}

