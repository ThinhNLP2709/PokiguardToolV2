namespace DG.Tweening;

public abstract class Tween : ABSSequentiable
{
	public float timeScale; //Field offset: 0x28
	public bool isBackwards; //Field offset: 0x2C
	internal bool isInverted; //Field offset: 0x2D
	public object id; //Field offset: 0x30
	public string stringId; //Field offset: 0x38
	public int intId; //Field offset: 0x40
	public object target; //Field offset: 0x48
	internal UpdateType updateType; //Field offset: 0x50
	internal bool isIndependentUpdate; //Field offset: 0x54
	public TweenCallback onPlay; //Field offset: 0x58
	public TweenCallback onPause; //Field offset: 0x60
	public TweenCallback onRewind; //Field offset: 0x68
	public TweenCallback onUpdate; //Field offset: 0x70
	public TweenCallback onStepComplete; //Field offset: 0x78
	public TweenCallback onComplete; //Field offset: 0x80
	public TweenCallback onKill; //Field offset: 0x88
	public TweenCallback<Int32> onWaypointChange; //Field offset: 0x90
	internal bool isFrom; //Field offset: 0x98
	internal bool isBlendable; //Field offset: 0x99
	internal bool isRecyclable; //Field offset: 0x9A
	internal bool isSpeedBased; //Field offset: 0x9B
	internal bool autoKill; //Field offset: 0x9C
	internal float duration; //Field offset: 0xA0
	internal int loops; //Field offset: 0xA4
	internal LoopType loopType; //Field offset: 0xA8
	internal float delay; //Field offset: 0xAC
	[CompilerGenerated]
	private bool <isRelative>k__BackingField; //Field offset: 0xB0
	internal Ease easeType; //Field offset: 0xB4
	internal EaseFunction customEase; //Field offset: 0xB8
	public float easeOvershootOrAmplitude; //Field offset: 0xC0
	public float easePeriod; //Field offset: 0xC4
	public string debugTargetId; //Field offset: 0xC8
	internal Type typeofT1; //Field offset: 0xD0
	internal Type typeofT2; //Field offset: 0xD8
	internal Type typeofTPlugOptions; //Field offset: 0xE0
	[CompilerGenerated]
	private bool <active>k__BackingField; //Field offset: 0xE8
	internal bool isSequenced; //Field offset: 0xE9
	internal Sequence sequenceParent; //Field offset: 0xF0
	internal int activeId; //Field offset: 0xF8
	internal SpecialStartupMode specialStartupMode; //Field offset: 0xFC
	internal bool creationLocked; //Field offset: 0x100
	internal bool startupDone; //Field offset: 0x101
	[CompilerGenerated]
	private bool <playedOnce>k__BackingField; //Field offset: 0x102
	[CompilerGenerated]
	private float <position>k__BackingField; //Field offset: 0x104
	internal float fullDuration; //Field offset: 0x108
	internal int completedLoops; //Field offset: 0x10C
	internal bool isPlaying; //Field offset: 0x110
	internal bool isComplete; //Field offset: 0x111
	internal float elapsedDelay; //Field offset: 0x114
	internal bool delayComplete; //Field offset: 0x118
	internal int miscInt; //Field offset: 0x11C

	public internal bool active
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	public float fullPosition
	{
		 get { } //Length: 152
		 set { } //Length: 34
	}

	public bool hasLoops
	{
		 get { } //Length: 23
	}

	public internal bool isRelative
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	public private bool playedOnce
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public internal float position
	{
		[CompilerGenerated]
		 get { } //Length: 9
		[CompilerGenerated]
		internal set { } //Length: 9
	}

	protected Tween() { }

	internal abstract bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice) { }

	internal static bool DoGoto(Tween t, float toPosition, int toCompletedLoops, UpdateMode updateMode) { }

	[CompilerGenerated]
	public bool get_active() { }

	public float get_fullPosition() { }

	public bool get_hasLoops() { }

	[CompilerGenerated]
	public bool get_isRelative() { }

	[CompilerGenerated]
	public bool get_playedOnce() { }

	[CompilerGenerated]
	public float get_position() { }

	internal static bool OnTweenCallback(TweenCallback<T> callback, Tween t, T param) { }

	internal static bool OnTweenCallback(TweenCallback callback, Tween t) { }

	internal override void Reset() { }

	[CompilerGenerated]
	internal void set_active(bool value) { }

	public void set_fullPosition(float value) { }

	[CompilerGenerated]
	internal void set_isRelative(bool value) { }

	[CompilerGenerated]
	private void set_playedOnce(bool value) { }

	[CompilerGenerated]
	internal void set_position(float value) { }

	internal abstract bool Startup() { }

	internal override float UpdateDelay(float elapsed) { }

	internal abstract bool Validate() { }

}

