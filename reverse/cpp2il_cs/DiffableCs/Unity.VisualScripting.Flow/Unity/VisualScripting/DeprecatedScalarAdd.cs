namespace Unity.VisualScripting;

[Obsolete("Use the new \"Add (Math/Scalar)\" node instead.")]
[RenamedFrom("Bolt.ScalarAdd")]
[RenamedFrom("Unity.VisualScripting.ScalarAdd")]
[UnitCategory("Math/Scalar")]
[UnitTitle("Add")]
public sealed class DeprecatedScalarAdd : Add<Single>
{

	protected virtual float defaultB
	{
		 get { } //Length: 9
	}

	public DeprecatedScalarAdd() { }

	protected virtual float get_defaultB() { }

	public virtual float Operation(float a, float b) { }

}

