namespace UnityEngine.UIElements;

public struct Angle : IEquatable<Angle>
{
	public class PropertyBag : ContainerPropertyBag<Angle>
	{
		private class UnitProperty : Property<Angle, AngleUnit>
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

			public UnitProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual AngleUnit GetValue(ref Angle container) { }

			public virtual void SetValue(ref Angle container, AngleUnit value) { }

		}

		private class ValueProperty : Property<Angle, Single>
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

			public ValueProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual float GetValue(ref Angle container) { }

			public virtual void SetValue(ref Angle container, float value) { }

		}


		public PropertyBag() { }

	}

	private enum Unit
	{
		Degree = 0,
		Gradian = 1,
		Radian = 2,
		Turn = 3,
		None = 4,
	}

	private float m_Value; //Field offset: 0x0
	private Unit m_Unit; //Field offset: 0x4

	public AngleUnit unit
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public float value
	{
		 get { } //Length: 5
		 set { } //Length: 5
	}

	public Angle(float value, AngleUnit unit) { }

	private Angle(float value, Unit unit) { }

	public override bool Equals(Angle other) { }

	public virtual bool Equals(object obj) { }

	public AngleUnit get_unit() { }

	public float get_value() { }

	public virtual int GetHashCode() { }

	internal static Angle None() { }

	public static bool op_Equality(Angle lhs, Angle rhs) { }

	public static Angle op_Implicit(float value) { }

	public void set_unit(AngleUnit value) { }

	public void set_value(float value) { }

	public float ToDegrees() { }

	public virtual string ToString() { }

}

