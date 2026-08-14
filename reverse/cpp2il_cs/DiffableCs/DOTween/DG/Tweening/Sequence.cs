namespace DG.Tweening;

public sealed class Sequence : Tween
{
	internal readonly List<Tween> sequencedTweens; //Field offset: 0x120
	private readonly List<ABSSequentiable> _sequencedObjs; //Field offset: 0x128
	internal float lastTweenInsertTime; //Field offset: 0x130

	internal Sequence() { }

	private static bool ApplyInternalCycle(Sequence s, float fromPos, float toPos, UpdateMode updateMode, bool useInverse, bool prevPosIsInverse, bool multiCycleStep = false) { }

	internal virtual bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice) { }

	internal static Sequence DoAppendInterval(Sequence inSequence, float interval) { }

	internal static bool DoApplyTween(Sequence s, float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode) { }

	internal static Sequence DoInsert(Sequence inSequence, Tween t, float atPosition) { }

	internal static Sequence DoInsertCallback(Sequence inSequence, TweenCallback callback, float atPosition) { }

	internal static Sequence DoPrepend(Sequence inSequence, Tween t) { }

	internal static Sequence DoPrependInterval(Sequence inSequence, float interval) { }

	internal static bool DoStartup(Sequence s) { }

	private static bool IsAnyCallbackSet(Sequence s) { }

	internal virtual void Reset() { }

	internal static void Setup(Sequence s) { }

	private static void StableSortSequencedObjs(List<ABSSequentiable> list) { }

	internal virtual bool Startup() { }

	internal virtual float UpdateDelay(float elapsed) { }

	internal virtual bool Validate() { }

}

