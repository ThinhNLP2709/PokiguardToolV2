namespace Unity.VisualScripting;

public abstract class GameObjectEventUnit : EventUnit<TArgs>, IGameObjectEventUnit, IEventUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
{
	internal class Data : Data<TArgs>
	{
		public GameObject target; //Field offset: 0x0

		public Data() { }

	}

	[CompilerGenerated]
	private ValueInput <target>k__BackingField; //Field offset: 0x0

	protected override string hookName
	{
		 get { } //Length: 98
	}

	public abstract Type MessageListenerType
	{
		 get { } //Length: 0
	}

	protected virtual bool register
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabel("Target")]
	[PortLabelHidden]
	public private ValueInput target
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected GameObjectEventUnit`1() { }

	public virtual IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	protected override string get_hookName() { }

	public abstract Type get_MessageListenerType() { }

	protected virtual bool get_register() { }

	[CompilerGenerated]
	public ValueInput get_target() { }

	public virtual EventHook GetHook(GraphReference reference) { }

	[CompilerGenerated]
	private void set_target(ValueInput value) { }

	protected void StartListening(GraphStack stack, bool updateTarget) { }

	public virtual void StartListening(GraphStack stack) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

	private void UpdateTarget(GraphStack stack) { }

}

