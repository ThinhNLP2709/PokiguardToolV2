namespace Unity.VisualScripting;

public sealed class UnitRelation : IUnitRelation, IConnection<IUnitPort, IUnitPort>
{
	[CompilerGenerated]
	private readonly IUnitPort <source>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly IUnitPort <destination>k__BackingField; //Field offset: 0x18

	public override IUnitPort destination
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public override IUnitPort source
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public UnitRelation(IUnitPort source, IUnitPort destination) { }

	[CompilerGenerated]
	public override IUnitPort get_destination() { }

	[CompilerGenerated]
	public override IUnitPort get_source() { }

}

