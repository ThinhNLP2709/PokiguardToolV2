namespace DG.Tweening;

public class TweenParams
{
	public static readonly TweenParams Params; //Field offset: 0x0
	internal object id; //Field offset: 0x10
	internal string stringId; //Field offset: 0x18
	internal int intId; //Field offset: 0x20
	internal object target; //Field offset: 0x28
	internal UpdateType updateType; //Field offset: 0x30
	internal bool isIndependentUpdate; //Field offset: 0x34
	internal TweenCallback onStart; //Field offset: 0x38
	internal TweenCallback onPlay; //Field offset: 0x40
	internal TweenCallback onRewind; //Field offset: 0x48
	internal TweenCallback onUpdate; //Field offset: 0x50
	internal TweenCallback onStepComplete; //Field offset: 0x58
	internal TweenCallback onComplete; //Field offset: 0x60
	internal TweenCallback onKill; //Field offset: 0x68
	internal TweenCallback<Int32> onWaypointChange; //Field offset: 0x70
	internal bool isRecyclable; //Field offset: 0x78
	internal bool isSpeedBased; //Field offset: 0x79
	internal bool autoKill; //Field offset: 0x7A
	internal int loops; //Field offset: 0x7C
	internal LoopType loopType; //Field offset: 0x80
	internal float delay; //Field offset: 0x84
	internal bool isRelative; //Field offset: 0x88
	internal Ease easeType; //Field offset: 0x8C
	internal EaseFunction customEase; //Field offset: 0x90
	internal float easeOvershootOrAmplitude; //Field offset: 0x98
	internal float easePeriod; //Field offset: 0x9C

	private static TweenParams() { }

	public TweenParams() { }

	public TweenParams Clear() { }

	public TweenParams OnComplete(TweenCallback action) { }

	public TweenParams OnKill(TweenCallback action) { }

	public TweenParams OnPlay(TweenCallback action) { }

	public TweenParams OnRewind(TweenCallback action) { }

	public TweenParams OnStart(TweenCallback action) { }

	public TweenParams OnStepComplete(TweenCallback action) { }

	public TweenParams OnUpdate(TweenCallback action) { }

	public TweenParams OnWaypointChange(TweenCallback<Int32> action) { }

	public TweenParams SetAutoKill(bool autoKillOnCompletion = true) { }

	public TweenParams SetDelay(float delay) { }

	public TweenParams SetEase(AnimationCurve animCurve) { }

	public TweenParams SetEase(Ease ease, Nullable<Single> overshootOrAmplitude = null, Nullable<Single> period = null) { }

	public TweenParams SetEase(EaseFunction customEase) { }

	public TweenParams SetId(int intId) { }

	public TweenParams SetId(string stringId) { }

	public TweenParams SetId(object objectId) { }

	public TweenParams SetLoops(int loops, Nullable<LoopType> loopType = null) { }

	public TweenParams SetRecyclable(bool recyclable = true) { }

	public TweenParams SetRelative(bool isRelative = true) { }

	public TweenParams SetSpeedBased(bool isSpeedBased = true) { }

	public TweenParams SetTarget(object target) { }

	public TweenParams SetUpdate(UpdateType updateType, bool isIndependentUpdate = false) { }

	public TweenParams SetUpdate(bool isIndependentUpdate) { }

}

