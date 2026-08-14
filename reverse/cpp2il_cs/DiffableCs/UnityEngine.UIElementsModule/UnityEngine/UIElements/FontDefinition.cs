namespace UnityEngine.UIElements;

public struct FontDefinition : IEquatable<FontDefinition>
{
	public class PropertyBag : ContainerPropertyBag<FontDefinition>
	{
		private class FontAssetProperty : Property<FontDefinition, FontAsset>
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

			public FontAssetProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual FontAsset GetValue(ref FontDefinition container) { }

			public virtual void SetValue(ref FontDefinition container, FontAsset value) { }

		}

		private class FontProperty : Property<FontDefinition, Font>
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

			public FontProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual Font GetValue(ref FontDefinition container) { }

			public virtual void SetValue(ref FontDefinition container, Font value) { }

		}


		public PropertyBag() { }

	}

	private Font m_Font; //Field offset: 0x0
	private FontAsset m_FontAsset; //Field offset: 0x8

	public Font font
	{
		 get { } //Length: 6
		 set { } //Length: 230
	}

	public FontAsset fontAsset
	{
		 get { } //Length: 7
		 set { } //Length: 231
	}

	public override bool Equals(FontDefinition other) { }

	public virtual bool Equals(object obj) { }

	public static FontDefinition FromFont(Font f) { }

	internal static FontDefinition FromObject(object obj) { }

	public static FontDefinition FromSDFFont(FontAsset f) { }

	public Font get_font() { }

	public FontAsset get_fontAsset() { }

	public virtual int GetHashCode() { }

	internal bool IsEmpty() { }

	public static bool op_Equality(FontDefinition left, FontDefinition right) { }

	public static bool op_Inequality(FontDefinition left, FontDefinition right) { }

	public void set_font(Font value) { }

	public void set_fontAsset(FontAsset value) { }

	public virtual string ToString() { }

}

