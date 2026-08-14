namespace Unity.VisualScripting;

[Obsolete("Use the new \"Add (Math/Vector 2)\" node instead.")]
[RenamedFrom("Bolt.Vector2Add")]
[RenamedFrom("Unity.VisualScripting.Vector2Add")]
[UnitCategory("Math/Vector 2")]
[UnitTitle("Add")]
public sealed class DeprecatedVector2Add : Add<Vector2>
{

	protected virtual Vector2 defaultB
	{
		 get { } //Length: 68
	}

	public DeprecatedVector2Add() { }

	protected virtual Vector2 get_defaultB() { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

}

