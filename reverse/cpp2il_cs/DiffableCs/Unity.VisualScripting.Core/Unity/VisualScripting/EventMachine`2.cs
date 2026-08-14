namespace Unity.VisualScripting;

public abstract class EventMachine : Machine<TGraph, TMacro>, IEventMachine, IMachine, IGraphRoot, IGraphParent, IGraphNester, IAotStubbable
{
	[CompilerGenerated]
	private sealed class <>c__4
	{
		public static readonly <>c__4<TGraph, TMacro, TArgs> <>9; //Field offset: 0x0
		public static Func<IGraphParentElement, Boolean> <>9__4_1; //Field offset: 0x0

		private static <>c__4`1() { }

		public <>c__4`1() { }

		internal bool <TriggerUnregisteredEvent>b__4_1(IGraphParentElement parent) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public EventHook hook; //Field offset: 0x0

		public <>c__DisplayClass4_0`1() { }

		internal bool <TriggerUnregisteredEvent>b__0(EventHook _hook) { }

	}


	protected EventMachine`2() { }

	protected virtual void Awake() { }

	protected override void FixedUpdate() { }

	protected override void LateUpdate() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected override void OnDrawGizmos() { }

	protected override void OnDrawGizmosSelected() { }

	protected virtual void OnEnable() { }

	protected virtual void OnInstantiateWhileEnabled() { }

	protected virtual void OnUninstantiateWhileEnabled() { }

	protected override void Start() { }

	public virtual void TriggerAnimationEvent(AnimationEvent animationEvent) { }

	protected void TriggerEvent(string name) { }

	protected void TriggerEvent(string name, TArgs args) { }

	protected override void TriggerRegisteredEvent(EventHook hook, TArgs args) { }

	public virtual void TriggerUnityEvent(string name) { }

	protected void TriggerUnregisteredEvent(string name) { }

	protected override void TriggerUnregisteredEvent(EventHook hook, TArgs args) { }

	protected override void Update() { }

}

