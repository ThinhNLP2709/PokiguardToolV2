namespace UnityEngine.UIElements;

public struct BackgroundPosition : IEquatable<BackgroundPosition>
{
	public class PropertyBag : ContainerPropertyBag<BackgroundPosition>
	{
		private class KeywordProperty : Property<BackgroundPosition, BackgroundPositionKeyword>
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

			public KeywordProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual BackgroundPositionKeyword GetValue(ref BackgroundPosition container) { }

			public virtual void SetValue(ref BackgroundPosition container, BackgroundPositionKeyword value) { }

		}

		private class OffsetProperty : Property<BackgroundPosition, Length>
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

			public OffsetProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual Length GetValue(ref BackgroundPosition container) { }

			public virtual void SetValue(ref BackgroundPosition container, Length value) { }

		}


		public PropertyBag() { }

	}

	public BackgroundPositionKeyword keyword; //Field offset: 0x0
	public Length offset; //Field offset: 0x4

	public BackgroundPosition(BackgroundPositionKeyword keyword) { }

	public BackgroundPosition(BackgroundPositionKeyword keyword, Length offset) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(BackgroundPosition other) { }

	public virtual int GetHashCode() { }

	internal static BackgroundPosition Initial() { }

	public static bool op_Equality(BackgroundPosition style1, BackgroundPosition style2) { }

	public static bool op_Inequality(BackgroundPosition style1, BackgroundPosition style2) { }

	public virtual string ToString() { }

}

