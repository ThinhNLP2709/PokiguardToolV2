namespace UnityEngine.UIElements;

public struct Rotate : IEquatable<Rotate>
{
	public class PropertyBag : ContainerPropertyBag<Rotate>
	{
		private class AngleProperty : Property<Rotate, Angle>
		{
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
			private readonly string <Name>k__BackingField; //Field offset: 0x18
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
			private readonly bool <IsReadOnly>k__BackingField; //Field offset: 0x20

			public virtual bool IsReadOnly
			{
				[CompilerGenerated]
				 get { } //Length: 5
			}

			public virtual string Name
			{
				[CompilerGenerated]
				 get { } //Length: 5
			}

			public AngleProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual Angle GetValue(ref Rotate container) { }

			public virtual void SetValue(ref Rotate container, Angle value) { }

		}

		private class AxisProperty : Property<Rotate, Vector3>
		{
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
			private readonly string <Name>k__BackingField; //Field offset: 0x18
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
			private readonly bool <IsReadOnly>k__BackingField; //Field offset: 0x20

			public virtual bool IsReadOnly
			{
				[CompilerGenerated]
				 get { } //Length: 5
			}

			public virtual string Name
			{
				[CompilerGenerated]
				 get { } //Length: 5
			}

			public AxisProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual Vector3 GetValue(ref Rotate container) { }

			public virtual void SetValue(ref Rotate container, Vector3 value) { }

		}


		public PropertyBag() { }

	}

	private Angle m_Angle; //Field offset: 0x0
	private Vector3 m_Axis; //Field offset: 0x8
	private bool m_IsNone; //Field offset: 0x14

	public Angle angle
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	internal Vector3 axis
	{
		internal get { } //Length: 19
		internal set { } //Length: 16
	}

	public Rotate(Angle angle) { }

	internal Rotate(Quaternion quaternion) { }

	public override bool Equals(Rotate other) { }

	public virtual bool Equals(object obj) { }

	public Angle get_angle() { }

	internal Vector3 get_axis() { }

	public virtual int GetHashCode() { }

	internal static Rotate Initial() { }

	public static Rotate None() { }

	public static bool op_Equality(Rotate lhs, Rotate rhs) { }

	public static bool op_Inequality(Rotate lhs, Rotate rhs) { }

	public void set_angle(Angle value) { }

	internal void set_axis(Vector3 value) { }

	internal Quaternion ToQuaternion() { }

	public virtual string ToString() { }

}

