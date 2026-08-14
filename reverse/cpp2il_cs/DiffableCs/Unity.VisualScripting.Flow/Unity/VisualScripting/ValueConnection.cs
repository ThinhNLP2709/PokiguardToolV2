namespace Unity.VisualScripting;

public sealed class ValueConnection : UnitConnection<ValueOutput, ValueInput>, IUnitConnection, IConnection<IUnitOutputPort, IUnitInputPort>, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	internal class DebugData : UnitConnectionDebugData
	{
		[CompilerGenerated]
		private object <lastValue>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private bool <assignedLastValue>k__BackingField; //Field offset: 0x28

		public bool assignedLastValue
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public object lastValue
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public DebugData() { }

		[CompilerGenerated]
		public bool get_assignedLastValue() { }

		[CompilerGenerated]
		public object get_lastValue() { }

		[CompilerGenerated]
		public void set_assignedLastValue(bool value) { }

		[CompilerGenerated]
		public void set_lastValue(object value) { }

	}


	public virtual ValueInput destination
	{
		 get { } //Length: 251
	}

	public virtual bool destinationExists
	{
		 get { } //Length: 138
	}

	public virtual ValueOutput source
	{
		 get { } //Length: 251
	}

	public virtual bool sourceExists
	{
		 get { } //Length: 138
	}

	private override IUnitInputPort Unity.VisualScripting.IConnection<Unity.VisualScripting.IUnitOutputPort,Unity.VisualScripting.IUnitInputPort>.destination
	{
		private get { } //Length: 20
	}

	private override IUnitOutputPort Unity.VisualScripting.IConnection<Unity.VisualScripting.IUnitOutputPort,Unity.VisualScripting.IUnitInputPort>.source
	{
		private get { } //Length: 20
	}

	[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
	public ValueConnection() { }

	public ValueConnection(ValueOutput source, ValueInput destination) { }

	public virtual IGraphElementDebugData CreateDebugData() { }

	public virtual ValueInput get_destination() { }

	public virtual bool get_destinationExists() { }

	public virtual ValueOutput get_source() { }

	public virtual bool get_sourceExists() { }

	private override IUnitInputPort Unity.VisualScripting.IConnection<Unity.VisualScripting.IUnitOutputPort,Unity.VisualScripting.IUnitInputPort>.get_destination() { }

	private override IUnitOutputPort Unity.VisualScripting.IConnection<Unity.VisualScripting.IUnitOutputPort,Unity.VisualScripting.IUnitInputPort>.get_source() { }

	private override FlowGraph Unity.VisualScripting.IUnitConnection.get_graph() { }

}

