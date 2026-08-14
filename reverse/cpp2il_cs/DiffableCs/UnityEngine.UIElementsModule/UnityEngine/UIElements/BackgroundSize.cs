namespace UnityEngine.UIElements;

public struct BackgroundSize : IEquatable<BackgroundSize>
{
	public class PropertyBag : ContainerPropertyBag<BackgroundSize>
	{
		private class SizeTypeProperty : Property<BackgroundSize, BackgroundSizeType>
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

			public SizeTypeProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual BackgroundSizeType GetValue(ref BackgroundSize container) { }

			public virtual void SetValue(ref BackgroundSize container, BackgroundSizeType value) { }

		}

		private class XProperty : Property<BackgroundSize, Length>
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

			public virtual Length GetValue(ref BackgroundSize container) { }

			public virtual void SetValue(ref BackgroundSize container, Length value) { }

		}

		private class YProperty : Property<BackgroundSize, Length>
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

			public virtual Length GetValue(ref BackgroundSize container) { }

			public virtual void SetValue(ref BackgroundSize container, Length value) { }

		}


		public PropertyBag() { }

	}

	private BackgroundSizeType m_SizeType; //Field offset: 0x0
	private Length m_X; //Field offset: 0x4
	private Length m_Y; //Field offset: 0xC

	public BackgroundSizeType sizeType
	{
		 get { } //Length: 5
		 set { } //Length: 85
	}

	public Length x
	{
		 get { } //Length: 7
		 set { } //Length: 11
	}

	public Length y
	{
		 get { } //Length: 7
		 set { } //Length: 11
	}

	public BackgroundSize(Length sizeX, Length sizeY) { }

	public BackgroundSize(BackgroundSizeType sizeType) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(BackgroundSize other) { }

	public BackgroundSizeType get_sizeType() { }

	public Length get_x() { }

	public Length get_y() { }

	public virtual int GetHashCode() { }

	internal static BackgroundSize Initial() { }

	public static bool op_Equality(BackgroundSize style1, BackgroundSize style2) { }

	public static bool op_Inequality(BackgroundSize style1, BackgroundSize style2) { }

	public void set_sizeType(BackgroundSizeType value) { }

	public void set_x(Length value) { }

	public void set_y(Length value) { }

	public virtual string ToString() { }

}

