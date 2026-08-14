namespace Unity.VisualScripting;

[Obsolete("Use the new \"Add (Math/Vector 3)\" instead.")]
[RenamedFrom("Bolt.Vector3Add")]
[RenamedFrom("Unity.VisualScripting.Vector3Add")]
[UnitCategory("Math/Vector 3")]
[UnitTitle("Add")]
public sealed class DeprecatedVector3Add : Add<Vector3>
{

	protected virtual Vector3 defaultB
	{
		 get { } //Length: 74
	}

	public DeprecatedVector3Add() { }

	protected virtual Vector3 get_defaultB() { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

}

