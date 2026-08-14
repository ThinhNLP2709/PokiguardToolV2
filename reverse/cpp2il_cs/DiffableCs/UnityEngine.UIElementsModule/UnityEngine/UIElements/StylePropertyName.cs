namespace UnityEngine.UIElements;

public struct StylePropertyName : IEquatable<StylePropertyName>
{
	public class PropertyBag : ContainerPropertyBag<StylePropertyName>
	{
		private class IdProperty : Property<StylePropertyName, StylePropertyId>
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

			public IdProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual StylePropertyId GetValue(ref StylePropertyName container) { }

			public virtual void SetValue(ref StylePropertyName container, StylePropertyId value) { }

		}

		private class NameProperty : Property<StylePropertyName, String>
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

			public NameProperty() { }

			[CompilerGenerated]
			public virtual bool get_IsReadOnly() { }

			[CompilerGenerated]
			public virtual string get_Name() { }

			public virtual string GetValue(ref StylePropertyName container) { }

			public virtual void SetValue(ref StylePropertyName container, string value) { }

		}


		public PropertyBag() { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly StylePropertyId <id>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly string <name>k__BackingField; //Field offset: 0x8

	internal StylePropertyId id
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 3
	}

	private string name
	{
		[CompilerGenerated]
		[IsReadOnly]
		private get { } //Length: 5
	}

	internal StylePropertyName(StylePropertyId stylePropertyId) { }

	public StylePropertyName(string name) { }

	public virtual bool Equals(object other) { }

	public override bool Equals(StylePropertyName other) { }

	[CompilerGenerated]
	[IsReadOnly]
	internal StylePropertyId get_id() { }

	[CompilerGenerated]
	[IsReadOnly]
	private string get_name() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StylePropertyName lhs, StylePropertyName rhs) { }

	public static StylePropertyName op_Implicit(string name) { }

	public static bool op_Inequality(StylePropertyName lhs, StylePropertyName rhs) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal static StylePropertyId StylePropertyIdFromString(string name) { }

	public virtual string ToString() { }

}

