namespace Unity.VisualScripting;

public abstract class UnitPortDefinition : IUnitPortDefinition
{
	[CompilerGenerated]
	private string <key>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <label>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <summary>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private bool <hideLabel>k__BackingField; //Field offset: 0x28

	[Inspectable]
	[Serialize]
	public override bool hideLabel
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	[DoNotSerialize]
	public override bool isValid
	{
		 get { } //Length: 22
	}

	[Inspectable]
	[InspectorDelayed]
	[Serialize]
	[WarnBeforeEditing("Edit Port Key", "Changing the key of this definition will break any existing connection to this port. Are you sure you want to continue?", new IL2CPP_TYPE_OBJECT[] {null, null})]
	public override string key
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Inspectable]
	[Serialize]
	public override string label
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Inspectable]
	[InspectorTextArea]
	[Serialize]
	public override string summary
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	protected UnitPortDefinition() { }

	[CompilerGenerated]
	public override bool get_hideLabel() { }

	public override bool get_isValid() { }

	[CompilerGenerated]
	public override string get_key() { }

	[CompilerGenerated]
	public override string get_label() { }

	[CompilerGenerated]
	public override string get_summary() { }

	[CompilerGenerated]
	public void set_hideLabel(bool value) { }

	[CompilerGenerated]
	public void set_key(string value) { }

	[CompilerGenerated]
	public void set_label(string value) { }

	[CompilerGenerated]
	public void set_summary(string value) { }

}

