namespace DG.Tweening.Core;

internal static class TweenManager
{
	public enum CapacityIncreaseMode
	{
		TweenersAndSequences = 0,
		TweenersOnly = 1,
		SequencesOnly = 2,
	}

	private const int _DefaultMaxTweeners = 200; //Field offset: 0x0
	private const int _DefaultMaxSequences = 50; //Field offset: 0x0
	private const string _MaxTweensReached = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup"; //Field offset: 0x0
	private const float _EpsilonVsTimeCheck = 1E-06; //Field offset: 0x0
	internal static bool isUnityEditor; //Field offset: 0x0
	internal static bool isDebugBuild; //Field offset: 0x1
	internal static int maxActive; //Field offset: 0x4
	internal static int maxTweeners; //Field offset: 0x8
	internal static int maxSequences; //Field offset: 0xC
	internal static bool hasActiveTweens; //Field offset: 0x10
	internal static bool hasActiveDefaultTweens; //Field offset: 0x11
	internal static bool hasActiveLateTweens; //Field offset: 0x12
	internal static bool hasActiveFixedTweens; //Field offset: 0x13
	internal static bool hasActiveManualTweens; //Field offset: 0x14
	internal static int totActiveTweens; //Field offset: 0x18
	internal static int totActiveDefaultTweens; //Field offset: 0x1C
	internal static int totActiveLateTweens; //Field offset: 0x20
	internal static int totActiveFixedTweens; //Field offset: 0x24
	internal static int totActiveManualTweens; //Field offset: 0x28
	internal static int totActiveTweeners; //Field offset: 0x2C
	internal static int totActiveSequences; //Field offset: 0x30
	internal static int totPooledTweeners; //Field offset: 0x34
	internal static int totPooledSequences; //Field offset: 0x38
	internal static int totTweeners; //Field offset: 0x3C
	internal static int totSequences; //Field offset: 0x40
	internal static bool isUpdateLoop; //Field offset: 0x44
	internal static Tween[] _activeTweens; //Field offset: 0x48
	private static Tween[] _pooledTweeners; //Field offset: 0x50
	private static readonly Stack<Tween> _PooledSequences; //Field offset: 0x58
	private static readonly List<Tween> _KillList; //Field offset: 0x60
	private static readonly Dictionary<Tween, TweenLink> _TweenLinks; //Field offset: 0x68
	private static int _totTweenLinks; //Field offset: 0x70
	private static int _maxActiveLookupId; //Field offset: 0x74
	private static bool _requiresActiveReorganization; //Field offset: 0x78
	private static int _reorganizeFromId; //Field offset: 0x7C
	private static int _minPooledTweenerId; //Field offset: 0x80
	private static int _maxPooledTweenerId; //Field offset: 0x84
	private static bool _despawnAllCalledFromUpdateLoopCallback; //Field offset: 0x88

	private static TweenManager() { }

	private static void AddActiveTween(Tween t) { }

	internal static void AddActiveTweenToSequence(Tween t) { }

	internal static void AddTweenLink(Tween t, TweenLink tweenLink) { }

	private static void ClearTweenArray(Tween[] tweens) { }

	internal static bool Complete(Tween t, bool modifyActiveLists = true, UpdateMode updateMode = 1) { }

	internal static void Despawn(Tween t, bool modifyActiveLists = true) { }

	private static void DespawnActiveTweens(List<Tween> tweens) { }

	internal static int DespawnAll() { }

	private static int DoGetTweensById(object id, bool playingOnly, bool addToList, List<Tween> fillableList) { }

	private static void EvaluateTweenLink(Tween t) { }

	internal static int FilteredOperation(OperationType operationType, FilterType filterType, object id, bool optionalBool, float optionalFloat, object optionalObj = null, Object[] optionalArray = null) { }

	internal static bool Flip(Tween t) { }

	internal static void ForceInit(Tween t, bool isSequenced = false) { }

	internal static List<Tween> GetActiveTweens(bool playing, List<Tween> fillableList = null) { }

	internal static Sequence GetSequence() { }

	internal static TweenerCore<T1, T2, TPlugOptions> GetTweener() { }

	internal static List<Tween> GetTweensById(object id, bool playingOnly, List<Tween> fillableList = null) { }

	internal static List<Tween> GetTweensByTarget(object target, bool playingOnly, List<Tween> fillableList = null) { }

	internal static bool Goto(Tween t, float to, bool andPlay = false, UpdateMode updateMode = 1) { }

	private static void IncreaseCapacities(CapacityIncreaseMode increaseMode) { }

	private static void ManageOnRewindCallbackWhenAlreadyRewinded(Tween t, bool isPlayBackwardsOrSmoothRewind) { }

	private static void MarkForKilling(Tween t, bool isSingleTweenManualUpdate = false) { }

	internal static bool Pause(Tween t) { }

	internal static bool Play(Tween t) { }

	internal static bool PlayBackwards(Tween t) { }

	internal static bool PlayForward(Tween t) { }

	internal static void PurgeAll(bool isApplicationQuitting) { }

	internal static void PurgePools() { }

	private static void RemoveActiveTween(Tween t) { }

	private static void RemoveTweenLink(Tween t) { }

	private static void ReorganizeActiveTweens() { }

	internal static void ResetCapacities() { }

	internal static bool Restart(Tween t, bool includeDelay = true, float changeDelayTo = -1) { }

	internal static bool Rewind(Tween t, bool includeDelay = true) { }

	internal static void SetCapacities(int tweenersCapacity, int sequencesCapacity) { }

	internal static void SetUpdateType(Tween t, UpdateType updateType, bool isIndependentUpdate) { }

	internal static bool SmoothRewind(Tween t) { }

	internal static bool TogglePause(Tween t) { }

	internal static int TotalPlayingTweens() { }

	internal static int TotalPooledTweens() { }

	internal static int TotalTweensById(object id, bool playingOnly) { }

	internal static bool Update(Tween t, float deltaTime, float independentTime, bool isSingleTweenManualUpdate) { }

	internal static void Update(UpdateType updateType, float deltaTime, float independentTime) { }

	internal static int Validate() { }

}

