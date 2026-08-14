namespace UnityEngine.UIElements;

public struct TimeValue : IEquatable<TimeValue>
{
	public class PropertyBag : ContainerPropertyBag<TimeValue>
	{
		private class UnitProperty : Property<TimeValue, TimeUnit>
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

			public virtual TimeUnit GetValue(ref TimeValue container) { }

			public virtual void SetValue(ref TimeValue container, TimeUnit value) { }

		}

		private class ValueProperty : Property<TimeValue, Single>
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

			public virtual float GetValue(ref TimeValue container) { }

			public virtual void SetValue(ref TimeValue container, float value) { }

		}


		public PropertyBag() { }

	}

	private float m_Value; //Field offset: 0x0
	private TimeUnit m_Unit; //Field offset: 0x4

	public TimeUnit unit
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public float value
	{
		 get { } //Length: 5
		 set { } //Length: 5
	}

	public TimeValue(float value) { }

	public TimeValue(float value, TimeUnit unit) { }

	public override bool Equals(TimeValue other) { }

	public virtual bool Equals(object obj) { }

	public TimeUnit get_unit() { }

	public float get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(TimeValue lhs, TimeValue rhs) { }

	public static TimeValue op_Implicit(float value) { }

	public static bool op_Inequality(TimeValue lhs, TimeValue rhs) { }

	public void set_unit(TimeUnit value) { }

	public void set_value(float value) { }

	public virtual string ToString() { }

}

