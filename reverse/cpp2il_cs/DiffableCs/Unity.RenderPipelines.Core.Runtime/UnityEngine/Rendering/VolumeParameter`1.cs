namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class VolumeParameter : VolumeParameter, IEquatable<VolumeParameter`1<T>>
{
	[SerializeField]
	protected T m_Value; //Field offset: 0x0

	public override T value
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public VolumeParameter`1() { }

	protected VolumeParameter`1(T value, bool overrideState = false) { }

	public virtual object Clone() { }

	public override bool Equals(VolumeParameter<T> other) { }

	public virtual bool Equals(object obj) { }

	public override T get_value() { }

	public virtual int GetHashCode() { }

	internal virtual void Interp(VolumeParameter from, VolumeParameter to, float t) { }

	public override void Interp(T from, T to, float t) { }

	public static bool op_Equality(VolumeParameter<T> lhs, T rhs) { }

	public static T op_Explicit(VolumeParameter<T> prop) { }

	public static bool op_Inequality(VolumeParameter<T> lhs, T rhs) { }

	public void Override(T x) { }

	public override void set_value(T value) { }

	public virtual void SetValue(VolumeParameter parameter) { }

	public virtual string ToString() { }

}

