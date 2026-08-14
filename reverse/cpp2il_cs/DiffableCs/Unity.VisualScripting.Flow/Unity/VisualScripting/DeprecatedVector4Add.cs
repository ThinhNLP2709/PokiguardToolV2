namespace Unity.VisualScripting;

[Obsolete("Use the new \"Add (Math/Vector 4)\" instead.")]
[RenamedFrom("Bolt.Vector4Add")]
[RenamedFrom("Unity.VisualScripting.Vector4Add")]
[UnitCategory("Math/Vector 4")]
[UnitTitle("Add")]
public sealed class DeprecatedVector4Add : Add<Vector4>
{

	protected virtual Vector4 defaultB
	{
		 get { } //Length: 66
	}

	public DeprecatedVector4Add() { }

	protected virtual Vector4 get_defaultB() { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b) { }

}

