namespace Unity.VisualScripting;

[Obsolete("Use the new \"Add (Math/Generic)\" node instead.")]
[RenamedFrom("Bolt.GenericAdd")]
[RenamedFrom("Unity.VisualScripting.GenericAdd")]
[UnitCategory("Math/Generic")]
[UnitTitle("Add")]
public sealed class DeprecatedGenericAdd : Add<Object>
{

	public DeprecatedGenericAdd() { }

	public virtual object Operation(object a, object b) { }

}

