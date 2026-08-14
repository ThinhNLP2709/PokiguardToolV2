namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets::All (32767), Inherited = False)]
public sealed class UsedImplicitlyAttribute : Attribute
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly ImplicitUseKindFlags <UseKindFlags>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly ImplicitUseTargetFlags <TargetFlags>k__BackingField; //Field offset: 0x14

	public UsedImplicitlyAttribute() { }

	public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags) { }

}

