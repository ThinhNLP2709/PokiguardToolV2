namespace UnityEngine.UIElements;

public struct BackgroundRepeat : IEquatable<BackgroundRepeat>
{
	public class PropertyBag : ContainerPropertyBag<BackgroundRepeat>
	{
		private class XProperty : Property<BackgroundRepeat, Repeat>
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

			public virtual Repeat GetValue(ref BackgroundRepeat container) { }

			public virtual void SetValue(ref BackgroundRepeat container, Repeat value) { }

		}

		private class YProperty : Property<BackgroundRepeat, Repeat>
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

			public virtual Repeat GetValue(ref BackgroundRepeat container) { }

			public virtual void SetValue(ref BackgroundRepeat container, Repeat value) { }

		}


		public PropertyBag() { }

	}

	public Repeat x; //Field offset: 0x0
	public Repeat y; //Field offset: 0x4

	public BackgroundRepeat(Repeat repeatX, Repeat repeatY) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(BackgroundRepeat other) { }

	public virtual int GetHashCode() { }

	internal static BackgroundRepeat Initial() { }

	public static bool op_Equality(BackgroundRepeat style1, BackgroundRepeat style2) { }

	public static bool op_Inequality(BackgroundRepeat style1, BackgroundRepeat style2) { }

	public virtual string ToString() { }

}

