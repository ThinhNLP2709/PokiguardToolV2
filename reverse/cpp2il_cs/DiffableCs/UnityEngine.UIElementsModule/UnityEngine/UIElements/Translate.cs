namespace UnityEngine.UIElements;

public struct Translate : IEquatable<Translate>
{
	public class PropertyBag : ContainerPropertyBag<Translate>
	{
		private class XProperty : Property<Translate, Length>
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

			public XProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual Length GetValue(ref Translate container) { }

			public virtual void SetValue(ref Translate container, Length value) { }

		}

		private class YProperty : Property<Translate, Length>
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

			public YProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual Length GetValue(ref Translate container) { }

			public virtual void SetValue(ref Translate container, Length value) { }

		}

		private class ZProperty : Property<Translate, Single>
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

			public ZProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual float GetValue(ref Translate container) { }

			public virtual void SetValue(ref Translate container, float value) { }

		}


		public PropertyBag() { }

	}

	private Length m_X; //Field offset: 0x0
	private Length m_Y; //Field offset: 0x8
	private float m_Z; //Field offset: 0x10
	private bool m_isNone; //Field offset: 0x14

	public Length x
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public Length y
	{
		 get { } //Length: 5
		 set { } //Length: 5
	}

	public float z
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public Translate(Length x, Length y, float z) { }

	internal Translate(Vector3 v) { }

	public override bool Equals(Translate other) { }

	public virtual bool Equals(object obj) { }

	public Length get_x() { }

	public Length get_y() { }

	public float get_z() { }

	public virtual int GetHashCode() { }

	public static Translate None() { }

	public static bool op_Equality(Translate lhs, Translate rhs) { }

	public static bool op_Inequality(Translate lhs, Translate rhs) { }

	public void set_x(Length value) { }

	public void set_y(Length value) { }

	public void set_z(float value) { }

	public virtual string ToString() { }

}

