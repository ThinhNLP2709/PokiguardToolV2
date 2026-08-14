namespace UnityEngine.UIElements;

public struct Length : IEquatable<Length>
{
	public class PropertyBag : ContainerPropertyBag<Length>
	{
		private class UnitProperty : Property<Length, LengthUnit>
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

			public virtual LengthUnit GetValue(ref Length container) { }

			public virtual void SetValue(ref Length container, LengthUnit value) { }

		}

		private class ValueProperty : Property<Length, Single>
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

			public virtual float GetValue(ref Length container) { }

			public virtual void SetValue(ref Length container, float value) { }

		}


		public PropertyBag() { }

	}

	private enum Unit
	{
		Pixel = 0,
		Percent = 1,
		Auto = 2,
		None = 3,
	}

	internal const float k_MaxValue = 8388608; //Field offset: 0x0
	[SerializeField]
	private float m_Value; //Field offset: 0x0
	[SerializeField]
	private Unit m_Unit; //Field offset: 0x4

	public LengthUnit unit
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public float value
	{
		 get { } //Length: 5
		 set { } //Length: 36
	}

	public Length(float value) { }

	public Length(float value, LengthUnit unit) { }

	private Length(float value, Unit unit) { }

	public static Length Auto() { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(Length other) { }

	public LengthUnit get_unit() { }

	public float get_value() { }

	public virtual int GetHashCode() { }

	public bool IsAuto() { }

	public bool IsNone() { }

	public static Length None() { }

	public static bool op_Equality(Length lhs, Length rhs) { }

	public static Length op_Implicit(float value) { }

	public static bool op_Inequality(Length lhs, Length rhs) { }

	public static Length Percent(float value) { }

	public void set_unit(LengthUnit value) { }

	public void set_value(float value) { }

	public virtual string ToString() { }

}

