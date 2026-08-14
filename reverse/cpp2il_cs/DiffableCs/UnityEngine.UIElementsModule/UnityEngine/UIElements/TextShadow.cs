namespace UnityEngine.UIElements;

public struct TextShadow : IEquatable<TextShadow>
{
	public class PropertyBag : ContainerPropertyBag<TextShadow>
	{
		private class BlurRadiusProperty : Property<TextShadow, Single>
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

			public BlurRadiusProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual float GetValue(ref TextShadow container) { }

			public virtual void SetValue(ref TextShadow container, float value) { }

		}

		private class ColorProperty : Property<TextShadow, Color>
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

			public ColorProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual Color GetValue(ref TextShadow container) { }

			public virtual void SetValue(ref TextShadow container, Color value) { }

		}

		private class OffsetProperty : Property<TextShadow, Vector2>
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

			public virtual Vector2 GetValue(ref TextShadow container) { }

			public virtual void SetValue(ref TextShadow container, Vector2 value) { }

		}


		public PropertyBag() { }

	}

	public Vector2 offset; //Field offset: 0x0
	public float blurRadius; //Field offset: 0x8
	public Color color; //Field offset: 0xC

	public virtual bool Equals(object obj) { }

	public override bool Equals(TextShadow other) { }

	public virtual int GetHashCode() { }

	internal static TextShadow LerpUnclamped(TextShadow a, TextShadow b, float t) { }

	public static bool op_Equality(TextShadow style1, TextShadow style2) { }

	public static bool op_Inequality(TextShadow style1, TextShadow style2) { }

	public virtual string ToString() { }

}

