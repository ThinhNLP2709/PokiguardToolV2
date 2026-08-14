namespace UnityEngine.UIElements;

public struct Scale : IEquatable<Scale>
{
	public class PropertyBag : ContainerPropertyBag<Scale>
	{
		private class ValueProperty : Property<Scale, Vector3>
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

			public virtual Vector3 GetValue(ref Scale container) { }

			public virtual void SetValue(ref Scale container, Vector3 value) { }

		}


		public PropertyBag() { }

	}

	private Vector3 m_Scale; //Field offset: 0x0
	private bool m_IsNone; //Field offset: 0xC

	public Vector3 value
	{
		 get { } //Length: 18
		 set { } //Length: 15
	}

	public Scale(Vector3 scale) { }

	public override bool Equals(Scale other) { }

	public virtual bool Equals(object obj) { }

	public Vector3 get_value() { }

	public virtual int GetHashCode() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal static Scale Initial() { }

	public static Scale None() { }

	public static bool op_Equality(Scale lhs, Scale rhs) { }

	public static bool op_Inequality(Scale lhs, Scale rhs) { }

	public void set_value(Vector3 value) { }

	public virtual string ToString() { }

}

