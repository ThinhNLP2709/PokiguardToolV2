namespace UnityEngine.UIElements;

public struct EasingFunction : IEquatable<EasingFunction>
{
	public class PropertyBag : ContainerPropertyBag<EasingFunction>
	{
		private class ModeProperty : Property<EasingFunction, EasingMode>
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

			public ModeProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual EasingMode GetValue(ref EasingFunction container) { }

			public virtual void SetValue(ref EasingFunction container, EasingMode value) { }

		}


		public PropertyBag() { }

	}

	private EasingMode m_Mode; //Field offset: 0x0

	public EasingMode mode
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public EasingFunction(EasingMode mode) { }

	public override bool Equals(EasingFunction other) { }

	public virtual bool Equals(object obj) { }

	public EasingMode get_mode() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(EasingFunction lhs, EasingFunction rhs) { }

	public static EasingFunction op_Implicit(EasingMode easingMode) { }

	public void set_mode(EasingMode value) { }

	public virtual string ToString() { }

}

