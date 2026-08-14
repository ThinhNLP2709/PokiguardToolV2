namespace DG.Tweening;

public class DOTween
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass67_0
	{
		public float v; //Field offset: 0x10
		public DOSetter<Single> setter; //Field offset: 0x18

		public <>c__DisplayClass67_0() { }

		internal float <To>b__0() { }

		internal void <To>b__1(float x) { }

	}

	public static readonly string Version; //Field offset: 0x0
	public static bool useSafeMode; //Field offset: 0x8
	public static SafeModeLogBehaviour safeModeLogBehaviour; //Field offset: 0xC
	public static NestedTweenFailureBehaviour nestedTweenFailureBehaviour; //Field offset: 0x10
	public static bool showUnityEditorReport; //Field offset: 0x14
	public static float timeScale; //Field offset: 0x18
	public static float unscaledTimeScale; //Field offset: 0x1C
	public static bool useSmoothDeltaTime; //Field offset: 0x20
	public static float maxSmoothUnscaledTime; //Field offset: 0x24
	internal static RewindCallbackMode rewindCallbackMode; //Field offset: 0x28
	private static LogBehaviour _logBehaviour; //Field offset: 0x2C
	public static Func<LogType, Object, Boolean> onWillLog; //Field offset: 0x30
	public static bool drawGizmos; //Field offset: 0x38
	public static bool debugMode; //Field offset: 0x39
	private static bool _fooDebugStoreTargetId; //Field offset: 0x3A
	public static UpdateType defaultUpdateType; //Field offset: 0x3C
	public static bool defaultTimeScaleIndependent; //Field offset: 0x40
	public static AutoPlay defaultAutoPlay; //Field offset: 0x44
	public static bool defaultAutoKill; //Field offset: 0x48
	public static LoopType defaultLoopType; //Field offset: 0x4C
	public static bool defaultRecyclable; //Field offset: 0x50
	public static Ease defaultEaseType; //Field offset: 0x54
	public static float defaultEaseOvershootOrAmplitude; //Field offset: 0x58
	public static float defaultEasePeriod; //Field offset: 0x5C
	public static DOTweenComponent instance; //Field offset: 0x60
	private static bool _foo_isQuitting; //Field offset: 0x68
	internal static int maxActiveTweenersReached; //Field offset: 0x6C
	internal static int maxActiveSequencesReached; //Field offset: 0x70
	internal static SafeModeReport safeModeReport; //Field offset: 0x74
	internal static readonly List<TweenCallback> GizmosDelegates; //Field offset: 0x88
	internal static bool initialized; //Field offset: 0x90
	private static int _isQuittingFrame; //Field offset: 0x94

	public static bool debugStoreTargetId
	{
		 get { } //Length: 151
		 set { } //Length: 84
	}

	internal static bool isQuitting
	{
		internal get { } //Length: 208
		internal set { } //Length: 138
	}

	public static LogBehaviour logBehaviour
	{
		 get { } //Length: 78
		 set { } //Length: 106
	}

	private static DOTween() { }

	public DOTween() { }

	private static TweenerCore<T1, T2, TPlugOptions> ApplyTo(DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration, ABSTweenPlugin<T1, T2, TPlugOptions> plugin = null) { }

	private static void AutoInit() { }

	internal static void Clear(bool destroy, bool isApplicationQuitting) { }

	public static void Clear(bool destroy = false) { }

	public static void ClearCachedTweens() { }

	public static int Complete(object targetOrId, bool withCallbacks = false) { }

	public static int CompleteAll(bool withCallbacks = false) { }

	internal static int CompleteAndReturnKilledTot(object target, object id) { }

	internal static int CompleteAndReturnKilledTot() { }

	internal static int CompleteAndReturnKilledTot(object targetOrId) { }

	internal static int CompleteAndReturnKilledTotExceptFor(Object[] excludeTargetsOrIds) { }

	public static int Flip(object targetOrId) { }

	public static int FlipAll() { }

	public static bool get_debugStoreTargetId() { }

	internal static bool get_isQuitting() { }

	public static LogBehaviour get_logBehaviour() { }

	public static int Goto(object targetOrId, float to, bool andPlay = false) { }

	public static int GotoAll(float to, bool andPlay = false) { }

	private static IDOTweenInit Init(DOTweenSettings settings, Nullable<Boolean> recycleAllByDefault, Nullable<Boolean> useSafeMode, Nullable<LogBehaviour> logBehaviour) { }

	public static IDOTweenInit Init(Nullable<Boolean> recycleAllByDefault = null, Nullable<Boolean> useSafeMode = null, Nullable<LogBehaviour> logBehaviour = null) { }

	private static void InitCheck() { }

	public static bool IsTweening(object targetOrId, bool alsoCheckIfIsPlaying = false) { }

	public static int Kill(object target, object id, bool complete = false) { }

	public static int Kill(object targetOrId, bool complete = false) { }

	public static int KillAll(bool complete, Object[] idsOrTargetsToExclude) { }

	public static int KillAll(bool complete = false) { }

	public static void ManualUpdate(float deltaTime, float unscaledDeltaTime) { }

	public static int Pause(object targetOrId) { }

	public static int PauseAll() { }

	public static List<Tween> PausedTweens(List<Tween> fillableList = null) { }

	public static int Play(object targetOrId) { }

	public static int Play(object target, object id) { }

	public static int PlayAll() { }

	public static int PlayBackwards(object targetOrId) { }

	public static int PlayBackwards(object target, object id) { }

	public static int PlayBackwardsAll() { }

	public static int PlayForward(object targetOrId) { }

	public static int PlayForward(object target, object id) { }

	public static int PlayForwardAll() { }

	public static List<Tween> PlayingTweens(List<Tween> fillableList = null) { }

	public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Punch(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 direction, float duration, int vibrato = 10, float elasticity = 1) { }

	public static int Restart(object targetOrId, bool includeDelay = true, float changeDelayTo = -1) { }

	public static int Restart(object target, object id, bool includeDelay = true, float changeDelayTo = -1) { }

	public static int RestartAll(bool includeDelay = true) { }

	public static int Rewind(object targetOrId, bool includeDelay = true) { }

	public static int RewindAll(bool includeDelay = true) { }

	public static Sequence Sequence(object target) { }

	public static Sequence Sequence() { }

	public static void set_debugStoreTargetId(bool value) { }

	internal static void set_isQuitting(bool value) { }

	public static void set_logBehaviour(LogBehaviour value) { }

	public static void SetTweensCapacity(int tweenersCapacity, int sequencesCapacity) { }

	private static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato, float randomness, bool ignoreZAxis, bool vectorBased, bool fadeOut, ShakeRandomnessMode randomnessMode) { }

	public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato = 10, float randomness = 90, bool fadeOut = true, ShakeRandomnessMode randomnessMode = 0) { }

	public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, float strength = 3, int vibrato = 10, float randomness = 90, bool ignoreZAxis = true, bool fadeOut = true, ShakeRandomnessMode randomnessMode = 0) { }

	public static int SmoothRewind(object targetOrId) { }

	public static int SmoothRewindAll() { }

	public static TweenerCore<String, String, StringOptions> To(DOGetter<String> getter, DOSetter<String> setter, string endValue, float duration) { }

	public static TweenerCore<UInt64, UInt64, NoOptions> To(DOGetter<UInt64> getter, DOSetter<UInt64> setter, ulong endValue, float duration) { }

	public static TweenerCore<Color, Color, ColorOptions> To(DOGetter<Color> getter, DOSetter<Color> setter, Color endValue, float duration) { }

	public static TweenerCore<Vector2, Vector2, VectorOptions> To(DOGetter<Vector2> getter, DOSetter<Vector2> setter, Vector2 endValue, float duration) { }

	public static TweenerCore<Rect, Rect, RectOptions> To(DOGetter<Rect> getter, DOSetter<Rect> setter, Rect endValue, float duration) { }

	public static Tweener To(DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, RectOffset endValue, float duration) { }

	public static TweenerCore<T1, T2, TPlugOptions> To(ABSTweenPlugin<T1, T2, TPlugOptions> plugin, DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration) { }

	public static TweenerCore<Quaternion, Vector3, QuaternionOptions> To(DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, Vector3 endValue, float duration) { }

	public static Tweener To(DOSetter<Single> setter, float startValue, float endValue, float duration) { }

	internal static TweenerCore<Color2, Color2, ColorOptions> To(DOGetter<Color2> getter, DOSetter<Color2> setter, Color2 endValue, float duration) { }

	public static TweenerCore<Int64, Int64, NoOptions> To(DOGetter<Int64> getter, DOSetter<Int64> setter, long endValue, float duration) { }

	public static TweenerCore<Int32, Int32, NoOptions> To(DOGetter<Int32> getter, DOSetter<Int32> setter, int endValue, float duration) { }

	public static TweenerCore<UInt32, UInt32, UintOptions> To(DOGetter<UInt32> getter, DOSetter<UInt32> setter, uint endValue, float duration) { }

	public static TweenerCore<Double, Double, NoOptions> To(DOGetter<Double> getter, DOSetter<Double> setter, double endValue, float duration) { }

	public static TweenerCore<Vector3, Vector3, VectorOptions> To(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 endValue, float duration) { }

	public static TweenerCore<Vector4, Vector4, VectorOptions> To(DOGetter<Vector4> getter, DOSetter<Vector4> setter, Vector4 endValue, float duration) { }

	public static TweenerCore<Single, Single, FloatOptions> To(DOGetter<Single> getter, DOSetter<Single> setter, float endValue, float duration) { }

	public static TweenerCore<Color, Color, ColorOptions> ToAlpha(DOGetter<Color> getter, DOSetter<Color> setter, float endValue, float duration) { }

	public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> ToArray(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3[] endValues, Single[] durations) { }

	public static TweenerCore<Vector3, Vector3, VectorOptions> ToAxis(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float endValue, float duration, AxisConstraint axisConstraint = 2) { }

	public static int TogglePause(object targetOrId) { }

	public static int TogglePauseAll() { }

	public static int TotalActiveSequences() { }

	public static int TotalActiveTweeners() { }

	public static int TotalActiveTweens() { }

	public static int TotalPlayingTweens() { }

	public static int TotalTweensById(object id, bool playingOnly = false) { }

	public static List<Tween> TweensById(object id, bool playingOnly = false, List<Tween> fillableList = null) { }

	public static List<Tween> TweensByTarget(object target, bool playingOnly = false, List<Tween> fillableList = null) { }

	public static int Validate() { }

}

