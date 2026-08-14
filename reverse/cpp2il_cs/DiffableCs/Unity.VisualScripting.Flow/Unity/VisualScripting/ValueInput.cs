namespace Unity.VisualScripting;

public sealed class ValueInput : UnitPort<ValueOutput, IUnitOutputPort, ValueConnection>, IUnitValuePort, IUnitPort, IGraphItem, IUnitInputPort
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ValueConnection, ValueOutput> <>9__11_0; //Field offset: 0x8
		public static Func<InvalidConnection, IUnitOutputPort> <>9__13_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal IUnitOutputPort <get_invalidConnectedPorts>b__13_0(InvalidConnection c) { }

		internal ValueOutput <get_validConnectedPorts>b__11_0(ValueConnection c) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public ValueOutput port; //Field offset: 0x10

		public <>c__DisplayClass33_0() { }

		internal bool <DisconnectFromValid>b__0(ValueConnection c) { }

	}

	private static readonly HashSet<Type> typesWithDefaultValues; //Field offset: 0x0
	[CompilerGenerated]
	private readonly Type <type>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private bool <nullMeansSelf>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <allowsNull>k__BackingField; //Field offset: 0x29

	[DoNotSerialize]
	internal object _defaultValue
	{
		internal get { } //Length: 133
		internal set { } //Length: 148
	}

	public private bool allowsNull
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public ValueConnection connection
	{
		 get { } //Length: 129
	}

	public bool hasDefaultValue
	{
		 get { } //Length: 133
	}

	public virtual bool hasValidConnection
	{
		 get { } //Length: 142
	}

	public virtual IEnumerable<IUnitOutputPort> invalidConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<InvalidConnection> invalidConnections
	{
		 get { } //Length: 158
	}

	public private bool nullMeansSelf
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public override Type type
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public virtual IEnumerable<ValueOutput> validConnectedPorts
	{
		 get { } //Length: 300
	}

	public virtual IEnumerable<ValueConnection> validConnections
	{
		 get { } //Length: 158
	}

	private static ValueInput() { }

	public ValueInput(string key, Type type) { }

	public ValueInput AllowsNull() { }

	public virtual bool CanConnectToValid(ValueOutput port) { }

	public virtual IUnitPort CompatiblePort(IUnit unit) { }

	public virtual void ConnectToInvalid(IUnitOutputPort port) { }

	public virtual void ConnectToValid(ValueOutput port) { }

	public virtual void DisconnectFromInvalid(IUnitOutputPort port) { }

	public virtual void DisconnectFromValid(ValueOutput port) { }

	internal object get__defaultValue() { }

	[CompilerGenerated]
	public bool get_allowsNull() { }

	public ValueConnection get_connection() { }

	public bool get_hasDefaultValue() { }

	public virtual bool get_hasValidConnection() { }

	public virtual IEnumerable<IUnitOutputPort> get_invalidConnectedPorts() { }

	public virtual IEnumerable<InvalidConnection> get_invalidConnections() { }

	[CompilerGenerated]
	public bool get_nullMeansSelf() { }

	[CompilerGenerated]
	public override Type get_type() { }

	public virtual IEnumerable<ValueOutput> get_validConnectedPorts() { }

	public virtual IEnumerable<ValueConnection> get_validConnections() { }

	public ValueInput NullMeansSelf() { }

	internal void set__defaultValue(object value) { }

	[CompilerGenerated]
	private void set_allowsNull(bool value) { }

	[CompilerGenerated]
	private void set_nullMeansSelf(bool value) { }

	public void SetDefaultValue(object value) { }

	public static bool SupportsDefaultValue(Type type) { }

}

